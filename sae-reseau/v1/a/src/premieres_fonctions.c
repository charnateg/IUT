#include "jeux.h"

//////////////////////////////////////////
// Gestion de la barre de progression
//////////////////////////////////////////

// Affichage de la barre de progression
void afficher_barre_progression(int progression) {
    int largeur_barre = 50;
    int position = (progression * largeur_barre) / 100;

    printf("[");
    for (int i = 0; i < largeur_barre; i++) {
        if (i < position) {
            // Utiliser la couleur verte pour la partie complétée
            printf("\033[0;32m=\033[0m");
        } else if (i == position) {
            // Utiliser la couleur jaune pour la position actuelle
            printf("\033[0;33m>\033[0m");
        } else {
            // Utiliser la couleur rouge pour la partie restante
            printf("\033[0;31m-\033[0m");
        }
    }
    printf("] %d%%\r", progression);
    fflush(stdout);
}

// Simulation d'un téléchargement avec la barre de progression
void simuler_telechargement(char* nom) {
    printf("Téléchargement de '%s' : \n", nom);
    for (int i = 0; i <= 100; i += 10) {
        afficher_barre_progression(i);
        sleep(1);
    }
    printf("\n");
}

//////////////////////////////////////////
// Gestion des instructions bloquantes et non-bloquantes
//////////////////////////////////////////

void ajouter_jeu(DemandeOperation op) {
    int resultat_ajout = execute_demande(op);
    if (resultat_ajout != -1) {
        printf("Jeu '%s' ajouté\n", op.NomJeu);
    } else {
        printf("Impossible d'ajouter le jeu '%s'\n", op.NomJeu);
    }
}

void supprimer_jeu(DemandeOperation op) {
    int resultat_suppression = execute_demande(op);
    if (resultat_suppression != -1) {
        printf("Jeu '%s' supprimé\n", op.NomJeu);
    } else {
        printf("Impossible de supprimer le jeu '%s'\n", op.NomJeu);
    }
}

void lister_jeux(DemandeOperation op) {
    if (fork() == 0) {
        int nb_jeux_telecharges = execute_demande(op);
        printf("Nombre de jeux téléchargés : %d\n", nb_jeux_telecharges);
        exit(0);
    } else {
        wait(NULL);
    }
}

void tester_jeu(DemandeOperation op) {
    if (fork() == 0) {
        int resultat_verification = estPresent(op.NomJeu);
        if (resultat_verification == 0) {
            printf("Le jeu '%s' est présent dans la BDD\n", op.NomJeu);
        } else {
            printf("Le jeu '%s' n'est pas trouvé dans la BDD\n", op.NomJeu);
        }
        exit(0);
    } else {
        wait(NULL);
    }
}

void simuler_combat(DemandeOperation op) {
    int pipefd[2];
    if (pipe(pipefd) == -1) {
        perror("Erreur de création de pipe");
        exit(1);
    }

    if (fork() == 0) {
        close(pipefd[0]);
        simulerCombat(op.NomJeu);
        int resultat_combat = 1; // Simuler un résultat
        write(pipefd[1], &resultat_combat, sizeof(resultat_combat));
        close(pipefd[1]);
        exit(0);
    } else {
        close(pipefd[1]);
        if (op.flag == 1) {
            wait(NULL);
            int resultat_combat;
            read(pipefd[0], &resultat_combat, sizeof(resultat_combat));
            printf("Résultat du combat : %d\n", resultat_combat);
        }
        close(pipefd[0]);
    }
}


//////////////////////////////////////////
// Execution des opérations
//////////////////////////////////////////

void free_jeux(){
    for (int i = 0; i < 100; i++){
       if (jeux[i] != NULL) {
          // Libérer la mémoire du champ Code si elle a été allouée
          if (jeux[i]->Code != NULL) {
            free(jeux[i]->Code);
          }
          free(jeux[i]);
       }
    }
}

int estPresent(char* nom) {
    for (int i = 0; i < 100; i++) {
        if (jeux[i] != NULL && strcmp(jeux[i]->NomJeu, nom) == 0) {
            printf("\033[38;5;214mDEBUG: Jeu '%s' trouvé à l'indice %d\033[0m\n", nom, i);
            return 0;
        }
    }
    printf("\033[38;5;214mDEBUG: Jeu '%s' non trouvé\033[0m\n", nom);
    return -1;
}

// Fonction pour afficher les jeux téléchargés et disponibles
int jeuxTelecharges(){
    //Si la base de données n'est pas allouée, renvoie -1
    if(jeux == NULL){
        return -1;
    }
    int nb_jeux_telecharges = 0;
    for (int i = 0; i < 100; i++){
        if (jeux[i] != NULL && jeux[i]->Code != NULL) {
            nb_jeux_telecharges++;
            printf("%s\n", jeux[i]->NomJeu);
        }
    }
    sleep(1);

    return nb_jeux_telecharges;
}

