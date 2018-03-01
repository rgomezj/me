using Newtonsoft.Json;
using rgomezj.Freelance.Me.Data.Implementation.JSON.Config;
using System.IO;

namespace rgomezj.Freelance.Me.Data.Implementation.JSON
{
    public abstract class JSONConfigContext
    {
        public FileInfo File { get; private set; }

        public JSONConfigContext(JSONDatabaseConfig config, string fileName)
        {
            File = new FileInfo(config.BasePath + fileName); 
        }

        public T GetEntity<T>()
        {
            T result = default(T);
            string typeName = typeof(T).FullName;

            using (StreamReader reader = File.OpenText())
            {
                result = JsonConvert.DeserializeObject<T>(reader.ReadToEnd());
            }
            return result;
        }
    }
}