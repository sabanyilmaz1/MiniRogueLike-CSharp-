using System;
using System.Collections.Generic;

namespace projetZombie
{
    public class Monde
    {
        protected int _nbl, _nbc;
        protected string[,] _terrain;
        protected List<Zombie> _lesZombie;
        protected List<Item> _lesItems;
        protected Personnage _lePerso;
        protected int _score;

        public Monde()
        {
            _nbc = 22;
            _nbl = 11;
            _terrain = new string[_nbl,_nbc];
            _lesZombie = new List<Zombie>();
            _lesItems = new List<Item>();
            _score = 0;
        }

        public void CreationMonde()
        {
            for (int i = 0; i < _nbl; i++)
            {
                for (int j=0;j<_nbc;j++)
                {
                    
                    if (j==_nbc-1)
                    {
                        if (i==5)
                        {
                            _terrain[i, j] = "-";
                        }
                        else
                        {
                            _terrain[i, j] = "*";
                        }
                    }
                    else if (j==4)
                    {
                        if (i<=3)
                        {
                            _terrain[i, j] = "*";
                        }
                        else
                        {
                            _terrain[i, j] = "-";
                        }
                    }
                    else if (i==3)
                    {
                        if (j>=5 && j<=7)
                            _terrain[i, j] = "*";
                        else if (j==13)
                            _terrain[i, j] = "*";
                        else
                            _terrain[i, j] = "-";
                    }
                    else if (j==13)
                    {
                        if (i<=5)
                            _terrain[i, j] = "*";
                        else
                            _terrain[i, j] = "-";
                    }
                    else if (i==2)
                    {
                        if (j>=17 && j<=21)
                            _terrain[i, j] = "*";
                        else
                            _terrain[i, j] = "-";
                    }
                    else if (j==16)
                    {
                        if (i>=6 && i<=10)
                            _terrain[i, j] = "*";
                        else
                            _terrain[i, j] = "-";
                    }
                    else if (j==9)
                    {
                        if (i>=6 && i<=9)
                            _terrain[i, j] = "*";
                        else
                            _terrain[i, j] = "-";
                    }
                    else if (j == 6)
                    {
                        if (i >= 6 && i <= 10)
                            _terrain[i, j] = "*";
                        else
                            _terrain[i, j] = "-";
                    }
                    else
                    {
                        _terrain[i, j] = "-";
                    }
                    _terrain[6, 7] = "*";
                    _terrain[6, 8] = "*";
                }
            }
        }

        public void AjouteZombie(Zombie z)
        {
            _lesZombie.Add(z);
        }

        

        public void AjouteZombieDansMonde(Monde m)
        {
            int nbMaxZombie = 1;
            Random r = new Random();
            int choix = r.Next(1, 4);
            while (nbMaxZombie<10) 
            {
                if (choix==1)
                {
                    Zombie_rapide zombieRapide = new Zombie_rapide(4,m);
                    AjouteZombie(zombieRapide);
                    int lZombie = zombieRapide.getLigneZombie();
                    int cZombie = zombieRapide.getColonneZombie();
                    _terrain[lZombie, cZombie] = "R";
                }
                
                else if (choix == 2)
                {
                    Zombie_lent zombieLent = new Zombie_lent(6,m);
                    AjouteZombie(zombieLent);
                    int lZombie = zombieLent.getLigneZombie();
                    int cZombie = zombieLent.getColonneZombie();
                    
                    _terrain[lZombie, cZombie] = "L";
                }
                
                else if (choix == 3)
                {
                    Zombie_diagonale zombieDiag = new Zombie_diagonale(5,m);
                    AjouteZombie(zombieDiag);
                    int lZombie = zombieDiag.getLigneZombie();
                    int cZombie = zombieDiag.getColonneZombie();

                    _terrain[lZombie, cZombie] = "D";
                }
                
                nbMaxZombie++;
                choix = r.Next(1, 4);
                
                 
            }
            
        }

        

