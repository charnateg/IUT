// Fichier : V3_Serveur.c
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <unistd.h>
#include <arpa/inet.h>
#include <pthread.h>

#include "jeux.h"

#define PORT 8080

// Fonction principale du serveur
int main() {
    int server_fd, new_socket;
    struct sockaddr_in address;
    int addrlen = sizeof(address);

    // Création du socket
    if ((server_fd = socket(AF_INET, SOCK_STREAM, 0)) == 0) {
        perror("Erreur de création du socket");
        exit(EXIT_FAILURE);
    }

    address.sin_family = AF_INET;
    address.sin_addr.s_addr = INADDR_ANY;
    address.sin_port = htons(PORT);

    // Liaison du socket
    if (bind(server_fd, (struct sockaddr*)&address, sizeof(address)) < 0) {
        perror("Erreur de liaison");
        exit(EXIT_FAILURE);
    }

    // Écoute des connexions
    if (listen(server_fd, 3) < 0) {
        perror("Erreur d'écoute");
        exit(EXIT_FAILURE);
    }

    printf("Serveur en attente de connexions sur le port %d...\n", PORT);

    while (1) {
        if ((new_socket = accept(server_fd, (struct sockaddr*)&address, 
                                 (socklen_t*)&addrlen)) < 0) {
            perror("Erreur d'acceptation");
            exit(EXIT_FAILURE);
        }

        printf("Connexion acceptée\n");

        // Traitement de la demande dans un thread séparé
        pthread_t thread_id;
        int* socket_ptr = malloc(sizeof(int));
        *socket_ptr = new_socket;
        pthread_create(&thread_id, NULL, traiter_demande, socket_ptr);
        pthread_detach(thread_id);
    }

    return 0;
}




