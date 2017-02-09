namespace Boilerplate.Logic.Simulated
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Boilerplate.Logic.Interfaces;
    using Models;
    using Real;

    public class MockFoodstuffService : IFoodstuffService
    {
        private readonly IDatabase db;
        private readonly DateTime dtThatShouldBeUsedAsNow;

        public MockFoodstuffService(IDatabase db, DateTime dtThatShouldBeUsedAsNow)
        {
            this.db = db;
            this.dtThatShouldBeUsedAsNow = dtThatShouldBeUsedAsNow;
        }

        public bool HasPerished(Foodstuff foodstuff)
        {
            return foodstuff.BestBeforeDate < this.dtThatShouldBeUsedAsNow;
        }

        public bool IsEatable(Foodstuff foodstuff)
        {
            return !this.HasPerished(foodstuff);
        }

        public void RecycleFoodstuff(Foodstuff foodstuff)
        {
            // Defer logic to real logic
            var realFoodstuffService = new FoodstuffService(this.db);
            realFoodstuffService.RecycleFoodstuff(foodstuff);
        }
    }
}