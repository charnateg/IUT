    // Fichier : V3_Client.c
    #include <stdio.h>
    #include <stdlib.h>
    #include <string.h>
    #include <unistd.h>
    #include <arpa/inet.h>
    #include <sys/socket.h>


    #define PORT 8080
    #define BUFFER_SIZE 1024

    typedef struct __attribute__((packed)) {
        int CodeOp;
        char NomJeu[25];
        char Param[200];
        int flag;
    } DemandeOperation;

    // Fonction pour afficher le menu
    void afficher_menu() {
        printf("\n=== Menu Client ===\n");
        printf("1. Vérifier si un jeu est présent\n");
        printf("2. Lister les jeux disponibles\n");
        printf("3. Ajouter un jeu\n");
        printf("4. Supprimer un jeu\n");
        printf("5. Simuler un combat\n");
        printf("0. Quitter\n");
        printf("Votre choix : ");
    }

    // Fonction pour envoyer une demande au serveur
    int envoyer_demande(DemandeOperation* demande, int* resultat) {
        int sock = 0;
        struct sockaddr_in serv_addr;

        // Création du socket
        if ((sock = socket(AF_INET, SOCK_STREAM, 0)) < 0) {
            perror("Erreur de création du socket");
            return -1;
        }

        serv_addr.sin_family = AF_INET;
        serv_addr.sin_port = htons(PORT);

        // Conversion de l'adresse IP
        if (inet_pton(AF_INET, "127.0.0.1", &serv_addr.sin_addr) <= 0) {
            perror("Adresse invalide");
            close(sock);
            return -1;
        }

        // Connexion au serveur
        if (connect(sock, (struct sockaddr*)&serv_addr, sizeof(serv_addr)) < 0) {
            perror("Erreur de connexion au serveur");
            close(sock);
            return -1;
        }

        if (write(sock, demande, sizeof(DemandeOperation)) != sizeof(DemandeOperation)) {
            perror("Erreur lors de l'envoi des données");
            close(sock);
            return -1;
        }

        ssize_t bytes_read = read(sock, resultat, sizeof(int));
        if (bytes_read != sizeof(int)) {
            printf("Erreur lors de la réception de la réponse: bytes_read = %ld\n", bytes_read);
            perror("Erreur lors de la réception de la réponse");
            close(sock);
            return -1;
        }

        close(sock);
        return 0;
    }

    int main() {
        int choix;
        do {
            afficher_menu();
            scanf("%d", &choix);
            getchar(); // Consommer le '\n' laissé par scanf

            DemandeOperation demande;
            memset(&demande, 0, sizeof(DemandeOperation));
            int resultat;

            switch (choix) {
                case 1: // Vérifier si un jeu est présent
                    printf("Entrez le nom du jeu à vérifier : ");
                    fgets(demande.NomJeu, sizeof(demande.NomJeu), stdin);
                    strtok(demande.NomJeu, "\n"); // Supprimer le '\n'
                    demande.CodeOp = 1;
                    if (envoyer_demande(&demande, &resultat) == 0) {
                        printf("Résultat : %s\n", resultat == 0 ? "Présent" : "Absent");
                    }
                    break;

                case 2: // Lister les jeux disponibles
                    demande.CodeOp = 2;
                    if (envoyer_demande(&demande, &resultat) == 0) {
                        printf("Nombre de jeux disponibles : %d\n", resultat);
                    }
                    break;

                case 3: // Ajouter un jeu
                    printf("Entrez le nom du jeu à ajouter : ");
                    fgets(demande.NomJeu, sizeof(demande.NomJeu), stdin);
                    strtok(demande.NomJeu, "\n");
                    printf("Entrez l'URL de téléchargement : ");
                    fgets(demande.Param, sizeof(demande.Param), stdin);
                    strtok(demande.Param, "\n");
                    demande.CodeOp = 3;
                    if (envoyer_demande(&demande, &resultat) == 0) {
                        printf("Taille du jeu téléchargé : %d Mio\n", resultat);
                    }
                    break;

                case 4: // Supprimer un jeu
                    printf("Entrez le nom du jeu à supprimer : ");
                    fgets(demande.NomJeu, sizeof(demande.NomJeu), stdin);
                    strtok(demande.NomJeu, "\n");
                    demande.CodeOp = 4;
                    if (envoyer_demande(&demande, &resultat) == 0) {
                        if (resultat == -1) {
                            printf("Erreur : Jeu introuvable.\n");
                        } else {
                            printf("Taille du jeu supprimé : %d Mio\n", resultat);
                        }
                    }
                    break;

                case 5: // Simuler un combat
                    printf("Entrez le nom du jeu pour le combat : ");
                    fgets(demande.NomJeu, sizeof(demande.NomJeu), stdin);
                    strtok(demande.NomJeu, "\n");
                    demande.CodeOp = 5;
                    envoyer_demande(&demande, &resultat); // Pas de retour spécifique attendu
                    printf("Combat simulé.\n");
                    break;

                case 0: // Quitter
                    printf("Fermeture du client...\n");
                    break;

                default:
                    printf("Choix invalide. Réessayez.\n");
            }
        } while (choix != 0);

        return 0;
    }
