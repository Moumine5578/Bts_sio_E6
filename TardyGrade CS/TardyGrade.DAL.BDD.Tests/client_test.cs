using TardyGrade.DAL.BDD;
using TradyGrade.DAL.BDD;
namespace TardyGrade.DAL.BDD.Tests
{
    public class client_test
    {
        [Fact]
        public void GetNombreCreationsCompte()
        {
            // Arrange
            Client client = new Client();

            // Act
            var result = client.GetNombreCreationsCompte(new Periode_DTO());

            // Assert
            Assert.NotNull(result);
        }
    }
}