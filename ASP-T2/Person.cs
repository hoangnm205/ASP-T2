using System;
namespace ASP_T2
{
	public class PersonDTO
	{
		public string Name { get; set; }
		public int Age { get; set; }
		public PersonDTO()
		{
		}

        public PersonDTO(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}

