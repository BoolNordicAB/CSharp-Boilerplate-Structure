namespace Boilerplate.Logic.Interfaces
{
    using Boilerplate.Models;
    using System;
    using System.Collections.Generic;

    public interface IFridgeService
    {
        IEnumerable<Foodstuff> GetAllFoodstuffsForFridge(Guid fridgeId);

        IEnumerable<Foodstuff> GetAllPerishedFoodstuffsForFridge(Guid fridgeId);

        void PurgeAllPerishedFoodstuffsForFridge(Guid fridgeId);
    }
}