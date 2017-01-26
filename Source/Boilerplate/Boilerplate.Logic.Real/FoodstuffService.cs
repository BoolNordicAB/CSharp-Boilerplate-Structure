namespace Boilerplate.Logic.Real
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models;

    public class FoodstuffService : IFoodstuffService
    {
        private readonly IDatabase db;

        public FoodstuffService(IDatabase db)
        {
            this.db = db;
        }

        public bool HasPerished(Foodstuff foodstuff)
        {
            return foodstuff.BestBeforeDate < DateTime.Now;
        }

        public bool IsEatable(Foodstuff foodstuff)
        {
            return !this.HasPerished(foodstuff);
        }

        public void RecycleFoodstuff(Foodstuff foodstuff)
        {
            var parentFridge = this.db.Fridges.ReadAll().First(fridge => fridge.FoodstuffIdentifiers.Contains(foodstuff.Identifier));
            parentFridge.FoodstuffIdentifiers.Remove(foodstuff.Identifier);
            this.db.Fridges.Update(parentFridge);
            this.db.Foodstuffs.Delete(foodstuff.Identifier);
        }
    }
}