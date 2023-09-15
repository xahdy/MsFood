﻿using Cadastro.Domain.ValueObject;

namespace Cadastro.Domain.Models.Dto
{
    public class RestauranteDto
    {
        public RestauranteDto(string proprietario, string nome, Cnpj cnpj, LocalizacaoDto localizacao)
        {
            Proprietario = proprietario;
            Nome = nome;
            Cnpj = cnpj;
            Localizacao = localizacao;
        }

        public string Proprietario { get; private set; }
        public string Nome { get; private set; }
        public Cnpj Cnpj { get; private set; }
        public LocalizacaoDto? Localizacao { get; private set; }
    }
}