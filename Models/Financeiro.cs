namespace Acesvv.Models
{

    public enum Mes
    {

        Janeiro, Fevereiro, Março, Abril, Maio, Junho, Julho, Agosto, Setembro, Outubro, Novembro, Dezembro
    }
    public class Financeiro
    {
        public int ID { get; set; }
        public string Mes { get; set; }
        public string Saldo_Mes { get; set; }
        public string Arrecadacao_Mensalidade_Atrasada { get; set; }
        public string Arrecadacao_Mensalidade_Antecipadas { get; set; }
        public double Total_Entradas { get; set; }
        public string Vencimento { get; set; }
        public string Contabilidade { get; set; }
        public string Tarifa_Bancaria { get; set; }
        public string Apolice_Seguro { get; set; }
        public string Advogada { get; set; }
        public string Renovacao_Assinatura { get; set; }
        public string Taxas_Bancarias { get; set; }
        public string Taxa_Internet { get; set; }
        public double Total_Gastos { get; set; }
        public double Total_Liquido { get; set; }


    }
}
