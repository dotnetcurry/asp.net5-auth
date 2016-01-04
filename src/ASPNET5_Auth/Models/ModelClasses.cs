using System.Collections.Generic;

namespace ASPNET5_Auth.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string PersonName { get; set; }
    }

    public class PersonDatabase : List<Person>
    {
        public PersonDatabase()
        {
            Add(new Person() { PersonId=1,PersonName="MS"});
            Add(new Person() { PersonId = 2, PersonName = "SA" });
            Add(new Person() { PersonId = 3, PersonName = "VP" });
        }
    }
}
