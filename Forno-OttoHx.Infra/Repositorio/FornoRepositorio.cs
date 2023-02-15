using Forno_OttoHx.Dominio.Modelos;
using Forno_OttoHx.Infra.Data;
using Forno_OttoHx.Infra.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Forno_OttoHx.Infra.Repositorio
{
    public class FornoRepositorio : IFornoRepositorio
    {
        private readonly DbContextOptions<OracleDbContext> _dbContext;

        public FornoRepositorio(DbContextOptions<OracleDbContext> dbContext)
        {
            _dbContext = dbContext;
        }
        public Task Adicionar(Forno forno)
        {
            using (var data = new OracleDbContext(_dbContext))
            {
                data.Set<Forno>().AddAsync(forno);
                data.SaveChangesAsync();
                return Task.CompletedTask;
            }

        }

        public Task Atualizar(Forno forno)
        {
            using (var data = new OracleDbContext(_dbContext))
            {
                data.Set<Forno>().Update(forno);
                data.SaveChangesAsync();
                return Task.CompletedTask;

            }
        }

        public Task Deletar(Forno forno)
        {
            using (var data = new OracleDbContext(_dbContext))
            {
                data.Set<Forno>().Remove(forno);
                data.SaveChangesAsync();
                return Task.CompletedTask;

            }
        }

        public Forno GetPorId(int Id)
        {
            using (var data = new OracleDbContext(_dbContext))
            {
                return data.Set<Forno>().FirstOrDefault(x => x.Id == Id);
            }
        }

        public List<Forno> Listar()
        {
            using (var data = new OracleDbContext(_dbContext))
            {
                return data.Set<Forno>().ToList();
            }
        }
    }
}
