﻿using log4net;
using NUnit.Framework;
using RemoteAnalyst.Repository.Concrete.RemoteAnalystdb;
using RemoteAnalyst.Repository.Models;
using RemoteAnalyst.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAS.Service.Tests.Concrete
{
    public class BatchTests
    {
        private static readonly ILog Log = LogManager.GetLogger("Batch");
        string connectionString;
        string profileConnectionString;
        string testConnectionString;
        string systemSerial;
        BatchRepository batch;
        BatchRepository batchProfile;
        BatchRepository batchTest;

        [SetUp]
        public void Setup()
        {
            systemSerial = "080627";
            /*
            profileConnectionString = "SERVER=127.0.0.1,3306;PORT=3306;DATABASE=nhibernate;UID=root;PASSWORD=asd@123;Allow User Variables=true";
            connectionString = "SERVER=127.0.0.1,3306;PORT=3306;DATABASE=nhibernate" + systemSerial + ";UID=root;PASSWORD=asd@123;Allow User Variables=true";
            testConnectionString = "SERVER=127.0.0.1,3306;PORT=3306;DATABASE=pmctest;UID=root;PASSWORD=asd@123;Allow User Variables=true";
            */
            var mySql = "Server=127.0.0.1,3306;DataBase=nhibernate;uid=root;pwd=asd@123";
            var msSql = "Data Source=DESKTOP-NTAS7MC\\SQLEXPRESS;Initial Catalog=LocalPMC;Integrated Security=True;";
            profileConnectionString = "Server=127.0.0.1,3306;DataBase=nhibernate;uid=root;pwd=asd@123";
            connectionString = "Server=127.0.0.1,3306;DataBase=nhibernate;uid=root;pwd=asd@123";
            testConnectionString = "Server=127.0.0.1,3306;DataBase=nhibernate;uid=root;pwd=asd@123";

            batch = new BatchRepository(connectionString, Log, true);
            batchProfile = new BatchRepository(profileConnectionString, Log, true);
            batchTest = new BatchRepository(testConnectionString, Log, true);
        }

        [Test]
        public void Test_Batch_GetAllSystemInformationForBatch()
        {
            // Arrange

            // Act
            DataTable result = batchProfile.GetAllSystemInformationForBatch();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<DataTable>());
            Assert.That(result.Rows.Count, Is.GreaterThan(0));
        }

        [Test]
        public void Test_Batch_GetBatchInformationBySystem()
        {
            // Arrange

            // Act
            DataTable result = batch.GetBatchInformationBySystem();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<DataTable>());
            Assert.That(result.Rows.Count, Is.GreaterThan(0));
        }

        [Test]
        public void Test_Batch_GetBatchInformationBySystemAndBatch()
        {
            // Arrange
            string batchSequenceName = "Olga test batch";

            // Act
            DataTable result = batch.GetBatchInformationByName(batchSequenceName);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<DataTable>());
            Assert.That(result.Rows.Count, Is.GreaterThan(0));
        }

        [Test]
        public void Test_Batch_GetRDSRetentionDays()
        {
            // Arrange
            
            // Act
            int result = batchProfile.GetRDSRetentionDays(systemSerial);

            // Assert
            Assert.That(result, Is.GreaterThan(0));
        }

        [Test]
        public void Test_Batch_GetProcessesTrendInformationByBatchId()
        {
            // Arrange
            string batchSequenceName = "Olga test batch";

            // Act
            DataTable result = batch.GetBatchInformationByName(batchSequenceName);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<DataTable>());
            Assert.That(result.Rows.Count, Is.GreaterThan(0));
        }

        [Test]
        //[Ignore("Need to figure out how to implement")]
        public void Test_Batch_InsertBatchTrendData()
        {
            // Arrange
            string query = "";
            List<BatchSequenceTrend> batchTrendList = new List<BatchSequenceTrend>()
            {
                new BatchSequenceTrend()
                {
                    ProgramFile = "$ISERV42.IWVP0206.EMSLINK",
                    StartTime = DateTime.Now.AddDays(-1),
                    EndTime = DateTime.Now.AddDays(-1).AddMinutes(15),
                    Duration = 900,
                    DataDate = DateTime.Now.AddDays(-1)
                },
                new BatchSequenceTrend()
                {
                    ProgramFile = "$ISERV42.IWVP0206.SAPROC",
                    StartTime = DateTime.Now.AddDays(-1),
                    EndTime = DateTime.Now.AddDays(-1).AddMinutes(30),
                    Duration = 1800,
                    DataDate = DateTime.Now.AddDays(-1)
                }
            };
            int batchSequenceProfileId = 20;
            // Act
            batch.InsertBatchTrendData(batchTrendList, batchSequenceProfileId);

            // Assert
            Assert.Pass();
        }

        [Test]
        public void Test_Batch_MySqlTableExists()
        {
            // Arrange
            string databaseName = "pmc080627";
            string tableName = "080627_CPU_2024_3_29";

            // Act
            bool result = batch.CheckBatchTablesExists();

            // Assert
            Assert.That(result, Is.True);
        }


        [Test]
        //[Ignore("Need to figure out how to implement")]
        public void Test_Batch_CreateBatchTables()
        {
            // Arrange
            // Act
            batchTest.CreateBatchTables();
            // Assert
            Assert.Pass("Batch tables created successfully");
        }
    }
}