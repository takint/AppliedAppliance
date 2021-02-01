namespace Application.IntegrationTests.Agents
{
    using Application.Agents.Queries;
    using NUnit.Framework;
    using System.Threading.Tasks;
    using static Testing;
    public class GetAgentsTests : TestBase
    {
        [Test]
        public async Task ShouldReturnAllLists()
        {
            // TODO: Add integration later on with a mock database
            //await AddAsync(new School
            //{
            //    Name = "Test School"
            //});

            var query = new GetAgentQuery();

            var result = await SendAsync(query);
        }
    }
}
