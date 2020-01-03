using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Adapter
{
    public class Response
    {
        public class Person
        {
            public string gender { get; set; }
        }
        public List<Person> results { get; set; }

    }
    public class ApiPerson
    {
        private readonly IRestClient _restClient;
        public ApiPerson(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public string GetGender()
        {
            _restClient.BaseUrl = new Uri("https://randomuser.me");
            var request = new RestRequest("/api", Method.GET);

            var response = _restClient.Execute<Response>(request);

            return response.Data.results[0].gender;

        }
    }
}
