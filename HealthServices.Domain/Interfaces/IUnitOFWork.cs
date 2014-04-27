using System;
using HealthServices.Domain.Models;

namespace HealthServices.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Person> PersonRepository { get; }

        void Commit();
    }
}
