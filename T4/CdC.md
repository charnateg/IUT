# Cahier des Charges : "Dôme C : Mission Rénovation"

## Objectifs Pédagogiques

Le jeu vise à sensibiliser les joueurs :

- Aux enjeux de l'architecture dans les environnements extrêmes (climat, isolement, logistique).
- Aux conditions de vie uniques sur la station Concordia.
- À la complexité de la prise de décisions techniques ayant des conséquences humaines (confort, sécurité, etc.).
- À la gestion de projets en milieu hostile, avec des contraintes de temps, de ressources, et d’efficacité.

## Description générale

**Type de jeu** : Point & Click narratif

**Plateforme cible** : PC/Mac (Appli Web)

**Public visé** : Étudiants, lycéens, passionnés de science et d’architecture

Le joueur incarne un architecte envoyé à la base Concordia avec une mission :
rénover et améliorer l’infrastructure pour assurer le confort, la sécurité et l’efficacité des chercheurs présents sur place.

## Univers & contexte

La base Concordia, située sur le dôme C de l’Antarctique à 3200m d’altitude,
est l’un des lieux les plus isolés de la planète. Elle est sujette à des conditions climatiques extrêmes ( -30°C en été et -70°C de moyenne en hivers),
à des problèmes logistiques majeurs, et à une gestion binationalité (France / Italie).

## Gameplay et mécaniques

### Interface

Carte interactive de la base Concordia : permet de se déplacer dans les différentes zones des deux tours.

Un indicateur claire sur le nombre de missions restantes.

### Missions

Chaque mission est un problème réel ou plausible lié à :

- L’isolation thermique
- L’évacuation des eaux usées
- La gestion de l’espace de vie
- Les besoins de recyclage (ex : eau, urine, air)
- Le confort psychologique des hivernants
- La sécurité face aux crevasses ou aux blackouts
- La gestion des déchets
- La logistique de livraison des ressources
- La gestion de l’énergie (électricité, chauffage, etc.)
- La gestion des conflits entre les équipes (FR/IT)
- La conception pratique des installations

### Objectifs du joueur

- Maintenir ou améliorer le bien-être des membres de la station
- Comprendre et résoudres les problèmes architecturaux
- Gérer les ressources de manière efficiente
- Éviter les incidents critiques (blackout, crise sanitaire…)

### Fonctionnalités clés

- Déplacements sur une carte de la base
- Interargir avec les éléments problématique de la station
- Récuperer puis utiliser des objets pour palier aux problèmes
- Dialogues interactifs avec les membres de la station

## Scénarios

Vous vous balladez dans la station polaire, quand soudain un problème vous saute au yeux, votre but est de le régler :
 - La fenêtre de la salle de sport, ouverte laissant l'air à -50°C pénétrer a l'intérieur du bâtiment ?
 - Bien d'autres problèmes sont réalisables

Cependant chaque fois que vous penser avoir réglé un problème, vous rendez rapidement compte qu'il était plus complexe que prévu :
 - La fenêtre que vous avez refermé a été réouverte, vous comprennez bien vite que la fermer déplaît aux sportif trouvant la température insupportable (il faut dire que les groupes électrogène font pas mal augmenté la température), mais comment allez vous donc palier à ça ?

la plupart des problèmes réglé doivent être la sources eux même d'autres problèmes démontrant ainsi la complexité de trouver de bon choix architecturaux dans un milieu hostile et isolé comme la base polaire Concordia.

## Contraintes de développement

Avoir une gestion d'un inventaire grâce a une classe/un type ayant pour attribut la liste des objets qu'il contient.

Ces dit-objets

## Fonctionnalités et scénarios avancés

 - Ajouter les ravitaillement du RAID
 - Implémentation du camps d'été
 - Implémentation des shelters (Physique, Sysmologie, ...)
 - Ajout de la gestion de la période d'été
