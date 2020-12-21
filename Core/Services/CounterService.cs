using System;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Extensions;
using Core.Interfaces;
using Core.Models;
using Shared.DbInit.Repository;

namespace Core.Services
{
    public class CounterService : ICounterService
    {
        private readonly IRepository<RCounter> _counterRepository;
        private readonly Random _random = new Random();

        public CounterService(IRepository<RCounter> counterRepository)
        {
            _counterRepository = counterRepository;
        }

        public async Task<CounterModel> Counter()
        {
            var entity = await _counterRepository.GetFirstBy(item => item.Where(q => q.Date == DateTime.Now.Date));

            if (entity == null)
            {
                var e = await _counterRepository.Create(new RCounter()
                {
                    Date = DateTime.Now,
                    TotalToday = 10,
                    RealTotalToday = 1
                });

                return new CounterModel()
                {
                    TotalToday = (int)e.TotalToday,
                    TotalAll = await TotalCount()
                };
            }
            else
            {
                entity.RealTotalToday += 1;
                entity.TotalToday += _random.Next(1,15);
                await _counterRepository.Update(entity);
                
                return new CounterModel()
                {
                    TotalToday = (int)entity.TotalToday,
                    TotalAll = await TotalCount()
                };
            }
        }

        private async Task<int> TotalCount()
        {
            return (await _counterRepository.GetAllBy(item => item.Map())).Sum();
        }
    }
}