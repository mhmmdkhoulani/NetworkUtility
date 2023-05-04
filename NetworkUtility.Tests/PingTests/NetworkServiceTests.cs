using FluentAssertions;
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
        [Fact]
        public void NetworkService_SendPing_ReturnsStringSuccess()
        {
            //Arrange 
            NetworkService service = new NetworkService();

            //Act 
            var actual = service.SendPing();

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
            NetworkService service = new NetworkService();

            //Act 
            var actual = service.AddPings(a,b);

            //Assert
            
            //Assert.Equal(expected, actual);
            actual.Should().Be(expected);
        }

        [Fact]
        public void NetworkService_LastPingDate_ReturnsDateTime()
        {
            //Arrange 
            NetworkService service = new NetworkService();

            //Act 
            var actual = service.LastPingDate().ToString("dd,MM,yyyy");

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
            NetworkService service = new NetworkService();

            //Act
            
            //Assert
            Assert.Throws<ArgumentNullException>( () => service.GetPingOption(pingOption));
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
            NetworkService service = new NetworkService();

            //Act
            var actual = service.GetPingOption(pingOption);
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
            NetworkService service = new NetworkService();

            //Act
            var actual = service.LastRecentPingOption();
            //Assert
            var expected = pingOption;
            Assert.True(actual.Any(o => o.Date == pingOption.Date));
        }
    }
}
