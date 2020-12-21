using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Shared.DbInit.DynamicRepository
{
    public class DynamicRepository
    {
        private readonly DataContext dataContext;

        public DynamicRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
    }
}