using Forno_OttoHx.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forno_OttoHx.Infra.Repositorio.Interfaces
{
    public interface IFornoRepositorio
    {
        Task Adicionar(Forno forno);
        Task Atualizar(Forno forno);
        Task Deletar(Forno forno);
        Forno GetPorId(int Id);
        List<Forno> Listar();
    }
}
