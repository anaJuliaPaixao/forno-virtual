using Forno_OttoHx.Dominio.Modelos;
using Forno_OttoHx.Infra.Data;
using Forno_OttoHx.Infra.Repositorio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forno_OttoHx.Infra.Repositorio
{
    public class FornoCustomizadoRepositorio : IFornoCustomizadoRepositorio
    {
        private readonly DbContextOptions<OracleDbContext> _dbContext;

        public FornoCustomizadoRepositorio(DbContextOptions<OracleDbContext> dbContext)
        {
            _dbContext = dbContext;
        }
        public Task Adicionar(FornosCustomizados forno)
        {
            using (var data = new OracleDbContext(_dbContext))
            {
                data.Set<FornosCustomizados>().AddAsync(forno);
                data.SaveChangesAsync();
                return Task.CompletedTask;
            }

        }

        public Task Atualizar(FornosCustomizados forno)
        {
            using (var data = new OracleDbContext(_dbContext))
            {
                data.Set<FornosCustomizados>().Update(forno);
                data.SaveChangesAsync();
                return Task.CompletedTask;

            }
        }

        public Task Deletar(FornosCustomizados forno)
        {
            using (var data = new OracleDbContext(_dbContext))
            {
                data.Set<FornosCustomizados>().Remove(forno);
                data.SaveChangesAsync();
                return Task.CompletedTask;

            }
        }

        public FornosCustomizados GetPorId(int Id)
        {
            using (var data = new OracleDbContext(_dbContext))
            {
                return data.Set<FornosCustomizados>().FirstOrDefault(x => x.Id == Id);
            }
        }
        public FornosCustomizados GetPorNome(string nomeAlimento)
        {
            using (var data = new OracleDbContext(_dbContext))
            {
                return data.Set<FornosCustomizados>().FirstOrDefault(x => x.NomeAlimento == nomeAlimento);
            }
        }

        public List<FornosCustomizados> Listar()
        {
            using (var data = new OracleDbContext(_dbContext))
            {
                return data.Set<FornosCustomizados>().ToList();
            }
        }
    }
}
