namespace Cadastro.Domain.Models
{
    public class Localizacao : BaseEntity
    {
        public Localizacao(string cep, string endereco, double latitude, double longitude)
        {
            Cep = cep;
            Endereco = endereco;
            Latitude = latitude;
            Longitude = longitude;
        }

        public string Cep { get; private set; }
        public string Endereco { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
    }
}
