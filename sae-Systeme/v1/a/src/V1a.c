#include "jeux.h"

// Déclarer le nombre de jeux de la BDD
int NOMBRE_JEUX = 0;
// Déclarer le tableau global de pointeurs de jeu
Jeu** jeux;

int main(int argc, char *argv[]) {

    printf("\n====== Bienvenue dans le programme de gestion de jeux ======\n");
    printf("=== Initialisation de la base de données... ===\n\n");

    // Allocations mémoires pour les jeux dans la BDD (ici on considère qu'on aura jamais plus de 100 jeux dans la base)
    jeux = (Jeu**)malloc(100 * sizeof(Jeu*));
    for (int i = 0; i < 100; i++) {
        jeux[i] = NULL;
    }

    printf("=== Base de données initialisée ===\n");
    printf("=== Début des opérations ===\n\n");

    // Liste des opérations à exécuter
    DemandeOperation operations[] = {
        {3, "Echec", "http://echecetmat.com", 1},
        {3, "Go", "http://goettic.com", 1},
        {3, "Othello", "http://oterleau.com", 1},
        {1, "Echec", "http://echecetmat.com", 1},
        {5, "Echec", "", 1},
        {2, "Go", " ", 0},
        {4, "Othello", "", 1},
        {2, "Go", " ", 0}
    };

    int nb_operations = sizeof(operations) / sizeof(DemandeOperation);

    for (int i = 0; i < nb_operations; i++) {
        printf("\033[38;5;214mOperation %d: CodeOp=%d, NomJeu=%s\033[0m\n", i, operations[i].CodeOp, operations[i].NomJeu);
        switch (operations[i].CodeOp) {
            case 1:
                printf("Recherche du jeu '%s' dans la base de données...\n", operations[i].NomJeu);
                tester_jeu(operations[i]);
                break;
            case 2:
                lister_jeux(operations[i]);
                break;
            case 3:
                printf("Ajout du jeu '%s' dans la base de données...\n", operations[i].NomJeu);
                ajouter_jeu(operations[i]);
                break;
            case 4:
                printf("Suppression du jeu '%s' de la base de données...\n", operations[i].NomJeu);
                supprimer_jeu(operations[i]);
                break;
            case 5:
                printf("Simulation de combat pour le jeu '%s'...\n", operations[i].NomJeu);
                simuler_combat(operations[i]);
                break;
            default:
                printf("Opération non reconnue\n");
                break;
        }
    }
    printf("=== Fin des opérations ===\n\n");

    free_jeux();
    free(jeux);

    return 0;
}