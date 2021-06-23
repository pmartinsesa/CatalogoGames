using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogo.Exceptions
{
    public class JogoNaoCadatradoException : Exception
    {
        public JogoNaoCadatradoException()
            : base("Este jogo não está cadastrado") { }
    }
}
