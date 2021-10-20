using System.Collections.Generic;
using System.Threading.Tasks;
using SysContasPessoal.Application.Models;
using SysContasPessoal.Domain.Models;

namespace SysContasPessoal.Application.Interfaces
{
    public interface IContaService
    {
        Task<IEnumerable<Conta>> GetContas();
        Task<(int status, string description)> CreateConta(ContaTransfer transfer);
    }
}