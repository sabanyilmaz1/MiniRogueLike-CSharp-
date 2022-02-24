using System;
namespace projetZombie
{
    public class Nourriture : Item
    {
        public Nourriture(Monde leMonde) : base (leMonde)
        {
            _nom = "nourriture";
            _sigleItem = "N";
        }

        
    }
}
