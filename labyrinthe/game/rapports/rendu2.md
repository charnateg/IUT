# Rapport Final

## Introduction
Ce rapport final présente les choix de conception et les évolutions effectuées depuis le premier rendu. Nous avons implémenté toutes les fonctionnalités demandées et intégré les bonus pour offrir une expérience complète et fluide.

### Évolutions depuis le Rendu 1

#### 1. Gestion des tuiles
- Orientation aléatoire.
- **Rotation de la tuile supplémentaire** :
    - Les joueurs peuvent faire pivoter la tuile supplémentaire par pas de 90 degrés dans le sens horaire ou anti-horaire.

#### 2. Génération du plateau
- Placement mixte comme dans le jeu de société.

#### 3. Distribution des cartes objectifs
-  Distribution aléatoire.

#### 4. Déplacement des pions
- Implémentation d'un système de déplacement case par case sur les tuiles voisines.

#### 5. Déplacement des lignes ou colonnes
- Gestion des différents niveaux avec :
    - Passage des joueurs éjectés au côté opposé.
    - Interdiction du déplacement inverse du précédent.

#### 6. Détection des objectifs
- Détection lorsqu'un joueur atteint un objectif et mise à jour vers l'objectif suivant.

#### 7. Gestion des tours et fin de partie
- Détection de la fin du tour d'un joueur.
- Détection de la fin de partie lorsque tous les objectifs sont atteints et retour à la position de départ.
- L'écran de fin de partie annonce le vainqueur.

#### 8. Ajout d'effets sonores
- Effets sonores pour les déplacements, la rotation des tuiles, et la fin de partie.
- Musique de fond pour une expérience immersive.


---

## Diagramme UML
Le diagramme de classes UML, conforme au code final.

---

## Conclusion
Nous avons respecté toutes les exigences du cahier des charges et intégré les bonus pour enrichir l'expérience utilisateur.

