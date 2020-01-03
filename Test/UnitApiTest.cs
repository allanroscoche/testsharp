using RestSharp;
using Xunit;
using Adapter;
using Moq;
using System.Collections.Generic;

namespace Test
{
    public class UnitApiTest
    {
        private RestResponse<Response> CreateResponse()
        {
            var person = new Response.Person { gender = "male" };
            var response = new Response { results = new List<Response.Person> { person }};
            var restResponse = new RestResponse<Response>();
            restResponse.Data = response;
            return restResponse;
        }
        [Fact]
        public void ShouldReturnOk()
        {
            var moqClient = new Mock<IRestClient>();
            var response = CreateResponse();
            moqClient.Setup(c => c.Execute<Response>(
                It.Is<RestRequest>(r => r.Parameters.Count == 0)
            )).Returns(response);
            var client = moqClient.Object;
            var api = new ApiPerson(client);

            var gender = api.GetGender();

            Assert.NotNull(gender);

        }
    }
}
