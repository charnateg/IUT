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
    // Interaction avec le joueur
    printf("%s lancé, appuyez sur la touche 1 pour lancer la manche !\n", nomJeu);
    int input = 0;
    if (scanf("%d", &input) != 1) {
        printf("Entrée invalide. Veuillez entrer un entier.\n");
        return -1;  // Sortir ou gérer l'erreur
    }

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
}