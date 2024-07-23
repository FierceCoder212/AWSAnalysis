using NUnit.Framework;
using RemoteAnalyst.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAS.Service.Tests.Concrete
{
    public class DISCEntityTableTests
    {
        string systemSerial;
        string connectionString;
        string tableName;
        DISCEntityTable discEntityTable;

        [SetUp]
        public void Setup()
        {
            systemSerial = "080627";
            connectionString = "Server=13.56.143.245;Database=pmc080627;User Id=localanalyst;Password=UpWork24;";
            tableName = "080627_DISC_2024_3_29";
            discEntityTable = new DISCEntityTable(connectionString);
        }

        [Test]
        public void Test_DISCEntityTable_GetDeviceNames()
        {
            // Arrange

            // Act
            List<string> result = discEntityTable.GetDeviceNames(tableName);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<List<string>>());
            Assert.That(result.Count, Is.GreaterThan(0));
        }



        [Test]
        public void Test_DISCEntityTable_GetDISCEntityTableIntervalList()
        {
            // Arrange

            // Act
            DataTable result = discEntityTable.GetDISCEntityTableIntervalList(tableName);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<DataTable>());
            Assert.That(result.Rows.Count, Is.GreaterThan(0));
        }

        [Test]
        public void Test_DISCEntityTable_CheckTableName()
        {
            // Arrange

            // Act
            bool result = discEntityTable.CheckTableName(tableName);

            // Assert
            Assert.That(result, Is.True);
        }
    }
}
