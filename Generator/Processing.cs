using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Shared.DbInit.Repository;

namespace Generator
{
    public interface IProcessing
    {
        Task ProcessLeagues(MozzartBetLiveScoreResponseModel model);
    }

    public class Processing : IProcessing
    {
        private readonly IRepository<RCountry> _countryRepository;

        public Processing(IRepository<RCountry> countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task ProcessLeagues(MozzartBetLiveScoreResponseModel model)
        {
            var countries = await _countryRepository.Get();
            foreach (var match in model.matches)
            {
                if (!countries.Select(item => item.RMozzartCountryId).Contains(match.competition.country.id))
                {
                    var entity = new RCountry()
                    {
                        RMozzartCountryId = match.competition.country.id,
                        MozzartCountryName = match.competition.country.name
                    };
                    await _countryRepository.Create(entity);
                }
            }
        }
    }
}