using Core.Interfaces;
using Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core
{
    public static class CoreServices
    {
        public static void AddCoreServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped<IIndexService, IndexService>();
            serviceCollection.AddScoped<ICounterService, CounterService>();
            serviceCollection.AddScoped<IHtmlService, HtmlService>();
            serviceCollection.AddScoped<IVipTicketService, VipTicketService>();
            serviceCollection.AddScoped<IMonthlySubscriptionService, MonthlySubscriptionService>();
            serviceCollection.AddScoped<IFreeTipsService, FreeTipsService>();
            serviceCollection.AddScoped<ICommentService, CommentService>();
        }
    }
}