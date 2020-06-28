using FluentValidation.Results;
using MediatR;
using MEO.Application.ApplicationObjects;
using MEO.Common.Extensions;
using MEO.Domain.Entities;
using MEO.Domain.Repositories;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MEO.Application.Commands.Handlers
{
    public class CriarTurmaCommandHandler : CommandHandler, IRequestHandler<CriarTurmaCommand, ValidationResult>
    {
        private readonly IEscolaRepository _escolaRepository;

        public CriarTurmaCommandHandler(IEscolaRepository escolaRepository)
        {
            _escolaRepository = escolaRepository;
        }

        public async Task<ValidationResult> Handle(CriarTurmaCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                return request.ValidationResult;
            }

            var escola = await _escolaRepository.ObterEscolaPorIdAsync(request.EscolaId, true);

            if(escola is null)
            {
                AddErro("Escola inválida");

                return ValidationResult;
            }

            if(escola.Turmas.HasAny() && escola.Turmas.Any(t => t.Codigo == request.Codigo))
            {
                AddErro("Turma já cadastrada");

                return ValidationResult;
            }

            var turma = new Turma(request.Codigo, 
                request.TipoTurnoId, request.QuantidadeAlunos, request.EscolaId);


            await _escolaRepository.AdicionarAsync(turma);

            var result = await _escolaRepository.UnitOfWork.CommitAsync();

            if (!result)
            {
                AddErro("Ocorreu um erro inesperado no sistema");
            }

            return ValidationResult;

        }
    }
}
