## Mode d'emploi (INSTALL.md)

### Prérequis
- JDK 17 ou supérieur
### Installation
1. Cloner le dépôt :
   ```bash
   git clone git@git.unistra.fr:saidi-hieber/labyrinthe.git
   ```
2. Se déplacer dans le répertoire :
   ```bash
   cd labyrinthe/game
   ```
#### Avec IntelliJ IDEA ou VS Code

- Ouvrir le projet avec l'IDE.
- Cliquer sur le bouton "Run" pour lancer l'application.

#### En ligne de commande
```bash
javac -d out $(find src -name "*.java")
java -cp out Main
```
!!! note
Pour des problèmes d'images, le projet ne va pas se lancer correctement en ligne de commande.
