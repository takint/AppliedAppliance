using Application.Schools.Queries;
using Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Application.IntegrationTests.Schools
{
    using static Testing;

    public class GetSchoolsTests:TestBase
    {
        [Test]
        public async Task ShouldReturnAllLists()
        {
            // TODO: Add integration later on with a mock database
            //await AddAsync(new School
            //{
            //    Name = "Test School"
            //});

            var query = new GetSchoolQuery();

            var result = await SendAsync(query);

            result.Lists.Should().HaveCount(0);
        }
    }
}
