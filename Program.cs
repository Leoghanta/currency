using RestSharp;
using System;
using System.Net;
using System.Xml;
using Newtonsoft.Json;
using System.Runtime.InteropServices;

namespace currency
{
	internal class response
	{

	}



	internal class Program
	{

		static string convert()
		{
			var client = new RestClient("https://openexchangerates.org/api/latest.json?app_id=ab216df194d2467d9fd3fdb3b352700c");
			var request = new RestRequest();
			request.AddHeader("accept", "application/json");
			RestResponse response = client.Execute(request);
			if (response.StatusCode == HttpStatusCode.OK)
			{
				return response.Content;
			} else
			{
				throw new HttpRequestException();
			}
        }

		static void Main(string[] args)
		{
			try
			{
				var json = convert();
				//Console.WriteLine(json);
				int ratesindex = json.IndexOf("\"rates\": ") +9;
				int length = json.Length;
				int size_rates = length - ratesindex;
				Console.WriteLine(ratesindex);
				string ratesJson = json.Substring(ratesindex, size_rates);
                Console.WriteLine(ratesJson);
                var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(ratesJson);

                Console.WriteLine(values.ContainsKey("GBP"));

				 
            } catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}
	}
}