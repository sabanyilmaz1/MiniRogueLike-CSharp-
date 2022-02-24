using System;
using System.Collections.Generic;

namespace projetZombie
{
    class Partie
    {
        public static ConsoleKeyInfo Menu()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\nMenu");
            Console.WriteLine("- Lire les regles (Touche ->)");
            Console.WriteLine("- Jouer (Touche <--)");
            Console.WriteLine("- Quitter (Touche Entrer)");
            Console.WriteLine("Toucher la touche de clavier en fonction de votre choix");
            ConsoleKeyInfo toucheMenu = Console.ReadKey();
            Console.ResetColor();
            return toucheMenu;
        }

        public static void Regle()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n**** Les regles ****");
            Console.WriteLine("- Le but du jeu est de reussir à traverser la map tout en tuant les zombies et atteindre la petite fente tout à droite et en meme temps avec le plus gros score");
            Console.WriteLine("- Il y a trois type de zombies : ");
            Console.WriteLine("  --> R : Zombie rapide ( se deplace de deux cases en deux cases )");
            Console.WriteLine("  --> L : Zombie lent ( se deplace d'une case tous les deux tours )");
            Console.WriteLine("  --> D : Zombie diagonale ( se deplace d'une case en diagonale )");
            Console.WriteLine("- On y trouve aussi plusieurs items dans la map");
            Console.WriteLine("  --> N : Nourriture");
            Console.WriteLine("  --> K : Kits de soins ( augmente de 1 les points de vie du perso )");
            Console.WriteLine("  --> F,M, : Les armes : fusil , machette)");
            Console.WriteLine("- Le perso meurt de deux facons : ");
            Console.WriteLine("  --> Si le perso ne va pas sur une case N au bout de 15 tours, il meurt de faim ");
            Console.WriteLine("  --> Si le perso a son point de vie egale à 0, il meurt");
            Console.WriteLine("- Le perso perd des points de vie si un zombie est pres de lui ( une case autour de lui)");
            Console.WriteLine("- Systeme de Points");
            Console.WriteLine("  --> 1000 points si le perso arrive à aller sur le petite fente");
            Console.WriteLine("  --> 200 points si le perso tue un zombie rapide");
            Console.WriteLine("  --> 100 points si le perso tue un zombie lent ou diagonale");
            Console.ResetColor();
        }




        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("========================== ZOMBIE SURVIVOR ==========================");
            Console.WriteLine("---------------------------------------------------------------------");
            Console.ResetColor();

            bool jeuQuitte = false;
            
            while (jeuQuitte==false)
            {
                ConsoleKeyInfo choixMenu = Menu();
                if (choixMenu.Key == ConsoleKey.RightArrow)
                {
                    Regle();
                }
                else if (choixMenu.Key == ConsoleKey.LeftArrow)
                {
                    Personnage lePerso = new Personnage();
                    Monde leMonde = new Monde();
                    Inventaire monInventaire = new Inventaire();

                    leMonde.CreationMonde();
                    
                    leMonde.ajoutePersoDansMonde(lePerso);                    
                    leMonde.AjouteZombieDansMonde(leMonde);
                    leMonde.ajouteItemsDansMonde(leMonde);

                    List<Zombie> leszombie = leMonde.getListZombie();


                    leMonde.AffichageMonde();
                    leMonde.AffichageInventaire(monInventaire);
                    lePerso.AffichagePerso(leMonde);

                    int nombreDeTours = 1;
                    bool mort = lePerso.estMort(leMonde);
                    bool gagne = lePerso.aGagne(leMonde);

                    while (mort == false  && gagne == false )
                    {
                        lePerso.Action(leMonde, monInventaire);
                        for (int z = 0; z < leszombie.Count; z++)
                        {
                            leszombie[z].DeplaceZombie(nombreDeTours, leMonde);
                            leszombie[z].ZombieEstMort(leMonde, leszombie[z]);

                        }

                        lePerso.estTouche(leMonde);
                        leMonde.AffichageMonde();
                        //lePerso.AffichagePerso(leMonde);
                        leMonde.AffichageInventaire(monInventaire);
                        int faimAvant = lePerso.getFaim();
                        lePerso.setFaim(faimAvant + 1);
                        nombreDeTours++;
                        gagne = lePerso.aGagne(leMonde);
                        mort = lePerso.estMort(leMonde);                       
                        lePerso.AffichagePerso(leMonde);

                    }
                }
                else if (choixMenu.Key == ConsoleKey.Enter)
                {
                    jeuQuitte = true;
                }
                
            }
        }
    }
}
