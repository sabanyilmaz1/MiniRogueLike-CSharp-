using System;
using System.Collections.Generic;

namespace projetZombie
{
    public class Zombie
    {
        protected int _ptsViesZombie;
        protected int _lzombie;
        protected int _czombie;
        protected string _typeZombie;
        

        public Zombie(int pdvZ,Monde lemonde)
        {
            Random r = new Random();
            int nbc = r.Next(0, 20);
            int nbl = r.Next(0, 10);

            int nbcMonde = lemonde.getNbColonne();
            int nblMonde = lemonde.getNbLigne();
            string[,] terrain = lemonde.GetTerrain();

            /* Cas ou le zombie se trouve sur le case de depart du perso alors
             * on change les coordonées du zombie
             */

            while (nbcMonde==0 && nblMonde==5)
            {
                 nbc = r.Next(0, 20);
                 nbl = r.Next(0, 10);
            }
            while  (terrain[nbl,nbc]=="*")
            {
                nbc = r.Next(0, 20);
                nbl = r.Next(0, 10);
            }
            _lzombie = nbl;
            _czombie = nbc;
            
            _ptsViesZombie = pdvZ;
        }

        public void ToucherZombie(int degat)
        {
            _ptsViesZombie = _ptsViesZombie - degat;
        }

        public void ZombieEstMort(Monde m,Zombie z)
        {
            if (_ptsViesZombie < 0)
            {
                string[,] leterrain = m.GetTerrain();
                List<Zombie> lesZombies = m.getListZombie();
                int ligneZ = z.getLigneZombie();
                int colonneZ = z.getColonneZombie();
                leterrain[ligneZ, colonneZ] = "-";
                lesZombies.Remove(z);
                // retirer dans la liste zombie dans le monde
            }
            
        }

       

        public int getPdvZombie()
        {
            return _ptsViesZombie;
        }

        public int getLigneZombie()
        {
            return _lzombie;
        }

        public int getColonneZombie()
        {
            return _czombie;
        }

        public string getTypeZombie()
        {
            return _typeZombie;
        }

        public virtual void DeplaceZombie(int nbtours,Monde lemonde)
        { }
    }
}
