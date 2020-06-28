using MediatR;
using MEO.Domain.Entities;
using System.Collections.Generic;

namespace MEO.Application.Queries
{
    public class ObterTodasEscolasQuery : IRequest<List<Escola>>
    {
    }
}
