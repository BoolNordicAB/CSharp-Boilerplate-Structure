namespace Boilerplate.Test.Unit.Logic
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Boilerplate.Logic.Interfaces;
    using Boilerplate.Logic.Real;
    using Boilerplate.Logic.Simulated;

    using SimpleInjector;
    using System.Collections.Generic;
    using Models;

    [TestClass]
    public class FridgeServiceTest
    {
        private IFridgeService UnitUnderTest
        {
            get
            {
                var iocContainer = new Container();

                var nowDate = new DateTime(2016, 10, 10);

                var initialFridges = new List<Fridge>
                {
                    new Fridge
                    {
                        Identifier = 1,
                        Location = "TEST ROOM",
                        FoodstuffIdentifiers = new List<int>(),
                    }
                };

                iocContainer.Register<IDatabase>(
                    () => new MockDatabase
                    {
                        Fridges = new MockDataset<Fridge>(initialFridges)
                    });

                iocContainer.Register<IFoodstuffService>(() => new MockFoodstuffService(nowDate));

                iocContainer.Register<IFridgeService, FridgeService>(Lifestyle.Transient);

                // Optionally verify the container's configuration.
                iocContainer.Verify();

                return iocContainer.GetInstance<IFridgeService>();
            }
        }

        [TestMethod]
        public void TestMethod1()
        {
            this.UnitUnderTest.PurgeAllPerishedFoodstuffsForFridge(1);
        }
    }
}