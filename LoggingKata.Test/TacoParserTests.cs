using System;
using Xunit;
using Xunit.Sdk;
using System.Collections.Generic;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            //DONE//TODO: Complete Something, if anything
            //Arrange
            TacoParser sut = new TacoParser();

            //Act
            var actual = sut.Parse("34.073638,-84.677017,Taco Bell Acwort....");

            //Assert
            Assert.NotNull(actual);
        }

        [Theory]
        [InlineData("34.073638,-84.677017,Taco Bell Acwort....", 34.073638, -84.677017, "Taco Bell Acwort....")]
        public void ShouldParse(string str, double latitude, double longitude, string name)
        {
            //Arrange
            TacoParser sut = new TacoParser();
            
            //Act
            var actual = sut.Parse(str);

            //Assert
            Assert.Equal(latitude, actual.Location.Latitude);
            Assert.Equal(longitude, actual.Location.Longitude);
            Assert.Equal(name, actual.Name);

            //DONE// TODO: Complete Should Parse
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ShouldFailParse(string str)
        {
            //Should Fail Parse
            //Arrange
            TacoParser sut = new TacoParser();

            //Act
            var actual = sut.Parse(str);

            //Assert
            Assert.Null(actual);
        }

        
    }
}    
