using DemoAPI.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private DemoAPIContext _context;
        private BaseRepository<Person> _person;

        public UnitOfWork(DemoAPIContext context)
        {
            this._context = context;
        }

        public IRepository<Person> Persons 
        {
            get 
            {
                return _person ?? (_person = new BaseRepository<Person>(_context));
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
