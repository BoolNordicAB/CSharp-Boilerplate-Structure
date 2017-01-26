namespace Boilerplate.Logic.Interfaces
{
    using Boilerplate.Models;
    using System;
    using System.Collections.Generic;

    public interface IFridgeService
    {
        IEnumerable<Foodstuff> GetAllFoodstuffsForFridge(int fridgeId);

        IEnumerable<Foodstuff> GetAllPerishedFoodstuffsForFridge(int fridgeId);

        void PurgeAllPerishedFoodstuffsForFridge(int fridgeId);
    }
}