using OrderingContext.Domain.Interfaces;

namespace OrderingContext.Domain.Repositories;

public interface IRepository<T> where T : AggregateRoot;
