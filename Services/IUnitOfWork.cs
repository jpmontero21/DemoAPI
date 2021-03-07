using DemoAPI.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Services
{
    public interface IUnitOfWork
    {
        IRepository<Person> Persons { get; }

        void Save();
    }
}
