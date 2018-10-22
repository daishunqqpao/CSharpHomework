using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharp_第六次作业;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_第六次作业.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        [TestMethod()]
        public void ExportTest()
        {
            OrderService i = new OrderService();
            List<OrderService> m = new List<OrderService>();
            bool b = i.Export(m);
            Assert.IsTrue(b);
        }

        [TestMethod()]
        public void ImportTest()
        {
            OrderService i = new OrderService();
            string a = "no";
            bool b = i.Import(a);
            Assert.IsFalse(b);
        }

        [TestMethod()]
        public void SearchByGNameTest()
        {
            OrderService i = new OrderService();
            List<OrderService> m = new List<OrderService>();
            string a = "no";
            bool b = i.SearchByGName(m, a);
            Assert.IsFalse(b);

        }

        [TestMethod()]
        public void SearchByCNameTest()
        {
            OrderService i = new OrderService();
            List<OrderService> m = new List<OrderService>();
            string a = "no";
            bool b = i.SearchByCName(m, a);
            Assert.IsFalse(b);
        }
    }
}