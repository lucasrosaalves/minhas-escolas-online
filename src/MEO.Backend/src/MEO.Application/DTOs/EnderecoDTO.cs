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
        public TipoLocalizacaoDTO TipoLocalizacao { get; set; }

    }
}
