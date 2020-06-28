namespace MEO.Application.DTOs
{
    public class TipoLocalizacaoDTO
    {
        public TipoLocalizacaoDTO(
            int id, 
            string descricao)
        {
            Id = id;
            Descricao = descricao;
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
    }
}
