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
            foreach (var fridge in db.Fridges.ReadAll())
            {
                Console.WriteLine("The fridge in the {0} contains:", fridge.Location);

                var contents = fridge.FoodstuffIdentifiers.Select(id => db.Foodstuffs.Read(id));
                foreach (var foodstuff in contents)
                {
                    Console.WriteLine("\t{0}", foodstuff.Name);
                }
            }

            Console.WriteLine("Press the \"Any key\" to exit.");
            Console.ReadKey();
        }

        private static void InitInjector()
        {
            // Configure the container (register concrete implementations to use where interfaces are requested)
            IocContainer.Register<IDatabase, Logic.Real.Database>(Lifestyle.Singleton);

            // Optionally verify the container's configuration.
            IocContainer.Verify();
        }
    }
}