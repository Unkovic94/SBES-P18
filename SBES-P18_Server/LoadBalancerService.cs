﻿using System;
using Common;
using System.Xml;
using System.Runtime.Serialization;
using System.IO;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace SBES_P18_Server
{
    public class LoadBalancerService : ILoadBalancerService
    {
        public bool Login(User u)
        {
            bool authenticated = false;
            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = "Users";
            // xRoot.Namespace = "http://www.cpandl.com";
            xRoot.IsNullable = true;

            XmlSerializer serializer = new XmlSerializer(typeof(List<User>), xRoot);
<<<<<<< HEAD
            List<User> deserializedList = new List<User>();

            using (FileStream stream = File.OpenRead("Users.xml"))
            {
                deserializedList = (List<User>)serializer.Deserialize(stream);
            }
            foreach (var item in deserializedList)
            {
                if (item.Username == u.Username && item.Pass == u.Pass)
=======
            List<User> dezerializedList = new List<User>();

            using (FileStream stream = File.OpenRead("Users.xml"))
            {
               dezerializedList = (List<User>)serializer.Deserialize(stream);
            }
         
            foreach (var item in dezerializedList)
            {
               if(item.Username == u.Username && item.Pass == u.Pass)
>>>>>>> b29379756fc0829bfe43b745aac3d329b6b2f139
                {
                    item.IsAuthenticated = true;
                    authenticated = true;
                    Console.WriteLine("Uspeso Logovanje na nalog {0} sa pravima {1}.", u.Username, u.Type);
                }
<<<<<<< HEAD
            }
            using (FileStream stream = File.OpenWrite("Users.xml"))
            {
                serializer.Serialize(stream, deserializedList);
            }
            return authenticated;

        }
=======
               
            }
            using (FileStream stream = File.OpenWrite("Users.xml"))
            {
                
                serializer.Serialize(stream, dezerializedList);
            }

            return authenticated;
            
         }

        public List<Brojilo> ReadXML()
        {
            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = "Brojila";
            // xRoot.Namespace = "http://www.cpandl.com";
          //  xRoot.IsNullable = true;
            
            XmlSerializer serializer = new XmlSerializer(typeof(List<Brojilo>), xRoot);
            List<Brojilo> dezerializedList = new List<Brojilo>();

            using (FileStream stream = File.OpenRead("Baza.xml"))
            {
                dezerializedList = (List<Brojilo>)serializer.Deserialize(stream);
            }

            return dezerializedList;
         }

>>>>>>> b29379756fc0829bfe43b745aac3d329b6b2f139
        public bool AddEntyty(Brojilo brojilo)
        {
            if (!File.Exists("Baza.xml"))
            {
                XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                xmlWriterSettings.Indent = true;
                xmlWriterSettings.NewLineOnAttributes = true;
                using (XmlWriter xmlWriter = XmlWriter.Create("Baza.xml", xmlWriterSettings))
                {
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("Brojila");
<<<<<<< HEAD

=======
                    
>>>>>>> b29379756fc0829bfe43b745aac3d329b6b2f139
                    xmlWriter.WriteStartElement("Brojilo");
                    xmlWriter.WriteElementString("Id", brojilo.Id);
                    xmlWriter.WriteElementString("Ime", brojilo.Ime);
                    xmlWriter.WriteElementString("Prezime", brojilo.Prezime);
                    xmlWriter.WriteElementString("Potrosnja", brojilo.Potrosnja);
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndDocument();
                }
            }
            else
            {
                XDocument xDocument = XDocument.Load("Baza.xml");
                XElement root = xDocument.Element("Brojila");
                IEnumerable<XElement> rows = root.Descendants("Brojilo");
                XElement firstRow = rows.First();
                firstRow.AddBeforeSelf(
                   new XElement("Brojilo",
                   new XElement("Id", brojilo.Id),
                   new XElement("Ime", brojilo.Ime),
<<<<<<< HEAD
                     new XElement("Prezime", brojilo.Prezime),
=======
                     new XElement("Prezime",brojilo.Prezime),
>>>>>>> b29379756fc0829bfe43b745aac3d329b6b2f139
                       new XElement("Potrosnja", brojilo.Potrosnja)
                   ));
                xDocument.Save("Baza.xml");
            }
            Console.WriteLine("Zavrsio sam sa upisivanjem podataka u fajl.");
            return true;
        }
        public bool RemoveEntyty(Brojilo counter)
        {
            bool success_remove = false;
            List<Brojilo> counters = new List<Brojilo>();
<<<<<<< HEAD
            counters = ReadXMLCounters();
            var itemToRemove = counters.Single(r => r.Id == counter.Id);
            success_remove = counters.Remove(itemToRemove);
            SaveCountersToXml(counters);

            return success_remove;
        }
        public bool Work(int id)
        {
            // sad ovde  LB izvuce ceo ENTITET iz XML-a i  posalje WORKERu !!!
            Brojilo counter = ReadCounterFromXml(id);



            return true;

        }
        public bool ChangeEntyty(Brojilo counterNew, Brojilo counterOld)
        {
            List<Brojilo> couters = ReadXMLCounters();
=======
            counters = ReadXML();
            var itemToRemove = counters.Single(r => r.Id == counter.Id);
            counters.Remove(itemToRemove);
            SaveCountersToXml(counters); 
            return success_remove;
        }
        public bool Work()
        {
            throw new NotImplementedException();
        }
        public bool ChangeEntyty(Brojilo counterNew, Brojilo counterOld)
        {
            List<Brojilo> couters = ReadXML();
>>>>>>> b29379756fc0829bfe43b745aac3d329b6b2f139
            foreach (var item in couters)
            {
                if (item.Id == counterOld.Id)
                {
                    item.Id = counterNew.Id;
                    item.Potrosnja = counterNew.Potrosnja;
                }
            }
            return true;
        }
<<<<<<< HEAD
        #region ReadXMl
        public List<Brojilo> ReadXMLCounters()
        {
            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = "Brojila";
            XmlSerializer serializer = new XmlSerializer(typeof(List<Brojilo>), xRoot);
            List<Brojilo> dezerializedList = new List<Brojilo>();
            using (FileStream stream = File.OpenRead("Baza.xml"))
            {
                dezerializedList = (List<Brojilo>)serializer.Deserialize(stream);
            }
            return dezerializedList;
        }
        public List<User> ReadXMLUsers()
        {
            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = "Users";
            XmlSerializer serializer = new XmlSerializer(typeof(List<User>), xRoot);
            List<User> dezerializedList = new List<User>();

            using (FileStream stream = File.OpenRead("Users.xml"))
            {
                dezerializedList = (List<User>)serializer.Deserialize(stream);
            }

            return dezerializedList;
        }
        public Brojilo ReadCounterFromXml(int id)
        {
            Brojilo u = null;
            List<Brojilo> deserializedList = new List<Brojilo>();
            deserializedList = ReadXMLCounters();
            u = deserializedList.Single(r => r.Id == id.ToString());

            return u;
        }
        #endregion
        #region SaveToXML
        public void SaveCountersToXml(List<Brojilo> serializedList)
        {
            /* XmlRootAttribute xRoot = new XmlRootAttribute();
             xRoot.ElementName = "Brojila";
             XmlSerializer serializer = new XmlSerializer(typeof(List<Brojilo>), xRoot);
             using (FileStream stream = File.OpenWrite("Baza.xml"))
             {
                 serializer.Serialize(stream, dezerializedList);
             }*/
            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = "Brojila";
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Brojilo>));
            using (StreamWriter streamWriter = System.IO.File.CreateText("Baza.xml"))
            {
                xmlSerializer.Serialize(streamWriter, serializedList);
            }
            /// ovo jedino valja
=======
        #region SaveToXML
        public void SaveCountersToXml(List<Brojilo> dezerializedList)
        {
            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = "Brojila";
            xRoot.IsNullable = true;

            XmlSerializer serializer = new XmlSerializer(typeof(List<Brojilo>), xRoot);
            using (FileStream stream = File.OpenWrite("Baza.xml"))
            {
                serializer.Serialize(stream, dezerializedList);
            }
>>>>>>> b29379756fc0829bfe43b745aac3d329b6b2f139
        }
        public void SaveEntityToXml(List<User> dezerializedList)
        {
            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = "Users";
            xRoot.IsNullable = true;
            XmlSerializer serializer = new XmlSerializer(typeof(List<User>), xRoot);
            using (FileStream stream = File.OpenWrite("Users.xml"))
            {
                serializer.Serialize(stream, dezerializedList);
            }
        }
<<<<<<< HEAD

        public bool Work()
        {
            throw new NotImplementedException();
        }
        #endregion



=======
        #endregion

>>>>>>> b29379756fc0829bfe43b745aac3d329b6b2f139
    }
}

