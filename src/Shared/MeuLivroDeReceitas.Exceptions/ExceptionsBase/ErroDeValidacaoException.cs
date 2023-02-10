using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Exceptions.ExceptionsBase
{
    public class ErroDeValidacaoException : MeuLivroDeReceitasException
    {
        public List<string> MensagensDeErro { get; set; }

        public ErroDeValidacaoException(List<String> mensagensDeErro)
        {
            MensagensDeErro = mensagensDeErro;
        }
    }
}
