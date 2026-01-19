# 🎮 Morpion Console (Tic-Tac-Toe)

> Projet réalisé dans le cadre du **BTS SIO (1ère année)**.
> Un jeu de Morpion classique jouable directement dans le terminal, codé en **C#**.

---

## 🚀 À propos du projet
Ce projet est une application console qui reprend les règles du jeu de Morpion. L'objectif était de mettre en pratique la **Programmation Orientée Objet (POO)** et la logique algorithmique en C#.

Il ne s'agit pas juste d'afficher du texte : le jeu gère un curseur mobile, une grille dynamique et une intelligence de jeu (détection de victoire).

## ✨ Fonctionnalités
* **Interface Graphique Console :** Affichage propre de la grille avec caractères ASCII.
* **Curseur Mobile :** Déplacement fluide (Haut, Bas, Gauche, Droite) pour sélectionner sa case.
* **Système de Tour par Tour :** Alternance automatique entre le joueur **X** et le joueur **O**.
* **Sécurité :** Impossible de jouer sur une case déjà occupée.
* **Arbitre Automatique :**
    * Détection des victoires (Lignes, Colonnes, Diagonales).
    * Détection des matchs nuls (Grille pleine).
    * Affichage dynamique du gagnant.

## 🛠️ Compétences Techniques (Tech Stack)
Ce projet met en œuvre plusieurs concepts clés du développement C# / .NET :

* **Langage :** C# (.NET Core / Framework).
* **POO (Programmation Orientée Objet) :**
    * Séparation logique : `Program.cs` (Entrée) vs `Game.cs` (Moteur).
    * Utilisation de **Propriétés**, **Constructeurs** et **Méthodes**.
* **Algorithmique :**
    * Mapping 2D vers 1D : Conversion des coordonnées (X,Y) vers un index de tableau `[0-8]`.
    * Boucle de jeu infinie (`while true`) avec gestion des événements clavier (`ConsoleKey`).
    * Utilisation de **Tuples** `(bool, string)` pour retourner plusieurs valeurs simultanément.
    * Switch Expressions (Syntaxe moderne).

## 🕹️ Comment jouer ?

1.  **Lancer le jeu** via Visual Studio ou le terminal.
2.  **Utiliser les flèches du clavier** `⬅️` `➡️` `⬆️` `⬇️` pour déplacer le carré vert.
3.  Appuyer sur **`ESPACE`** pour valider et poser son pion.
4.  Le jeu s'arrête quand un joueur aligne 3 symboles ou que la grille est pleine.
