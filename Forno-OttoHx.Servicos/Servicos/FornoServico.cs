using Forno_OttoHx.Dominio.Modelos;
using Forno_OttoHx.Dominio.Modelos.Enums;
using Forno_OttoHx.Infra.Repositorio;
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
        private readonly IFornoCustomizadoRepositorio _fornoCustomizadoRepositorio;

        public FornoServico(IFornoRepositorio fornoRepositorio, IFornoCustomizadoRepositorio fornoCustomizadoRepositorio)
        {
            _fornoRepositorio = fornoRepositorio;
            _fornoCustomizadoRepositorio = fornoCustomizadoRepositorio;
        }

        public Task AdicionarPersonalizado(string aquecimentoPersonalizado)
        {
            Forno forno = new Forno();
            var fornoCustomizado = _fornoCustomizadoRepositorio.GetPorNome(aquecimentoPersonalizado);

            if (fornoCustomizado.Id > 0)
            {
                forno = new Forno()
                {
                    Ativo = true,
                    HoraInicio = DateTime.Now,
                    Potencia = fornoCustomizado.Potencia,
                    SegundosAquecimento = fornoCustomizado.SegundosAquecimento,
                };

               return Adicionar(forno);
            }

            throw new Exception("Alimento não encontrado");
        }

        public Task Adicionar(Forno forno)
        {
            if (ValidarFornoLigado())
            {
                List<Forno> fornos = new List<Forno>();

                fornos = _fornoRepositorio.Listar();

                TimeSpan tempoDecorrido = DateTime.Now - fornos.LastOrDefault().HoraInicio;

                forno.SegundosAquecimento += Convert.ToInt32(tempoDecorrido.TotalSeconds);
                if (forno.TipoAquecimento > 0)
                {
                    switch (forno.TipoAquecimento)
                    {
                        case TipoAquecimento.Pipoca:
                            forno.SegundosAquecimento = 180;
                            forno.Potencia = 7;
                            break;

                        case TipoAquecimento.Leite:
                            forno.SegundosAquecimento = 300;
                            forno.Potencia = 5;
                            break;

                        case TipoAquecimento.CarnesDeBoi:
                            forno.SegundosAquecimento = 840;
                            forno.Potencia = 4;
                            break;

                        case TipoAquecimento.Frango:
                            forno.SegundosAquecimento = 420;
                            forno.Potencia = 7;
                            break;

                        case TipoAquecimento.Feijao:
                            forno.SegundosAquecimento = 480;
                            forno.Potencia = 0;
                            break;
                    }
                }

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

        public Task PararForno()
        {
            Forno forno  = new Forno();
            var fornos = _fornoRepositorio.Listar();
            if(fornos.Count > 0)
            {
                forno = fornos.LastOrDefault();
                forno.Ativo = false;

                return _fornoRepositorio.Atualizar(forno);
                
            }

             throw new Exception("Nenhum Forno Ativo!");

        }

        public Task AdicionarNovoAlimento(FornosCustomizados forno)
        {

            if (forno.Potencia > 10)
                throw new Exception("Não é possivel inserir potencia maior que 10");
            if (forno.Potencia <= 0)
                throw new Exception("Não é possivel inserir potencia menor ou igual a 0");
            if (forno.SegundosAquecimento > 120)
                throw new Exception("Não é possivel inserir tempo maior que 2 min (120 segundos)");
            if (forno.SegundosAquecimento <= 1)
                throw new Exception("Não é possivel inserir tempo meno que 1 segundo");
            if(forno.Abreviacao.Length <= 0)
                throw new Exception("Não é possivel inserir sem abreviacao");
            if (forno.NomeAlimento.Length <= 0)
                throw new Exception("Não é possivel inserir sem nome");

            return _fornoCustomizadoRepositorio.Adicionar(forno);
        }
    }
}
