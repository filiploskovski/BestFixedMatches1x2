using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Shared.DbInit;

namespace Core
{
    public class DbInit : Context, IModelGenerator
    {
        void IModelGenerator.OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}