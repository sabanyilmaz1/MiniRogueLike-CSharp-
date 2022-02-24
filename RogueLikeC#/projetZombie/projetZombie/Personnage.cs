using System;
using System.Collections.Generic;

namespace projetZombie
{
     public class Personnage
        {
        protected int _nbPointVie;
        protected int _posLDepart;
        protected int _posCDepart;
        protected int _faim;
        
        
        

        public Personnage ()
        {
            _posLDepart = 5;
            _posCDepart = 0;
            _nbPointVie = 10;
            _faim = 0;
            
            

        }
        public int getPointVie()
        {
            return _nbPointVie;
        }

        public void setPointVie(int f)
        {
            _nbPointVie = f;
        }
        public int getFaim()
        {
            return _faim;
        }
        public void setFaim(int f)
        {
            _faim = f;
        }
        public int getLignePerso()
        {
            return _posLDepart;
        }
        public int getColonnePerso()
        {
            return _posCDepart;
        }

        public bool estMort(Monde m)
        {
            bool estMort = false;
            if (_nbPointVie<=0)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("**** Vous etes mort !!! ****");
                Console.WriteLine("**** La partie est finie ****");
                Console.ResetColor();
                estMort = true;
            }
            if (_faim==16)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("**** Vous etes mort de faim !!! ****");
                Console.WriteLine("**** La partie est finie ****");
                Console.ResetColor();
                estMort = true;
            }
            return estMort;
        }

        public bool aGagne(Monde m)
        {
            bool aGagne = false;
            string[,] terrain = m.GetTerrain();

            if (terrain[5,21]=="O")
            {
                m.Score(1000);
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("**** Vous avez gagné !!! ****");
                Console.WriteLine("**** La partie est finie ****");
                Console.ResetColor();
                aGagne = true;
            }
            return aGagne;
        }

        public void estTouche(Monde m) // le perso perd un point de vie si il y a un zombie dans une case voisines
        {
            int colonnePerso = 0;
            int lignePerso = 0;
            string[,] terrain = m.GetTerrain();

            // Recuperation de la position du perso

            for (int i = 0; i < m.getNbLigne(); i++)
            {
                for (int j = 0; j < m.getNbColonne(); j++)
                {
                    if (terrain[i, j] == "O")
                    {
                        colonnePerso = j;
                        lignePerso = i;
                    }
                }

            }
            // on etudie tous les cas possible par rapport à la position du perso ( 9 cas )

            // cas 1 : le perso est sur le coin en haut à gauche
            if (lignePerso==0 && colonnePerso==0)
            {
                // on a donc 3 cases voisins
                string voisin1 = terrain[lignePerso, colonnePerso + 1];
                string voisin2 = terrain[lignePerso+1, colonnePerso + 1];
                string voisin3 = terrain[lignePerso+1, colonnePerso];

                if (voisin1 == "R" || voisin1 == "L" || voisin1 == "D")
                    _nbPointVie--;
                if (voisin2 == "R" || voisin2 == "L" || voisin2 == "D")
                    _nbPointVie--;
                if (voisin3 == "R" || voisin3 == "L" || voisin3 == "D")
                    _nbPointVie--;
            }

            // cas 2 : le perso est sur le coin en bas à gauche
            else if (lignePerso==10 && colonnePerso==0)
            {
                // on a donc 3 cases voisines
                string voisin1 = terrain[lignePerso-1, colonnePerso];
                string voisin2 = terrain[lignePerso-1, colonnePerso + 1];
                string voisin3 = terrain[lignePerso, colonnePerso+1];

                if (voisin1 == "R" || voisin1 == "L" || voisin1 == "D")
                    _nbPointVie--;
                if (voisin2 == "R" || voisin2 == "L" || voisin2 == "D")
                    _nbPointVie--;
                if (voisin3 == "R" || voisin3 == "L" || voisin3 == "D")
                    _nbPointVie--;
            }

            // cas 3 : le perso est sur le coin en haut à droite
            else if (lignePerso==0 && colonnePerso==20)
            {
                // on a donc 3 cases voisines
                string voisin1 = terrain[lignePerso, colonnePerso-1];
                string voisin2 = terrain[lignePerso +1, colonnePerso - 1];
                string voisin3 = terrain[lignePerso+1, colonnePerso];

                if (voisin1 == "R" || voisin1 == "L" || voisin1 == "D")
                    _nbPointVie--;
                if (voisin2 == "R" || voisin2 == "L" || voisin2 == "D")
                    _nbPointVie--;
                if (voisin3 == "R" || voisin3 == "L" || voisin3 == "D")
                    _nbPointVie--;
            }

            // cas 4 : le perso est sur le coin en bas à droite
            else if (lignePerso == 10 && colonnePerso == 20)
            {
                // on a donc 3 cases voisines
                string voisin1 = terrain[lignePerso-1, colonnePerso - 1];
                string voisin2 = terrain[lignePerso -1, colonnePerso];
                string voisin3 = terrain[lignePerso, colonnePerso-1];

                if (voisin1 == "R" || voisin1 == "L" || voisin1 == "D")
                    _nbPointVie--;
                if (voisin2 == "R" || voisin2 == "L" || voisin2 == "D")
                    _nbPointVie--;
                if (voisin3 == "R" || voisin3 == "L" || voisin3 == "D")
                    _nbPointVie--;
            }

            // cas 5 : le perso est sur le coté verticale à gauche
            else if (lignePerso>=1 && lignePerso<=9 && colonnePerso==0)
            {
                // on a 5 cases voisines
                string voisin1 = terrain[lignePerso - 1, colonnePerso];
                string voisin2 = terrain[lignePerso - 1, colonnePerso+1];
                string voisin3 = terrain[lignePerso, colonnePerso + 1];
                string voisin4 = terrain[lignePerso+1, colonnePerso + 1];
                string voisin5 = terrain[lignePerso+1, colonnePerso];

                if (voisin1 == "R" || voisin1 == "L" || voisin1 == "D")
                    _nbPointVie--;
                if (voisin2 == "R" || voisin2 == "L" || voisin2 == "D")
                    _nbPointVie--;
                if (voisin3 == "R" || voisin3 == "L" || voisin3 == "D")
                    _nbPointVie--;
                if (voisin4 == "R" || voisin4 == "L" || voisin4 == "D")
                    _nbPointVie--;
                if (voisin5 == "R" || voisin5 == "L" || voisin5 == "D")
                    _nbPointVie--;
            }

            // cas 6 : le perso est sur le coté verticale à droite
            else if (lignePerso >= 1 && lignePerso <= 9 && colonnePerso == 20)
            {
                // on a 5 cases voisines
                string voisin1 = terrain[lignePerso - 1, colonnePerso];
                string voisin2 = terrain[lignePerso - 1, colonnePerso - 1];
                string voisin3 = terrain[lignePerso, colonnePerso - 1];
                string voisin4 = terrain[lignePerso + 1, colonnePerso - 1];
                string voisin5 = terrain[lignePerso + 1, colonnePerso];

                if (voisin1 == "R" || voisin1 == "L" || voisin1 == "D")
                    _nbPointVie--;
                if (voisin2 == "R" || voisin2 == "L" || voisin2 == "D")
                    _nbPointVie--;
                if (voisin3 == "R" || voisin3 == "L" || voisin3 == "D")
                    _nbPointVie--;
                if (voisin4 == "R" || voisin4 == "L" || voisin4 == "D")
                    _nbPointVie--;
                if (voisin5 == "R" || voisin5 == "L" || voisin5 == "D")
                    _nbPointVie--;
            }

            //cas 7 : le perso est sur le coté horizontale en haut
            else if (lignePerso==0 && colonnePerso>=1 && colonnePerso<=19)
            {
                // on a 5 cases voisines
                string voisin1 = terrain[lignePerso, colonnePerso-1];
                string voisin2 = terrain[lignePerso + 1, colonnePerso - 1];
                string voisin3 = terrain[lignePerso+1, colonnePerso];
                string voisin4 = terrain[lignePerso + 1, colonnePerso + 1];
                string voisin5 = terrain[lignePerso , colonnePerso+1];

                if (voisin1 == "R" || voisin1 == "L" || voisin1 == "D")
                    _nbPointVie--;
                if (voisin2 == "R" || voisin2 == "L" || voisin2 == "D")
                    _nbPointVie--;
                if (voisin3 == "R" || voisin3 == "L" || voisin3 == "D")
                    _nbPointVie--;
                if (voisin4 == "R" || voisin4 == "L" || voisin4 == "D")
                    _nbPointVie--;
                if (voisin5 == "R" || voisin5 == "L" || voisin5 == "D")
                    _nbPointVie--;
            }

            //cas 8 : le perso est sur le coté horizontale en bas
            else if (lignePerso == 10 && colonnePerso >= 1 && colonnePerso <= 19)
            {
                // on a 5 cases voisines
                string voisin1 = terrain[lignePerso, colonnePerso - 1];
                string voisin2 = terrain[lignePerso - 1, colonnePerso - 1];
                string voisin3 = terrain[lignePerso - 1, colonnePerso];
                string voisin4 = terrain[lignePerso -1, colonnePerso + 1];
                string voisin5 = terrain[lignePerso, colonnePerso + 1];

                if (voisin1 == "R" || voisin1 == "L" || voisin1 == "D")
                    _nbPointVie--;
                if (voisin2 == "R" || voisin2 == "L" || voisin2 == "D")
                    _nbPointVie--;
                if (voisin3 == "R" || voisin3 == "L" || voisin3 == "D")
                    _nbPointVie--;
                if (voisin4 == "R" || voisin4 == "L" || voisin4 == "D")
                    _nbPointVie--;
                if (voisin5 == "R" || voisin5 == "L" || voisin5 == "D")
                    _nbPointVie--;
            }

            // cas 9 : le perso est sur une case qui n'est pas un coté ou un coin
            else if (lignePerso<=10 && lignePerso<=9 && colonnePerso>=1 && colonnePerso<=20)
            {
                string voisin1 = terrain[lignePerso-1, colonnePerso - 1];
                string voisin2 = terrain[lignePerso, colonnePerso - 1];
                string voisin3 = terrain[lignePerso + 1, colonnePerso-1];
                string voisin4 = terrain[lignePerso + 1, colonnePerso];
                string voisin5 = terrain[lignePerso+1, colonnePerso + 1];
                string voisin6 = terrain[lignePerso, colonnePerso+1];
                string voisin7 = terrain[lignePerso - 1, colonnePerso + 1];
                string voisin8 = terrain[lignePerso-1, colonnePerso];

                if (voisin1 == "R" || voisin1 == "L" || voisin1 == "D")
                    _nbPointVie--;
                if (voisin2 == "R" || voisin2 == "L" || voisin2 == "D")
                    _nbPointVie--;
                if (voisin3 == "R" || voisin3 == "L" || voisin3 == "D")
                    _nbPointVie--;
                if (voisin4 == "R" || voisin4 == "L" || voisin4 == "D")
                    _nbPointVie--;
                if (voisin5 == "R" || voisin5 == "L" || voisin5 == "D")
                    _nbPointVie--;
                if (voisin6 == "R" || voisin6 == "L" || voisin6 == "D")
                    _nbPointVie--;
                if (voisin7 == "R" || voisin7 == "L" || voisin7 == "D")
                    _nbPointVie--;
                if (voisin8 == "R" || voisin8 == "L" || voisin8 == "D")
                    _nbPointVie--;
            }

        }

        
        public void Action(Monde m,Inventaire inventaire)
        {
            // Recuperation de l'inventaire et du monde

            List<Item> ItemPerso = inventaire.getListeItem(); 
            int colonnePerso = 0;
            int lignePerso = 0;
            string[,] terrain = m.GetTerrain();

            // Recuperation de la position du perso

            for (int i = 0; i < m.getNbLigne(); i++)
            {
                for (int j = 0; j < m.getNbColonne(); j++)
                {
                    if (terrain[i, j] == "O")
                    {
                        colonnePerso = j;
                        lignePerso = i;
                    }
                }
                
            }

            // Demande de touche à l'utilisateur
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine ("---> Appuyer sur une touche directionelle ( pour se deplacer) ou espace (pour tirer) \n");
            ConsoleKeyInfo touche = Console.ReadKey();
            Console.ResetColor();

            // Si erreur de touche , on redemande

            while ((touche.Key != ConsoleKey.UpArrow) && (touche.Key != ConsoleKey.DownArrow) && (touche.Key != ConsoleKey.LeftArrow)
                && (touche.Key != ConsoleKey.RightArrow) &&  (touche.Key != ConsoleKey.Spacebar) && (touche.Key != ConsoleKey.I))
            {
                Console.WriteLine(" --->Vous n'avez pas tapé une bonne commande. Appuyer sur une touche directionnelle");
                touche = Console.ReadKey();
            }


            // Si le joueur appuie sur la fleche du haut

            if (touche.Key == ConsoleKey.UpArrow)
            {
                    if (lignePerso==0)
                        {
                            // Impossible de bouger
                        }
                    // Si la case est prise par un zombie

                    else if (m.GetTerrain()[lignePerso-1, colonnePerso] == "R" || m.GetTerrain()[lignePerso-1, colonnePerso] == "L"
                        || m.GetTerrain()[lignePerso-1, colonnePerso] == "D" || m.GetTerrain()[lignePerso - 1, colonnePerso] == "*")
                        {
                            // Impossible de bouger
                        }

                    // Si la case est prise par un item

                    else if (m.GetTerrain()[lignePerso - 1, colonnePerso] == "N" || m.GetTerrain()[lignePerso - 1, colonnePerso] == "S"
                        || m.GetTerrain()[lignePerso - 1, colonnePerso] == "F" || m.GetTerrain()[lignePerso - 1, colonnePerso] == "G"
                        || m.GetTerrain()[lignePerso - 1, colonnePerso] == "M")

                    {
                        // Si la future case est un item : nourriture

                        if (m.GetTerrain()[lignePerso - 1, colonnePerso] == "N")
                        {
                            Manger();
                            m.GetTerrain()[lignePerso - 1, colonnePerso] = "O";
                            m.GetTerrain()[lignePerso, colonnePerso] = "-";
                                
                        }

                        // Si c'est un kit de soins

                        else if (m.GetTerrain()[lignePerso - 1, colonnePerso] == "S")
                        {
                            AjoutePV();
                            m.GetTerrain()[lignePerso - 1, colonnePerso] = "O";
                            m.GetTerrain()[lignePerso, colonnePerso] = "-";
                        }
                        else if (m.GetTerrain()[lignePerso - 1, colonnePerso] == "F")
                        {
                            Fusil unItem = new Fusil(m);
                            // si le nb de place !=0
                            if (inventaire.getNbPlace() != 0)
                            {
                                inventaire.RecupItem(unItem);
                                m.GetTerrain()[lignePerso - 1, colonnePerso] = "O";
                                m.GetTerrain()[lignePerso, colonnePerso] = "-";
                            }
                            else
                            {
                                string sigleAvant = inventaire.EchangeItem(unItem);
                                m.GetTerrain()[lignePerso - 1, colonnePerso] = "O";
                                m.GetTerrain()[lignePerso, colonnePerso] = sigleAvant;
                            }

                        }
                        else if (m.GetTerrain()[lignePerso - 1, colonnePerso] == "M")
                        {
                            Machette unItem = new Machette(m);
                            // si le nb de place !=0
                            if (inventaire.getNbPlace() != 0)
                            {
                                inventaire.RecupItem(unItem);
                                m.GetTerrain()[lignePerso - 1, colonnePerso] = "O";
                                m.GetTerrain()[lignePerso, colonnePerso] = "-";
                            }
                            else
                            {
                                string sigleAvant = inventaire.EchangeItem(unItem);
                                m.GetTerrain()[lignePerso - 1, colonnePerso] = "O";
                                m.GetTerrain()[lignePerso, colonnePerso] = sigleAvant;
                            }


                        }
                            
                    }
                    else
                    {
                        m.GetTerrain()[lignePerso, colonnePerso] = "-";
                        lignePerso--;
                        m.GetTerrain()[lignePerso, colonnePerso] = "O";
                    }
                }
            

            else if (touche.Key == ConsoleKey.DownArrow)
            {
                if (lignePerso==10)
                {
                    // Impossible de bouger
                }
               

                else if (m.GetTerrain()[lignePerso + 1, colonnePerso] == "R" || m.GetTerrain()[lignePerso + 1, colonnePerso] == "L"
                    || m.GetTerrain()[lignePerso + 1, colonnePerso] == "D" || m.GetTerrain()[lignePerso + 1, colonnePerso] == "*")
                {
                    //Impossible de bouger
                }

                else if (m.GetTerrain()[lignePerso + 1, colonnePerso] == "N" || m.GetTerrain()[lignePerso + 1, colonnePerso] == "S"
                    || m.GetTerrain()[lignePerso + 1, colonnePerso] == "F" || m.GetTerrain()[lignePerso + 1, colonnePerso] == "M"
                    || m.GetTerrain()[lignePerso + 1, colonnePerso] == "G")

                {
                    if (m.GetTerrain()[lignePerso + 1, colonnePerso] == "N")
                    {
                                                   
                        Manger();
                        m.GetTerrain()[lignePerso + 1, colonnePerso] = "O";
                        m.GetTerrain()[lignePerso, colonnePerso] = "-";                                                  
                    }
                    else if (m.GetTerrain()[lignePerso + 1, colonnePerso] == "S")
                    {
                                             
                        AjoutePV();
                        m.GetTerrain()[lignePerso + 1, colonnePerso] = "O";
                        m.GetTerrain()[lignePerso, colonnePerso] = "-";                            
                    }
                    else if (m.GetTerrain()[lignePerso + 1, colonnePerso] == "F")
                    {
                        Fusil unItem = new Fusil(m);
                        if (inventaire.getNbPlace() != 0)
                        {
                            inventaire.RecupItem(unItem);
                            m.GetTerrain()[lignePerso + 1, colonnePerso] = "O";
                            m.GetTerrain()[lignePerso, colonnePerso] = "-";
                        }
                        else
                        {
                            string sigleAvant = inventaire.EchangeItem(unItem);
                            m.GetTerrain()[lignePerso + 1, colonnePerso] = "O";
                            m.GetTerrain()[lignePerso, colonnePerso] = sigleAvant;
                        }

                    }
                    else if (m.GetTerrain()[lignePerso + 1, colonnePerso] == "M")
                    {
                        Machette unItem = new Machette(m);
                        if (inventaire.getNbPlace() != 0)
                        {
                            inventaire.RecupItem(unItem);
                            m.GetTerrain()[lignePerso + 1, colonnePerso] = "O";
                            m.GetTerrain()[lignePerso, colonnePerso] = "-";
                        }
                        else
                        {
                            string sigleAvant = inventaire.EchangeItem(unItem);
                            m.GetTerrain()[lignePerso + 1, colonnePerso] = "O";
                            m.GetTerrain()[lignePerso, colonnePerso] = sigleAvant;
                        }

                    }
                }
                else
                {
                    m.GetTerrain()[lignePerso, colonnePerso] = "-";
                    lignePerso++;
                    m.GetTerrain()[lignePerso, colonnePerso] = "O";
                }                
            }
            else if (touche.Key == ConsoleKey.RightArrow)
            {
                if (lignePerso==5 && colonnePerso==21)
                {
                    //Impossible de bouger
                }
                else if (m.GetTerrain()[lignePerso, colonnePerso+1] == "R" || m.GetTerrain()[lignePerso, colonnePerso+1] == "L"
                    || m.GetTerrain()[lignePerso, colonnePerso+1] == "D" || m.GetTerrain()[lignePerso, colonnePerso+1] == "*")
                {
                    //Impossible de bouger
                }

                else if (m.GetTerrain()[lignePerso, colonnePerso+1] == "N" || m.GetTerrain()[lignePerso , colonnePerso+1] == "S"
                        || m.GetTerrain()[lignePerso , colonnePerso+1] == "F" || m.GetTerrain()[lignePerso, colonnePerso + 1] == "M"
                        || m.GetTerrain()[lignePerso, colonnePerso + 1] == "G")

                {
                    if (m.GetTerrain()[lignePerso, colonnePerso+1] == "N")
                    {                        
                        Manger();
                        m.GetTerrain()[lignePerso, colonnePerso + 1] = "O";
                        m.GetTerrain()[lignePerso, colonnePerso] = "-";
                    }
                    else if (m.GetTerrain()[lignePerso, colonnePerso+1] == "S")
                    {
                                                  
                        AjoutePV();
                        m.GetTerrain()[lignePerso, colonnePerso + 1] = "O";
                        m.GetTerrain()[lignePerso, colonnePerso] = "-";
                            
                    }
                    else if (m.GetTerrain()[lignePerso, colonnePerso + 1] == "F")
                    {
                        Fusil unItem = new Fusil(m);
                        if (inventaire.getNbPlace() != 0)
                        {
                            inventaire.RecupItem(unItem);
                            m.GetTerrain()[lignePerso, colonnePerso + 1] = "O";
                            m.GetTerrain()[lignePerso, colonnePerso] = "-";
                        }
                        else
                        {
                            string sigleAvant = inventaire.EchangeItem(unItem);
                            m.GetTerrain()[lignePerso, colonnePerso + 1] = "O";
                            m.GetTerrain()[lignePerso, colonnePerso] = sigleAvant;
                        }

                    }
                    else if (m.GetTerrain()[lignePerso, colonnePerso + 1] == "M")
                    {
                        Machette unItem = new Machette(m);
                        if (inventaire.getNbPlace() != 0)
                        {
                            inventaire.RecupItem(unItem);
                            m.GetTerrain()[lignePerso, colonnePerso + 1] = "O";
                            m.GetTerrain()[lignePerso, colonnePerso] = "-";
                        }
                        else
                        {
                            string sigleAvant = inventaire.EchangeItem(unItem);
                            m.GetTerrain()[lignePerso, colonnePerso + 1] = "O";
                            m.GetTerrain()[lignePerso, colonnePerso] = sigleAvant;
                        }

                    }
                       
                }                   
                else
                {
                    m.GetTerrain()[lignePerso, colonnePerso] = "-";
                    colonnePerso++;
                    m.GetTerrain()[lignePerso, colonnePerso] = "O";
                }               
            }
            else if (touche.Key == ConsoleKey.LeftArrow)
            {
                if (colonnePerso == 0)
                {
                    // Impossible de bouger
                }
                else if (m.GetTerrain()[lignePerso, colonnePerso - 1] == "R" || m.GetTerrain()[lignePerso, colonnePerso - 1] == "L"
                    || m.GetTerrain()[lignePerso, colonnePerso - 1] == "D" || m.GetTerrain()[lignePerso, colonnePerso - 1] == "*")
                {
                    //Impossible de bouger
                }
                

                else if (m.GetTerrain()[lignePerso, colonnePerso - 1] == "N" || m.GetTerrain()[lignePerso, colonnePerso - 1] == "S"
                    || m.GetTerrain()[lignePerso, colonnePerso - 1] == "F" || m.GetTerrain()[lignePerso, colonnePerso - 1] == "M"
                    || m.GetTerrain()[lignePerso, colonnePerso - 1] == "G")

                {
                    if (m.GetTerrain()[lignePerso, colonnePerso - 1] == "N")
                    {
                                             
                        Manger();
                        m.GetTerrain()[lignePerso, colonnePerso - 1] = "O";
                        m.GetTerrain()[lignePerso, colonnePerso] = "-";                        
                    }
                    else if (m.GetTerrain()[lignePerso, colonnePerso - 1] == "S")
                    {
                        
                        AjoutePV();
                        m.GetTerrain()[lignePerso, colonnePerso - 1] = "O";
                        m.GetTerrain()[lignePerso, colonnePerso] = "-";                      
                    }
                    else if (m.GetTerrain()[lignePerso, colonnePerso - 1] == "F")
                    {
                        Fusil unItem = new Fusil(m);
                        if (inventaire.getNbPlace() != 0)
                        {
                            inventaire.RecupItem(unItem);
                            m.GetTerrain()[lignePerso, colonnePerso - 1] = "O";
                            m.GetTerrain()[lignePerso, colonnePerso] = "-";
                        }
                        else
                        {
                            string sigleAvant = inventaire.EchangeItem(unItem);
                            m.GetTerrain()[lignePerso, colonnePerso - 1] = "O";
                            m.GetTerrain()[lignePerso, colonnePerso] = sigleAvant;
                        }

                    }
                    else if (m.GetTerrain()[lignePerso, colonnePerso - 1] == "M")
                    {
                        Machette unItem = new Machette(m);
                        if (inventaire.getNbPlace() != 0)
                        {
                            inventaire.RecupItem(unItem);
                            m.GetTerrain()[lignePerso, colonnePerso - 1] = "O";
                            m.GetTerrain()[lignePerso, colonnePerso] = "-";
                        }
                        else
                        {
                            string sigleAvant = inventaire.EchangeItem(unItem);
                            m.GetTerrain()[lignePerso, colonnePerso - 1] = "O";
                            m.GetTerrain()[lignePerso, colonnePerso] = sigleAvant;
                        }

                    }
                }
                else
                {
                    m.GetTerrain()[lignePerso, colonnePerso] = "-";
                    colonnePerso--;
                    m.GetTerrain()[lignePerso, colonnePerso] = "O";
                }

                

            }
            // Pour tirer
            else if (touche.Key==ConsoleKey.Spacebar)
            {
               
                if (ItemPerso.Count==0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n--> ERROR : L'inventaire est vide\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    
                    Console.WriteLine("---> Appuyer sur f (pour tirer avec le fusil");
                    Console.WriteLine("---> Appuyer sur m (pour la machette");
                    Console.WriteLine("---> Appuyer sur a (pour annuler le tir");
                    Console.WriteLine("Touchez la touche souhaité puis entrer pour valider le choix");
                    string choixArme = Console.ReadLine();
                    
                    while (choixArme!="f" && choixArme!="m" && choixArme!="a")
                    {
                        Console.WriteLine("--> Mauvaise touche ( f,m,ou a");
                        choixArme = Console.ReadLine();
                    }
                    Console.ResetColor();

                    string choix = "";

                    if (choixArme == "f")
                        choix = "fusil";
                    else if (choixArme == "m")
                        choix = "machette";
                    else if (choixArme == "f")
                        choix = "Annulee";


                    foreach (Item it in ItemPerso)
                    {
                        if (it.getNom() == choix)
                        {
                            if (choix == "fusil")
                            {
                                Fusil unFusil = new Fusil(m);
                                unFusil.Tirer(m);
                            }
                            else if (choix=="machette")
                            {
                                Machette uneMachette = new Machette(m);
                                uneMachette.Tirer(m);
                            }
                            
                        }
                        
                    }   
                    
                }
                
            }
            
        }
        public void Manger()
        {
            
              _faim = 0;
                  
        }


        public void AjoutePV()
        {
            int vie = getPointVie();
            if (vie < 5)
            {
                setPointVie(vie + 1);
            }
            else
            {
                Console.WriteLine(" vous avez déjà le maximum de points de vie possible !");
            }
        }

        

        public void AffichagePerso(Monde m)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("============ Perso =================\n\n");
            Console.WriteLine("--> Point de Vie : " + _nbPointVie);
            Console.WriteLine("\n--> Compteur de faim : " + _faim);
            Console.WriteLine("\n--> Score : "+m.getScore() );
            Console.WriteLine("\n\n====================================\n");
            Console.ResetColor();
        }





    }
}
