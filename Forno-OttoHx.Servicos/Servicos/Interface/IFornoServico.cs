using Forno_OttoHx.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forno_OttoHx.Servicos.Servicos.Interface
{
    public interface IFornoServico
    {
        Task Adicionar(Forno forno);
        Task AdicionarPersonalizado(string  aquecimentoPersonalizado);
        Task AdicionarNovoAlimento(FornosCustomizados forno);
        void Atualizar(Forno forno);
        void Deletar(Forno forno);
        Forno GetPorId(int Id);
        List<Forno> Listar();
        Task PararForno();
    }
}
