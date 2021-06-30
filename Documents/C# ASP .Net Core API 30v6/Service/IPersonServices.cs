using System.Collections.Generic;
using API30v6.Models;

public interface IPersonServices
{
    List<Person> GetAll();
    Person Get(int id);
    void AddPerson(Person person);
    void AddPeople(List<Person> person);
    bool Delete(int id);
    void Update(Person person);
    void Remove(Person person);
    List<Person> Filter(Person person);
}