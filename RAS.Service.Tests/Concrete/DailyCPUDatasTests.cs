using NUnit.Framework;
using RemoteAnalyst.Repository.Concrete.RemoteAnalystdbSPAM;
using RemoteAnalyst.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAS.Service.Tests.Concrete
{
    public class DailyCPUDatasTests
    {
        string systemSerial;
        string connectionString;
        string databaseName;
        DailyCPUDataRepository dailyCPUDatas;

        [SetUp]
        public void Setup()
        {
            connectionString = "Server=13.56.143.245;Database=pmc080627;User Id=localanalyst;Password=UpWork24;";
            dailyCPUDatas = new DailyCPUDataRepository(connectionString);
        }

        [Test]
        public void Test_CheckTableName()
        {
            // Arrange

            // Act
            bool result = dailyCPUDatas.CheckTableName(databaseName);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void Test_CreateDailyCPUDatas()
        {
            // Arrange

            // Act
            dailyCPUDatas.CreateDailyCPUDatas();

            // Assert
            Assert.Pass();
        }

        [Test]
        public void Test_CheckDailiesTopProcessesTableName()
        {
            // Arrange

            // Act
            bool result = dailyCPUDatas.CheckDailiesTopProcessesTableName(databaseName);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void Test_CreateDailiesTopProcessesTable()
        {
            // Arrange

            // Act
            dailyCPUDatas.CreateDailiesTopProcessesTable();

            // Assert
            Assert.Pass();
        }


    }
}