        public void ajouteItemsDansMonde(Monde m)
        {
            int nbMaxItems = 1;
            Random r = new Random();
            Random r1 = new Random();
            int choix = r.Next(1, 12);
            while (nbMaxItems<20)
            {
                if (choix == 1 || choix == 4 || choix==7)
                {
                    Nourriture unItem = new Nourriture(m);
                    _lesItems.Add(unItem);
                    int lItem = unItem.getLigneItem();
                    int cItem = unItem.getColonneItem();

                    // Cas ou la case est deja utilisé pour un zombie ou un autre item

                    while(_terrain[lItem, cItem] != "-" )
                    {

                        lItem = r1.Next(1, 9);
                        cItem = r1.Next(1, 19);
                    }
                    _terrain[lItem, cItem] = "N";
                }
                else if (choix==2 || choix==5)
                {
                    KitDeSoins unItem = new KitDeSoins(m);
                    _lesItems.Add(unItem);
                    int lItem = unItem.getLigneItem();
                    int cItem = unItem.getColonneItem();

                    // Cas ou la case est deja utilisé pour un zombie ou un autre item

                    while (_terrain[lItem, cItem] != "-")
                    {

                        lItem = r1.Next(1, 9);
                        cItem = r1.Next(1, 19);
                    }
                    _terrain[lItem, cItem] = "S";
                }
                else if (choix==3 || choix==6 || choix==8 || choix==9 || choix==10 || choix==11) 
                {
                    int lItem = 0;
                    int cItem = 0;
                    int choixArme = r.Next(1, 3);
                    if (choixArme == 1)
                    {
                        
                        Fusil unItem = new Fusil(m);
                        _lesItems.Add(unItem);
                        lItem = unItem.getLigneItem();
                         cItem = unItem.getColonneItem();

                        while (_terrain[lItem, cItem] == "N" || _terrain[lItem, cItem] == "S" || _terrain[lItem, cItem] == "F" ||
                        _terrain[lItem, cItem] == "M" || _terrain[lItem, cItem] == "G" || _terrain[lItem, cItem] == "R" ||
                        _terrain[lItem, cItem] == "L" || _terrain[lItem, cItem] == "D")
                        {

                            lItem = r1.Next(1, 9);
                            cItem = r1.Next(1, 19);
                        }
                        _terrain[lItem, cItem] = "F";

                    }
                    else if (choixArme==2)
                    {
                        Machette unItem = new Machette(m);
                        _lesItems.Add(unItem);
                        lItem = unItem.getLigneItem();
                         cItem = unItem.getColonneItem();

                        while (_terrain[lItem, cItem] != "-")
                        {

                            lItem = r1.Next(1, 9);
                            cItem = r1.Next(1, 19);
                        }

                        _terrain[lItem, cItem] = "M";
                    }
                    
                }
                nbMaxItems++;
                choix = r.Next(1, 6);
            }
            
        }
        
        public void ajoutePersoDansMonde(Personnage perso)
        {
            int lperso = perso.getLignePerso();
            int cperso = perso.getColonnePerso();
            _terrain[lperso,cperso] = "O";
        }

        
        

        public void AffichageMonde()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\n========================== Le Monde ============================\n\n");
            Console.ResetColor();
            for (int i = 0; i < _nbl; i++)
            {
                for (int j = 0; j < _nbc; j++)
                {
                    //ch = ch + _terrain[i, j] + "  ";
                    if (_terrain[i,j]=="-")
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(_terrain[i, j] + "  ");
                        Console.ResetColor();
                    }
                    if (_terrain[i,j]=="*")
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(_terrain[i, j] + "  ");
                        Console.ResetColor();
                    }
                    if (_terrain[i,j]=="O")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(_terrain[i, j] + "  ");
                        Console.ResetColor();
                    }
                    if (_terrain[i, j] == "N" || _terrain[i,j]=="S")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(_terrain[i, j] + "  ");
                        Console.ResetColor();
                    }
                    if (_terrain[i, j] == "R" || _terrain[i, j] == "L" || _terrain[i,j]=="D")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(_terrain[i, j] + "  ");
                        Console.ResetColor();
                    }
                    if (_terrain[i, j] == "F" || _terrain[i, j] == "M")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(_terrain[i, j] + "  ");
                        Console.ResetColor();
                    }


                }
                //ch = ch + "\n";
                Console.Write("\n");

            }
            Console.WriteLine("\n");
        }

        public void AffichageInventaire(Inventaire inventaire)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n============ Inventaire ============\n");
            List<Item> ItemPerso = inventaire.getListeItem();
            if (ItemPerso.Count==0)
            {
                Console.WriteLine("--> Aucun item dans l'inventaire\n");
            }
            else
            {
                for (int i=0;i<ItemPerso.Count;i++)
                {
                    Console.WriteLine("-Item "+(i+1)+" : "+ItemPerso[i].getNom()+"\n");
                }
            }
            Console.WriteLine("====================================\n");
            Console.ResetColor();
        }


        public int getScore()
        {
            return _score;
        }

        public void Score(int point)
        {
            _score = _score + point;
        }

        public int getNbLigne()
        {
            return _nbl;
        }

        public int getNbColonne()
        {
            return _nbc;
        }

        public string[,] GetTerrain()
        {
            return _terrain;
        }

        public List<Zombie> getListZombie()
        {
            return _lesZombie;

        }
    }
}
