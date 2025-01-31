﻿using NUnit.Framework;
using NUnit.Framework.Constraints;
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
    public class CPUEntityTableTests
    {
        string systemSerial;
        string connectionString;
        CPUEntityTable cpuEntityTable;
        string tableName;
        DateTime startTime;
        DateTime stopTime;
        long interval;

        [SetUp]
        public void Setup()
        {
            systemSerial = "080627";
            connectionString = "Server=13.56.143.245;Database=pmc080627;User Id=localanalyst;Password=UpWork24;";
            cpuEntityTable = new CPUEntityTable(connectionString);
            tableName = "080627_CPU_2024_3_29";
            startTime = Convert.ToDateTime("2023-09-15 23:00:00");
            stopTime = Convert.ToDateTime("2023-09-15 23:00:00");
            interval = 900;
        }

        [Test]
        public void Test_GetCPUEntityTableIntervalList()
        {
            // Arrange

            // Act
            DataTable result = cpuEntityTable.GetCPUEntityTableIntervalList(tableName);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<DataTable>());
            Assert.That(result.Rows.Count, Is.GreaterThan(0));
        }

        [Test]
        public void Test_CheckIPU()
        {
            // Arrange

            // Act
            bool result = cpuEntityTable.CheckIPU(tableName);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void Test_GetNumOfIPUs()
        {
            // Arrange

            // Act
            int result = cpuEntityTable.GetNumOfIPUs(tableName);

            // Assert
            Assert.That(result, Is.GreaterThan(0));
        }

        [Test]
        public void Test_GetAllCPUBusyAndQueue()
        {
            // Arrange
            List<string> cpuTables = new List<string>()
            {
                tableName
            };

            // Act
            DataTable result = cpuEntityTable.GetAllCPUBusyAndQueue(cpuTables,
                false, interval, Convert.ToDateTime("2024-03-29 00:00:00"), Convert.ToDateTime("2024-03-29 00:15:00"));

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<DataTable>());
            Assert.That(result.Rows.Count, Is.GreaterThan(0));
        }
        [Test]
        public void Test_GetAllCPUBusyAndMemory()
        {
            // Arrange
            List<DateTime> dateList = new List<DateTime>()
            {
                startTime
            };

            // Act
            DataTable result = cpuEntityTable.GetAllCPUBusyAndMemory(dateList, startTime, stopTime);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<DataTable>());
            Assert.That(result.Rows.Count, Is.GreaterThan(0));
        }
        [Test]
        public void Test_GetAllIPUBusyAndQueue()
        {
            // Arrange
            List<string> cpuTables = new List<string>()
            {
                tableName
            };

            // Act
            DataTable result = cpuEntityTable.GetAllIPUBusyAndQueue(cpuTables, 1, interval, Convert.ToDateTime("2024-03-29 00:00:00"), Convert.ToDateTime("2024-03-29 00:15:00"));

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<DataTable>());
            Assert.That(result.Rows.Count, Is.GreaterThan(0));
        }

        [Test]
        public void Test_GetApplicationBusy()
        {
            // Arrange

            // Act
            DataTable result = cpuEntityTable.GetApplicationBusy(
                Convert.ToDateTime("2023-09-16 06:00:00"), 
                Convert.ToDateTime("2023-10-16 06:00:00"));

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<DataTable>());
            Assert.That(result.Rows.Count, Is.GreaterThan(0));
        }

        [Test]
        public void Test_GetPageSizeBytes()
        {
            // Arrange

            // Act
            int result = cpuEntityTable.GetPageSizeBytes(tableName);

            // Assert
            Assert.That(result, Is.GreaterThan(0));
        }
    }
}
