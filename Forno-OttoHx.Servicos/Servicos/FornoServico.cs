using Forno_OttoHx.Dominio.Modelos;
using Forno_OttoHx.Infra.Repositorio.Interfaces;
using Forno_OttoHx.Servicos.Servicos.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forno_OttoHx.Servicos.Servicos
{
    public class FornoServico : IFornoServico
    {
        private readonly IFornoRepositorio _fornoRepositorio;

        public FornoServico(IFornoRepositorio fornoRepositorio)
        {
            _fornoRepositorio = fornoRepositorio;
        }

        public Task Adicionar(Forno forno)
        {
            if (ValidarFornoLigado())
            {
                List<Forno> fornos = new List<Forno>();

                fornos = _fornoRepositorio.Listar();

                TimeSpan tempoDecorrido = DateTime.Now - fornos.LastOrDefault().HoraInicio;

                forno.SegundosAquecimento += Convert.ToInt32(tempoDecorrido.TotalSeconds);

                if (forno.SegundosAquecimento > 120)
                    throw new Exception("Não é possivel inserir tempo maior que 2 min (120 segundos)");
                if (forno.Potencia <= 0)
                    throw new Exception("Não é possivel inserir potencia menor ou igual a 0");

                return _fornoRepositorio.Atualizar(forno);

            }

            if (forno.Potencia > 10)
                throw new Exception("Não é possivel inserir potencia maior que 10");
            if (forno.Potencia <= 0)
                throw new Exception("Não é possivel inserir potencia menor ou igual a 0");
            if (forno.SegundosAquecimento > 120)
                throw new Exception("Não é possivel inserir tempo maior que 2 min (120 segundos)");
            if (forno.SegundosAquecimento <= 1)
                throw new Exception("Não é possivel inserir tempo meno que 1 segundo");
            return _fornoRepositorio.Adicionar(forno);
        }

        private bool ValidarFornoLigado()
        {
            List<Forno> fornos = new List<Forno>();

            fornos = _fornoRepositorio.Listar();

            if (fornos.Count > 0)
            {
                Forno forno = fornos.LastOrDefault();

                TimeSpan tempoDecorrido = DateTime.Now - forno.HoraInicio;

                if (tempoDecorrido.TotalSeconds < forno.SegundosAquecimento)
                    return true;
            }

            return false;
        }

        public void Atualizar(Forno forno)
        {
            _fornoRepositorio.Atualizar(forno);
        }

        public void Deletar(Forno forno)
        {
            _fornoRepositorio.Deletar(forno);
        }

        public Forno GetPorId(int Id)
        {
            return _fornoRepositorio.GetPorId(Id);
        }

        public List<Forno> Listar()
        {
            return _fornoRepositorio.Listar();
        }
    }
}
