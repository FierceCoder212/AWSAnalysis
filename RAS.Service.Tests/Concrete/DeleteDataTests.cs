using NUnit.Framework;
using RemoteAnalyst.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAS.Service.Tests.Concrete
{
    public class DeleteDataTests
    {
        string systemSerial;
        string connectionString;
        DateTime oldDate;

        [SetUp]
        public void Setup()
        {
            systemSerial = "080627";
            connectionString = "Server=13.56.143.245;Database=pmc080627;User Id=localanalyst;Password=UpWork24;";
            oldDate = Convert.ToDateTime("2021-09-15 23:00:00");
        }

        [Test]
        public void Test_AlertSummary_DeleteData()
        {
            // Arrange
            AlertSummaryRepository alertSummary = new AlertSummaryRepository(connectionString);

            // Act
            alertSummary.DeleteData(oldDate);

            // Assert
            Assert.Pass();
        }

        [Test]
        public void Test_CpuAlerts_DeleteData()
        {
            // Arrange
            CpuAlertRepository cpuAlerts = new CpuAlertRepository(connectionString);

            // Act
            cpuAlerts.DeleteData(oldDate);

            // Assert
            Assert.Pass();
        }
        
        [Test]
        public void Test_DiskAlerts_DeleteData()
        {
            // Arrange
            DiskAlertRepository diskAlerts = new DiskAlertRepository(connectionString);

            // Act
            diskAlerts.DeleteData(oldDate);

            // Assert
            Assert.Pass();
        }

        [Test]
        public void Test_DiskFileAlerts_DeleteData()
        {
            // Arrange
            DiskFileAlertRepository diskFileAlerts = new DiskFileAlertRepository(connectionString);

            // Act
            diskFileAlerts.DeleteData(oldDate);

            // Assert
            Assert.Pass();
        }

        [Test]
        public void Test_ProcessAlerts_DeleteData()
        {
            // Arrange
            ProcessAlertRepository processAlerts = new ProcessAlertRepository(connectionString);

            // Act
            processAlerts.DeleteData(oldDate);

            // Assert
            Assert.Pass();
        }

        [Test]
        public void Test_ProcessInterval_DeleteData()
        {
            // Arrange
            ProcessIntervalRepository processInterval = new ProcessIntervalRepository(connectionString);

            // Act
            processInterval.DeleteData(oldDate);

            // Assert
            Assert.Pass();
        }

        [Test]
        public void Test_SystemInterval_DeleteData()
        {
            // Arrange
            SystemIntervalRepository systemInterval = new SystemIntervalRepository(connectionString);

            // Act
            systemInterval.DeleteData(oldDate);

            // Assert
            Assert.Pass();
        }

        [Test]
        public void Test_TrendCleaner_DeleteDataFor()
        {
            // Arrange
            TrendCleaner trendCleaner = new TrendCleaner(connectionString);

            // Act
            trendCleaner.DeleteDataFor("TrendCpuInterval", "Interval", oldDate);

            // Assert
            Assert.Pass();
        }
    }
}
