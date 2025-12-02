using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json;

namespace DoctorAppointment.Repositories
{
    public class JsonStorage : IDataStorage
    {
        public List<T> Load<T>(string file)
        {
            if (!File.Exists(file)) return new List<T>();

            string json = File.ReadAllText(file);
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }

        public void Save<T>(string file, List<T> data)
        {
            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(file, json);
        }
    }
}
