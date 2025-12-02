using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace DoctorAppointment.Repositories;

public class XmlRepository<T> : IRepository<T>
{
    private readonly string _filePath;

    public XmlRepository(string filePath)
    {
        _filePath = filePath;
    }

    public List<T> GetAll()
    {
        if (!File.Exists(_filePath)) return new List<T>();

        var serializer = new XmlSerializer(typeof(List<T>));

        using var stream = File.OpenRead(_filePath);
        return (List<T>)serializer.Deserialize(stream);
    }

    public void SaveAll(List<T> items)
    {
        var serializer = new XmlSerializer(typeof(List<T>));

        using var stream = File.Create(_filePath);
        serializer.Serialize(stream, items);
    }
}
