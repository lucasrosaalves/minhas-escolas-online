namespace MEO.Application.DTOs
{
    public class ContatoDTO
    {
        public ContatoDTO(
            string telefone, 
            string email, 
            string site)
        {
            Telefone = telefone;
            Email = email;
            Site = site;
        }

        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Site { get; set; }
    }
}
