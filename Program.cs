using System;

namespace Morpion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("--- MORPION BTS SIO ---");
            
            Game partie = new Game(3);
            partie.Affichage();
            
            while (true)
            {
                ConsoleKeyInfo touche = Console.ReadKey(true);
                
                switch (touche.Key)
                {
                    case ConsoleKey.LeftArrow:
                        partie.DeplacerGauche();
                        break;

                    case ConsoleKey.RightArrow:
                        partie.DeplacerDroite();
                        break;

                    case ConsoleKey.UpArrow:
                        partie.DeplacerHaut();
                        break;

                    case ConsoleKey.DownArrow:
                        partie.DeplacerBas();
                        break;
                    case ConsoleKey.Spacebar:
                        partie.PlacerMarqueur(); 
                        break;
                }
                partie.Affichage();
                
                (bool estFini, string gagnant) = partie.Victoire();

                // 2. Si la partie est finie
                if (estFini)
                {
                    // On se place sous la grille pour écrire proprement
                    Console.SetCursorPosition(0, 17);

                    if (gagnant == "Nul")
                    {
                        Console.WriteLine("🛑 MATCH NUL ! Personne n'a gagné.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine($"🎉 BRAVO ! Le joueur {gagnant} a gagné !");
                        Console.ReadKey();
                    }
                    break; 
                }
            }
            
            //Console.ReadKey();
        }
    }

    public class Game
    {
        // Q14 : Les propriétés
        public int CurseurX { get; set; }
        public int CurseurY { get; set; }
        public int DepartGrille { get; set; }
        public string[] Data { get; set; }
        public string MarqueurActif { get; set; }

        public Game(int departGrille)
        {
            this.DepartGrille = departGrille;
            CurseurX = 1;
            CurseurY = 1;
            
            Data = new string[9]; 
            
            MarqueurActif = "X";
        }
        
        public void Affichage()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            Console.WriteLine("--- MORPION SIO ---\n");

            string haut = "┌─────────┬─────────┬─────────┐";
            string separateur = "├─────────┼─────────┼─────────┤";
            string bas = "└─────────┴─────────┴─────────┘";
            string vide = "│         │         │         │";

            Console.WriteLine(haut);
            Console.WriteLine(vide);
            Console.WriteLine(vide);
            Console.WriteLine(vide);

            Console.WriteLine(separateur);

            Console.WriteLine(vide);
            Console.WriteLine(vide);
            Console.WriteLine(vide);

            Console.WriteLine(separateur);

            Console.WriteLine(vide);
            Console.WriteLine(vide);
            Console.WriteLine(vide);

            Console.WriteLine(bas);
            
            AffichageCurseur();
            AffichageMarqueur();
            
            Console.SetCursorPosition(0, 15);
        }

        private void AffichageCurseur()
        {
            int x = 1 + (CurseurX * 10);
            int y = DepartGrille + (CurseurY * 4);

            Console.BackgroundColor = ConsoleColor.Green;

            Console.SetCursorPosition(x, y);
            Console.Write("         ");

            Console.SetCursorPosition(x, y + 1);
            Console.Write("         ");

            Console.SetCursorPosition(x, y + 2);
            Console.Write("         ");

            Console.BackgroundColor = ConsoleColor.Black;
        }
        
        public void DeplacerGauche()
        {
            if (CurseurX > 0) CurseurX--;
        }

        public void DeplacerDroite()
        {
            if (CurseurX < 2) CurseurX++;
        }

        public void DeplacerHaut()
        {
            if (CurseurY > 0) CurseurY--;
        }

        public void DeplacerBas()
        {
            if (CurseurY < 2) CurseurY++;
        }
        
        public void AffichageMarqueur()
        {
            for (int i = 0; i < 9; i++)
            {
                if (Data[i] != null)
                {
                    int col = i % 3; // Reste de la division par 3
                    int lig = i / 3; // Résultat entier de la division
                    
                    int x = 1 + (col * 10) + 4;
                    
                    int y = DepartGrille + (lig * 4) + 1;

                    // 3. Affichage
                    Console.SetCursorPosition(x, y);
                    Console.Write(Data[i]);
                }
            }
        }
        
        public void PlacerMarqueur()
        {
            // 1. Calcul de l'index dans le tableau (0 à 8)
            int index = CurseurX + (CurseurY * 3);

            // Q32 : Vérification que la case est vide (null)
            // On ne pose le pion que si la place est libre !
            if (Data[index] == null)
            {
                // Q31 : On enregistre le symbole (X ou O) dans la mémoire
                Data[index] = MarqueurActif;

                // Q33 : On change de joueur (Tour par tour)
                // Si c'était X, ça devient O. Sinon, ça devient X.
                MarqueurActif = (MarqueurActif == "X") ? "O" : "X";
            }
        }
        
        // Q40 : On change "bool" par "(bool, string)"
// Le bool = Est-ce que le jeu est fini ?
// Le string = Qui est le gagnant ? ("X", "O" ou "Nul")
        public (bool, string) Victoire()
        {
            // --- 1. EST-CE QUE X A GAGNÉ ? ---
            if (Data[0] == "X" && Data[1] == "X" && Data[2] == "X") return (true, "X");
            if (Data[3] == "X" && Data[4] == "X" && Data[5] == "X") return (true, "X");
            if (Data[6] == "X" && Data[7] == "X" && Data[8] == "X") return (true, "X");
            if (Data[0] == "X" && Data[3] == "X" && Data[6] == "X") return (true, "X");
            if (Data[1] == "X" && Data[4] == "X" && Data[7] == "X") return (true, "X");
            if (Data[2] == "X" && Data[5] == "X" && Data[8] == "X") return (true, "X");
            if (Data[0] == "X" && Data[4] == "X" && Data[8] == "X") return (true, "X");
            if (Data[2] == "X" && Data[4] == "X" && Data[6] == "X") return (true, "X");

            // --- 2. EST-CE QUE O A GAGNÉ ? ---
            if (Data[0] == "O" && Data[1] == "O" && Data[2] == "O") return (true, "O");
            if (Data[3] == "O" && Data[4] == "O" && Data[5] == "O") return (true, "O");
            if (Data[6] == "O" && Data[7] == "O" && Data[8] == "O") return (true, "O");
            if (Data[0] == "O" && Data[3] == "O" && Data[6] == "O") return (true, "O");
            if (Data[1] == "O" && Data[4] == "O" && Data[7] == "O") return (true, "O");
            if (Data[2] == "O" && Data[5] == "O" && Data[8] == "O") return (true, "O");
            if (Data[0] == "O" && Data[4] == "O" && Data[8] == "O") return (true, "O");
            if (Data[2] == "O" && Data[4] == "O" && Data[6] == "O") return (true, "O");

            // --- 3. TEST MATCH NUL ---
            bool grillePleine = true;
            for (int i = 0; i < 9; i++)
            {
                if (Data[i] == null)
                {
                    grillePleine = false;
                    break;
                }
            }

            if (grillePleine)
            {
                // Jeu fini (true), mais gagnant "Nul"
                return (true, "Nul");
            }

            // --- 4. JEU EN COURS ---
            // Jeu pas fini (false), pas de gagnant (null ou "")
            return (false, "");
        }
    }
}