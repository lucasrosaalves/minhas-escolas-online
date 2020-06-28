using System;

namespace MEO.Application.DTOs
{
    public class TurmaDTO
    {
        public TurmaDTO(
            Guid id, 
            string codigo,
            TipoTurnoDTO tipoTurno,
            int quantidadeAlunos)
        {
            Id = id;
            Codigo = codigo;
            TipoTurno = tipoTurno;
            QuantidadeAlunos = quantidadeAlunos;
        }

        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public TipoTurnoDTO TipoTurno { get; set; }
        public int QuantidadeAlunos { get; set; }
    }
}
