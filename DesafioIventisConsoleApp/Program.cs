namespace DesafioIventisConsoleApp
{
    internal class Program
    {
        static int numero;
        
        // 17 é o tamanho da string (com padding) utilizada na mensagem "XXXXX divisores: "
        static int CONST_ESPACAMENTO = 17;

        // 10 é um número arbitrário de quando houver 10 ou mais divisores o programa exibe na tela
        // os resultados tabulados para ficar melhor a leitura
        static int CONST_TABULA_RESULTADOS_A_PARTIR_DE = 10;

        static void Main(string[] args)
        {
            string entrada = "";

            ServicoNumerico.Progresso += ServicoNumerico_Progresso;

            while (entrada != "S")
            {
                Console.WriteLine("Digite o número que deseja decompor ou 'S' para sair.");

                entrada = $"{ Console.ReadLine()?.ToUpper() }";

                if (int.TryParse(entrada, out numero))
                {
                    Console.Write($"Decompondo { numero }...");

                    var resultado = ServicoNumerico.DecomporNumero(numero);

                    if (resultado.Sucesso)
                    {
                        Console.Write($"\r\n{resultado.Divisores.Count, 5} divisores: ");

                        ExibirLista(resultado.Divisores, CONST_ESPACAMENTO);   
                    
                        Console.Write($"{resultado.DivisoresPrimos.Count, 4} são primos");
                    
                        if (resultado.DivisoresPrimos.Count > 0)
                        {
                            Console.Write(": ");
                            Console.WriteLine(string.Join(", ", resultado.DivisoresPrimos));
                        }
                        else
                        {
                            // o número 1 é um caso válido que não tem divisores primos.
                            Console.WriteLine(".");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"\r\nErro: { resultado.MensagemErro }");
                    }
                }
                else if (entrada != "S")
                {
                    Console.WriteLine($"Valor inválido, por favor utilize um número inteiro maior que zero e menor que { int.MaxValue }.");
                }
                
                Console.WriteLine(Environment.NewLine);
            }
        }

        private static void ExibirLista(List<int> lista, int espacamento)
        {
            if (lista.Count < CONST_TABULA_RESULTADOS_A_PARTIR_DE)
            {
                //lista em linha simples para poucos valores
                Console.WriteLine(string.Join(", ", lista));
            }
            else
            {
                // lista tabulada de 5 em 5
                for (int l = 0; l < lista.Count; l+= 5)
                {
                    if (l > 0) Console.Write("".PadLeft(espacamento, ' '));

                    for (int c = 0; c < 5; c++)
                    {
                        if (l + c < lista.Count)
                            Console.Write(lista[l + c] + ", ");
                    }
                    
                    Console.WriteLine();
                }
            }
        }

        private static void ServicoNumerico_Progresso(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                decimal pct = Convert.ToDecimal(sender);
                
                if (pct < 100)
                {
                    Console.Write($"\rDecompondo { numero }... {pct:n4}% (Ctrl+C para interromper e fechar)");
                }
                else
                {
                    Console.Write($"\rDecompondo { numero }... pronto.");
                }
            }
        }
    }
}
