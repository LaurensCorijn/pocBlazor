using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poc_blazor.Shared.Classes
{
    public class Product
    {
        #region Properties

        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        #endregion

        #region Constructors

        public Product(string name, string image, double price, string description)
        {
            this.Name = name;
            this.Image = image;
            this.Price = price;
            this.Description = description;
        }

        public Product()
        {
        }

        #endregion
    }
}