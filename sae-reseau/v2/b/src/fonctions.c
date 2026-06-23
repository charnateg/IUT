#include "../includes/jeux.h"

//Initialise l'espace mémoire de la BDD
void init_jeux(){
    //Allocations mémoires pour les jeux dans la BDD (ici on considère qu'on aura jamais plus de 100 jeux dans la base)
    jeux = (Jeu**)malloc(100 * sizeof(Jeu*));
    for (int i = 0; i < 100; i++) {
        jeux[i] = NULL;
    }
}

//Libère l'espace mémoire de la BDD
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
    free(jeux);
}

//Ajoute un jeu à la BDD
int ajouterJeu(char* nom){
    //Si il y a déjà 100 jeux, on ne peut plus en ajouter
    if (NOMBRE_JEUX >= 100){
        printf("Impossible d'ajouter le jeu '%s' car il n'y a plus de place dans la BDD.\n", nom);
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

    printf("Jeu '%s' ajouté.\n\n", nom);
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

            printf("Jeu '%s' supprimé \n\n", nom);
            return tailleJeu; // Retour de la taille du jeu
        }
    }

    // Si le jeu n'a pas été trouvé, alors on retourne -1
    printf("Impossible de supprimer le jeu '%s' car il n'est pas présent dans la BDD.\n\n", nom);
    return -1;
}

// Fonction pour afficher les jeux téléchargés et disponibles
int jeuxTelecharges(){
    //Si la base de données n'est pas allouée, renvoie -1
    if(jeux == NULL){
        printf("BDD non allouée.\n\n");
        return -1;
    }
    int nb_jeux_telecharges = 0;
    for (int i = 0; i < 100; i++){
        if (jeux[i] != NULL && jeux[i]->Code != NULL) {
            nb_jeux_telecharges++;
        }
    }
    sleep(1);

    printf("Nombre de jeux téléchargés : %d\n\n", nb_jeux_telecharges);
    return nb_jeux_telecharges;
}

int estPresent(char* nomJeu){
    pid_t pid;

    // arguments execv
    const char* path = "./bin/estPresent";
    char * ARGV[NOMBRE_JEUX + 3];
    ARGV[0] = "estPresent";
    ARGV[1] = nomJeu;
    for (int i = 2; i < NOMBRE_JEUX + 2; i++){
        ARGV[i] = jeux[i-2]->NomJeu;
    }
    ARGV[NOMBRE_JEUX + 2] = NULL;

    if ((pid = fork()) < 0){
        perror("Erreur lors du fork");
        return EXIT_FAILURE;
    }
    else if(pid == 0){
        //Code éxécuté par le fils
        if (execv(path, ARGV) == -1) {
            perror("Erreur lors de execv");
            return EXIT_FAILURE; 
        }
    }
    else{
        //Code éxécuté par le père
        PIDS[NOMBRE_PID] = pid;
        NOMBRE_PID++;
    }

    int status;
    waitpid(pid,&status,0);
    return WEXITSTATUS(status);
}

void simulerCombat(char* nom){
    // Vérifier si le jeu est présent
    DemandeOperation verification = {0};
    verification.CodeOp = 1;
    strncpy(verification.NomJeu, nom, sizeof(verification.NomJeu) - 1);
    verification.NomJeu[sizeof(verification.NomJeu) - 1] = '\0'; // Sécurité pour éviter un dépassement

    int jeuTrouve = execute_demande(verification);
    if (jeuTrouve != 0) {
        printf("Fin de la simulation.\n");
        return;
    }

    //Lance la simulation
    pid_t pid;

    // arguments execv
    const char* path = "./bin/simulerCombat";
    char * ARGV[3];
    ARGV[0] = "simulerCombat";
    ARGV[1] = nom;
    ARGV[2] = NULL;

    if ((pid = fork()) < 0){
        perror("Erreur lors du fork");
        return;
    }
    else if(pid == 0){
        //Code éxécuté par le fils
        if (execv(path, ARGV) == -1) {
            perror("Erreur lors de execv");
            return; 
        }
    }
    else{
        //Code éxécuté par le père
        PIDS[NOMBRE_PID] = pid;
        NOMBRE_PID++;
    }
}

void lancerJeu(char* nom){
    // Vérifier si le jeu est présent
    DemandeOperation verification = {0};
    verification.CodeOp = 1;
    strncpy(verification.NomJeu, nom, sizeof(verification.NomJeu) - 1);
    verification.NomJeu[sizeof(verification.NomJeu) - 1] = '\0'; // Sécurité pour éviter un dépassement

    int jeuTrouvee = execute_demande(verification);
    if (jeuTrouvee == 255) {
        printf("Fin de la simulation.\n");
        return;
    }

    // Charger le jeu en mémoire (tableau de taille 1)
    Jeu* jeuLance = (Jeu*)malloc(sizeof(Jeu));
    for (int i = 0; i < 100; i++) {
        if (jeux[i] != NULL && strcmp(jeux[i]->NomJeu, nom) == 0) {
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

    //Lance la simulation
    pid_t pid;

    // arguments execv
    const char* path = "./bin/lancerCombat";
    char * ARGV[3];
    ARGV[0] = "lancerCombat";
    ARGV[1] = nom;
    ARGV[2] = NULL;

    if ((pid = fork()) < 0){
        perror("Erreur lors du fork");
        //Libère le jeu lancé
        if(jeuLance->Code != NULL){
            free(jeuLance->Code);
        }
        free(jeuLance);
        return;
    }
    else if(pid == 0){
        //Code éxécuté par le fils
        if (execv(path, ARGV) == -1) {
            perror("Erreur lors de execv");
            //Libère le jeu lancé
            if(jeuLance->Code != NULL){
                free(jeuLance->Code);
            }
            free(jeuLance);
            return; 
        }
    }
    else{
        //Code éxécuté par le père
        PIDS[NOMBRE_PID] = pid;
        NOMBRE_PID++;
    }
    
    //Libère le jeu lancé
    if(jeuLance->Code != NULL){
        free(jeuLance->Code);
    }
    free(jeuLance);
}

/* Fonction pour éxecuter une demande */
int execute_demande(DemandeOperation OP){
    switch (OP.CodeOp) {
        case 1: return estPresent(OP.NomJeu);
        case 2: return jeuxTelecharges();
        case 3: return ajouterJeu(OP.NomJeu);
        case 4: return supprimerJeu(OP.NomJeu);
        case 5: simulerCombat(OP.NomJeu);
        return 0;
        case 6: lancerJeu(OP.NomJeu);
        return 0;
    }
    //Si le CodeOP n'a pas une bonne valeur
    printf("Le code de votre opération n'existe pas\n");
    return -1;
}

void attendre_processus(){
    for(int i = 0; i < NOMBRE_PID; i++){
        if (kill(PIDS[i], SIGKILL) == -1) {
            perror("Erreur lors de l'envoi du signal SIGKILL");
        } else {
            printf("Signal SIGKILL envoyé au processus PID %d\n", PIDS[i]);
        }
    }
    //On aurait pu envoyer un autre signal afin de free les jeux des fork au lieu de les fermer brutalement
    sleep(3);
    printf("Tous les processus enfants sont terminés.\n");
}