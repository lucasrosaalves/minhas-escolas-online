namespace MEO.Application.DTOs
{
    public class EnderecoDTO
    {
        public EnderecoDTO(
            string logradouro, 
            string numero, 
            string complemento, 
            string bairro, 
            string cep, 
            TipoLocalizacaoDTO tipoLocalizacao)
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cep = cep;
            TipoLocalizacao = tipoLocalizacao;
        }

        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }

        public string EnderecoCompleto {
            get
            {
                string final;
                final = string.Concat(Logradouro, ", ", Numero);

                if (!string.IsNullOrWhiteSpace(Complemento))
                {
                    final = string.Concat(final, " - ", Complemento);
                }

                if (!string.IsNullOrWhiteSpace(Bairro))
                {
                    final = string.Concat(final, " - ", Bairro);
                }
                if (!string.IsNullOrWhiteSpace(Cep))
                {
                    final = string.Concat(final, " - ", Cep);
                }

                return final;
            }
        }


        public TipoLocalizacaoDTO TipoLocalizacao { get; set; }

    }
}
