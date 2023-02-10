using MeuLivroDeReceitas.Comunicacao.Requisicoes;

namespace MeuLivroDeReceitas.Application.UseCase.Usuario.Registrar
{
    public class RegistrarUsuarioUseCase
    {
        public Task Executar(RequisicaoRegistrarUsuarioJson requisiao)
        { 
            
        }

        private void Validar(RequisicaoRegistrarUsuarioJson requisiao)
        { 
            var validator = new RegistrarUsuarioValidator();
            var resultado = validator.Validate(requisiao);

            if (resultado.IsValid)
            {
                var mensagensDeErro = resultado.Errors.Select(erro => erro.ErrorMessage);
                throw new Exception();
            }
        }
    }
}
