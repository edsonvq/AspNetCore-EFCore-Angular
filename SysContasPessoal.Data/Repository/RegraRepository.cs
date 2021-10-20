using System.Collections.Generic;
using System.Threading.Tasks;
using SysContasPessoal.Data.Context;
using SysContasPessoal.Domain.Interfaces;
using SysContasPessoal.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace SysContasPessoal.Data.Repository
{
    public class RegraRepository : IRegraRepository
    {
        private readonly DataContext _context;

        public RegraRepository(DataContext context)
        {
            _context = context;
        }

        
        public async Task<IEnumerable<Regra>> GetRegras()
        {
            return await _context.Regras.ToListAsync();
        }
    }
}