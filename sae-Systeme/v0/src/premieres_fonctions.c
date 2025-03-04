#include "../includes/jeux.h"

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

int estPresent(char* nom){
    for (int i = 0; i < 100; i++){
        char res[25];
        strcpy(res,jeux[i]->NomJeu);
        if(strcmp(nom, res) == 0){
            return 0;
        }
    }
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

int ajouterJeu(char* nom){
    //Si il y a déjà 100 jeux, on ne peut plus en ajouter
    if (NOMBRE_JEUX >= 100){
        return -1;
    }
    //Cherche le premier indice ou aucun jeu n'a été alloué
    int indice = 0;
    for(int i = 0; i < 100;i++){
        if (jeux[i] == NULL){
            indice = i;
            break;
        }
    }
    //Alloue l'espace d'un jeu et met le nom du jeu
    jeux[indice] = (Jeu*)malloc(sizeof(Jeu));
    strcpy(jeux[indice]->NomJeu, nom);

    //Alloue un nombre aléatoire de caractères entre 1 et 1000 pour le code et sleep pendant 10 sec pour simuler le téléchargement
    // Initialisation du générateur de nombres aléatoires avec le temps actuel
    srand(time(NULL));
    // Génère un nombre aléatoire entre 1 et 1000
    int taille = rand() % 1000 + 1;

    jeux[indice]->Code = (char *)malloc(taille*sizeof(char));
    sleep(10);

    //Augmente le nombre de jeux dans la base
    NOMBRE_JEUX++;

    return taille;
}

// Fonction pour supprimer un jeu de la base de données
int supprimerJeu(char* nom) {
    for (int i = 0; i < 100; i++) {
        if (jeux[i] != NULL && strcmp(jeux[i]->NomJeu, nom) == 0) {
            //Cherche le jeu à supprimer

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

int execute_demande(DemandeOperation OP){
    switch (OP.CodeOp) {
        case 1: return estPresent(OP.NomJeu);
        case 2: return jeuxTelecharges();
        case 3: return ajouterJeu(OP.NomJeu);
        case 4: return supprimerJeu(OP.NomJeu);
    }
    //Si le CodeOP n'a pas une bonne valeur
    printf("Le code de votre opération n'existe pas");
    return -1;
}