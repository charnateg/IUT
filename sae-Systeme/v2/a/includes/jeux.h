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

//Déclare le tableau de PID
extern pid_t PIDS[];

//Nombre de PID
extern int NOMBRE_PID;

void init_jeux();
void free_jeux();
int ajouterJeu(char* nom);
int supprimerJeu(char* nom);
int jeuxTelecharges();
int estPresent(char* nomJeu);
void simulerCombat(char* nom);
void lancerJeu(char* nom);
int execute_demande(DemandeOperation OP);
void attendre_processus();