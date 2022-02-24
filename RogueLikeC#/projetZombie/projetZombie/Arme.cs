using System;
namespace projetZombie
{
    public class Arme : Item
    {
        protected int _portee;
        protected int _degat;
        protected string _type;

        public Arme(int p, int d,Monde leMonde):base(leMonde)
        {
            _portee = p;
            _degat = d;
            
                       
        }

        public int getDegat ()
        {
            return _degat;
        }
        public int getPortee()
        {
            return _portee;
        }
        public string getType()
        {
            return _type;
        }
        public virtual void Tirer(Monde m)
        {

        }
    }
}
