namespace BookYourTable.DAL.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BookYourTable.DAL.BookYourTableDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BookYourTable.DAL.BookYourTableDBContext context)
        {
            context.MenuItems.AddOrUpdate(
                new MenuItem { RestaurantID = 1, Name = "Burek ispod saca", Description = "Sint moderatius mel ex, sed ubique animal luptatum ei, no homero commune eos!", Price = 300.00m },
                new MenuItem { RestaurantID = 1, Name = "Cufte", Description = "At mel veritus expetenda reprimique, nihil aeterno evertitur in mel, ex nec magna aeque facilis.", Price = 350.00m },
                new MenuItem { RestaurantID = 1, Name = "Svinjsko pecenje", Description = "Has utinam detracto et, eu nullam fuisset quo. Sea aeterno epicurei et, graece semper quo eu!", Price = 850.00m },
                new MenuItem { RestaurantID = 1, Name = "Junece pecenje", Description = " Sint moderatius mel ex, sed ubique animal luptatum ei, no homero commune eos!", Price = 970.00m },
                new MenuItem { RestaurantID = 1, Name = "Pohovano belo meso", Description = "At mel veritus expetenda reprimique, nihil aeterno evertitur in mel, ex nec magna aeque facilis.", Price = 580.00m },
                new MenuItem { RestaurantID = 1, Name = "Karadjordjeva snicla", Description = " Has utinam detracto et, eu nullam fuisset quo. Sea aeterno epicurei et, graece semper quo eu!", Price = 500.00m },
                new MenuItem { RestaurantID = 1, Name = "Fasirane snicle", Description = "Sonet utinam hendrerit ei vis, has meliore scaevola no. Verear eripuit.", Price = 300.00m }
                );
        }
    }
}
