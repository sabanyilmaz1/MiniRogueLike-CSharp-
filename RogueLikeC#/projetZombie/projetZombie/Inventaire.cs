using System;
using System.Collections.Generic;
namespace projetZombie
{
    public class Inventaire
    {
        protected int _nbPlace=3;
        protected List <Item> _ListItem;

        public Inventaire()
        {
            
            _ListItem = new List<Item>();
        }
        public int getNbPlace()
        {
            return _nbPlace;
        }

        public List<Item> getListeItem()
        {
            return _ListItem;
        }
        public void RecupItem (Item i)
        {
            if (_nbPlace > 0)
            {
                _nbPlace -= 1;
            }
            _ListItem.Add(i);
            bool b = true;
            i.setEstPris(b);
            
        }

        
       
        public string EchangeItem(Item b)
        {
            string sigle = "";
            Console.WriteLine(" ---> Vous venez de récupérer l'item : " + b.getNom() +"\n");
            
            Console.WriteLine(" si vous souhaitez échanger un item avec celui que vous venez de récupérer tapez '1' sinon tapez '2' : ");
            int res = int.Parse(Console.ReadLine());
            while ((res != 1) && (res != 2))
            {
                Console.WriteLine(" vous n'avez pas tapé une bonne commande. si vous souhaitez échanger un item avec celui que vous venez de récupérer tapez '1' sinon tapez '2' :  ");
            }
            if (res == 1)
            {
                Console.WriteLine("=== Voici les différents objets de votre inventaire :  ===\n");
                foreach (Item i in _ListItem)
                {
                    Console.WriteLine(i.getNom()+"\n");
                }
                Console.WriteLine("--->Choisissez l'objet que vous souhaitez retirer de l'inventaire. tapez '1' pour le premier '2' pour le second et '3' pour le troisième : ");
                int res1 = int.Parse(Console.ReadLine());
                while ((res != 1) && (res != 2) && (res != 3))
                 {
                    Console.WriteLine("Vous n'avez pas tapé une bonne commande tapez '1' pour le premier '2' pour le second et '3' pour le troisième : ");
                 }
                    if (res1 == 1)
                    {
                        Item a = _ListItem[0];
                        _ListItem[0]=b;
                        sigle = a.getSigle();
                    
                    }
                    if (res1 == 2)
                    {
                        Item a = _ListItem[1];
                        _ListItem[0] = b;
                        sigle = a.getSigle();
                }
                    if (res1 == 3)
                    {
                        Item a = _ListItem[2];
                        _ListItem[0] = b;
                        sigle = a.getSigle();
                }

            }
            else
            {
                Console.WriteLine(" vous n'avez pas échangé d'items.");
                sigle = b.getSigle();
            }
            return sigle;
            
        }
        

    }
}
