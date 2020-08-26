using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestaurantRaterAPI.Models
{
    
    public class Rating
    {
        // Primary Key
        [Key]
        public int Id { get; set; }

        // Foreign Key (Restaurant Key)　どこに行くかおしえてくれるKey
        [ForeignKey(nameof(Restaurant))] //[ForeignKey] Attribute needs to have (associated navigation property string name)※stringをnameof()にかえることでいつでもNavigationとassociateできる。
        public int RestaurantId { get; set; }　//Restaurant/Ratingどっちに行くかおしえてくれるKey
        // ForeignKey Navigation Property, virtual=I don't have to store because this already exists in RestaurantDBContext.
        public virtual Restaurant Restaurant { get; set; }

        [Required]
        [Range(0, 10)]
        public double FoodScore { get; set; }

        [Required]
        [Range(0, 10)] //can be written side by side [Required, Range(0, 10)]
        public double EnvironmentScore { get; set; }

        [Required]
        [Range(0, 10)]
        public double CleanlinessScore { get; set; }

        public double AverageRating 
        { 
            get
            {
                var totalScore = FoodScore + EnvironmentScore + CleanlinessScore;
                return totalScore / 3;
            }
        }
    }
}