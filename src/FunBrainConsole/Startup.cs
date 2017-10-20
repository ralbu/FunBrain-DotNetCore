using System;
using System.Linq;
using FunBrainDomain;
using FunBrainInfrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace FunBrainConsole
{
    public class Startup
    {
        private IServiceProvider Services { get; set; }

        public void Run()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<IUserRankingService, UserRankingService>();
            serviceCollection.AddTransient<IRandomGenerator, RandomGenerator>();
            serviceCollection.AddTransient<IUserRankingRepository, UserRankingRepository>();
            Services = serviceCollection.BuildServiceProvider();

            var service = Services.GetService(typeof(IUserRankingService)) as IUserRankingService;

            var repeat = "y";
            while (repeat == "y")
            {
                Print(service);
                Console.WriteLine("Repeat? y/n");
                repeat = Console.ReadLine();
            }
        }

        private void Print(IUserRankingService userService)
        {
            var users = userService.Get().ToList();
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Name} \t {user.Ranking}");
            }
        }
    }
}