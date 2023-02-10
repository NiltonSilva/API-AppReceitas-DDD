using MeuLivroDeReceitas.Application.UseCase.Usuario.Registrar;
using MeuLivroDeReceitas.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : Controller
    {
        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> Get()
        {
            var usecase = new RegistrarUsuarioUseCase();
            await usecase.Executar(new Comunicacao.Requisicoes.RequisicaoRegistrarUsuarioJson { 
                
            });

            //var mensagem = ResourceMensagensDeErro.NOME_USUARIO_EM_BRANCO;
            return Ok();
        }
    }
}
