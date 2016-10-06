using System;
namespace auladesabado
{
	public enum Gender
	{ 
		Mulher,
		Homem
	}

	public class Person : BaseItem
	{
		public string FirstName
		{
			get;
			set;
		}

		public string LastName
		{
			get;
			set;
		}
		public int Age
		{
			get;
			set;
		}

		public Gender Gender
		{
			get;
			set;
		}

		public override string ToString()
		{
			return string.Format("[Person: FirstName={0}, LastName={1}, Age={2}, Gender={3}]", FirstName, LastName, Age, Gender.ToString());
		}

		public Person()
		{
		}
	}
}