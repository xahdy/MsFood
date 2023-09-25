namespace Cadastro.Domain.ValueObject
{
    public class Cnpj
    {
        public Cnpj(string numero)
        {
            Numero = numero;

            DocumentoApenasNumeros();
        }
        public string Numero { get; private set; }

        public void DocumentoApenasNumeros()
        {
            if (!string.IsNullOrEmpty(Numero))
            {
                Numero = Numero.Replace(".", "").Replace("-", "").Replace("/", "");
            }
        }

        public bool ValidarDocumento()
        {
            if (!string.IsNullOrEmpty(Numero) && Numero.Length == 14 && Numero.All(char.IsDigit))
            {
                return ValidarCnpj(Numero);
            }
            else
            {
                return false;
            }

        }

        private bool ValidarCnpj(string cnpj)
        {
            int[] multiplicador1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int soma = 0;
            for (int i = 0; i < 12; i++)
            {
                soma += (cnpj[i] - '0') * multiplicador1[i];
            }

            int resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;
            string digito = resto.ToString();

            soma = 0;
            for (int i = 0; i < 13; i++)
            {
                soma += (cnpj[i] - '0') * multiplicador2[i];
            }

            resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;
            digito += resto.ToString();

            return cnpj.EndsWith(digito);
        }
    }
}

