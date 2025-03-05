# Rapport

## Choix de conception
### MVC 
Le jeu est structuré autour du MVC pour séparer les responsabilités logiques, faciliter les mises à jour et améliorer la testabilité.

- Model:
Le modèle encapsule les données du jeu et sa logique. Les entités comme Board, Game, Player, et Tile contiennent les règles fondamentales du jeu et les états respectifs.

- View:
Les classes dans le package view (comme BoardView, AdditionalTileView, GameView, PlayerView) gèrent l'affichage des informations et l'interface utilisateur.

- Controller:
Les contrôleurs (GameController, BoardController, PlayerController) orchestrent les interactions entre la vue et le modèle, répondant aux événements utilisateur et mettant à jour les états.

#### Avantages

- Facilité de maintenance:
La séparation des préoccupations permet de modifier une partie du code sans affecter les autres parties. Par exemple, on peut changer l'affichage sans toucher à la logique du jeu.

#### Inconvénients

- Complexe
- Redondance de code
- Difficulté à maintenir la synchronisation entre les vues et le modèle à cause de Swing

### Observer

Le pattern Observer est utilisé pour notifier les vues des changements dans le modèle. Les vues s'abonnent aux événements du modèle et se mettent à jour automatiquement.

- Board informe ses observateurs (BoardView, AdditionalTileView) lors de modifications.
- Game informe les vues des changements d’état, comme la fin d’un tour.

#### Avantages
- Reactivité
- Syncronisation entre les vues et le modèle

### Factory

Le jeu utilise des classes de fabrique (TaskFactory, TileFactory, BoardFactory) pour la création des tuiles, des tâches ou le plateau.

## Packages

Les packages (model, view, controller, helpers, tiles, factories) organisent les classes par fonction. Cela facilite la navigation et la gestion des responsabilités.
