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
        // Primary Key
        [Key] //using System.ComponentModel.DataAnnotationsを呼ぶ
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Rating 
        {
            get 
            {
                // Calculate a total average score based on Ratings
                double totalAverageRating = 0;

                foreach (var rating in Ratings)
                {
                    totalAverageRating += rating.AverageRating;
                }

                // Return Average of Total if the count is above 0
                return (Ratings.Count > 0) ? totalAverageRating / Ratings.Count : 0;
            } 
        }

        // Average Food Rating
        public double FoodRating 
        {
            get 
            {
                double totalFoodScore = 0;

                foreach (var rating in Ratings)
                {
                    totalFoodScore += rating.FoodScore;
                }

                return (Ratings.Count > 0) ? totalFoodScore / Ratings.Count : 0;
            }
        }

        // Average Environment Rating. foreach => 
        public double EnvironmentRating
        {
            get
            {
                IEnumerable<double> scores = Ratings.Select(rating => rating.EnvironmentScore);

                double totalEnvironmentScore = scores.Sum();

                return (Ratings.Count > 0) ? totalEnvironmentScore / Ratings.Count : 0;
            }
        }

        // Average Cleanliness Rating
        public double CleanlinessScore
        {
            get
            {
                var totalScore = Ratings.Select(r => r.CleanlinessScore).Sum();
                return (Ratings.Count > 0) ? totalScore / Ratings.Count : 0;
                // return(Ratings.Count > 0 ) ? totalScore / Ratings.Count : 0;
            }
        }


        //これはreadonly property
        //public bool IsRecommended => Rating > 3.5;
        public bool IsRecommended
        {
            get
            {
                return (Rating > 8.5);
            }
        }
        //expression body can be used to simplify
        //public bool IsRecommended => Rating > 3.5;

        // All of the associated Rating objects from the database
        public virtual List<Rating> Ratings { get; set; } = new List<Rating>();
    }
}