
using FakeItEasy;
using FluentAssertions;
using FluentAssertions.Extensions;
using NetworkUtility.DNS;
using NetworkUtility.Ping;
using System.Net.NetworkInformation;

namespace NetworkUtility.Tests.PingTests
{
    public class NetworkServiceTests
    {
        private readonly NetworkService _pingService;
        private readonly IDNS _dns;

        public NetworkServiceTests()
        {

            // Dependencies
            _dns = A.Fake<IDNS>();

            // SUT - System under test
            _pingService = new NetworkService(_dns);
        }

        [Fact]
        public void NetworkService_SendPing_ReturnString()
        {
            //Arrange - variables, classes, mocks
            //var pingService = new NetworkService();
            A.CallTo(() => _dns.SendDNS()).Returns(true);

            //Act
            var result = _pingService.SendPing();

            //Assert
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be("Success: Ping Sent!");
            result.Should().Contain("Success", Exactly.Once());
        }

        [Theory] // allow passing of variables
        [InlineData(1, 2, 3)]
        public void NetworkService_PingTimeout_ReturnInt(int a, int b, int expected)
        {
            //Arrange
            //var pingService = new NetworkService();

            //Act
            var result = _pingService.PingTimeout(a, b);

            //Assert
            result.Should().Be(expected);
            result.Should().BeGreaterThanOrEqualTo(3);
            result.Should().NotBeInRange(-1000, 0);
        }

        [Fact]
        public void NetworkService_LastPingDate_ReturnString()
        {
            //Arrange - variables, classes, mocks
            //var pingService = new NetworkService();

            //Act
            var result = _pingService.LastPingDate();

            //Assert
            result.Should().BeAfter(1.January(2010));
            result.Should().BeBefore(1.January(2030));
        }

        [Fact]
        public void NetworkService_GetPingOptions_ReturnObject()
        {
            //Arrange - variables, classes, mocks
            //var pingService = new NetworkService();
            var expected = new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };


            //Act
            var result = _pingService.GetPingOptions();

            //Assert WARNING: "Be" careful
            result.Should().BeOfType<PingOptions>();
            result.Should().BeEquivalentTo(expected);
            result.Ttl.Should().Be(expected.Ttl);
        }

        [Fact]
        public void NetworkService_MostRecentPings_ReturnObject()
        {
            //Arrange - variables, classes, mocks
            //var pingService = new NetworkService();
            var expected = new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };


            //Act
            var result = _pingService.MostRecentPings();

            //Assert WARNING: "Be" careful
            result.Should().BeOfType<List<PingOptions>>();
            result.Should().ContainEquivalentOf(expected);
            result.Should().Contain(x => x.DontFragment == true);
        }
    }
}
