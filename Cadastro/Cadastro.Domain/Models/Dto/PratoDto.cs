namespace Cadastro.Domain.Models.Dto
{
    public class PratoDto
    {
        public PratoDto(string nome, string descricao, decimal preco)
        {
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public RestauranteDto? Restaurante { get; private set; }
        public decimal Preco { get; private set; }
    }
}
