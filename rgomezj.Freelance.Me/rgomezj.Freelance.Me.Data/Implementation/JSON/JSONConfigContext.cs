using Newtonsoft.Json;
using rgomezj.Freelance.Me.Data.Implementation.JSON.Config;
using System.IO;
using System.Threading.Tasks;

namespace rgomezj.Freelance.Me.Data.Implementation.JSON
{
    public abstract class JSONConfigContext
    {
        public FileInfo File { get; private set; }

        public JSONConfigContext(JSONDatabaseConfig config, string fileName)
        {
            File = new FileInfo(config.BasePath + fileName); 
        }

        public async Task<T> GetEntity<T>()
        {
            T result = default(T);
            string typeName = typeof(T).FullName;

            using (StreamReader reader = File.OpenText())
            {
                var resultString = await reader.ReadToEndAsync();
                result = JsonConvert.DeserializeObject<T>(resultString);
            }
            return result;
        }
    }
}