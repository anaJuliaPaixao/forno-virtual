using Forno_OttoHx.Dominio.Modelos;
using Forno_OttoHx.DTO;
using Forno_OttoHx.Servicos.Servicos.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Forno_OttoHx.Controllers
{
    [Route("api/[controller]")]
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
                SegundosAquecimento = fornoModeloEntrada.SegundosAquecimento
            };

            if (_fornoServico.Adicionar(forno).IsCompleted)
                return Created("GetForno", forno);
            else
                return BadRequest(_fornoServico.Adicionar(forno).Exception);

        }
        [HttpGet]
        public ActionResult<IEnumerable<Forno>> GetForno()
        {
            return _fornoServico.Listar();


        }
    }
}
