using System;
using System.IO;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(auladesabado.iOS.SQLiteService))]
namespace auladesabado.iOS
{
	public class SQLiteService : ISQLiteService
	{
		string GetPath(string dataBaseName)
		{
			if (string.IsNullOrWhiteSpace(dataBaseName))
			{
				throw new ArgumentException("Database inválido", nameof(dataBaseName));
			}

			var sqliteFileName = $"{dataBaseName}.db3";
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var libraryPath = Path.Combine(documentsPath, "..", "Library");
			var path = Path.Combine(libraryPath,sqliteFileName);

			return path;
		}

		public SQLiteService()
		{
		}

		public SQLiteConnection GetConnection(string databaseName)
		{
			return new SQLiteConnection(GetPath(databaseName));
		}

		public long GetSize(string databaseName)
		{
			var fileInfo = new FileInfo(GetPath(databaseName));
			return fileInfo != null ? fileInfo.Length : 0;
		}
	}
}
