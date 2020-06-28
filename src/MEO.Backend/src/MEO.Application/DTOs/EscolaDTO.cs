using System;
using System.Collections.Generic;
using System.Linq;

namespace MEO.Application.DTOs
{
    public class EscolaDTO
    {
        public EscolaDTO(Guid id,
            string nome,
            string codigo,
            ContatoDTO contato,
            EnderecoDTO endereco,
            int quantidadeTurmas)
        {
            Id = id;
            Nome = nome;
            Codigo = codigo;
            Contato = contato;
            Endereco = endereco;
            QuantidadeTurmas = quantidadeTurmas;
            Turmas = new List<TurmaDTO>();
        }

        public EscolaDTO(Guid id,
            string nome, 
            string codigo,
            ContatoDTO contato,
            EnderecoDTO endereco,
            IEnumerable<TurmaDTO> turmas)
        {
            Id = id;
            Nome = nome;
            Codigo = codigo;
            Contato = contato;
            Endereco = endereco;
            Turmas = turmas?.ToList() ?? new List<TurmaDTO>();
            QuantidadeTurmas = turmas?.Count() ?? 0;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public ContatoDTO Contato { get; set; }
        public EnderecoDTO Endereco { get; set; }
        public int QuantidadeTurmas { get; set; }
        public List<TurmaDTO> Turmas { get; set; }
    }
}
