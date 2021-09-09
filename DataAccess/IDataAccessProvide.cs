using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_Core_Application_1.Models;

namespace ASP.NET_Core_Application_1.DataAccess
{
    public interface IDataAccessProvider
    {
        void AddPerson(PersonModel person);
        void UpdatePerson(PersonModel person);
        void DeletePerson(int id);
        PersonModel GetPersonSingleRecord(int id);
        List<PersonModel> GetPerson();
    }
}
