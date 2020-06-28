using MEO.Domain.DomainObjects;

namespace MEO.Domain.Enums
{
    public class TipoTurno : Enumeration
    {
        public static TipoTurno Manha = new TipoTurno(1, "Manhã");
        public static TipoTurno Tarde = new TipoTurno(2, "Tarde");
        public static TipoTurno Noite = new TipoTurno(3, "Noite");

        public TipoTurno(int id, string nome)
            : base(id, nome)
        {
        }

    }
}
