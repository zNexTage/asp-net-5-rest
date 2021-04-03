using HttpVerbs.Model;
using HttpVerbs.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HttpVerbs.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private MysqlContext _context;

        public List<Person> FindAll()
        {
            return _context.People.ToList();
        }

        public Person FindById(long id)
        {
            return _context.People.SingleOrDefault(p => p.Id == id);
        }

        public PersonServiceImplementation(MysqlContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch(Exception err)
            {
                throw err;
            }

            return person;
        }

        public void Delete(long id)
        {
            Person result = _context.People.SingleOrDefault(p => p.Id == id);

            if (result != null)
            {
                try
                {
                    _context.People.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception err)
                {
                    throw err;
                }
            }
        }

        public Person Update(Person person)
        {
            if (!Exists(person.Id)) return new Person();
            
            Person result = _context.People.SingleOrDefault(p => p.Id == person.Id);

            if(result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception err)
                {
                    throw err;
                }
            }           

            return person;
        }

        private bool Exists(long id)
        {
            return _context.People.Any(p => p.Id == id);
        }
    }
}
