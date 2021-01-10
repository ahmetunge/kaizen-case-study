using Bogus;
using Kaizen.Blog.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Kaizen.Blog.DataAccess.EFCore
{
    public class Seed
    {
        private static KaizenContext _context;
        private static ILogger<Seed> _logger;

        public static async Task SeedDataAsync(KaizenContext context, ILoggerFactory loggerFactory)
        {
            _context = context;

            _logger = loggerFactory.CreateLogger<Seed>();

            try
            {
                SeedArticles();
                await _context.SaveChangesAsync();
                _logger.LogInformation("Seeded Data");
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
            }
        }

       
        private static void SeedArticles()
        {
            if (!_context.Articles.Any())
            {
                var user = new User
                {
                    Email = "ahmet@unge.com",
                    Password = "1907",
                    InsertTime=DateTime.Now
                };

                _context.Users.Add(user);

                _context.SaveChanges();

                var articleFaker = new Faker<Article>()
               .RuleFor(b => b.Title, f => f.Lorem.Sentence(4).ToUpper())
               .RuleFor(b => b.Content, f => f.Lorem.Paragraph(7))
               .RuleFor(b => b.InsertTime, DateTime.Now)
               .RuleFor(b => b.UserId, user.Id);

                var softwareCategoryFaker = new Faker<Category>()
                   .RuleFor(c => c.Name, "Software")
                   .RuleFor(c=>c.InsertTime,DateTime.Now)
                   .RuleFor(b => b.Articles, (f, c) =>
                   {
                       var articles = articleFaker.Generate(5000);
                       return articles;
                   });

                Category softwareCategory = softwareCategoryFaker.Generate();

                _context.Categories.Add(softwareCategory);

                var historyCategoryFaker = new Faker<Category>()
                    .RuleFor(c => c.Name, "History")
                    .RuleFor(b => b.Articles, (f, c) =>
                    {
                        var articles = articleFaker.Generate(2850);
                       
                        return articles;
                    });

                Category historyCategory = historyCategoryFaker.Generate();

                _context.Categories.Add(historyCategory);

                var scienceFictionCategoryFaker = new Faker<Category>()
                    .RuleFor(c => c.Name, "Science && Fiction")
                    .RuleFor(b => b.Articles, (f, c) =>
                    {
                        var articles = articleFaker.Generate(3456);
                        return articles;
                    });

                Category sfCategory = scienceFictionCategoryFaker.Generate();


                _context.Categories.Add(scienceFictionCategoryFaker);

            }



        }
    }
}
