
using FluentValidation;
using MeuLivroDeReceitas.Comunicacao.Requisicoes;
using MeuLivroDeReceitas.Exceptions;
using System.Text.RegularExpressions;

namespace MeuLivroDeReceitas.Application.UseCase.Usuario.Registrar
{
    public class RegistrarUsuarioValidator : AbstractValidator<RequisicaoRegistrarUsuarioJson>
    {
        public RegistrarUsuarioValidator()
        {
            RuleFor(c => c.Nome).NotEmpty().WithMessage(ResourceMensagensDeErro.NOME_USUARIO_EM_BRANCO);
            RuleFor(c => c.Email).NotEmpty().WithMessage(ResourceMensagensDeErro.EMAIL_USUARIO_EM_BRANCO);
            RuleFor(c => c.Senha).NotEmpty().WithMessage(ResourceMensagensDeErro.SENHA_USUARIO_EM_BRANCO);
            RuleFor(c => c.Telefone).NotEmpty().WithMessage(ResourceMensagensDeErro.TELEFONE_USUARIO_EM_BRANCO);
            
            /* Usando o 'When' o meu validador de 'email válido' só será acionado se houver alguma coisa dentro do email. Em caso de 
             * e-mail vazio somente será acionado a validação de 'email vazio'. Ele recebe dois parâmetros: o primeiro é a condição
             * e o segundo uma função. Esta função pode ser uma arrow function, como pode ser também uma função desenvolvida la em baixo
             e eu apenas chamo ela aqui em cima. */
            When(c => !string.IsNullOrEmpty(c.Email), () =>
            {
                RuleFor(c => c.Email).EmailAddress().WithMessage(ResourceMensagensDeErro.EMAIL_USUARIO_INVALIDO);
            });

            When(c => !string.IsNullOrEmpty(c.Senha), () =>
            {
                RuleFor(c => c.Senha.Length).GreaterThanOrEqualTo(6).WithMessage(ResourceMensagensDeErro.SENHA_USUARIO_MINIMO_SEIS_CARACTERES);
            });

            When(c => !string.IsNullOrEmpty(c.Telefone), () =>
            {
                RuleFor(c => c.Telefone).Custom((telefone, contexto) =>
                {
                    string padraoTelefone = "[0-9]{2} [1-9]{1} [0-9]{4}-[0-9]{4}";
                    var isMatch = Regex.IsMatch(telefone, padraoTelefone);
                    if(!isMatch)
                    {
                        contexto.AddFailure(new FluentValidation.Results.ValidationFailure(nameof(telefone), ResourceMensagensDeErro.TELEFONE_USUARIO_INVALIDO));
                    }
                });
            });
        }
    }
}
