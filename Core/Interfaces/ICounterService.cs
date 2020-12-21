using System.Threading.Tasks;
using Core.Models;

namespace Core.Interfaces
{
    public interface ICounterService
    {
        Task<CounterModel> Counter();
    }
}