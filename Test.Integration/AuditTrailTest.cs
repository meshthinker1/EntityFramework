using Db;
using Db.Table;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq;
using Test.Integration;
using System.Configuration; // Namespace for ConfigurationManager
using System.Threading.Tasks; // Namespace for Task
using Azure.Storage.Queues; // Namespace for Queue storage types
using Azure.Storage.Queues.Models; // Namespace for PeekedMessage

namespace Tests
{
    public class AuditTrailTest
    {
        //var storageConnString = null;

        protected ITestDbContext Db { get; set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Db = new TestDb();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Db.Dispose();
            Db = null;
        }

        [SetUp]
        public void Setup()
        {
           
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void Table_Mapp()
        {
            var audits = Db.Audit.Take(1).ToList();
            var inst = Db.Institution.Take(1).ToList();
        }

        [Test]
        public void Audit_Single_Row()
        {
            
            
            string user = "ANDY";

            Institution inst = new Institution();
            
            inst.SalesForceId = "10000";
            inst.SapCustomerId = "10000";
            inst.DisplayName = "TestDev100";
            inst.Location = "{\"WindowsTimeZoneId\":\"Eastern Standard Time\",\"IanaTimeZoneId\":\"America\\/New_York\",\"Latitude\":\"40.856766\",\"Longitude\":\"-74.128476\"}";
            inst.CreatedUtc = System.DateTime.Now;
            inst.CreatedBy = "smeshram@abiomed.com";
            inst.LastModifiedBy = "";
            inst.LastModifiedUtc = System.DateTime.Now;
            inst.Deleted = false;
            inst.GlobalDisplayName = user;

            Db.Institution.Add(inst);
            Db.SaveChanges(user);

            string s = JsonConvert.SerializeObject(inst, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            Console.WriteLine(" ENTITY OBJECT OUT =====>");
            Console.WriteLine(s);

            // insert a message in the queue
            InsertMessage("auditqueue", s);

            /*Update detail column/
            inst.Location = "US-DANVERS";
            inst.GlobalDisplayName = "SUNNY";
            Db.SaveChanges(user);

            /*Delete/
            inst.DisplayName = "TestDev21";
            Db.Institution.Remove(inst);
            Db.SaveChanges(user);
            */
        }

        //-------------------------------------------------
        // Create the queue service client
        //-------------------------------------------------
        public void CreateQueueClient(string queueName)
        {
            // Get the connection string from app settings
            string connectionString = ConfigurationManager.AppSettings["StorageConnectionString"];

            // Instantiate a QueueClient which will be used to create and manipulate the queue
            QueueClient queueClient = new QueueClient(connectionString, queueName);
        }

        //-------------------------------------------------
        // Create a message queue
        //-------------------------------------------------
        public bool CreateQueue(string queueName)
        {
            try
            {
                // Get the connection string from app settings
                string connectionString = ConfigurationManager.AppSettings["StorageConnectionString"];

                // Instantiate a QueueClient which will be used to create and manipulate the queue
                QueueClient queueClient = new QueueClient(connectionString, queueName);

                // Create the queue
                queueClient.CreateIfNotExists();

                if (queueClient.Exists())
                {
                    Console.WriteLine($"Queue created: '{queueClient.Name}'");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Make sure the Azurite storage emulator running and try again.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}\n\n");
                Console.WriteLine($"Make sure the Azurite storage emulator running and try again.");
                return false;
            }
        }

        //-------------------------------------------------
        // Insert a message into a queue
        //-------------------------------------------------
        public void InsertMessage(string queueName, string message)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("configsettings.json")
                .Build();
            var storageConnString = config.GetSection("StorageConnectionString").Value;

            // Get the connection string from app settings
            string connectionString = storageConnString;// ConfigurationManager.AppSettings["StorageConnectionString"];

            // Instantiate a QueueClient which will be used to create and manipulate the queue
            QueueClient queueClient = new QueueClient(connectionString, queueName);

            // Create the queue if it doesn't already exist
            queueClient.CreateIfNotExists();

            if (queueClient.Exists())
            {
                // Send a message to the queue
                queueClient.SendMessage(message);
            }

            Console.WriteLine($"Inserted: {message}");
        }
    }
}