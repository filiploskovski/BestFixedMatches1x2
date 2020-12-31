using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

namespace Generator
{
    public interface IHarvester
    {
        MozzartBetLiveScoreResponseModel Harvest();
    }

    public class RequestModel
    {
        public string events { get; set; }
        public string by { get; set; }
        public int sportId { get; set; }
        public List<int> competitions { get; set; } = new List<int>();
        public DateTime date { get; set; }
        public int size { get; set; }
        public int offset { get; set; }
        public long fromTime { get; set; }
        public long toTime { get; set; }
    }

    public class Harvester : IHarvester
    {
        private const string URL = "https://www.mozzartbet.mk/livescores2";

        public MozzartBetLiveScoreResponseModel Harvest()
        {
            var date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 00, 00, 01,
                DateTimeKind.Utc).AddDays(-1);
            var fromTimeStamp = GetTimestamp(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 00,
                00, 01, DateTimeKind.Utc).AddDays(-1));
            var toTimeStamp = GetTimestamp(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59,
                59, DateTimeKind.Utc).AddDays(-1));

            var requestModel = new RequestModel
            {
                competitions = new List<int>(),
                by = "days",
                date = date,
                events = "all",
                fromTime = fromTimeStamp,
                toTime = toTimeStamp,
                offset = 0,
                size = 1000,
                sportId = 1
            };

            var client = new RestClient(URL);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Cookie", "i18next=mk");
            request.AddParameter("application/json", JsonConvert.SerializeObject(requestModel, Formatting.None),
                ParameterType.RequestBody);
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<MozzartBetLiveScoreResponseModel>(response.Content);
        }

        private long GetTimestamp(DateTime value)
        {
            return (long) value
                .Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc))
                .TotalMilliseconds;
        }
    }
}