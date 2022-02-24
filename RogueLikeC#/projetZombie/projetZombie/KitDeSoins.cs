using System;
namespace projetZombie
{
    public class KitDeSoins : Item
    {
        public KitDeSoins(Monde leMonde): base (leMonde)
        {
            _nom = "kitdesoins";
            _sigleItem = "S";
        }
       
    }
}
