﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Comunicacao
{
    public class RespostaErroJson
    {
        public List<string> Mensagens { get; set; }

        public RespostaErroJson(string mensagem)
        {
            Mensagens = new List<string>
            {
                mensagem
            };
        }

        public RespostaErroJson(List<string> mensagens)
        {
            Mensagens = mensagens;
        }
    }
}
