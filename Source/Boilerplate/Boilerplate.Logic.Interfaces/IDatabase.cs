namespace Boilerplate.Logic.Interfaces
{
    using Boilerplate.Models;

    public interface IDatabase
    {
        IDataset<Fridge> Fridges { get; }

        IDataset<Foodstuff> Foodstuffs { get; }
    }
}