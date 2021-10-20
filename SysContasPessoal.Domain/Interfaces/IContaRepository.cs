using System.Collections.Generic;
using System.Threading.Tasks;
using SysContasPessoal.Domain.Models;

namespace SysContasPessoal.Domain.Interfaces
{
    public interface IContaRepository
    {
        Task<IEnumerable<Conta>> GetContas();
        Task CreateConta(Conta conta);
    }
}