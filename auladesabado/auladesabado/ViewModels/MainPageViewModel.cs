using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace auladesabado
{
	public class MainPageViewModel : BaseViewModel
	{
		readonly Database dataBase;

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Age { get; set; }
		public int GenderIndex { get; set; } = -1;
		public ObservableCollection<string> Records { get; set; }

		public ICommand AddCommand { get; set; }
		public ICommand DeleteCommand
		{
			get;
			set;
		}
		public ICommand DeleteAllCommand
		{
			get;
			set;
		}
		public ICommand GenderCommand
		{
			get;
			set;
		}
		public ICommand AgeFilterCommand
		{
			get;
			set;
		}

		public MainPageViewModel()
		{
			AddCommand = new Command(Add);
			DeleteCommand = new Command(Delete);
			DeleteAllCommand = new Command(DeleteAll);
			GenderCommand = new Command(FilterByGender);
			AgeFilterCommand = new Command(FilterByAge);

			//caso nao exista ele cria a base
			dataBase = new Database("People");
			//caso nao exista ele cria a tabela
			dataBase.CreateTable<Person>();

			Records = new ObservableCollection<string>();

			ShowAllRecords();
		}

		void Add()
		{
			int age;
			if (int.TryParse(Age, out age))
			{
				var record = new Person
				{
					FirstName = FirstName,
					LastName = LastName,
					Age = age,
					Gender = GenderIndex == 0 ? Gender.Mulher : Gender.Homem
				};

				dataBase.SaveItem(record);
				Records.Add(record.ToString());
				RaisePropertyChanged(nameof(Records));
				ClearForm();
			}
		}

		void Delete(object obj)
		{
			var itemString = (string)obj;
			var columns = itemString.Split(',').Select(i => i.Trim()).ToList();
			int id;
			if (int.TryParse(columns[0], out id))
			{
				dataBase.DeleteItem<Person>(id);
				Records.Clear();
			}

		}

		void DeleteAll()
		{
			dataBase.DeleteAll<Person>();
			Records.Clear();
		}

		void FilterByAge(object obj)
		{
			int age;
			if (int.TryParse((string)obj, out age))
			{
				var results = dataBase.Query<Person>("SELECT * FROM Person WHERE Age > ?",
				                                     new object[] { age });
				Records.Clear();

				foreach (var person in results)
				{
					Records.Add(person.ToString());
				}
			}
		}

		void FilterByGender(object obj)
		{
			var gender = ((string)obj) == "Mulher" ? Gender.Mulher : Gender.Homem;
			var result = dataBase.Query<Person>("SELECT * FROM Person WHERE Gender = ?", new object[] { gender });

			Records.Clear();
			foreach (var person in result)
				Records.Add(person.ToString());
		}

		void ClearForm()
		{
			FirstName = string.Empty;
			LastName = string.Empty;
			Age = string.Empty;
			GenderIndex = -1;
			RaisePropertyChanged(nameof(FirstName));
			RaisePropertyChanged(nameof(LastName));
			RaisePropertyChanged(nameof(Age));
			RaisePropertyChanged(nameof(GenderIndex));
		}

		void ShowAllRecords()
		{
			Records.Clear();
			var people = dataBase.GetItems<Person>();

			foreach (var person in people)
			{
				Records.Add(person.ToString());
			}
		}
	}
}