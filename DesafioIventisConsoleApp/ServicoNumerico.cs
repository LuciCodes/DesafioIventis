using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioIventisConsoleApp
{
    public static class ServicoNumerico
    {
        public static event EventHandler? Progresso;

        private static bool NumeroEhPrimo(int numero)
        {
            if (numero < 2) return false;

            for (int i = 2; i <= Math.Sqrt(numero); i++)
            {
                if (numero % i == 0) return false;
            }

            return true;
        }

        public static ResultadoDecomposicao DecomporNumero(int numero)
        {
            ResultadoDecomposicao resultado = new ResultadoDecomposicao();
            
            if (numero > 0 && numero <= int.MaxValue)
            {
                for (int i = 1; i <= numero; i++)
                {
                    Debug.WriteLine($"Verificando { i }");

                    if (numero % i == 0)
                    {
                        resultado.Divisores.Add(i);

                        if (NumeroEhPrimo(i))
                            resultado.DivisoresPrimos.Add(i);
                    }

                    Progresso?.Invoke((decimal)(i * 100 / (decimal)numero), new EventArgs());
                }
                
                Progresso?.Invoke(100, new EventArgs());
            }
            else if (numero <= 0)
            {
                resultado.Sucesso = false;
                resultado.MensagemErro = "A decomposição só pode ser efetuada em números positivos maiores que zero.";
            }
            else if (numero == int.MaxValue)
            {
                resultado.Sucesso = false;
                resultado.MensagemErro = $"A decomposição só pode ser efetuada em números positivos menores que { int.MaxValue - 1 }.";
            }

            return resultado;
        }
    }
}
