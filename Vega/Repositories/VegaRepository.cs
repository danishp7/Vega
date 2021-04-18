using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vega.Data;

namespace Vega.Repositories
{
    public class VegaRepository : IVegaRepository
    {
        private readonly VegaDbContext _ctx;
        public VegaRepository(VegaDbContext context)
        {
            _ctx = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _ctx.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _ctx.Remove(entity);
        }

        public async Task<bool> SaveAll()
        {
            return await _ctx.SaveChangesAsync() > 0;
        }
    }
}
