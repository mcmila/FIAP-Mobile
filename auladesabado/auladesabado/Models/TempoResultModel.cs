using System;
namespace auladesabado
{
	public class TempoResultModel
	{
		public TempoResultModel()
		{
			
		}

		public WeatherObservation weatherObservation
		{
			get;
			set;
		}

		public class WeatherObservation
		{
			public string temperature { get; set; }
			public string stationName { get; set; }
		}
	}
}