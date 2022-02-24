using System;
using System.Collections.Generic;


namespace projetZombie
{
    public class Zombie_rapide : Zombie
    {
        
        public Zombie_rapide(int pdvZ, Monde leMonde) : base(pdvZ, leMonde)
        {
            _typeZombie = "rapide";
        }

        
        public override void DeplaceZombie(int nbtours,Monde m)
        {
            string[,] terrain = m.GetTerrain(); // On recupere la map
            Random r = new Random();
            int choix = r.Next(1, 5); // si le zombie va à <-,->,en haut et en bas
            
            if (choix==1) // le zombie va vers la droite 
            {
                if (_czombie==19 || _czombie==20)
                {
                   // le zombie ne bouge pas
                }
                else 
                {
                    if (terrain[_lzombie, _czombie + 2] == "-")
                    {
                        
                        terrain[_lzombie, _czombie + 2] = "R";
                        terrain[_lzombie, _czombie] = "-";
                        _czombie = _czombie + 2;
                       
                    }
                }
                
            }
            if (choix==2) // le zombie va vers la gauche
            {
                if (_czombie==0 || _czombie==1)
                {
                    // le zombie ne bouge pas                  
                }
                else 
                {
                    if (terrain[_lzombie, _czombie - 2] == "-")
                    {
                        
                        terrain[_lzombie, _czombie - 2] = "R";
                        terrain[_lzombie, _czombie] = "-";
                        _czombie = _czombie - 2;
                    }
                    
                }
            
            }
            if (choix == 3) // le zombie va vers le bas
            {
                if (_lzombie==10 || _lzombie==9)
                {
                    // le zombie ne bouge pas
                }
                else 
                {
                    if (terrain[_lzombie + 2, _czombie] == "-")
                    {
                        
                        terrain[_lzombie + 2, _czombie] = "R";
                        terrain[_lzombie, _czombie] = "-";
                        _lzombie = _lzombie + 2;
                    }
                    
                     
                    
                }
            }
            if (choix == 4) // le zombie va vers le haut
            {
                if (_lzombie==0 || _lzombie==1)
                {
                    // le zombie ne bouge pas
                }
                else 
                {
                    if (terrain[_lzombie - 2, _czombie] == "-")
                    {
                        terrain[_lzombie - 2, _czombie] = "R";
                        terrain[_lzombie, _czombie] = "-";
                        _lzombie = _lzombie - 2;

                    }
                     
                    
                    
                }
            }

        }

        
    }
}
