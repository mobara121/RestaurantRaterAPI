using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantRaterAPI.Models
{
    //Restaurant Entity (The class that gets stored in the database)
    public class Restaurant
    {
        [Key] //using System.ComponentModel.DataAnnotationsを呼ぶ
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Rating { get; set; }
        
        //これはreadonly property
        //public bool IsRecommended => Rating > 3.5;
        public bool IsRecommended
        {
            get
            {
                return (Rating > 3.5);
            }
        }
        //expression body can be used to simplify
        //public bool IsRecommended => Rating > 3.5;
    }
}