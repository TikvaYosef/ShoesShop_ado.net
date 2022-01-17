using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoesShop_ado.net.Models
{
    public class SportShoe
    {
        public int id;
        public string company;
        public int price;
        public int size;

        public SportShoe(string company, int price, int size)
        {
            
            this.company = company;
            this.price = price;
            this.size = size;
        }
    }
}