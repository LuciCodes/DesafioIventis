using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioIventisConsoleApp
{
    public class ResultadoDecomposicao
    {
        /// <summary>
        /// Contém os divisores do número decomposto
        /// </summary>
        public List<int> Divisores { get; set; } = new List<int>();

        /// <summary>
        /// Contém os divisores que forem primos dentro da lista de divisores
        /// </summary>
        public List<int> DivisoresPrimos { get; set; } = new List<int>();

        /// <summary>
        /// Flag se a operação foi realizada com sucesso
        /// </summary>
        public bool Sucesso { get; set; } = true;
        
        /// <summary>
        /// Mensagem de erro caso haja
        /// </summary>
        public string? MensagemErro { get; set; }
    }
}
