using MEO.Domain.DomainObjects;

namespace MEO.Domain.Enums
{
    public class TipoLocalizacao : Enumeration
    {
        public static TipoLocalizacao Urbana = new TipoLocalizacao(1, "Urbana");
        public static TipoLocalizacao Rural = new TipoLocalizacao(2, "Rural");

        public TipoLocalizacao(int id, string nome)
            : base(id, nome)
        {
        }

    }
}
