using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldReturnNonNullObject()
        {
            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638,-84.677017,Taco Bell Acwort...", -84.677017)]
        [InlineData("31.236691,-85.459825,Taco Bell Dothan...", -85.459825)]
        [InlineData("31.835933,-86.630853,Taco Bell Greenville...", -86.630853)]
        [InlineData("34.741158,-86.662532,Taco Bell Huntsville...", -86.662532)]
        [InlineData("30.190097,-85.711394,Taco Bell Panama City...", -85.711394)]
        [InlineData("34.113051,-84.56005,Taco Bell Woodstoc...", -84.56005)]
        //Add additional inline data. Refer to your CSV file.
        public void ShouldParseLongitude(string line, double expected)
        {
            var tacoParser = new TacoParser();
            var actual = tacoParser.Parse(line);
            Assert.Equal(expected, actual.Location.Longitude);
        }

        
        [Theory]
        [InlineData("34.073638,-84.677017,Taco Bell Acwort...", 34.073638)]
        [InlineData("31.236691,-85.459825,Taco Bell Dothan...", 31.236691)]
        [InlineData("31.835933,-86.630853,Taco Bell Greenville...", 31.835933)]
        [InlineData("34.741158,-86.662532,Taco Bell Huntsville...", 34.741158)]
        [InlineData("30.190097,-85.711394,Taco Bell Panama City...", 30.190097)]
        [InlineData("34.113051,-84.56005,Taco Bell Woodstoc...", 34.113051)]
        public void ShouldParseLatitude(string line, double expected)
        {
            var TacoParser = new TacoParser();
            
            var actual = TacoParser.Parse(line);
            
            Assert.Equal(expected, actual.Location.Latitude);
        }
    }
}
