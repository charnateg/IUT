#include "../includes/jeux.h"

//Déclarer le nombre de jeux de la BDD
int NOMBRE_JEUX = 0;
//Déclarer le tableau global de pointeurs de jeu
Jeu** jeux;
//Déclarer le tableau de pids
pid_t PIDS[100];
//Déclarer le nombre de PID
int NOMBRE_PID = 0;

int main (int argc, char *argv[]){

    /* Initialisation de la BDD */

    init_jeux();

    /* ajouter un jeu */

    DemandeOperation ajouter_chess = {3, "Chess", "http://chess.com", 0};
    execute_demande(ajouter_chess);

    /* Vérifier si un jeu est présent */

    DemandeOperation verifier_chess = {1, "Chess", "", 0};
    execute_demande(verifier_chess);
    
    /* lister les jeux téléchargés */

    DemandeOperation lister_jeux = {2, "", "", 0};
    execute_demande(lister_jeux);
    
    /* supprimer un jeu */

    DemandeOperation supprimer_chess = {4, "Chess", "", 0};
    execute_demande(supprimer_chess);

    /* Ajoute un jeu */

    DemandeOperation ajouter_pokemon = {3, "Pokemon", "http://pokemon.com", 0};
    execute_demande(ajouter_pokemon);

    /* Simuler un combat */

    DemandeOperation simuler_pokemon= {5, "Pokemon", "", 0};
    execute_demande(simuler_pokemon);

    /* Ajoute d'autres jeux */

    DemandeOperation ajouter_gta = {3, "GTA", "http://gta.com", 0};
    execute_demande(ajouter_gta);
    DemandeOperation ajouter_mario = {3, "Mario", "http://mario.com", 0};
    execute_demande(ajouter_mario);

    /* Lancer un combat */

    DemandeOperation lancer_gta = {6, "GTA", "", 0};
    execute_demande(lancer_gta);

    /* Supprime un jeu */

    DemandeOperation supprimer_mario= {4, "Mario", "", 0};
    execute_demande(supprimer_mario);

    /* Attente de la fin des fils */

    attendre_processus();

    /* Libération mémoire */

    free_jeux();
    
    return 0;
}