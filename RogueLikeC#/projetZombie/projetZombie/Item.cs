using System;
namespace projetZombie
{
    public class Item
    {
        protected int _lItem; // Position ligne de l'item
        protected int _cItem; // POsition colonne de l'item
        protected string _nom;
        protected string _sigleItem;
        protected bool _estPris;
        protected Monde leMonde;

        public Item(Monde leMonde)
        {
            Random r = new Random();
            int nbc = r.Next(1, 19);
            int nbl = r.Next(1, 9);

            int nbcMonde = leMonde.getNbColonne();
            int nblMonde = leMonde.getNbLigne();

            /* Cas ou le zombie se trouve sur le case de depart du perso alors
             * on change les coordonées du zombie
             */

            while (nbcMonde == 0 && nblMonde == 5)
            {
                nbc = r.Next(1, 19);
                nbl = r.Next(1, 9);
            }
            _lItem = nbl;
            _cItem = nbc;


            
            _estPris = false;
        }


        public bool getEstPris()
        {
            return _estPris;
        }
        public void setEstPris(bool b)
        {
            _estPris = b;
        }
        public string getNom()
        {
            return _nom;
        }
        public string getSigle()
        {
            return _sigleItem;
        }

        public int getLigneItem()
        {
            return _lItem;
        }

        public int getColonneItem()
        {
            return _cItem;
        }
    }
}
