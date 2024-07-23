using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RemoteAnalyst.Repository.Concrete.RemoteAnalystdb;
using System.Data;
using System.Net;
using System.Security.Cryptography;
using RemoteAnalyst.Repository.Repositories;

namespace RAS.Service.Tests.Concrete
{
    public class ForecastTests
    {
        string connectionString;
        string systemSerial;
        ForecastRepository forecast;
        DateTime startTime;
        DateTime stopTime;

        [SetUp]
        public void Setup()
        {
            systemSerial = "080627";
            connectionString = "Server=13.56.143.245;Database=pmc080627;User Id=localanalyst;Password=UpWork24;";
            forecast = new ForecastRepository(connectionString);
            startTime = Convert.ToDateTime("2021-04-08 00:00:00");
            stopTime = Convert.ToDateTime("2021-04-08 00:00:00");
        }

        [Test]
        public void Test_GetForecastData()
        {
            // Arrange

            // Act
            DataTable result = forecast.GetForecastData(startTime, stopTime);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Rows.Count, Is.GreaterThan(0));
        }

        [Test]
        public void Test_GetForecastIpuData()
        {
            // Arrange

            // Act
            DataTable result = forecast.GetForecastIpuData(startTime, stopTime);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Rows.Count, Is.GreaterThan(0));
        }

        [Test]
        public void Test_GetForecastDiskData()
        {
            // Arrange

            // Act
            DataTable result = forecast.GetForecastDiskData(startTime, stopTime);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Rows.Count, Is.GreaterThan(0));
        }

        [Test]
        public void Test_GetForecastStorageData()
        {
            // Arrange

            // Act
            DataTable result = forecast.GetForecastStorageData(startTime, stopTime);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Rows.Count, Is.GreaterThan(0));
        }

        [Test]

        [Ignore("Not used anymore")]
        public void Test_GetForecastProcessData()
        {
            // Arrange

            // Act
            DataTable result = forecast.GetForecastProcessData(startTime, stopTime);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Rows.Count, Is.GreaterThan(0));
        }

        [Test]
        [Ignore("Not used anymore")]
        public void Test_GetForecastTmfData()
        {
            // Arrange

            // Act
            DataTable result = forecast.GetForecastTmfData(startTime, stopTime);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Rows.Count, Is.GreaterThan(0));
        }
    }
}
