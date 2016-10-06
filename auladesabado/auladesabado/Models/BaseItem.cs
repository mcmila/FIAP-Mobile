using System;
using SQLite;

namespace auladesabado
{
	public class BaseItem
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		public BaseItem()
		{

		}
	}
}
