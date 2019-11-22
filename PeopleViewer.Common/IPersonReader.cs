using System.Collections.Generic;

namespace PeopleViewer.Common
{
    //Creating the interface for the dependency injection
    public interface IPersonReader
    {
        IEnumerable<Person> GetPeople();
        Person GetPerson(int id);
    }
}
