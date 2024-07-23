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
    public class DailiesTopProcessesTests
    {
        string systemSerial;
        string connectionString;
        DailiesTopProcessRepository dailiesTopProcesses;
        DateTime startDateTime;
        DateTime stopDateTime;

        [SetUp]
        public void Setup()
        {
            systemSerial = "080627";
            connectionString = "Server=13.56.143.245;Database=pmc080627;User Id=localanalyst;Password=UpWork24;";
            dailiesTopProcesses = new DailiesTopProcessRepository(connectionString);
            startDateTime = Convert.ToDateTime("2024-03-30 00:00:00");
            stopDateTime = Convert.ToDateTime("2024-03-30 01:00:00");
        }


        [Test]
        public void Test_GetProcessBusyData()
        {
            // Arrange

            // Act
            DataTable result = dailiesTopProcesses.GetProcessBusyData(startDateTime, stopDateTime);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<DataTable>());
            Assert.That(result.Rows.Count, Is.GreaterThan(0));
        }

        [Test]
        public void Test_GetProcessQueueData()
        {
            // Arrange

            // Act
            DataTable result = dailiesTopProcesses.GetProcessQueueData(startDateTime, stopDateTime);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<DataTable>());
            Assert.That(result.Rows.Count, Is.GreaterThan(0));
        }
    }
}
