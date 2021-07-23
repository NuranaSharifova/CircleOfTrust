using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp6
{
    class Service
    {
        public List<Friends> Open(string filename)
        {
            var friends = new List<Friends>();
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Friends>));
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                friends = jsonFormatter.ReadObject(fs) as List<Friends>;
            }
            return friends;
        }

        public void Save(string filename, List<Friends> movies)
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Friends>));
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                jsonFormatter.WriteObject(stream: fs, graph: movies);
            }
        }
    }
}
