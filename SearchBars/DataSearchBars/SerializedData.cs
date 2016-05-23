using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetierSearchBars;
using System.IO;
using System.Xml;
using System.Runtime.Serialization;

namespace DataSearchBars
{
    public class SerializedData : IDataManager
    {
        

        public IEnumerable<IUser> loadUsers()
        {
            DirectoryInfo dirInfo = Directory.GetParent(Directory.GetCurrentDirectory());
            string dirData = string.Format("{0}\\DataSearchBars\\XML\\", dirInfo.FullName);
            string xmlFile = string.Format("{0}{1}", dirData, "user.xml");
            var serializer = new DataContractSerializer(typeof(User));

            List<User> list;
            using (Stream s = File.OpenRead(xmlFile))
            {
                list = serializer.ReadObject(s) as List<User>;
            }
            return list;
        }

        public IEnumerable<IVille> loadVilles()
        {
            DirectoryInfo dirInfo = Directory.GetParent(Directory.GetCurrentDirectory());
            string dirData = string.Format("{0}\\DataSearchBars\\XML\\", dirInfo.FullName);
            string xmlFile = string.Format("{0}{1}", dirData, "ville.xml");
            var serializer = new DataContractSerializer(typeof(Ville));

            List<Ville> list;
            using (Stream s = File.OpenRead(xmlFile))
            {
                list = serializer.ReadObject(s) as List<Ville>;
            }
            return list;
        }

        public void saveUsers(List<IUser> userList)
        {
            DirectoryInfo dirInfo = Directory.GetParent(Directory.GetCurrentDirectory());
            string dirData = string.Format("{0}\\DataSearchBars\\XML\\", dirInfo.FullName);
            string xmlFile = string.Format("{0}{1}", dirData, "user.xml");
            var serializer = new DataContractSerializer(typeof(User));

            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };
            using (XmlWriter writer = XmlWriter.Create(xmlFile, settings))
            {
                serializer.WriteObject(writer, userList);
            }
        }

        public void saveVille(List<IVille> villeList)
        {
            DirectoryInfo dirInfo = Directory.GetParent(Directory.GetCurrentDirectory());
            string dirData = string.Format("{0}\\DataSearchBars\\XML\\", dirInfo.FullName);
            string xmlFile = string.Format("{0}{1}", dirData, "ville.xml");
            var serializer = new DataContractSerializer(typeof(Ville));

            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };
            using (XmlWriter writer = XmlWriter.Create(xmlFile, settings))
            {
                serializer.WriteObject(writer, villeList);
            }
        }
    }
}
