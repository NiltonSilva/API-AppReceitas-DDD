using MeuLivroDeReceitas.Comunicacao;
using MeuLivroDeReceitas.Exceptions;
using MeuLivroDeReceitas.Exceptions.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;

namespace MeuLivroDeReceitas.Api.Filtros
{
    public class FiltroDasExceptions : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if(context.Exception is MeuLivroDeReceitasException)
            {
                TratarMeuLivroDeReceitaException(context);
            }
        }
        private void TratarMeuLivroDeReceitaException(ExceptionContext context)
        {
            
            if(context.Exception is ErroDeValidacaoException)
            {
                TratarErrosDeValidacaoException(context);
            }
        }

        private void TratarErrosDeValidacaoException(ExceptionContext context)
        {
            var erroDeValidacaoException = context.Exception as ErroDeValidacaoException;

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Result = new ObjectResult(new RespostaErroJson(erroDeValidacaoException.MensagensDeErro));
        }

        private void LancarErroDesconhecido(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new ObjectResult(new RespostaErroJson(ResourceMensagensDeErro.ERRO_DESCONHECIDO));
        }
    }
}
