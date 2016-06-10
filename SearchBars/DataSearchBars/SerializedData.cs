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
            DirectoryInfo dirInfo = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent;
            string dirData = string.Format("{0}\\DataSearchBars\\XML\\", dirInfo.FullName);
            string xmlFile = string.Format("{0}{1}", dirData, "user.xml");
            var serializer = new DataContractSerializer(typeof(List<IUser>),
                new Type[] { typeof(User)});

            List<IUser> list;
            using (Stream s = File.OpenRead(xmlFile))
            {
                list = serializer.ReadObject(s) as List<IUser>;
            }
            return list;
        }

        public IEnumerable<IVille> loadVilles()
        {
            DirectoryInfo dirInfo = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent;
            string dirData = string.Format("{0}\\DataSearchBars\\XML\\", dirInfo.FullName);
            string xmlFile = string.Format("{0}{1}", dirData, "ville.xml");
            var serializer = new DataContractSerializer(typeof(List<IVille>),
               new Type[] { typeof(Ville), typeof(BoissonSimple), typeof(BoissonComposee), typeof(Vin) });

            List<IVille> list;
            using (Stream s = File.OpenRead(xmlFile))
            {
                list = serializer.ReadObject(s) as List<IVille>;
            }
            return list;
        }

        public void saveUsers(List<IUser> userList)
        {
            DirectoryInfo dirInfo = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent;
            string dirData = string.Format("{0}\\DataSearchBars\\XML\\", dirInfo.FullName);
            string xmlFile = string.Format("{0}{1}", dirData, "user.xml");
            var serializer = new DataContractSerializer(typeof(List<IUser>),
                new Type[] { typeof(User)});

            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };
            using (XmlWriter writer = XmlWriter.Create(xmlFile, settings))
            {
                serializer.WriteObject(writer, userList);
            }
        }

        public void saveVille(List<IVille> villeList)
        {
            DirectoryInfo dirInfo = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent;
            string dirData = string.Format("{0}\\DataSearchBars\\XML\\", dirInfo.FullName);
            string xmlFile = string.Format("{0}{1}", dirData, "ville.xml");
            var serializer = new DataContractSerializer(typeof(List<IVille>),
                new Type[] { typeof(Ville), typeof(BoissonSimple), typeof(BoissonComposee), typeof(Vin)});

            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };
            using (XmlWriter writer = XmlWriter.Create(xmlFile, settings))
            {
                serializer.WriteObject(writer, villeList);
            }
        }
    }
}
