using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineBookShop.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } 
        public string Author { get; set; }
        public int publicDate { get; set; }
        public string category { get; set; }
        public double price { get; set; }   
        public string imageURL { get; set; }


        public Book()
        {

        }
         
    }
}