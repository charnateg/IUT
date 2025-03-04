#include "includes.h"

typedef struct {
    char NomJeu[25];
    char * Code; // NULL si le jeu n’a pas encore été téléchargé
} Jeu;

typedef struct {
    int CodeOp;
    char NomJeu[25];
    char Param[200];
    int flag;
} DemandeOperation;

//Nombre de jeux de la BDD
extern int NOMBRE_JEUX;

//Déclare le tableau de pointeur vers les structures de jeu (BDD) qui sera implémentée dans le main
extern Jeu** jeux;

void afficher_barre_progression(int progression);
void simuler_telechargement(char* nom);

void ajouter_jeu(DemandeOperation op);
void supprimer_jeu(DemandeOperation op);
void lister_jeux(DemandeOperation op);
void tester_jeu(DemandeOperation op);
void simuler_combat(DemandeOperation op);

void free_jeux();
int estPresent(char* nom);
int jeuxTelecharges();
int ajouterJeu(char* nom);
int supprimerJeu(char* nom);
void simulerCombat(char* nomJeu);
void lancerJeu(char* nomJeu);
int execute_demande(DemandeOperation op);