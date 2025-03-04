#include "../includes/jeux.h"

// Déclarer le nombre de jeux de la BDD
int NOMBRE_JEUX = 0;
// Déclarer le tableau global de pointeurs de jeu
Jeu **jeux;
// Déclarer le tableau de pids
pid_t PIDS[100];
// Déclarer le nombre de PID
int NOMBRE_PID = 0;

int main(int argc, char *argv[])
{

    /* Lancement des fork */

    int fd1[2];
    pid_t pid1;
    char buffer1[25];

    if (pipe(fd1) == -1)
    {
        perror("pipe");
        return EXIT_FAILURE;
    }

    if ((pid1 = fork()) < 0)
    {
        perror("Erreur lors du fork");
        return EXIT_FAILURE;
    }
    else if (pid1 == 0)
    {
        // Code éxécuté par le fils
        close(fd1[1]);
        init_jeux();
        while (true)
        {
            printf("Fils estPresent en lecture\n\n");
            ssize_t bytes_read = read(fd1[0], buffer1, sizeof(buffer1));
            if (bytes_read == -1)
            {
                perror("read");
                return EXIT_FAILURE;
            }
            else if (bytes_read == 0)
            {
                fprintf(stderr, "Fin de fichier atteinte\n");
                return EXIT_FAILURE;
            }
            printf("Enfant estPresent a lu : %s\n\n", buffer1);

            char *nb = strtok(buffer1, " ");
            char nom[25];
            if (strcmp(nb, "3") == 0)
            {
                DemandeOperation ajout = {0};
                ajout.CodeOp = 3;
                snprintf(nom, sizeof(nom), "%s", strtok(NULL, " "));
                snprintf(ajout.NomJeu, sizeof(ajout.NomJeu), "%s", nom);
                execute_demande(ajout);
            }
            else if (strcmp(nb, "4") == 0){
                DemandeOperation suppression = {0};
                suppression.CodeOp = 4;
                snprintf(nom, sizeof(nom), "%s", strtok(NULL, " "));
                snprintf(suppression.NomJeu, sizeof(suppression.NomJeu), "%s", nom);
                execute_demande(suppression);
            }
            else
            {
                DemandeOperation verification = {0};
                verification.CodeOp = 1;
                snprintf(verification.NomJeu, sizeof(verification.NomJeu), "%s", buffer1);
                execute_demande(verification);
            }
        }
    }
    else
    {
        // Code éxécuté par le père
        PIDS[NOMBRE_PID] = pid1;
        NOMBRE_PID++;

        close(fd1[0]);
    }


    int fd2[2];
    pid_t pid2;
    char buffer2[25];

    if (pipe(fd2) == -1)
    {
        perror("pipe");
        return EXIT_FAILURE;
    }

    if ((pid2 = fork()) < 0)
    {
        perror("Erreur lors du fork");
        return EXIT_FAILURE;
    }
    else if (pid2 == 0)
    {
        // Code éxécuté par le fils
        close(fd2[1]);
        init_jeux();
        while (true)
        {
            printf("Fils simulerCombat en lecture\n\n");
            ssize_t bytes_read = read(fd2[0], buffer2, sizeof(buffer2));
            if (bytes_read == -1)
            {
                perror("read");
                return EXIT_FAILURE;
            }
            else if (bytes_read == 0)
            {
                fprintf(stderr, "Fin de fichier atteinte\n");
                return EXIT_FAILURE;
            }
            printf("Enfant simulerCombat a lu : %s\n\n", buffer2);

            char *nb = strtok(buffer2, " ");
            char nom[25];
            if (strcmp(nb, "3") == 0)
            {
                DemandeOperation ajout = {0};
                ajout.CodeOp = 3;
                snprintf(nom, sizeof(nom), "%s", strtok(NULL, " "));
                snprintf(ajout.NomJeu, sizeof(ajout.NomJeu), "%s", nom);
                execute_demande(ajout);
            }
            else if (strcmp(nb, "4") == 0){
                DemandeOperation suppression = {0};
                suppression.CodeOp = 4;
                snprintf(nom, sizeof(nom), "%s", strtok(NULL, " "));
                snprintf(suppression.NomJeu, sizeof(suppression.NomJeu), "%s", nom);
                execute_demande(suppression);
            }
            else
            {
                DemandeOperation simulation = {0};
                simulation.CodeOp = 5;
                snprintf(simulation.NomJeu, sizeof(simulation.NomJeu), "%s", buffer2);
                execute_demande(simulation);
            }
        }
    }
    else
    {
        // Code éxécuté par le père
        PIDS[NOMBRE_PID] = pid2;
        NOMBRE_PID++;

        close(fd2[0]);
    }


    int fd3[2];
    pid_t pid3;
    char buffer3[25];

    if (pipe(fd3) == -1)
    {
        perror("pipe");
        return EXIT_FAILURE;
    }

    if ((pid3 = fork()) < 0)
    {
        perror("Erreur lors du fork");
        return EXIT_FAILURE;
    }
    else if (pid3 == 0)
    {
        // Code éxécuté par le fils
        close(fd3[1]);
        init_jeux();
        while (true)
        {
            printf("Fils lancerCombat en lecture\n\n");
            ssize_t bytes_read = read(fd3[0], buffer3, sizeof(buffer3));
            if (bytes_read == -1)
            {
                perror("read");
                return EXIT_FAILURE;
            }
            else if (bytes_read == 0)
            {
                fprintf(stderr, "Fin de fichier atteinte\n");
                return EXIT_FAILURE;
            }
            printf("Enfant lancerCombat a lu : %s\n\n", buffer3);

            char *nb = strtok(buffer3, " ");
            char nom[25];
            if (strcmp(nb, "3") == 0)
            {
                DemandeOperation ajout = {0};
                ajout.CodeOp = 3;
                snprintf(nom, sizeof(nom), "%s", strtok(NULL, " "));
                snprintf(ajout.NomJeu, sizeof(ajout.NomJeu), "%s", nom);
                execute_demande(ajout);
            }
            else if (strcmp(nb, "4") == 0){
                DemandeOperation suppression = {0};
                suppression.CodeOp = 4;
                snprintf(nom, sizeof(nom), "%s", strtok(NULL, " "));
                snprintf(suppression.NomJeu, sizeof(suppression.NomJeu), "%s", nom);
                execute_demande(suppression);
            }
            else
            {
                DemandeOperation lancement = {0};
                lancement.CodeOp = 6;
                snprintf(lancement.NomJeu, sizeof(lancement.NomJeu), "%s", buffer3);
                execute_demande(lancement);
            }
        }
    }
    else
    {
        // Code éxécuté par le père
        PIDS[NOMBRE_PID] = pid3;
        NOMBRE_PID++;

        close(fd3[0]);
    }

    /* Initialisation de la BDD */

    init_jeux();

    /* ajouter un jeu */

    // Les fork doivent également ajouter le jeu a leur base
    char *message = "3 Chess";
    ssize_t bytes_written = write(fd1[1], message, strlen(message) + 1);
    if (bytes_written == -1)
    {
        perror("write");
        return EXIT_FAILURE;
    }
    else if ((size_t)bytes_written != strlen(message) + 1)
    {
        fprintf(stderr, "Erreur : tous les bytes n'ont pas été écrits\n");
        return EXIT_FAILURE;
    }

    bytes_written = write(fd2[1], message, strlen(message) + 1);
    if (bytes_written == -1)
    {
        perror("write");
        return EXIT_FAILURE;
    }
    else if ((size_t)bytes_written != strlen(message) + 1)
    {
        fprintf(stderr, "Erreur : tous les bytes n'ont pas été écrits\n");
        return EXIT_FAILURE;
    }

    bytes_written = write(fd3[1], message, strlen(message) + 1);
    if (bytes_written == -1)
    {
        perror("write");
        return EXIT_FAILURE;
    }
    else if ((size_t)bytes_written != strlen(message) + 1)
    {
        fprintf(stderr, "Erreur : tous les bytes n'ont pas été écrits\n");
        return EXIT_FAILURE;
    }
    DemandeOperation ajouter_chess = {3, "Chess", "http://chess.com", 0};
    execute_demande(ajouter_chess);

    /* Vérifier si un jeu est présent */

    sleep(3); //Envoyer un signal a la place mais pas le temps
    message = "Chess";
    bytes_written = write(fd1[1], message, strlen(message) + 1);
    if (bytes_written == -1)
    {
        perror("write");
        return EXIT_FAILURE;
    }
    else if ((size_t)bytes_written != strlen(message) + 1)
    {
        fprintf(stderr, "Erreur : tous les bytes n'ont pas été écrits\n");
        return EXIT_FAILURE;
    }

    /* lister les jeux téléchargés */

    DemandeOperation lister_jeux = {2, "", "", 0};
    execute_demande(lister_jeux);

    /* supprimer un jeu */

    // Les fork doivent également supprimer le jeu de leur base
    message = "4 Chess";
    bytes_written = write(fd1[1], message, strlen(message) + 1);
    if (bytes_written == -1)
    {
        perror("write");
        return EXIT_FAILURE;
    }
    else if ((size_t)bytes_written != strlen(message) + 1)
    {
        fprintf(stderr, "Erreur : tous les bytes n'ont pas été écrits\n");
        return EXIT_FAILURE;
    }

    bytes_written = write(fd2[1], message, strlen(message) + 1);
    if (bytes_written == -1)
    {
        perror("write");
        return EXIT_FAILURE;
    }
    else if ((size_t)bytes_written != strlen(message) + 1)
    {
        fprintf(stderr, "Erreur : tous les bytes n'ont pas été écrits\n");
        return EXIT_FAILURE;
    }

    bytes_written = write(fd3[1], message, strlen(message) + 1);
    if (bytes_written == -1)
    {
        perror("write");
        return EXIT_FAILURE;
    }
    else if ((size_t)bytes_written != strlen(message) + 1)
    {
        fprintf(stderr, "Erreur : tous les bytes n'ont pas été écrits\n");
        return EXIT_FAILURE;
    }
    DemandeOperation supprimer_chess = {4, "Chess", "", 0};
    execute_demande(supprimer_chess);

    /* Ajoute un jeu */

    //Les fork doivent également l'ajouter
    message = "3 Pokemon";
    bytes_written = write(fd1[1], message, strlen(message) + 1);
    if (bytes_written == -1)
    {
        perror("write");
        return EXIT_FAILURE;
    }
    else if ((size_t)bytes_written != strlen(message) + 1)
    {
        fprintf(stderr, "Erreur : tous les bytes n'ont pas été écrits\n");
        return EXIT_FAILURE;
    }

    bytes_written = write(fd2[1], message, strlen(message) + 1);
    if (bytes_written == -1)
    {
        perror("write");
        return EXIT_FAILURE;
    }
    else if ((size_t)bytes_written != strlen(message) + 1)
    {
        fprintf(stderr, "Erreur : tous les bytes n'ont pas été écrits\n");
        return EXIT_FAILURE;
    }

    bytes_written = write(fd3[1], message, strlen(message) + 1);
    if (bytes_written == -1)
    {
        perror("write");
        return EXIT_FAILURE;
    }
    else if ((size_t)bytes_written != strlen(message) + 1)
    {
        fprintf(stderr, "Erreur : tous les bytes n'ont pas été écrits\n");
        return EXIT_FAILURE;
    }
    DemandeOperation ajouter_pokemon = {3, "Pokemon", "http://pokemon.com", 0};
    execute_demande(ajouter_pokemon);

    /* Simuler un combat (jeu n'existe pas) */

    sleep(3);
    message = "Chess";
    bytes_written = write(fd2[1], message, strlen(message) + 1);
    if (bytes_written == -1)
    {
        perror("write");
        return EXIT_FAILURE;
    }
    else if ((size_t)bytes_written != strlen(message) + 1)
    {
        fprintf(stderr, "Erreur : tous les bytes n'ont pas été écrits\n");
        return EXIT_FAILURE;
    }

    /* Lancer un combat (jeu existe) */

    sleep(3);
    message = "Pokemon";
    bytes_written = write(fd3[1], message, strlen(message) + 1);
    if (bytes_written == -1)
    {
        perror("write");
        return EXIT_FAILURE;
    }
    else if ((size_t)bytes_written != strlen(message) + 1)
    {
        fprintf(stderr, "Erreur : tous les bytes n'ont pas été écrits\n");
        return EXIT_FAILURE;
    }

    /* Ajoute un jeu */

    //Les fork doivent également l'ajouter
    sleep(10);
    message = "3 GTA";
    bytes_written = write(fd1[1], message, strlen(message) + 1);
    if (bytes_written == -1)
    {
        perror("write");
        return EXIT_FAILURE;
    }
    else if ((size_t)bytes_written != strlen(message) + 1)
    {
        fprintf(stderr, "Erreur : tous les bytes n'ont pas été écrits\n");
        return EXIT_FAILURE;
    }

    bytes_written = write(fd2[1], message, strlen(message) + 1);
    if (bytes_written == -1)
    {
        perror("write");
        return EXIT_FAILURE;
    }
    else if ((size_t)bytes_written != strlen(message) + 1)
    {
        fprintf(stderr, "Erreur : tous les bytes n'ont pas été écrits\n");
        return EXIT_FAILURE;
    }

    bytes_written = write(fd3[1], message, strlen(message) + 1);
    if (bytes_written == -1)
    {
        perror("write");
        return EXIT_FAILURE;
    }
    else if ((size_t)bytes_written != strlen(message) + 1)
    {
        fprintf(stderr, "Erreur : tous les bytes n'ont pas été écrits\n");
        return EXIT_FAILURE;
    }
    DemandeOperation ajouter_gta = {3, "GTA", "http://gta.com", 0};
    execute_demande(ajouter_gta);

    /* Lister les jeux */

    DemandeOperation lister = {2, "", "", 0};
    execute_demande(lister);

    /* Simule un combat (jeu existe) */

    sleep(10); //Faire attendre (signal est mieux)
    message = "Pokemon";
    bytes_written = write(fd2[1], message, strlen(message) + 1);
    if (bytes_written == -1)
    {
        perror("write");
        return EXIT_FAILURE;
    }
    else if ((size_t)bytes_written != strlen(message) + 1)
    {
        fprintf(stderr, "Erreur : tous les bytes n'ont pas été écrits\n");
        return EXIT_FAILURE;
    }

    /* Attente de la fin des fils */

    sleep(40);
    attendre_processus();

    /* Libération mémoire */

    free_jeux();

    return 0;
}