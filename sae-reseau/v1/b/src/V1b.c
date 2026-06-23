#include "jeux.h"

int NOMBRE_JEUX = 0;
Jeu** jeux;

int main(int argc, char *argv[]) {
    jeux = (Jeu**)malloc(100 * sizeof(Jeu*));
    for (int i = 0; i < 100; i++) {
        jeux[i] = NULL;
    }
    srand(time(NULL));

    DemandeOperation operations[] = {
        {3, "Echec", "http://echecetmat.com", 1},
        {3, "Othello", "http://oterleau.com", 1},
        {3, "Go", "http://goettic.com", 1},
        {1, "Echec", "http://echecetmat.com", 1},
        {5, "Echec", "", 1},
        {2, "Go", " ", 1},
        {4, "Othello", "", 1}
    };

    int nb_operations = sizeof(operations) / sizeof(DemandeOperation);
    pthread_t threads[nb_operations];

    // Création des récepteurs de signaux
    //signal(SIGUSR1, recepteur_sigusr1);
    //signal(SIGUSR2, recepteur_sigusr2);

    for (int i = 0; i < nb_operations; i++) {
        if (pthread_create(&threads[i], NULL, thread_function, &operations[i]) != 0) {
            perror("Erreur de création de thread");
            return 1;
        }
    }

    // Envoi du signal SIGUSR1 au premier thread
    //pthread_kill(threads[0], SIGUSR1);

    for (int i = 0; i < nb_operations; i++) {
        if (pthread_join(threads[i], NULL) != 0) {
            perror("Erreur lors de l'attente du thread");
            return 1;
        }
    }

    free_jeux();
    free(jeux);

    return 0;
}