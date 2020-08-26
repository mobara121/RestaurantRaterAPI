using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;

namespace RestaurantRaterAPI.Models
{
    public class RestaurantDbContext : DbContext  //Using System.Data.Entity                                                                         
    {

        //Connection stringが必要　=>Web.config に<connectionStrings>として加える。 base("name" <= Web.config)
        public RestaurantDbContext() : base("DefaultConnection") { }


        //DbContextクラス と　<Restaurant><Rating>クラスをつなげていく
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Rating> Ratings { get; set; }
    }
}