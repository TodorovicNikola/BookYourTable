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
            var passwordBytes = System.Text.Encoding.UTF8.GetBytes("admin");
            String encodedPasswordAdmin = System.Convert.ToBase64String(passwordBytes);

            context.SystemManagers.AddOrUpdate(
                new SystemManager { E_Mail = "admin@admin.com", Password = encodedPasswordAdmin, FirstName = "Admin", LastName = "Admin" }
                );

            passwordBytes = System.Text.Encoding.UTF8.GetBytes("petar");
            String encodedPasswordPetar = System.Convert.ToBase64String(passwordBytes);

            passwordBytes = System.Text.Encoding.UTF8.GetBytes("nenad");
            String encodedPasswordNenad = System.Convert.ToBase64String(passwordBytes);

            passwordBytes = System.Text.Encoding.UTF8.GetBytes("majkl");
            String encodedPasswordMajkl = System.Convert.ToBase64String(passwordBytes);

            passwordBytes = System.Text.Encoding.UTF8.GetBytes("hasan");
            String encodedPasswordHasan = System.Convert.ToBase64String(passwordBytes);

            passwordBytes = System.Text.Encoding.UTF8.GetBytes("hakala");
            String encodedPasswordHakala = System.Convert.ToBase64String(passwordBytes);

            passwordBytes = System.Text.Encoding.UTF8.GetBytes("nikola");
            String encodedPasswordNikola = System.Convert.ToBase64String(passwordBytes);

            context.Guests.AddOrUpdate(
                new Guest { E_Mail = "petar@nepostojeci.com", FirstName = "Petar Pero", LastName = "Kalimero", Password = encodedPasswordPetar, Address = "Petra Drapsina 2, Subotica", ConfirmedRegistration = true },
                new Guest { E_Mail = "nenadtod@live.com", FirstName = "Nenad", LastName = "Todorovic", Password = encodedPasswordNenad, Address = "Ilirska 5/a, Subotica", ConfirmedRegistration = true },
                new Guest { E_Mail = "majkl@nepostojeci.com", FirstName = "Majkl", LastName = "Jordan", Password = encodedPasswordMajkl, Address = "Bulevar Oslobodjenja 23, Novi Sad", ConfirmedRegistration = true },
                new Guest { E_Mail = "hasan@nepostojeci.com", FirstName = "Hasan", LastName = "Sakic", Password = encodedPasswordHasan, Address = "Aleja Marsala Tita 15, Subotica", ConfirmedRegistration = true },
                new Guest { E_Mail = "hakala@nepostojeci.com", FirstName = "Hakala", LastName = "ABre", Password = encodedPasswordHakala, Address = "Tolstojeva 5, Novi Sad", ConfirmedRegistration = true },
                new Guest { E_Mail = "nikola5tod@yahoo.com", FirstName = "Nikola", LastName = "Todorovic", Password = encodedPasswordNikola, Address = "Tolstojeva 12, Novi Sad", ConfirmedRegistration = true }
                );

            context.Restaurants.AddOrUpdate(
                new Restaurant { Name = "NIRVANA", Description = "DOMACA KUHINJA", Address = "Banijska 5, Subotica", TablesMatrixHeight = null, TablesMatrixWidth = null, Configured = true },
                new Restaurant { Name = "BOSS", Description = "SVE VRSTE KUHINJA", Address = "Aleja Marsala Tita 8, Subotica", TablesMatrixHeight = null, TablesMatrixWidth = null, Configured = true },
                new Restaurant { Name = "CRNA MACA", Description = "ITALIJANSA KUHINJA", Address = "Laze Teleckog 15, Novi Sad", TablesMatrixHeight = null, TablesMatrixWidth = null, Configured = true },
                new Restaurant { Name = "SNAILS", Description = "FRANCUSKA KUHINJA", Address = "Knez Mihajlova 18, Beograd", TablesMatrixHeight = null, TablesMatrixWidth = null, Configured = true },
                new Restaurant { Name = "DVA STAPICA", Description = "KINESKA KUHINJA", Address = "Bulevar Cara Lazara 58, Novi Sad", TablesMatrixHeight = null, TablesMatrixWidth = null, Configured = true },
                new Restaurant { Name = "PIZZA", Description = "ITALIJANSKA KUHINJA", Address = "Ilirska 5/a, Subotica", TablesMatrixHeight = null, TablesMatrixWidth = null, Configured = true }
                );

            passwordBytes = System.Text.Encoding.UTF8.GetBytes("nirvana");
            String encodedPasswordNirvana = System.Convert.ToBase64String(passwordBytes);

            passwordBytes = System.Text.Encoding.UTF8.GetBytes("nirvanaNovi");
            String encodedPasswordNirvanaNovi = System.Convert.ToBase64String(passwordBytes);

            passwordBytes = System.Text.Encoding.UTF8.GetBytes("boss");
            String encodedPasswordBoss = System.Convert.ToBase64String(passwordBytes);

            passwordBytes = System.Text.Encoding.UTF8.GetBytes("crnaMaca");
            String encodedPasswordCrnaMaca = System.Convert.ToBase64String(passwordBytes);

            passwordBytes = System.Text.Encoding.UTF8.GetBytes("nirvanaNoviNovi");
            String encodedPasswordNirvanaNoviNovi = System.Convert.ToBase64String(passwordBytes);

            passwordBytes = System.Text.Encoding.UTF8.GetBytes("pizza");
            String encodedPasswordPizza = System.Convert.ToBase64String(passwordBytes);

            passwordBytes = System.Text.Encoding.UTF8.GetBytes("dvaStapica");
            String encodedPasswordDvaStapica = System.Convert.ToBase64String(passwordBytes);

            passwordBytes = System.Text.Encoding.UTF8.GetBytes("dvaStapicaNovi");
            String encodedPasswordDvaStapicaNovi = System.Convert.ToBase64String(passwordBytes);


            context.RestaurantManagers.AddOrUpdate(
                new RestaurantManager { E_Mail = "nirvana@nepostojeci.com", FirstName = "Nirv", LastName = "Ana", RestaurantID = 1, Password = encodedPasswordNirvana },
                new RestaurantManager { E_Mail = "nirvanaNovi@nepostojeci.com", FirstName = "Nirv", LastName = "Ana Novi", RestaurantID = 1, Password = encodedPasswordNirvanaNovi },
                new RestaurantManager { E_Mail = "boss@nepostojeci.com", FirstName = "BO", LastName = "SS", RestaurantID = 2, Password = encodedPasswordBoss },
                new RestaurantManager { E_Mail = "crnaMaca@nepostojeci.com", FirstName = "Crna", LastName = "Maca", RestaurantID = 3, Password = encodedPasswordCrnaMaca },
                new RestaurantManager { E_Mail = "nirvanaNoviNovi@nepostojeci.com", FirstName = "Nirv", LastName = "Ana NoviNovi", RestaurantID = 1, Password = encodedPasswordNirvanaNoviNovi },
                new RestaurantManager { E_Mail = "pizza@nepostojeci.com", FirstName = "Piz", LastName = "Za", RestaurantID = 6, Password = encodedPasswordPizza },
                new RestaurantManager { E_Mail = "dvaStapica@nepostojeci.com", FirstName = "Dva", LastName = "Stapica", RestaurantID = 5, Password = encodedPasswordDvaStapica },
                new RestaurantManager { E_Mail = "dvaStapicaNovi@nepostojeci.com", FirstName = "Dva", LastName = "Stapica Novi", RestaurantID = 5, Password = encodedPasswordDvaStapicaNovi }
                );

        }
    }
}
