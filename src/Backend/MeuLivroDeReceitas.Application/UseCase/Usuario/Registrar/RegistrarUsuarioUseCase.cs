using MeuLivroDeReceitas.Comunicacao.Requisicoes;
using MeuLivroDeReceitas.Exceptions.ExceptionsBase;

namespace MeuLivroDeReceitas.Application.UseCase.Usuario.Registrar
{
    public class RegistrarUsuarioUseCase
    {
        public async Task Executar(RequisicaoRegistrarUsuarioJson requisicao)
        {
            Validar(requisicao);

            //salvar no banco de dados
        }

        private void Validar(RequisicaoRegistrarUsuarioJson requisicao)
        { 
            var validator = new RegistrarUsuarioValidator();
            var resultado = validator.Validate(requisicao);

            if (!resultado.IsValid)
            {
                var mensagensDeErro = resultado.Errors.Select(erro => erro.ErrorMessage).ToList();
                throw new ErroDeValidacaoException(mensagensDeErro);
            }
        }
    }
}
