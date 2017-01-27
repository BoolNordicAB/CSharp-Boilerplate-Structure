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
    using System.Linq;

    [TestClass]
    public class FridgeServiceTest
    {
        private IFridgeService UnitUnderTest
        {
            get
            {
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

                var iocContainer = new Container();
                iocContainer.Register<IDatabase>(
                    () => new MockDatabase
                    {
                        Fridges = new MockDataset<Fridge>(initialFridges)
                    });
                iocContainer.Register<IFoodstuffService>(() => new MockFoodstuffService(nowDate));
                iocContainer.Register<IFridgeService, FridgeService>(Lifestyle.Transient);

                iocContainer.Verify();

                return iocContainer.GetInstance<IFridgeService>();
            }
        }

        [TestMethod]
        public void Test_GetAllFoodstuffsForFridge_should_return_all_foodstuffs_for_the_fridge()
        {
            var allFoodstuff = this.UnitUnderTest.GetAllFoodstuffsForFridge(1);
            Assert.AreEqual(allFoodstuff.Count(), 0);
        }
    }
}