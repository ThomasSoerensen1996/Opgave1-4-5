using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OBLBog;

namespace OBLOpg1
{
    [TestClass]
    public class UnitTest
    {
        private Bog test;


        [TestInitialize]
        public void BeforeTest()
        {
            test = new Bog("C# Beginner", "Peter", 450, "2345930958919");

        }

        [TestMethod]
        public void TestMethod1()
        {
            //Tester de 4 værdier i test objektet
            Assert.AreEqual("C# Beginner", test.Titel);
            Assert.AreEqual("Peter",test.Forfatteer);
            Assert.AreEqual(450, test.Sidetal);
            Assert.AreEqual("2345930958919", test.Isbn13);


           
            // Tester en for kort titel
            try
            {
                test.Titel = "P";
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Titel is not long enough", ex.Message);
            }
            // Tester for lavt sidetal
            try
            {
                test.Sidetal = 9;
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Sidetal is outside the limitation", ex.Message);
            }
            // Tester for højt sidetal
            try
            {
                test.Sidetal = 1001;
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Sidetal is outside the limitation", ex.Message);
            }

            // Tester ISBN der er for kort
            try
            {
                test.Isbn13 = "192039485789";
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("The number must be exactly 13 long", ex.Message);
            }

            // Tester ISBN som er for langt
            try
            {
                test.Isbn13 = "19203948578923";
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("The number must be exactly 13 long", ex.Message);
            }






        }
    }
}
