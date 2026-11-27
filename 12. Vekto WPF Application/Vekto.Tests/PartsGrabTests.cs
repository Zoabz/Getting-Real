using Vekto.Models;
using Vekto.ViewModels;

namespace Vekto.Tests
{
    // Usecase 6: Udtag reservedel
    [TestClass]
    public class PartsGrabTests
    {
        [TestInitialize]
        public void Setup()
        {
            File.WriteAllText("Parts.csv", "Bremseklods,Shimano,20,5");
        }

        [TestMethod]
        public void Save_UdtagReservedel_LagerTrækkesFra()
        {
            // Arrange
            PartsGrabController controller = new PartsGrabController();
            controller.SelectedService = new ServiceRow { Number = 1 };
            controller.SelectedEmployee = new Employee("Test", "TE");
            controller.SelectedPart = controller.Parts[0];
            controller.AddPart("3");

            // Act
            controller.Save();

            // Assert
            Part? part = new PartRepository().Get("Bremseklods");
            Assert.AreEqual(17, part!.Quantity);
        }
    }
}
