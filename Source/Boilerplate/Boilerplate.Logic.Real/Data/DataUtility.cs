namespace Boilerplate.Logic.Real.Data
{
    using Boilerplate.Models;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    internal static class DataUtility
    {
        internal static List<T> Load<T>(string relativeFileName)
        {
            var directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var fileName = Path.Combine(directoryName, relativeFileName);

            var contents = File.ReadAllText(fileName);
            return JsonConvert.DeserializeObject<List<T>>(contents);
        }

        internal static void Overwrite<T>(string relativeFileName, IList<T> data)
        {
            var directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var fileName = Path.Combine(directoryName, relativeFileName);
            File.WriteAllText(fileName, JsonConvert.SerializeObject(data, Formatting.Indented));
        }
    }
}