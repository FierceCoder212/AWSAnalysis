using NUnit.Framework;
using RemoteAnalyst.Repository.Concrete.RemoteAnalystdbSPAM;
using RemoteAnalyst.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAS.Service.Tests.Concrete
{
    public class DailyAppUnratedTests
    {
        string systemSerial;
        string connectionString;
        DailyAppUnratedRepository dailiesAppUnrated;
        DateTime oldDate;

        [SetUp]
        public void Setup()
        {
            systemSerial = "asd";
            connectionString = "Server=13.56.143.245;Database=pmc080627;User Id=localanalyst;Password=UpWork24;";
            dailiesAppUnrated = new DailyAppUnratedRepository(connectionString);
            oldDate = Convert.ToDateTime("2024-03-28 00:00:00");
        }


        [Test]
        public void Test_GetAllApplicationData()
        {
            // Arrange

            // Act
            DataTable result = dailiesAppUnrated.GetAllApplicationData();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<DataTable>());
            Assert.That(result.Rows.Count, Is.GreaterThan(0));
        }

        [Test]
        public void Test_GetHourlyData()
        {
            // Arrange

            // Act
            DataTable result = dailiesAppUnrated.GetHourlyData(systemSerial, 1, "1", 3, 2024);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<DataTable>());
            Assert.That(result.Rows.Count, Is.GreaterThan(0));
        }

        [Test]
        public void Test_DeleteData()
        {
            // Arrange

            // Act
            dailiesAppUnrated.DeleteData(oldDate);

            // Assert
            Assert.Pass();
        }
    }
}
