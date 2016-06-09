using System;
using System.IO;

using RestSharp;



namespace MSG91
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			
			//			generateOTP("91","9999999999","")
			//verifyCode ("6375", "91", "9999999999", "");

		}
		public static void generateOTP(string countryCode, string mobileNumber, string appKey)
		{
			var client = new RestClient("https://sendotp.msg91.com/api/generateOTP");
			var request = new RestRequest(Method.POST);
			request.AddHeader("cache-control", "no-cache");
			request.AddHeader ("application-key", appKey);
			request.AddParameter("undefined", "{\n \"countryCode\": "+countryCode+",\n \"mobileNumber\": "+mobileNumber+",\n \"getGeneratedOTP\": true\n}", ParameterType.RequestBody);
			IRestResponse response = client.Execute(request);

			Console.WriteLine (response.Content);
		}

		public static void verifyCode( string verificationCode, string countryCode, string mobileNumber,string appKey){
			var client = new RestClient("https://sendotp.msg91.com/api/verifyOTP");
			var request = new RestRequest(Method.POST);
			request.AddHeader("cache-control", "no-cache");
			request.AddHeader ("application-key", appKey);
			request.AddParameter("undefined", "{\n \"countryCode\": "+countryCode+",\n \"mobileNumber\": "+mobileNumber+",\n \"oneTimePassword\": "+verificationCode+"\n}", ParameterType.RequestBody);
			IRestResponse response = client.Execute(request);

			Console.WriteLine (response.Content);
		}
	}
}
