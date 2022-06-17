using System;
using System.Collections.Generic;
using System.Text;

namespace DishPicker.Model
{
    [Serializable]
    public class AddableProduct : Product
    {
        public bool Ischecked { get; set; }

        public AddableProduct(string name, int kkal, int weight, string source, bool ischecked = false) : base(name, kkal, weight, source)
        {
        }

        public AddableProduct()
        {

        }
    }
}
