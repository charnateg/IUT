#include <stdio.h>
#include <string.h>

int main(int argc, char *argv[])
{
    if (argc < 2) {
        fprintf(stderr, "Erreur : nombre d'arguments invalide\n\n");
        return -1;
    }

    if (argc == 2){
        printf("La BDD est vide.\n\n");
        return -1;
    }

    char* NomJeu = argv[1];
    for (int i = 2; i < argc ; i++)
    {
        char res[25];
        strcpy(res, argv[i]);
        if (strcmp(NomJeu, res) == 0)
        {
            printf("Le jeu %s est présent dans la BDD.\n\n", NomJeu);
            return 0;
        }
    }
    printf("Le jeu %s n'est pas présent dans la BDD.\n\n", NomJeu);
    return -1;
}