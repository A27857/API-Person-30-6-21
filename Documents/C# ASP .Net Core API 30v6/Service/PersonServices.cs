using API30v6.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API30v6.Services
{
    public class PersonServices : IPersonServices
    {
        static List<Person> _persons = new List<Person>()
            {
                new Person{
                Id = 18,
                FirstName = "Long",
                LastName = "Bao",
                Gender = "Male",
                BirthPlace = "Bac Ninh"
            },
            new Person{
                Id = 14,
                FirstName = "Dat",
                LastName = "Dam Tuan",
                Gender = "Male",
                BirthPlace = "Ha noi"
            },
            new Person{
                Id = 11,
                FirstName = "Hung",
                LastName = "Ngo Quoc",
                Gender = "Male",
                BirthPlace = "Hai Phong"
            }
            };
        static int nextId = 4;

        public List<Person> GetAll()
        {
            return _persons;
        }

        public Person Get(int id)
        {
            var item = _persons.FirstOrDefault(p => p.Id == id);
            return item;
        }

        public void AddPerson(Person person)
        {
            person.Id = nextId++;
            _persons.Add(person);
        }

        public void AddPeople(List<Person> person)
        {
            for (var i = 0; i < person.Count; i++)
            {
                person[i].Id = nextId++;
                _persons.Add(person[i]);
            }
        }

        public bool Delete(int id)
        {
            var temp = Get(id);
            if (temp is null)
            {
                return false;
            }
            _persons.Remove(temp);
            return true;
        }

        public void Update(Person person)
        {
            var index = _persons.FindIndex(p => p.Id == person.Id);
            if (index == -1)
                return;

            _persons[index] = person;
        }

        public void Remove(Person person)
        {
            _persons.Remove(person);
        }

        public List<Person> Filter(Person person)
        {
            return _persons.Where(x =>
            (!string.IsNullOrEmpty(person.LastName) && x.LastName.Equals(person.LastName, StringComparison.CurrentCultureIgnoreCase)) ||
            (!string.IsNullOrEmpty(person.FirstName) && x.FirstName.Equals(person.FirstName, StringComparison.CurrentCultureIgnoreCase)) ||
            (!string.IsNullOrEmpty(person.BirthPlace) && x.BirthPlace.Equals(person.BirthPlace, StringComparison.CurrentCultureIgnoreCase)) ||
            (!string.IsNullOrEmpty(person.Gender) && x.Gender.Equals(person.Gender, StringComparison.CurrentCultureIgnoreCase))).ToList();
        }
    }
}