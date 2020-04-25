using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ScorchApi.Controllers;
using ScorchApi.Models;
using ScorchApi.Models.EfModels;

namespace ScorchApi.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.ApplicationDbContext>
    {
        private ApplicationDbContext context;
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Models.ApplicationDbContext context)
        {
            this.context = context;
            PopulateSearchOptions();
            context.SaveChanges();
        }

        private void PopulateSearchOptions()
        {
            var categories = new List<string>
            {
                "Club Lounge",
                "Restaurant Lounge",
                "Pub/Bar",
                "Bistro",
                "Sports Lounge",
                "Music Lounge",
                "Live Entertainment",
                "Festivals/Events"
            };
            var tags = new List<string>
            {
                "Food",
                "Drinks",
                "Entrance",
            };

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(categories.Select(s => new Category
                {
                    Name = s
                }));
            }

            if (!context.Tags.Any())
            {
                context.Tags.AddRange(tags.Select(s => new Tag
                {
                    Name = s
                }));
            }
        }
    }
}
