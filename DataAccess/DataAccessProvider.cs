using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_Core_Application_1.Models;

namespace ASP.NET_Core_Application_1.DataAccess
{
    public class DataAccessProvider : IDataAccessProvider
    {
        private readonly DataContext _context;

        public DataAccessProvider(DataContext context)
        { _context = context; }
        public void AddPerson(PersonModel person) {
            _context.person.Add(person);
            _context.SaveChanges();
        }

        public void DeletePerson(int id){
            var entity = _context.person.FirstOrDefault(t => t.id == id);
            _context.person.Remove(entity);
            _context.SaveChanges();
        }

        public List<PersonModel> GetPerson(){
            return _context.person.ToList();
        }

        public PersonModel GetPersonSingleRecord(int id){
            return _context.person.FirstOrDefault(t=>t.id==id);
        }

        public void UpdatePerson(PersonModel person){
            _context.person.Update(person);
            _context.SaveChanges();
        }
    }
}
