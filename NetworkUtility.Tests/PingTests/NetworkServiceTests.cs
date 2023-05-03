using FluentAssertions;
using NetworkUtility.Ping;
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

        //[Fact]
        //public void NetworkService_AddPings_ReturnsAddingOfTwoNumbers()
        //{
        //    //Arrange 
        //    NetworkService service = new NetworkService();

        //    //Act 
        //    var actual = service.AddPings(2, 4);

        //    //Assert
        //    var expected = 6;
        //    Assert.Equal(expected, actual);
        //    //actual.Should().NotBeNullOrWhiteSpace();
        //    //actual.Should().Be(expected);
        //}

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
    }
}
