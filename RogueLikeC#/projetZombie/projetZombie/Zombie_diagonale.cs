using System;
namespace projetZombie
{
    public class Zombie_diagonale:Zombie
    {
       

        public Zombie_diagonale(int pdvZ,Monde lemonde) : base(pdvZ,lemonde)
        {
            _typeZombie = "diagonale";
        }

        public override void DeplaceZombie(int nbtours,Monde leMonde)
        {
            // manque les cas ou les zombies seront à l'extremité du monde
            string[,] terrain = leMonde.GetTerrain();
            Random r = new Random();
            int choix = r.Next(1, 5);
            
                if (choix == 1) // le zombie va vers la diagonale en haut à gauche (-1,-1)
                {
                    if (_lzombie==0)
                    {//le zombie ne bouge pas
                    }
                    else if (_czombie==0)
                    {//le zombie ne bouge pas
                    }
                    else if (terrain[_lzombie - 1, _czombie - 1] == "-")
                    {
                        terrain[_lzombie, _czombie] = "-";
                        terrain[_lzombie - 1, _czombie - 1] = "D";
                        _lzombie = _lzombie - 1;
                        _czombie = _czombie - 1;
                    }
                    
                }
                else if (choix == 2) // le zombie va vers la diagonale en haut à droite (-1,+1)
                {
                    if (_lzombie == 0)
                    {//le zombie ne bouge pas
                    }
                    else if (_czombie == 20)
                    {//le zombie ne bouge pas
                    }
                    else if (terrain[_lzombie - 1, _czombie + 1] == "-")
                    {
                        terrain[_lzombie, _czombie] = "-";
                        terrain[_lzombie - 1, _czombie + 1] = "D";
                        _lzombie = _lzombie - 1;
                        _czombie = _czombie + 1;
                    }
                    
                }

                else if (choix == 3) // le zombie va vers la diagonale en bas à gauche (+1,-1)
                {
                    if (_lzombie == 10)
                    {//le zombie ne bouge pas
                    }
                    else if (_czombie == 0)
                    {//le zombie ne bouge pas
                    }
                    else if (terrain[_lzombie +1, _czombie - 1] == "-")
                    {
                        terrain[_lzombie, _czombie] = "-";
                        terrain[_lzombie + 1, _czombie - 1] = "D";
                        _lzombie = _lzombie + 1;
                        _czombie = _czombie - 1;
                    }
                    
                }
                else if (choix == 4) // le zombie va vers la diagonale en bas à droite (+1,+1)
                {
                    if (_lzombie == 10)
                    {//le zombie ne bouge pas
                    }
                    else if (_czombie == 20)
                    {//le zombie ne bouge pas
                    }
                    else if (terrain[_lzombie + 1, _czombie +1] == "-")
                    {
                        terrain[_lzombie, _czombie] = "-";
                        terrain[_lzombie + 1, _czombie + 1] = "D";
                        _lzombie = _lzombie + 1;
                        _czombie = _czombie + 1;
                    }
                }
        }
        
    }
}
