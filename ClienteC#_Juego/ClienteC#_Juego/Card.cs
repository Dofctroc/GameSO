using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteC__Juego
{
    internal class Card
    {
        public int ID { get; set; }
        public Image image { get; set; }
        public string type { get; set; }

        public Card(int id, Image img, string type)
        {
            this.ID = id;
            this.image = img;
            this.type = type;
        }
    }
}
