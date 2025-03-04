#include "../includes/jeux.h"

//Déclarer le nombre de jeux de la BDD
int NOMBRE_JEUX = 0;
//Déclarer le tableau global de pointeurs de jeu
Jeu** jeux;

int main (int argc, char *argv[]){

    //Allocations mémoires pour les jeux dans la BDD (ici on considère qu'on aura jamais plus de 100 jeux dans la base)
    jeux = (Jeu**)malloc(100 * sizeof(Jeu*));
    for (int i = 0; i < 100; i++) {
        jeux[i] = NULL;
    }

    // Initialiser le générateur de nombres aléatoires
    srand(time(NULL));

    // ajouter un jeu
    DemandeOperation ajouter_op = {3, "Chess", "http://chess.com", 0};
    int resultat_ajout = execute_demande(ajouter_op);
    if (resultat_ajout != -1) {
        printf("Jeu '%s' ajouté\n", ajouter_op.NomJeu);
    } else {
        printf("Impossible d'ajouter le jeu '%s'\n", ajouter_op.NomJeu);
    }

    // vérifier si un jeu est présent
    DemandeOperation verifier_op = {1, "Chess", "", 0};
    int resultat_verification = execute_demande(verifier_op);
    if (resultat_verification == 0) {
        printf("Le jeu '%s' est présent dans la BDD\n", verifier_op.NomJeu);
    } else {
        printf("Le jeu '%s' n'est pas trouvé dans la BDD\n", verifier_op.NomJeu);
    }

    // lister les jeux téléchargés
    DemandeOperation lister_op = {2, "", "", 0};
    int nb_jeux_telecharges = execute_demande(lister_op);
    printf("Nombre de jeux téléchargés : %d\n", nb_jeux_telecharges);

    // supprimer un jeu
    DemandeOperation supprimer_op = {4, "Chess", "", 0};
    int resultat_suppression = execute_demande(supprimer_op);
    if (resultat_suppression != -1) {
        printf("Jeu '%s' supprimé \n", supprimer_op.NomJeu);
    } else {
        printf("Impossible de supprimer le jeu '%s'\n", supprimer_op.NomJeu);
    }

    free_jeux();
    free(jeux);

    return 0;
}