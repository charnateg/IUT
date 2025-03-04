#include "includes.h"

typedef struct {
    char NomJeu[25];
    char* Code;
} Jeu;

typedef struct {
    int CodeOp;
    char NomJeu[25];
    char Param[200];
    int flag;
} DemandeOperation;

extern int NOMBRE_JEUX;
extern Jeu** jeux;

void recepteur_sigusr1(int sig);
void recepteur_sigusr2(int sig);

void* thread_function(void* arg);
void free_jeux();
int estPresent(char* nom);
int jeuxTelecharges();
int ajouterJeu(char* nom);
int supprimerJeu(char* nom);
void simulerCombat(char* nomJeu);
void lancerJeu(char* nomJeu);
int execute_demande(DemandeOperation OP);
void afficher_barre_progression(int progression);
void simuler_telechargement(char* nom);

