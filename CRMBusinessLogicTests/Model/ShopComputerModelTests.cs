﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRMBusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CRMBusinessLogic.Model.Tests
{
    [TestClass()]
    public class ShopComputerModelTests
    {
        [TestMethod()]
        public void StartTest()
        {
            var model = new ShopComputerModel();
            model.Start();
            Thread.Sleep(10000);
        }
    }
}