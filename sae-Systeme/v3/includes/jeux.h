#pragma once

typedef struct {
    char NomJeu[25];
    char * Code; // NULL si le jeu n’a pas encore été téléchargé
} Jeu;

typedef struct __attribute__((packed)) {
    int CodeOp;
    char NomJeu[25];
    char Param[200];
    int flag;
} DemandeOperation;

//Nombre de jeux de la BDD
extern int nb_jeux;

//Déclare le tableau de jeux
extern Jeu jeux[];

// Prototypes des fonctions
void* traiter_demande(void* arg);
int execute_demande(DemandeOperation* demande);
int verifier_jeu(const char* nomJeu);
int lister_jeux();
int ajouter_jeu(const char* nomJeu, const char* param);
int supprimer_jeu(const char* nomJeu);
void simuler_combat(const char* nomJeu);
void lancer_jeu(const char* nomJeu);