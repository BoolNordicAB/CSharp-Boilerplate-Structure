namespace Boilerplate.Logic.Simulated
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Boilerplate.Logic.Interfaces;
    using Models;

    public class MockFoodstuffService : IFoodstuffService
    {
        private readonly DateTime dtThatShouldBeUsedAsNow;

        public MockFoodstuffService(DateTime dtThatShouldBeUsedAsNow)
        {
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
            // No-op
        }
    }
}