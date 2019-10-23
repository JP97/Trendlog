using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace Trendlogg.Utilities
{
	public class ApiObjectPopulater<T>
	{
		private T model;
		public string Address { get; set; }
		public List<string> Headers { get; set; }

		public ApiObjectPopulater(T Model)
		{
			model = Model;
		}

		public T PopulateModel()
		{
			string json = GetJsonData();
			JsonConvert.PopulateObject(json, model);
			return model;
		}

		private string GetJsonData()
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Address);
			request.Method = "GET";
			foreach (string h in Headers)
			{
				request.Headers.Add(h);
			}
			string json;
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			using (StreamReader reader = new StreamReader(response.GetResponseStream()))
			{
				json = reader.ReadToEnd();
			}
			return json;
		}
	}
}