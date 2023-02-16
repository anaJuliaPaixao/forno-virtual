using Forno_OttoHx.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forno_OttoHx.Infra.Repositorio.Interfaces
{
    public interface IFornoCustomizadoRepositorio
    {
        Task Adicionar(FornosCustomizados forno);
        Task Atualizar(FornosCustomizados forno);
        Task Deletar(FornosCustomizados forno);
        FornosCustomizados GetPorId(int Id);
        FornosCustomizados GetPorNome(string nomeAlimento);
        List<FornosCustomizados> Listar();
    }
}
