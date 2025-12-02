using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace DoctorAppointment.Repositories
{
    public class XmlStorage : IDataStorage
    {
        public List<T> Load<T>(string file)
        {
            if (!File.Exists(file)) return new List<T>();

            var serializer = new XmlSerializer(typeof(List<T>));
            using var stream = File.OpenRead(file);
            return (List<T>)serializer.Deserialize(stream);
        }

        public void Save<T>(string file, List<T> data)
        {
            var serializer = new XmlSerializer(typeof(List<T>));

            using var stream = File.Create(file);
            serializer.Serialize(stream, data);
        }
    }
}
