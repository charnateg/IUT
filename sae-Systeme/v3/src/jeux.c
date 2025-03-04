#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <unistd.h>
#include <arpa/inet.h>
#include <pthread.h>

#include "jeux.h"

#define MAX_JEUX 50

// Variables globales
Jeu jeux[MAX_JEUX];
int nb_jeux = 0;
pthread_mutex_t mutex_jeux = PTHREAD_MUTEX_INITIALIZER;

// Traitement de la demande
void* traiter_demande(void* arg) {
    int socket = *(int*)arg;
    free(arg);

    DemandeOperation demande;
    ssize_t bytes_read = read(socket, &demande, sizeof(DemandeOperation));
    if (bytes_read != sizeof(DemandeOperation)) {
        printf("Erreur : données reçues incorrectes (taille = %ld)\n", bytes_read);
        close(socket);
        pthread_exit(NULL);
    }

    printf("Demande reçue : CodeOp = %d, NomJeu = %s\n", demande.CodeOp, demande.NomJeu);

    // Vérifier que le CodeOp est valide
    if (demande.CodeOp < 1 || demande.CodeOp > 6) {
        printf("CodeOp non valide : %d\n", demande.CodeOp);
        close(socket);
        pthread_exit(NULL);
    }

    // Exécuter la demande
    int resultat = execute_demande(&demande);

    ssize_t bytes_written = write(socket, &resultat, sizeof(int));
    if (bytes_written != sizeof(int)) {
        printf("Erreur lors de l'envoi de la réponse: bytes_written = %ld\n", bytes_written);
        perror("Erreur lors de l'envoi de la réponse");
    }

    // Fermer le socket
    close(socket);

    printf("Demande traitée et connexion fermée.\n");
    pthread_exit(NULL);
}

// Exécution de la demande
int execute_demande(DemandeOperation* demande) {
    switch (demande->CodeOp) {
        case 1: // Vérifier si un jeu est présent
            return verifier_jeu(demande->NomJeu);
        case 2: // Lister les jeux
            return lister_jeux();
        case 3: // Ajouter un jeu
            return ajouter_jeu(demande->NomJeu, demande->Param);
        case 4: // Supprimer un jeu
            return supprimer_jeu(demande->NomJeu);
        case 5: // Simuler un combat
            simuler_combat(demande->NomJeu);
            return 0; // Pas de retour spécifique
        default:
            printf("CodeOp non pris en charge\n");
            return -1;
    }
}

// Vérifier si un jeu est présent
int verifier_jeu(const char* nomJeu) {
    pthread_mutex_lock(&mutex_jeux);
    for (int i = 0; i < nb_jeux; i++) {
        if (strcmp(jeux[i].NomJeu, nomJeu) == 0) {
            pthread_mutex_unlock(&mutex_jeux);
            return 0; // Jeu trouvé
        }
    }
    pthread_mutex_unlock(&mutex_jeux);
    return -1; // Jeu non trouvé
}

// Lister les jeux disponibles
int lister_jeux() {
    pthread_mutex_lock(&mutex_jeux);
    printf("Liste des jeux disponibles :\n");
    for (int i = 0; i < nb_jeux; i++) {
        printf("- %s (Téléchargé : %s)\n", jeux[i].NomJeu, jeux[i].Code ? "Oui" : "Non");
    }
    pthread_mutex_unlock(&mutex_jeux);
    sleep(1); // Simuler le délai
    return nb_jeux;
}

// Ajouter un jeu
int ajouter_jeu(const char* nomJeu, const char* param) {
    pthread_mutex_lock(&mutex_jeux);
    if (nb_jeux >= MAX_JEUX) {
        pthread_mutex_unlock(&mutex_jeux);
        return -1;
    }

    strncpy(jeux[nb_jeux].NomJeu, nomJeu, sizeof(jeux[nb_jeux].NomJeu));
    jeux[nb_jeux].NomJeu[sizeof(jeux[nb_jeux].NomJeu) - 1] = '\0'; // Sécuriser la terminaison

    // Simuler l'utilisation de param
    printf("Téléchargement depuis l'URL : %s\n", param);

    jeux[nb_jeux].Code = malloc(1000); // Simuler un téléchargement
    memset(jeux[nb_jeux].Code, '*', 1000);
    nb_jeux++;

    pthread_mutex_unlock(&mutex_jeux);
    sleep(10); // Simuler le temps de téléchargement

    return 1000; // Taille simulée
}

// Supprimer un jeu
int supprimer_jeu(const char* nomJeu) {
    pthread_mutex_lock(&mutex_jeux);
    for (int i = 0; i < nb_jeux; i++) {
        if (strcmp(jeux[i].NomJeu, nomJeu) == 0) {
            free(jeux[i].Code);
            jeux[i] = jeux[nb_jeux - 1];
            nb_jeux--;
            pthread_mutex_unlock(&mutex_jeux);
            sleep(2); // Simuler le temps de suppression
            return 1000; // Taille simulée
        }
    }
    pthread_mutex_unlock(&mutex_jeux);
    return -1;
}

// Simuler un combat
void simuler_combat(const char* nomJeu) {
    printf("Combat en cours sur %s...\n", nomJeu);
    sleep(20); // Simuler le temps du combat
    printf("Gagnant : %s\n", rand() % 2 ? "Joueur 1" : "Joueur 2");
}