int ajouterJeu(char* nom) {
    srand(time(NULL));

        // Code du processus enfant
        if (NOMBRE_JEUX >= 100) {
            printf("Erreur : Nombre maximum de jeux atteint.\n");
            exit(-1);
        }
            // Trouver un emplacement libre
            int indice = -1;
            for (int i = 0; i < 100; i++) {
                if (jeux[i] == NULL) {
                    printf("\033[38;5;214mDEBUG: Emplacement libre trouvé à l'indice %d\033[0m\n", i);
                    indice = i;
                    break;
                }
            }
            if (indice == -1) {
                printf("Erreur : Aucun emplacement libre trouvé.\n");
                return -1;
            }

        // Allocation mémoire
        jeux[indice] = (Jeu*)malloc(sizeof(Jeu));
        if (jeux[indice] == NULL) {
            printf("Erreur : Allocation mémoire échouée pour le jeu '%s'.\n", nom);
            exit(-1);
        }

        // Copie du nom
        strncpy(jeux[indice]->NomJeu, nom, sizeof(jeux[indice]->NomJeu) - 1);
        jeux[indice]->NomJeu[sizeof(jeux[indice]->NomJeu) - 1] = '\0';

        // Allocation aléatoire pour le code
        int taille = rand() % 1000 + 1;
        jeux[indice]->Code = (char*)malloc(taille * sizeof(char));
        if (jeux[indice]->Code == NULL) {
            printf("Erreur : Allocation mémoire échouée pour le code du jeu '%s'.\n", nom);
            free(jeux[indice]);
            jeux[indice] = NULL;
            exit(-1);
        }

        simuler_telechargement(nom);

        NOMBRE_JEUX++;
        printf("\033[38;5;214mDEBUG: Jeu '%s' ajouté à l'indice %d avec succès (taille code : %d).\033[0m\n", nom, indice, taille);
        return(taille);
}



// Fonction pour supprimer un jeu de la base de données
int supprimerJeu(char* nom) {
    for (int i = 0; i < 100; i++) {
        if (jeux[i] != NULL && strcmp(jeux[i]->NomJeu, nom) == 0) {
            //Cherche le jeu à supprimer
            printf("\033[38;5;214mSuppression du jeu trouvé : %s\033[0m\n", jeux[i]->NomJeu);
            int tailleJeu = 0;


            if (jeux[i]->Code != NULL) {
                // Calcule la taille du jeu
                tailleJeu = strlen(jeux[i]->Code);
                // Libération de la mémoire
                free(jeux[i]->Code);
            }

            // Libération de la mémoire de la structure
            free(jeux[i]);
            jeux[i] = NULL;

            //Décrémente le nombre de jeux
            NOMBRE_JEUX--;

            // 2 secondes de délai
            sleep(2);

            return tailleJeu; // Retour de la taille du jeu
        }
    }

    // Si le jeu n'a pas été trouvé, alors on retourne -1
    return -1;
}

// Fonction pour lancer un jeu entre un serveur et lui meme
void simulerCombat(char* nomJeu) {
    // Vérifier si le jeu est présent
    int jeuTrouve = estPresent(nomJeu);
    if (jeuTrouve == -1) {
        printf("Le jeu '%s' n'est pas trouvé dans la base de données.\n", nomJeu);
        return;
    }

    printf("Combat en cours sur le jeu '%s'...\n", nomJeu);
    sleep(20);  // Durée du combat

    // Générez aléatoirement un gagnant
    srand(time(NULL));  // Initialisation du nombre aléatoire
    int gagnant = rand() % 2;  // 0 pour S1, 1 pour S2

    // Afficher le résultat
    if (gagnant == 0) {
        printf("S1 winner sur '%s' !\n", nomJeu);
    } else {
        printf("S2 winner sur '%s' !\n", nomJeu);
    }
}

// Fonction pour lancer un jeu entre un serveur et un joueur
void lancerJeu(char* nomJeu) {
    // Vérifier si le jeu est présent
    int jeuTrouve = estPresent(nomJeu);
    if (jeuTrouve == -1) {
        printf("Le jeu '%s' n'est pas trouvé dans la base de données.\n", nomJeu);
        return;
    }

    // Charger le jeu en mémoire (tableau de taille 1)
    Jeu* jeuLance = (Jeu*)malloc(sizeof(Jeu));
    for (int i = 0; i < 100; i++) {
        if (jeux[i] != NULL && strcmp(jeux[i]->NomJeu, nomJeu) == 0) {
            // Copie du jeu dans la mémoire
            strcpy(jeuLance->NomJeu, jeux[i]->NomJeu);
            if (jeux[i]->Code != NULL) {
                jeuLance->Code = strdup(jeux[i]->Code);
            } else {
                jeuLance->Code = NULL;
            }
            break;
        }
    }

    // Interaction avec le joueur
    printf("%s lancé, appuyez sur la touche 1 pour lancer la manche !", nomJeu);
    int input = 0;
    scanf("%d", &input);

    if(input == 1){
        printf("Lancement du combat sur '%s'...\n", nomJeu);

        // Générez aléatoirement un gagnant
        srand(time(NULL));  // Initialisation du nombre aléatoire
        int gagnant = rand() % 2;  // 0 pour le Joueur, 1 pour S2

        // Afficher le résultat
        if (gagnant == 0) {
            printf("Bravo ! Vous avez gagné contre le serveur sur '%s' !\n", nomJeu);
        } else {
            printf("Aïe ! Vous avez perdu contre le serveur sur '%s' !\n", nomJeu);
        }
    } else {
    printf("Arrêt du jeu\n");
    }

    if(jeuLance->Code != NULL){
        free(jeuLance->Code);
    }
    free(jeuLance);
}

// Fonction pour éxecuter une demande

int execute_demande(DemandeOperation op) {
    switch (op.CodeOp) {
        case 1: return estPresent(op.NomJeu);
        case 2: return jeuxTelecharges();
        case 3: return ajouterJeu(op.NomJeu);
        case 4: return supprimerJeu(op.NomJeu);
        case 5: simulerCombat(op.NomJeu);
        case 6: lancerJeu(op.NomJeu);
    }
    printf("Le code de votre opération n'existe pas");
    return -1;
}