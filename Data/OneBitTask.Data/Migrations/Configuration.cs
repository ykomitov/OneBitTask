namespace OneBitTask.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Threading;
    using Models;

    public sealed class Configuration : DbMigrationsConfiguration<OneBitTaskDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        public static string RandomString()
        {
            const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            var random = new Random();

            Thread.Sleep(66);

            return new string(Enumerable.Repeat(Chars, random.Next(random.Next(5, 8), random.Next(10, 15)))
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string GetRandomTelephone()
        {
            const string Chars = "0123456789";
            var random = new Random();

            return new string(Enumerable.Repeat(Chars, 9)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        protected override void Seed(OneBitTaskDbContext context)
        {
            if (context.Contacts.Any())
            {
                return;
            }

            var random = new Random();

            for (int i = 0; i < 20; i++)
            {
                var randomContact = new Contact()
                {
                    FirstName = RandomString(),
                    LastName = RandomString(),
                    Sex = random.Next(0, 11) % 2 == 0,
                    Status = (Status)random.Next(0, 3),
                    Telephone = GetRandomTelephone(),
                    PhotoUrl = "https://www.onebitsoftware.net/Themes/OBSWebsite/Content/Images/logo.png",
                    CreatedOn = DateTime.UtcNow
                };

                context.Contacts.Add(randomContact);
            }

            context.SaveChanges();
        }
    }
}
