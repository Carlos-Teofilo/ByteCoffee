using System;
using MediatR;

namespace CatalogContext.Application.UseCases.GetById;

public record Request(Guid Id) : IRequest<Response>;
