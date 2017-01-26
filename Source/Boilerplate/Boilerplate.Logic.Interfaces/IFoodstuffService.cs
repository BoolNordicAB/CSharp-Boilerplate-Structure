namespace Boilerplate.Logic.Interfaces
{
    using Boilerplate.Models;
    using System;
    using System.Collections.Generic;

    public interface IFoodstuffService
    {
        bool IsEatable(Foodstuff foodstuff);

        bool HasPerished(Foodstuff foodstuff);

        void RecycleFoodstuff(Foodstuff foodstuff);
    }
}