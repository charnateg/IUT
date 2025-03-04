#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <time.h>
#include <unistd.h>

int main(int argc, char *argv[])
{
    if (argc != 2) {
        fprintf(stderr, "Erreur : nombre d'arguments invalide\n");
        return -1;
    }

    char* nomJeu = argv[1];
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
    return 0;
}