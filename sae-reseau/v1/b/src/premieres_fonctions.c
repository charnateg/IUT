#include "jeux.h"

//////////////////////////////////////////
// Gestion des signaux
//////////////////////////////////////////

// SIGUSR1
void recepteur_sigusr1(int sig) {
    printf("SIGUSR1 reçu\n");
}

// SIGUSR2
void recepteur_sigusr2(int sig) {
    printf("SIGUSR2 reçu\n");
}

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
    printf("==== Téléchargement de '%s' : ==== \n", nom);
    for (int i = 0; i <= 100; i += 10) {
        afficher_barre_progression(i);
        printf("\n");
        sleep(1);
    }
    printf("\n");
}


//////////////////////////////////////////
// Fonctions de gestion des jeux
//////////////////////////////////////////


//Fonction que le thread va exécuter
void* thread_function(void* arg) {
    DemandeOperation* op = (DemandeOperation*)arg;

    // En attente de SIGUSR1
    //sigset_t set;
    //sigemptyset(&set);
    //sigaddset(&set, SIGUSR1);
    //int sig;
    //sigwait(&set, &sig);

    execute_demande(*op);
    sleep(2);

    // Envoie de SIGUSR2 au thread suivant
    //pthread_kill(pthread_self(), SIGUSR2);

    pthread_exit(NULL);
}

void free_jeux() {
    for (int i = 0; i < 100; i++) {
        if (jeux[i] != NULL) {
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
            return 0;
        }
    }
    return -1;
}

int jeuxTelecharges() {
    if (jeux == NULL) {
        return -1;
    }
    int nb_jeux_telecharges = 0;
    printf("==== Liste des jeux téléchargés : ====\n");
    for (int i = 0; i < 100; i++) {
        if (jeux[i] != NULL && jeux[i]->Code != NULL) {
            nb_jeux_telecharges++;
            printf("%s\n", jeux[i]->NomJeu);
        }
    }
    return nb_jeux_telecharges;
}

int ajouterJeu(char* nom) {
    //vérifier si la liste des jeux n'est pas complète
    if (NOMBRE_JEUX >= 100) {
        return -1;
    }
    //Cherche un emplacement libre pour ajouter le jeu
    int indice = -1;
    for (int i = 0; i < 100; i++) {
        if (jeux[i] == NULL) {
            indice = i;
            break;
        }
    }
    //Si aucun emplacement libre n'est trouvé
    if (indice == -1) {
        return -1;
    }
    //Alloue de la mémoire pour la structure jeu
    jeux[indice] = (Jeu*)malloc(sizeof(Jeu));
    if (jeux[indice] == NULL) {
        return -1;
    }
    //Copie le nom du jeu
    strcpy(jeux[indice]->NomJeu, nom);

    //Alloue de la mémoire pour le code du jeu
    srand(time(NULL));
    int taille = rand() % 1000 + 1;
    jeux[indice]->Code = (char*)malloc(taille * sizeof(char));
    if (jeux[indice]->Code == NULL) {
        free(jeux[indice]);
        jeux[indice] = NULL;
        return -1;
    }


    //Incrémenter le nombre de jeux
    NOMBRE_JEUX++;

    return taille;
}

int supprimerJeu(char* nom) {
    for (int i = 0; i < 100; i++) {
        if (jeux[i] != NULL && strcmp(jeux[i]->NomJeu, nom) == 0) {
            int tailleJeu = 0;
            if (jeux[i]->Code != NULL) {
                tailleJeu = strlen(jeux[i]->Code);
                free(jeux[i]->Code);
            }
            free(jeux[i]);
            jeux[i] = NULL;
            NOMBRE_JEUX--;
            sleep(2);
            return tailleJeu;
        }
    }
    return -1;
}

