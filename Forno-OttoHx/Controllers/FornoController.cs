using Forno_OttoHx.Dominio.Modelos;
using Forno_OttoHx.DTO;
using Forno_OttoHx.Servicos.Servicos.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Forno_OttoHx.Controllers
{
    [Route("api/Forno")]
    [ApiController]
    public class FornoController : ControllerBase
    {
        private readonly IFornoServico _fornoServico;

        public FornoController(IFornoServico fornoServico)
        {
            _fornoServico = fornoServico;
        }

        [HttpPost]
        public ActionResult<Forno> IniciarForno(FornoModeloEntrada fornoModeloEntrada)
        {
            Forno forno = new Forno()
            {
                HoraInicio = DateTime.Now,
                Potencia = fornoModeloEntrada.Potencia,
                SegundosAquecimento = fornoModeloEntrada.SegundosAquecimento,
                Ativo = true,
                TipoAquecimento = fornoModeloEntrada.TipoAquecimento,

            };

            if ((fornoModeloEntrada.Potencia > 0) && (fornoModeloEntrada.SegundosAquecimento > 0))
            {
                if (_fornoServico.Adicionar(forno).IsCompleted)
                    return Created("GetForno", forno);
                else
                    return BadRequest(_fornoServico.Adicionar(forno).Exception);

            }
            else if (fornoModeloEntrada.TipoAquecimento > 0)
            {
                if (_fornoServico.Adicionar(forno).IsCompleted)
                    return Created("GetForno", forno);
                else
                    return BadRequest(_fornoServico.Adicionar(forno).Exception);

            }
            else if (fornoModeloEntrada.AquecimentoPersonalizado != null)
            {
                if (_fornoServico.AdicionarPersonalizado(fornoModeloEntrada.AquecimentoPersonalizado).IsCompleted)
                    return Created("GetForno", forno);
                else
                    return BadRequest(_fornoServico.Adicionar(forno).Exception);

            }
            else
            {
                return BadRequest("Entrada Invalida");
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Forno>> GetForno()
        {
            return _fornoServico.Listar();
        }

        [HttpPut]
        public ActionResult PararForno()
        {
            if (_fornoServico.PararForno().IsCompleted) ;
            return Ok();
        }

        [Route("Pausar-Forno")]
        [HttpPut]
        public ActionResult PausarForno()
        {
            if (_fornoServico.PararForno().IsCompleted) ;
            return Ok();
        }

        [Route("Cadastrar-Alimento")]
        [HttpPost]
        public ActionResult<FornosCustomizados> CadastrarAlimento(FornosCustomizadosEntrada fornoModeloEntrada)
        {
            FornosCustomizados forno = new FornosCustomizados()
            {
                Potencia = fornoModeloEntrada.Potencia,
                SegundosAquecimento = fornoModeloEntrada.SegundosAquecimento,
                NomeAlimento = fornoModeloEntrada.NomeAlimento,
                Abreviacao = fornoModeloEntrada.Abreviacao
            };

            if ((fornoModeloEntrada.Potencia > 0) && (fornoModeloEntrada.SegundosAquecimento > 0))
            {
                if (_fornoServico.AdicionarNovoAlimento(forno).IsCompleted)
                    return Created("GetForno", forno);
                else
                    return BadRequest(_fornoServico.AdicionarNovoAlimento(forno).Exception);

            }
            else
            {
                return BadRequest("Entrada Invalida");
            }
        }
    }
}
