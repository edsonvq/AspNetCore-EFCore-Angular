using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SysContasPessoal.Application.Models;
using SysContasPessoal.Application.Services;
using SysContasPessoal.Controllers;
using SysContasPessoal.Data.Context;
using SysContasPessoal.Data.Repository;
using SysContasPessoal.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace SysContasPessoal.Test
{
    public class Test
    {
        [Fact]
        public async Task ReturnsList()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ContasDatabase;Trusted_Connection=True;MultipleActiveResultSets=true");
            var context = new DataContext(optionsBuilder.Options);
            var contaRepo = new ContaRepository(context);
            var regraRepo = new RegraRepository(context);
            
            var service = new ContaService(contaRepo, regraRepo);
            var sut = new ContasController(service, new NullLogger<ContasController>());
            var result = await sut.GetAll() as ObjectResult;

            Assert.IsType<List<Conta>>(result.Value);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async Task FailsToCreateEntry()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseInMemoryDatabase("InMemoryDatabaseName");
            var context = new DataContext(optionsBuilder.Options);
            var contaRepo = new ContaRepository(context);
            var regraRepo = new RegraRepository(context);

            var service = new ContaService(contaRepo, regraRepo);
            var sut = new ContasController(service, new NullLogger<ContasController>());
            var result = await sut.Create(new ContaTransfer
            {
                Nome = "",
                Valor = 0,
                Vencimento = new DateTime(2020, 12, 10),
                Pagamento = new DateTime(2020, 12, 20)
            }) as ObjectResult;

            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public async Task CreatesEntry()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseInMemoryDatabase("InMemoryDatabaseName");
            var context = new DataContext(optionsBuilder.Options);
            var contaRepo = new ContaRepository(context);
            var regraRepo = new RegraRepository(context);

            var service = new ContaService(contaRepo, regraRepo);
            var sut = new ContasController(service, new NullLogger<ContasController>());
            var result = await sut.Create(new ContaTransfer
            {
                Nome = "Conta",
                Valor = 20.8m,
                Vencimento = new DateTime(2020, 12, 10),
                Pagamento = new DateTime(2020, 12, 20)
            }) as ObjectResult;

            Assert.Equal(200, result.StatusCode);
        }
    }
}