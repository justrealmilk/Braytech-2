using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Braytech_2.Models
{
    public class Item
    {
        private string name;
        private string icon;
        private string quantity;
        private string cost;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Icon
        {
            get { return icon; }
            set { icon = value; }
        }

        public string Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public string Cost
        {
            get { return cost; }
            set { cost = value; }
        }
    }
}
