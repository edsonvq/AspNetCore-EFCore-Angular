using System.Collections.Generic;
using System.Threading.Tasks;
using SysContasPessoal.Domain.Models;

namespace SysContasPessoal.Domain.Interfaces
{
    public interface IRegraRepository
    {
        Task<IEnumerable<Regra>> GetRegras();
    }
}