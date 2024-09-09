using System.ComponentModel.DataAnnotations.Schema;

namespace Acesv.Models

{
    public enum Categoria
    {

        D,
        AD
    }
    public class Dados
    {

        public int Id { get; set; }
        public List<int> EscolaId { get; set; }

        public string Telefone { get; set; }
        public string Placa { get; set; }
        public string NomeCompleto { get; set; }
        public string Apelido { get; set; }
        public string Cpf { get; set; }
        public DateTime Data_Nascimento { get; set; }
        public string Prefixo { get; set; }
        public string Bairros { get; set; }
        public string Veiculo { get; set; }
        public int Ano { get; set; }
        public string Cnh { get; set; }
        [NotMapped]
        public IFormFile FotoCnh { get; set; }
        public Categoria CategoriaSelecionada { get; set; }
        public DateTime Validade { get; set; }

        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Número { get; set; }
        public string Complemento { get; set; }


        public virtual Escola Escola { get; set; }
        public string EscolasSelecionadas { get; set; }

    }
}