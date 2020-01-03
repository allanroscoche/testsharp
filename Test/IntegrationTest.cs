using RestSharp;
using Xunit;
using Adapter;

namespace Test
{
    public class IntegrationTest
    {
        [Fact]
        public void ShouldReturnOk()
        {
            var client = new RestClient();
            var api = new ApiPerson(client);

            var gender = api.GetGender();

            Assert.NotNull(gender);

        }
    }
}
