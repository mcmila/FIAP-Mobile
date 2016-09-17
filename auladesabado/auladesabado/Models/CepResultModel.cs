using System;
using Newtonsoft.Json;

namespace auladesabado
{
	public class CepResultModel
	{
		[JsonProperty("cep")]
		public string cep { get; set; }

		[JsonProperty("logradouro")]
		public string logradouro { get; set; }

		[JsonProperty("complemento")]
		public string complemento { get; set; }

		[JsonProperty("bairro")]
		public string bairro { get; set; }

		[JsonProperty("localidade")]
		public string localidade { get; set; }

		[JsonProperty("uf")]
		public string uf { get; set; }

		public string unidade { get; set; }

		public string ibge { get; set; }

		public string gia { get; set; }

		public CepResultModel()
		{

		}
	}
}