void simulerCombat(char* nomJeu) {
    int jeuTrouve = estPresent(nomJeu);
    if (jeuTrouve == -1) {
        printf("==== Le jeu '%s' n'est pas trouvé dans la base de données. ==== \n", nomJeu);
        return;
    }
    printf("\033[0;33m==== Combat en cours sur le jeu '%s'... ==== \033[0m\n", nomJeu);
    sleep(20);
    srand(time(NULL));
    int gagnant = rand() % 2;
    if (gagnant == 0) {
        printf("==== S1 winner sur '%s' ! ==== \n", nomJeu);
    } else {
        printf("==== S2 winner sur '%s' ! ==== \n", nomJeu);
    }
}

void lancerJeu(char* nomJeu) {
    int jeuTrouve = estPresent(nomJeu);
    if (jeuTrouve == -1) {
        printf("==== Le jeu '%s' n'est pas trouvé dans la base de données. ==== \n", nomJeu);
        return;
    }
    Jeu* jeuLance = (Jeu*)malloc(sizeof(Jeu));
    for (int i = 0; i < 100; i++) {
        if (jeux[i] != NULL && strcmp(jeux[i]->NomJeu, nomJeu) == 0) {
            strcpy(jeuLance->NomJeu, jeux[i]->NomJeu);
            if (jeux[i]->Code != NULL) {
                jeuLance->Code = strdup(jeux[i]->Code);
            } else {
                jeuLance->Code = NULL;
            }
            break;
        }
    }
    printf("==== %s lancé, appuyez sur la touche 1 pour lancer la manche ! ==== \n", nomJeu);
    int input = 0;
    if (scanf("%d", &input) != 1) {
        printf("\033[0;31m Entrée invalide. Veuillez entrer un entier. \033[0m\n");
        return;
    }
    if (input == 1) {
        printf("\033[0;33m==== Lancement du combat sur '%s'... ==== \033[0m\n", nomJeu);
        srand(time(NULL));
        int gagnant = rand() % 2;
        if (gagnant == 0) {
            printf("\033[0;32m==== Bravo ! Vous avez gagné contre le serveur sur '%s' ! ==== \033[0m\n", nomJeu);
        } else {
            printf("\033[0;31m==== Aïe ! Vous avez perdu contre le serveur sur '%s' ! ====\033[0m\n", nomJeu);
        }
    } else {
        printf("\033[0;31mArrêt du jeu\033[0m\n");
    }
    if (jeuLance->Code != NULL) {
        free(jeuLance->Code);
    }
    free(jeuLance);
}

int execute_demande(DemandeOperation OP) {
    switch (OP.CodeOp) {
        case 1:
        {
            int present = estPresent(OP.NomJeu);
            if (present == -1) {
                printf("==== Le jeu '%s' n'a pas été trouvé dans la base de données. ====\n", OP.NomJeu);
                return -1;
            } else {
                printf("\033[0;32m==== Le jeu '%s' est présent dans la base de données. ====\033[0m\n", OP.NomJeu);
                return 0;
            }
        }
        case 2:
        {
            return jeuxTelecharges();
        }
        case 3:
        {
            int ajout = ajouterJeu(OP.NomJeu);
            if (ajout == -1) {
                printf("Impossible d'ajouter le jeu '%s'.\n\n", OP.NomJeu);
                return -1;
            } else {
                printf("\033[0;32m==== Le jeu '%s' a été ajouté avec succès. Taille du jeu : %d ====\033[0m\n", OP.NomJeu, ajout);
                return ajout;
            }
        }
        case 4:
        {
            int suppression = supprimerJeu(OP.NomJeu);
            if (suppression == -1) {
                printf("Impossible de supprimer le jeu '%s'.\n\n", OP.NomJeu);
                return -1;
            } else {
                printf("\033[0;32m==== Le jeu '%s' a été supprimé avec succès. Taille du jeu supprimé : %d ====\033[0m\n", OP.NomJeu, suppression);
                return suppression;
            }
        }
        case 5:
            simulerCombat(OP.NomJeu);
        case 6:
            lancerJeu(OP.NomJeu);
    }
    printf("Le code '%d' de votre opération pour le jeu '%s' n'existe pas", OP.CodeOp, OP.NomJeu);
    return -1;
}