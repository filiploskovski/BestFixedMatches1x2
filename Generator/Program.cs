using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared;

namespace Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddScoped<IHarvester,Harvester>()
                .AddScoped<IProcessing,Processing>()
                .BuildServiceProvider();

            var harvester = serviceProvider.GetService<IHarvester>();
            var response = harvester.Harvest();

            var processing = serviceProvider.GetService<IProcessing>();
            processing.ProcessLeagues(response);

            Console.ReadKey();
        }
    }
}
