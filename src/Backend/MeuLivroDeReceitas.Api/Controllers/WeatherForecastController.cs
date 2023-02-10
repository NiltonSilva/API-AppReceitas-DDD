using MeuLivroDeReceitas.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace MeuLivroDeReceitas.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : Controller
    {
        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        {
            var mensagem = ResourceMensagensDeErro.NOME_USUARIO_EM_BRANCO;
            return Ok();
        }
    }
}
