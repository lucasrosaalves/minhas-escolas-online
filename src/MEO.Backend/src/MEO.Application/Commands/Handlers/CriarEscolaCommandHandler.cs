using FluentValidation.Results;
using MediatR;
using MEO.Application.ApplicationObjects;
using MEO.Domain.Entities;
using MEO.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace MEO.Application.Commands.Handlers
{
    public class CriarEscolaCommandHandler : CommandHandler, IRequestHandler<CriarEscolaCommand, ValidationResult>
    {
        private readonly IEscolaRepository _escolaRepository;

        public CriarEscolaCommandHandler(IEscolaRepository escolaRepository)
        {
            _escolaRepository = escolaRepository;
        }

        public async Task<ValidationResult> Handle(CriarEscolaCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                return request.ValidationResult;
            }

            var escolaBanco = await _escolaRepository.ObterEscolaPorCodigoAsync(request.Codigo);

            if(!(escolaBanco is null))
            {
                AddErro("Escola já cadastrada");

                return ValidationResult;
            }

            var endereco = new Endereco(request.Logradouro,
                request.Numero, request.Complemento, request.Bairro, request.Cep, request.TipoLocalizacaoId);

            var contato = new Contato(request.Telefone, request.Email, request.Site);

            var escola = new Escola(request.Nome, request.Codigo, endereco, contato);

            await _escolaRepository.AdicionarAsync(escola);

            var result = await _escolaRepository.UnitOfWork.CommitAsync();

            if (!result)
            {
                AddErro("Ocorreu um erro inesperado no sistema");
            }

            return ValidationResult;

        }
    }
}
