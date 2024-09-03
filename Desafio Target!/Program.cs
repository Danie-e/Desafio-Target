using Desafio_Target_.Models;
using Newtonsoft.Json;

internal class Program
{
    private static void Main(string[] args)
    {
        QuestaoUm();
        Console.WriteLine(QuestaoDois(33));
        QuestaoTres("dados.json");
        QuestaoQuatro();
        QuestaoCinco("Palavra");
    }

    public static void QuestaoUm()
    {
        int indice = 13;
        int soma = 0;
        int k = 0;
        while (k < indice)
        {
            k++;
            soma += k;
        }
        Console.WriteLine("1) " + soma);
    }
    public static string QuestaoDois(int valor)
    {
        int primeiro = 0;
        int segundo = 1;
        int terceiro = 1;
        do
        {
            terceiro = primeiro + segundo;
            primeiro = segundo;
            segundo = terceiro;
        } while (terceiro < valor);
        if (terceiro == valor) return $"2) O valor {valor} pertence a sequencia de Fibonacci.";
        else return $"2) O valor {valor} não pertence a sequencia de Fibonacci.";
    }
    public static void QuestaoTres(string caminhoArquivo)
    {
        double menorFaturamento;
        double maiorFaturamento = 0;
        double diasComFaturamento = 0;
        double mediaMensal = 0;

        StreamReader arquivo = new StreamReader(caminhoArquivo);
        string json = arquivo.ReadToEnd();
        List<Datas> calendarioFaturamento = JsonConvert.DeserializeObject<List<Datas>>(json);
        arquivo.Close();

        menorFaturamento = calendarioFaturamento[0].valor;

        foreach (Datas item in calendarioFaturamento)
        {
            if (item.valor == null || item.valor == 0) continue;

            if (item.valor < menorFaturamento)
                menorFaturamento = item.valor;

            if (item.valor > maiorFaturamento)
                maiorFaturamento = item.valor;

            diasComFaturamento++;
            mediaMensal = item.valor;
        }

        int diasMaiorMedia = CalcularDiasMaioresMediaDeFaturamento(diasComFaturamento, calendarioFaturamento, mediaMensal);

        Console.WriteLine($@"3) O valor do menor faturamento no mes foi de R$ {menorFaturamento}.
   O valor do maior faturamento no mes foi de R$ {maiorFaturamento}.
   A quantidade de dias que o faturamento foi superior à média mensal são {diasMaiorMedia} dias.");

    }

    public static void QuestaoQuatro()
    {
        double SP = 67836.43;
        double RJ = 36678.66;
        double MG = 29229.88;
        double ES = 27165.48;
        double outros = 1984.53;

        double FaturamentoTotal = SP + RJ + MG + ES + outros;

        double porcentagemSP = (SP / FaturamentoTotal) * 100;
        double porcentagemRJ = (RJ / FaturamentoTotal) * 100;
        double porcentagemMG = (MG / FaturamentoTotal) * 100;
        double porcentagemES = (ES / FaturamentoTotal) * 100;
        double porcentagemOutros = (outros / FaturamentoTotal) * 100;

        //Console.WriteLine(FaturamentoTotal);

        Console.WriteLine($"4) O percentual de representação que o estado SP teve dentro do valor total mensal da distribuidora foi de {porcentagemSP:F2}%");
        Console.WriteLine($"   O percentual de representação que o estado RJ teve dentro do valor total mensal da distribuidora foi de {porcentagemRJ:F2}%");
        Console.WriteLine($"   O percentual de representação que o estado MG teve dentro do valor total mensal da distribuidora foi de {porcentagemMG:F2}%");
        Console.WriteLine($"   O percentual de representação que o estado ES teve dentro do valor total mensal da distribuidora foi de {porcentagemES:F2}%");
        Console.WriteLine($"   O percentual de representação que outros estados tiveram dentro do valor total mensal da distribuidora foi de {porcentagemOutros:F2}%");

    }

    public static void QuestaoCinco(string palavra)
    {
        string palavraReversa = string.Empty;
        for (int i = palavra.Length - 1; i >= 0; i--)
        {
            palavraReversa = palavraReversa + palavra[i];
        }
        Console.WriteLine($"5) {palavraReversa}");
    }


    private static int CalcularDiasMaioresMediaDeFaturamento(double diasComFaturamento, List<Datas> calendarioFaturamento, double mediaMensal)
    {
        double mediaFaturamento = mediaMensal / diasComFaturamento;
        int diasFaturamentoMaiorMedia = 0;

        foreach (Datas item in calendarioFaturamento)
        {
            if (item.valor > mediaFaturamento)
                diasFaturamentoMaiorMedia++;
        }
        return diasFaturamentoMaiorMedia;
    }
}