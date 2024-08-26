using FalzoniCalculo.Api.Controllers;
using FalzoniCalculo.DI;
using FalzoniCalculo.Models.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;

namespace FalzoniCalculo.Api.Tests
{
    [TestClass]
    public class CalcControllerTest
    {
        private CalcController _controller;

        private CurrencyEntryModel _entry;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            DependencyService.GetServiceProviders();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            _controller = new CalcController();
            _controller.Request = new HttpRequestMessage();
            _controller.Configuration = new System.Web.Http.HttpConfiguration();
        }

        [TestMethod]
        public void TestController_CalculateCurrency_Success()
        {
            var entry = new CurrencyEntryModel
            {
                Date = DateTime.Now.AddMonths(3),
                Value = 50.00M
            };

            var response = _controller.CalculateCurrency(entry);

            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void TestController_CalculateCurrency_BadRequest()
        {
            var entry = new CurrencyEntryModel
            {
                Date = DateTime.Now.AddMonths(-3),
                Value = 100.0M
            };

            var response = _controller.CalculateCurrency(entry);

            Assert.IsFalse(response.IsSuccessStatusCode);
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.BadRequest);
        }

        [ClassCleanup]
        public static void ClassCleanup() 
        {
            DependencyService.ServiceProvider.Dispose();
        }
    }
}
