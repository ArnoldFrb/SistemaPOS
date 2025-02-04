using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SistemaPOS.Src.Domain.Entities
{
    public class Product
    {
        public Product()
        {
        }

        public Product(int id, string title, double price, string description, string category, string image, Rating rating)
        {
            Id = id;
            Title = title;
            Price = price;
            Description = description;
            Category = category;
            Image = image;
            Rating = rating;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public Rating Rating { get; set; }
    }

    public record Rating
    {
        public Rating()
        {
        }

        public Rating(double rate, int count)
        {
            Rate = rate;
            Count = count;
        }

        public int Id { get; set; }
        public double Rate { get; set; }
        public int Count { get; set; }
    }
}
