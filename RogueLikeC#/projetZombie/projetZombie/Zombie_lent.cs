using System;
namespace projetZombie
{
    public class Zombie_lent:Zombie
    {
        


        public Zombie_lent(int pdvZ, Monde leMonde) : base(pdvZ, leMonde)
        {
            _typeZombie = "lent";
        }

        public override void DeplaceZombie(int nbTours, Monde m)
        {
            string[,] terrain = m.GetTerrain();
            Random r = new Random();
            int choix = r.Next(1, 5); // si le zombie va à <-,->,en haut et en bas
            if (nbTours % 2 == 0)
            {
                if (choix == 1) // le zombie va vers la droite 
                {
                    if (_czombie == 20)
                    {
                        // le zombie ne bouge pas
                    }
                    else
                    {
                        if (terrain[_lzombie, _czombie + 1] == "-")
                        {

                            terrain[_lzombie, _czombie + 1] = "L";
                            terrain[_lzombie, _czombie] = "-";
                            _czombie = _czombie + 1;

                        }
                    }

                }
                if (choix == 2) // le zombie va vers la gauche
                {
                    if (_czombie == 0)
                    {
                        // le zombie ne bouge pas                  
                    }
                    else
                    {
                        if (terrain[_lzombie, _czombie - 1] == "-")
                        {

                            terrain[_lzombie, _czombie - 1] = "L";
                            terrain[_lzombie, _czombie] = "-";
                            _czombie = _czombie - 1;
                        }

                    }

                }
                if (choix == 3) // le zombie va vers le bas
                {
                    if (_lzombie == 10)
                    {
                        // le zombie ne bouge pas
                    }
                    else
                    {
                        if (terrain[_lzombie + 1, _czombie] == "-")
                        {

                            terrain[_lzombie + 1, _czombie] = "L";
                            terrain[_lzombie, _czombie] = "-";
                            _lzombie = _lzombie + 1;
                        }



                    }
                }
                if (choix == 4) // le zombie va vers le haut
                {
                    if (_lzombie == 0)
                    {
                        // le zombie ne bouge pas
                    }
                    else
                    {
                        if (terrain[_lzombie - 1, _czombie] == "-")
                        {
                            terrain[_lzombie - 1, _czombie] = "L";
                            terrain[_lzombie, _czombie] = "-";
                            _lzombie = _lzombie - 1;

                        }



                    }
                }
            }
            

        }


    }
}