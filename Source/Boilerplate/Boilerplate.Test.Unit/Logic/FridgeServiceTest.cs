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
        private IFridgeService GetUnitUnderTest()
        {
            var nowDate = new DateTime(2016, 10, 10);
            var initialFoodstuffs = new List<Foodstuff>
                {
                    new Foodstuff
                    {
                        Identifier = 1,
                        BestBeforeDate = nowDate.Add(TimeSpan.FromDays(1)),
                        Name = "Milk",
                    },
                    new Foodstuff
                    {
                        Identifier = 2,
                        BestBeforeDate = nowDate.Subtract(TimeSpan.FromDays(1)),
                        Name = "Milk",
                    },
                };
            var initialFridges = new List<Fridge>
                {
                    new Fridge
                    {
                        Identifier = 1,
                        Location = "TEST ROOM",
                        FoodstuffIdentifiers = initialFoodstuffs.Select(fs => fs.Identifier).ToList(),
                    }
                };

            var iocContainer = new Container();
            iocContainer.Register<IDatabase>(
                () => new MockDatabase
                {
                    Fridges = new MockDataset<Fridge>(initialFridges),
                    Foodstuffs = new MockDataset<Foodstuff>(initialFoodstuffs)
                });
            iocContainer.Register<IFoodstuffService>(() => new MockFoodstuffService(iocContainer.GetInstance<IDatabase>(), nowDate));
            iocContainer.Register<IFridgeService, FridgeService>(Lifestyle.Transient);

            iocContainer.Verify();

            return iocContainer.GetInstance<IFridgeService>();
        }

        [TestMethod]
        public void Test_GetAllFoodstuffsForFridge_should_return_all_foodstuffs_for_the_fridge()
        {
            var unit = this.GetUnitUnderTest();
            var data = unit.GetAllFoodstuffsForFridge(1);
            Assert.AreEqual(2, data.Count());
        }

        [TestMethod]
        public void Test_GetAllPerishedFoodstuffsForFridge_should_return_all_foodstuffs_for_the_fridge_that_have_perished()
        {
            var unit = this.GetUnitUnderTest();
            var data = unit.GetAllPerishedFoodstuffsForFridge(1);
            Assert.AreEqual(1, data.Count());
        }

        [TestMethod]
        public void Test_PurgeAllPerishedFoodstuffsForFridge_should_remove_all_foodstuffs_from_the_fridge_that_have_perished()
        {
            var unit = this.GetUnitUnderTest();
            var data = unit.GetAllPerishedFoodstuffsForFridge(1);
            Assert.AreEqual(1, data.Count());

            unit.PurgeAllPerishedFoodstuffsForFridge(1);
            data = unit.GetAllPerishedFoodstuffsForFridge(1);
            Assert.AreEqual(0, data.Count());
        }
    }
}