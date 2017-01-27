namespace Boilerplate.UI.Console
{
    using Boilerplate.Logic.Interfaces;
    using SimpleInjector;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class Program
    {
        private static readonly Container IocContainer = new Container();

        private static void Main(string[] args)
        {
            InitInjector();
            var db = IocContainer.GetInstance<IDatabase>();
            var fridgeSvc = IocContainer.GetInstance<IFridgeService>();
            var foodstuffSvc = IocContainer.GetInstance<IFoodstuffService>();

            foreach (var fridge in db.Fridges.ReadAll())
            {
                Console.WriteLine("The fridge#{0} in the {1} contains:", fridge.Identifier, fridge.Location);

                var contents = fridge.FoodstuffIdentifiers.Select(id => db.Foodstuffs.Read(id));
                foreach (var foodstuff in contents)
                {
                    Console.WriteLine("\t[{0}] {1}#{2}", foodstuffSvc.IsEatable(foodstuff) ? "OK" : "Bad", foodstuff.Name, foodstuff.Identifier);
                }
            }

            Console.WriteLine("Press the \"Any key\" to exit.");
            Console.ReadKey();
        }

        private static void InitInjector()
        {
            // Configure the container (register concrete implementations to use where interfaces are requested)
            IocContainer.Register<IDatabase, Logic.Real.FileBackedDatabase>(Lifestyle.Singleton);
            IocContainer.Register<IFridgeService, Logic.Real.FridgeService>(Lifestyle.Singleton);
            IocContainer.Register<IFoodstuffService, Logic.Real.FoodstuffService>(Lifestyle.Singleton);

            // Optionally verify the container's configuration.
            IocContainer.Verify();
        }
    }
}