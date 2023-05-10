using FluentAssertions;
using Moq;
using NetworkUtility.DNS;
using NetworkUtility.Models;
using NetworkUtility.Ping;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkUtility.Tests.PingTests
{
    public class NetworkServiceTests
    {
        private readonly NetworkService _networkService;
        private readonly IDNSService _dnsService;
        private readonly Mock<IDNSService> mock;
        public NetworkServiceTests()
        {
            //Depedancies 
             mock = new Mock<IDNSService>();
            _dnsService = mock.Object;
            //SUT
            _networkService = new NetworkService(_dnsService);
        }

        [Fact]
        public void NetworkService_SendPing_ReturnsStringSuccess()
        {
            //Arrange 
            mock.Setup(p => p.SendDNS()).Returns(true);
            //Act 
            var actual = _networkService.SendPing();

            //Assert
            var expected = "Success: Ping Sent!";
           // Assert.Equal(expected, actual);
           actual.Should().NotBeNullOrWhiteSpace();
            actual.Should().Be(expected);
        }

        

        [Theory]
        [InlineData(2,4, 6)]
        [InlineData(2,5, 7)]
        public void NetworkService_AddPings_ReturnsAddingOfTwoNumbersTheory(int a, int b, int expected)
        {
            //Arrange 
            

            //Act 
            var actual = _networkService.AddPings(a,b);

            //Assert
            
            //Assert.Equal(expected, actual);
            actual.Should().Be(expected);
        }

        [Fact]
        public void NetworkService_LastPingDate_ReturnsDateTime()
        {
            //Arrange 
           

            //Act 
            var actual = _networkService.LastPingDate().ToString("dd,MM,yyyy");

            //Assert
            var expected = DateTime.Now.ToString("dd,MM,yyyy");
            Assert.Equal(expected, actual);
            //actual.Should().NotBeNullOrWhiteSpace();
            //actual.Should().Be(expected);
        }

        [Fact]
        public void NetworkService_GetPingOption_ReturnsArgumentNullException()
        {
            //Arrange 
            var pingOption = new PingOption
            {
                Date = DateTime.Now,
                Size = 1232,
                Type = ""
            }; 
            

            //Act
            
            //Assert
            Assert.Throws<ArgumentNullException>( () => _networkService.GetPingOption(pingOption));
        }

        [Fact]
        public void NetworkService_GetPingOption_ReturnsPingOption()
        {
            //Arrange 
            var pingOption = new PingOption
            {
                Date = DateTime.Now,
                Size = 1232,
                Type = "Ping"
            };
            

            //Act
            var actual = _networkService.GetPingOption(pingOption);
            //Assert
            var expected = pingOption;
            Assert.Equal(expected, actual); 
        }

        [Fact]
        public void NetworkService_LastRecentPingOption_ReturnsIEnumerableOfPingOptions()
        {
            //Arrange 
            var pingOption = new PingOption
            {
                Date = new DateTime(2022, 2, 12),
                Size = 1232,
                Type = "Ping"
            };
            

            //Act
            var actual = _networkService.LastRecentPingOption();
            //Assert
            var expected = pingOption;
            Assert.True(actual.Any(o => o.Date == pingOption.Date));
        }
    }
}
