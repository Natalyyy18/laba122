using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using Microsoft.Analytics.UnitTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using лабораторная_12_2_часть_хеш;
using ClassLibrary10;



namespace USqlCSharpUdoUnitTestProject3
{
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Capacity_ReturnsCorrectCapacity()
        {
            // Arrange
            MyHashTable<BankCard> table = new MyHashTable<BankCard>(5);

            // Act
            int capacity = table.Capacity;

            // Assert
            Assert.AreEqual(5, capacity);
        }

        [TestMethod]
        public void PrintTable_EmptyTable_PrintsTableIsEmptyMessage()
        {
            // Arrange
            MyHashTable<BankCard> table = new MyHashTable<BankCard>(3);
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            table.PrintTable();

            // Assert
            Assert.AreEqual("Таблица пуста\n", sw.ToString());
        }

        [TestMethod]
        public void RemoveData_TableIsNull_ReturnsZero()
        {
            // Arrange
            MyHashTable<BankCard> table = new MyHashTable<BankCard>(5);

            // Act
            int result = table.RemoveData("John");

            // Assert
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void SearchName_ElementExists_ReturnsOne()
        {
            // Arrange
            MyHashTable<BankCard> table = new MyHashTable<BankCard>(5);


            // Act
            int result = table.SearchName("Alice");

            // Assert
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void GetHashCode_NullData_ReturnsZero()
        {
            // Arrange
            var point = new Point<string>(null);

            // Act
            int hash = point.GetHashCode();

            // Assert
            Assert.AreEqual(0, hash);
        }
        [TestMethod]
        public void GetHashCode_NonNullData_ReturnsHashCode()
        {
            // Arrange
            var point = new Point<int>(42); // Пример данных типа int

            // Act
            int hash = point.GetHashCode();

            // Assert
            Assert.AreEqual(42.GetHashCode(), hash);
        }
  
  
       




    }
}
