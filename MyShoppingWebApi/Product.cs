using System;

namespace MyShoppingWebApi
{
    public class Product
    {
        public DateTime Date { get; set; }

        public int Id { get; set; }

        public string ProductName => "Product "+Id;

        public string Description { get; set; }
        public string ImageSource { get; set; }
        public string Text { get; set; }
    }
}
