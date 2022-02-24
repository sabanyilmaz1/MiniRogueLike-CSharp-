using System;
using System.Collections.Generic;

namespace projetZombie
{
    public class Machette : Arme
    {
        public Machette(Monde leMonde) : base (2, 2,leMonde)
        {
            _sigleItem = "M";
            _nom = "machette";
        }

        public override void Tirer(Monde m)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--> Viser à l'aide des touches directionnelles");
            ConsoleKeyInfo toucheViser = Console.ReadKey();
            Console.ResetColor();

            while ((toucheViser.Key != ConsoleKey.UpArrow) && (toucheViser.Key != ConsoleKey.DownArrow) && (toucheViser.Key != ConsoleKey.LeftArrow)
               && (toucheViser.Key != ConsoleKey.RightArrow) && (toucheViser.Key != ConsoleKey.Spacebar) && (toucheViser.Key != ConsoleKey.I))
            {
                Console.WriteLine(" --> Appuyer sur une touche directionnelle");
                toucheViser = Console.ReadKey();
            }

            string[,] terrain = m.GetTerrain();
            List<Zombie> lesZombies = m.getListZombie();

            int colonnePerso = 0;
            int lignePerso = 0;
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

            if (toucheViser.Key == ConsoleKey.UpArrow)
            {
                if (lignePerso - _portee < 0)
                {
                    for (int i = lignePerso; i >= 0; i--)
                    {
                        if ((terrain[i, colonnePerso] == "R") || (terrain[i, colonnePerso] == "L") || (terrain[i, colonnePerso] == "D"))
                        {
                            string zombie = terrain[i, colonnePerso];
                            // trouvons ce zombie dans la liste de zombie
                            int ligneZombie = i;
                            int colonneZombie = colonnePerso;
                            foreach (Zombie zom in lesZombies)
                            {
                                if (zom.getLigneZombie() == ligneZombie && zom.getColonneZombie() == colonneZombie)
                                {
                                    zom.ToucherZombie(_degat);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine(" \n %%% Vous avez touché un zombie %%%\n");
                                    Console.ResetColor();
                                    if (zom.getPdvZombie() < 0)
                                    {
                                        if (zombie == "R")
                                            m.Score(200);
                                        if (zombie == "L" || zombie == "D")
                                            m.Score(100);
                                        Console.ForegroundColor = ConsoleColor.Magenta;
                                        Console.WriteLine(" \n <<< le zombie est mort >>>\n");
                                        Console.ResetColor();
                                        terrain[ligneZombie, colonneZombie] = "-";

                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    for (int i = lignePerso; i > lignePerso - _portee; i--)
                    {
                        if ((terrain[i, colonnePerso] == "R") || (terrain[i, colonnePerso] == "L") || (terrain[i, colonnePerso] == "D"))
                        {
                            string zombie = terrain[i, colonnePerso];
                            // trouvons ce zombie dans la liste de zombie
                            int ligneZombie = i;
                            int colonneZombie = colonnePerso;
                            foreach (Zombie zom in lesZombies)
                            {
                                if (zom.getLigneZombie() == ligneZombie && zom.getColonneZombie() == colonneZombie)
                                {
                                    zom.ToucherZombie(_degat);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine(" \n %%% Vous avez touché un zombie %%%\n");
                                    Console.ResetColor();
                                    if (zom.getPdvZombie() < 0)
                                    {
                                        if (zombie == "R")
                                            m.Score(200);
                                        if (zombie == "L" || zombie == "D")
                                            m.Score(100);
                                        Console.ForegroundColor = ConsoleColor.Magenta;
                                        Console.WriteLine(" \n <<< le zombie est mort >>>\n");
                                        Console.ResetColor();
                                        terrain[ligneZombie, colonneZombie] = "-";

                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (toucheViser.Key == ConsoleKey.DownArrow)
            {
                if (lignePerso + _portee > 10)
                {
                    for (int i = lignePerso; i <= 10; i++)
                    {
                        if ((terrain[i, colonnePerso] == "R") || (terrain[i, colonnePerso] == "L") || (terrain[i, colonnePerso] == "D"))
                        {
                            string zombie = terrain[i, colonnePerso];
                            // trouvons ce zombie dans la liste de zombie
                            int ligneZombie = i;
                            int colonneZombie = colonnePerso;
                            foreach (Zombie zom in lesZombies)
                            {
                                if (zom.getLigneZombie() == ligneZombie && zom.getColonneZombie() == colonneZombie)
                                {
                                    zom.ToucherZombie(_degat);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine(" \n %%% Vous avez touché un zombie %%%\n");
                                    Console.ResetColor();
                                    if (zom.getPdvZombie() < 0)
                                    {
                                        if (zombie == "R")
                                            m.Score(200);
                                        if (zombie == "L" || zombie == "D")
                                            m.Score(100);
                                        Console.ForegroundColor = ConsoleColor.Magenta;
                                        Console.WriteLine(" \n <<< le zombie est mort >>>\n");
                                        Console.ResetColor();
                                        terrain[ligneZombie, colonneZombie] = "-";

                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    for (int i = lignePerso; i < lignePerso + _portee; i++)
                    {
                        if ((terrain[i, colonnePerso] == "R") || (terrain[i, colonnePerso] == "L") || (terrain[i, colonnePerso] == "D"))
                        {
                            string zombie = terrain[i, colonnePerso];
                            // trouvons ce zombie dans la liste de zombie
                            int ligneZombie = i;
                            int colonneZombie = colonnePerso;
                            foreach (Zombie zom in lesZombies)
                            {
                                if (zom.getLigneZombie() == ligneZombie && zom.getColonneZombie() == colonneZombie)
                                {
                                    zom.ToucherZombie(_degat);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine(" \n %%% Vous avez touché un zombie %%%\n");
                                    Console.ResetColor();
                                    if (zom.getPdvZombie() < 0)
                                    {
                                        if (zombie == "R")
                                            m.Score(200);
                                        if (zombie == "L" || zombie == "D")
                                            m.Score(100);
                                        Console.ForegroundColor = ConsoleColor.Magenta;
                                        Console.WriteLine(" \n <<< le zombie est mort >>>\n");
                                        Console.ResetColor();
                                        terrain[ligneZombie, colonneZombie] = "-";

                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (toucheViser.Key == ConsoleKey.RightArrow)
            {
                if (colonnePerso + _portee > 21)
                {
                    for (int j = colonnePerso; j <= 21; j++)
                    {
                        if ((terrain[lignePerso, j] == "R") || (terrain[lignePerso, j] == "L") || (terrain[lignePerso, j] == "D"))
                        {
                            string zombie = terrain[lignePerso, j];
                            int ligneZombie = lignePerso;
                            int colonneZombie = j;
                            foreach (Zombie zom in lesZombies)
                            {
                                if (zom.getLigneZombie() == ligneZombie && zom.getColonneZombie() == colonneZombie)
                                {
                                    zom.ToucherZombie(_degat);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine(" \n %%% Vous avez touché un zombie %%%\n");
                                    Console.ResetColor();
                                    if (zom.getPdvZombie() < 0)
                                    {
                                        if (zombie == "R")
                                            m.Score(200);
                                        if (zombie == "L" || zombie == "D")
                                            m.Score(100);
                                        Console.ForegroundColor = ConsoleColor.Magenta;
                                        Console.WriteLine(" \n <<< le zombie est mort >>>\n");
                                        Console.ResetColor();
                                        terrain[ligneZombie, colonneZombie] = "-";

                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    for (int j = colonnePerso; j < colonnePerso + _portee; j++)
                    {
                        if ((terrain[lignePerso, j] == "R") || (terrain[lignePerso, j] == "L") || (terrain[lignePerso, j] == "D"))
                        {
                            string zombie = terrain[lignePerso, j];
                            int ligneZombie = lignePerso;
                            int colonneZombie = j;
                            foreach (Zombie zom in lesZombies)
                            {
                                if (zom.getLigneZombie() == ligneZombie && zom.getColonneZombie() == colonneZombie)
                                {
                                    zom.ToucherZombie(_degat);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine(" \n %%% Vous avez touché un zombie %%%\n");
                                    Console.ResetColor();
                                    if (zom.getPdvZombie() < 0)
                                    {
                                        if (zombie == "R")
                                            m.Score(200);
                                        if (zombie == "L" || zombie == "D")
                                            m.Score(100);
                                        Console.ForegroundColor = ConsoleColor.Magenta;
                                        Console.WriteLine(" \n <<< le zombie est mort >>>\n");
                                        Console.ResetColor();
                                        terrain[ligneZombie, colonneZombie] = "-";

                                    }
                                }
                            }
                        }
                    }
                }

            }
            if (toucheViser.Key == ConsoleKey.LeftArrow)
            {
                if (colonnePerso - _portee < 0)
                {
                    for (int j = colonnePerso; j > 0; j--)
                    {
                        if ((terrain[lignePerso, j] == "R") || (terrain[lignePerso, j] == "L") || (terrain[lignePerso, j] == "D"))
                        {
                            string zombie = terrain[lignePerso, j];
                            int ligneZombie = lignePerso;
                            int colonneZombie = j;

                            foreach (Zombie zom in lesZombies)
                            {
                                if (zom.getLigneZombie() == ligneZombie && zom.getColonneZombie() == colonneZombie)
                                {
                                    zom.ToucherZombie(_degat);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine(" \n %%% Vous avez touché un zombie %%%\n");
                                    Console.ResetColor();
                                    if (zom.getPdvZombie() < 0)
                                    {
                                        if (zombie == "R")
                                            m.Score(200);
                                        if (zombie == "L" || zombie == "D")
                                            m.Score(100);
                                        Console.ForegroundColor = ConsoleColor.Magenta;
                                        Console.WriteLine(" \n <<< le zombie est mort >>>\n");
                                        Console.ResetColor();
                                        terrain[ligneZombie, colonneZombie] = "-";

                                    }
                                }
                            }

                        }
                    }
                }
                else
                {
                    for (int j = colonnePerso; j > colonnePerso - _portee; j--)
                    {
                        if ((terrain[lignePerso, j] == "R") || (terrain[lignePerso, j] == "L") || (terrain[lignePerso, j] == "D"))
                        {
                            string zombie = terrain[lignePerso, j];
                            int ligneZombie = lignePerso;
                            int colonneZombie = j;

                            foreach (Zombie zom in lesZombies)
                            {
                                if (zom.getLigneZombie() == ligneZombie && zom.getColonneZombie() == colonneZombie)
                                {
                                    zom.ToucherZombie(_degat);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine(" \n %%% Vous avez touché un zombie %%%\n");
                                    Console.ResetColor();
                                    if (zom.getPdvZombie() < 0)
                                    {
                                        if (zombie == "R")
                                            m.Score(200);
                                        if (zombie == "L" || zombie == "D")
                                            m.Score(100);
                                        Console.ForegroundColor = ConsoleColor.Magenta;
                                        Console.WriteLine(" \n <<< le zombie est mort >>>\n");
                                        Console.ResetColor();
                                        terrain[ligneZombie, colonneZombie] = "-";

                                    }
                                }
                            }

                        }
                    }
                }


            }


        }

    }
}
