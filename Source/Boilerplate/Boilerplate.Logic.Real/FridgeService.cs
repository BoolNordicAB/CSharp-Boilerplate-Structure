namespace Boilerplate.Logic.Real
{
    using Boilerplate.Logic.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Boilerplate.Models;

    public class FridgeService : IFridgeService
    {
        private readonly IDatabase db;
        private readonly IFoodstuffService foodstuffSvc;

        public FridgeService(IDatabase db, IFoodstuffService foodstuffSvc)
        {
            this.db = db;
            this.foodstuffSvc = foodstuffSvc;
        }

        public IEnumerable<Foodstuff> GetAllFoodstuffsForFridge(int fridgeId)
        {
            return this.db.Fridges.Read(fridgeId).FoodstuffIdentifiers
                .Select(id => this.db.Foodstuffs.Read(id));
        }

        public IEnumerable<Foodstuff> GetAllPerishedFoodstuffsForFridge(int fridgeId)
        {
            var allFoodstuffs = this.GetAllFoodstuffsForFridge(fridgeId);
            return allFoodstuffs
                .Where(this.foodstuffSvc.HasPerished);
        }

        public void PurgeAllPerishedFoodstuffsForFridge(int fridgeId)
        {
            var allPerished = this.GetAllPerishedFoodstuffsForFridge(fridgeId);
            foreach (var foodstuff in allPerished)
            {
                this.foodstuffSvc.RecycleFoodstuff(foodstuff);
            }
        }
    }
}