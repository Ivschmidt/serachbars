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
            var serializer = new DataContractSerializer(typeof(List<User>));

            List<User> list;
            using (Stream s = File.OpenRead(xmlFile))
            {
                list = serializer.ReadObject(s) as List<User>;
            }
            return list;
        }

        public IEnumerable<IVille> loadVilles()
        {
            DirectoryInfo dirInfo = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent;
            string dirData = string.Format("{0}\\DataSearchBars\\XML\\", dirInfo.FullName);
            string xmlFile = string.Format("{0}{1}", dirData, "ville.xml");
            var serializer = new DataContractSerializer(typeof(List<Ville>));

            List<Ville> list;
            using (Stream s = File.OpenRead(xmlFile))
            {
                list = serializer.ReadObject(s) as List<Ville>;
            }
            return list;
        }

        public void saveUsers(List<IUser> userList)
        {
            //obliger de caster List<IUser> en List<User> pour serialiser car sinon exception quand on met typeof(List<IUser>) pour DataContractSerializer
            //peut etre plus propre de faire en sorte que typeof(List<IUser>) ==> demander prof
            List<User> uL = userList.Select(Iuser => Iuser as User).ToList();

            DirectoryInfo dirInfo = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent;
            string dirData = string.Format("{0}\\DataSearchBars\\XML\\", dirInfo.FullName);
            string xmlFile = string.Format("{0}{1}", dirData, "user.xml");
            var serializer = new DataContractSerializer(typeof(List<User>));

            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };
            using (XmlWriter writer = XmlWriter.Create(xmlFile, settings))
            {
                serializer.WriteObject(writer, uL);
            }
        }

        public void saveVille(List<IVille> villeList)
        {
            DirectoryInfo dirInfo = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent;
            string dirData = string.Format("{0}\\DataSearchBars\\XML\\", dirInfo.FullName);
            string xmlFile = string.Format("{0}{1}", dirData, "ville.xml");
            var serializer = new DataContractSerializer(typeof(List<Ville>));

            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };
            using (XmlWriter writer = XmlWriter.Create(xmlFile, settings))
            {
                serializer.WriteObject(writer, villeList);
            }
        }
    }
}
