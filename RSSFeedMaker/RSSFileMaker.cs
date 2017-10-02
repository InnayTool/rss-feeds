using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace YB
{
    public class VirtualRSSXmlFile
    {
        public List<item> ItemList;
        int ItemCount;

        public string Title;
        public string Description;
        public string Link;
        public string Generator;
        public string Docs;
        public string Language;
        public string PublicationDate;
        public string LastBuildDate;

        
        public class item
        {   
            public string Title;
            public string Link;
            public string Description;
            public string PublicationDate;
        }
        public VirtualRSSXmlFile(string Title, string Description, string Link, string Generator, string Docs, string Language, string PublicationDate, string LastBuildDate)
        {
            
            this.Title = Title;
            this.Description = Description;
            this.Link = Link;
            this.Generator = Generator;
            this.Docs = Docs;
            this.Language = Language;
            this.PublicationDate = PublicationDate;
            this.LastBuildDate = LastBuildDate;
            
            ItemList = new List<item>();
        }
        public VirtualRSSXmlFile()
        {
            ItemList = new List<item>();
        }
        public static VirtualRSSXmlFile Load(string FilePath)
        {
            VirtualRSSXmlFile LoadedVirtualRSSXmlFile;
            try
            {
                System.Xml.Linq.XDocument RSSXmlFile = System.Xml.Linq.XDocument.Load(FilePath);
                System.Xml.Linq.XElement RSS_Channel = RSSXmlFile.Element("rss").Element("channel");
                LoadedVirtualRSSXmlFile = new VirtualRSSXmlFile(
                    RSS_Channel.Element("title").Value,
                    RSS_Channel.Element("description").Value,
                    RSS_Channel.Element("link").Value,
                    RSS_Channel.Element("generator").Value,
                    RSS_Channel.Element("docs").Value,
                    RSS_Channel.Element("language").Value,
                    RSS_Channel.Element("pubDate").Value,
                    RSS_Channel.Element("lastBuildDate").Value
                );

                System.Xml.Linq.XElement[] ItemArray = RSS_Channel.Elements("item").ToArray();
                foreach (System.Xml.Linq.XElement Item in ItemArray)
                {
                    item CurrentItem = new item();
                    CurrentItem.Title = Item.Element("title").Value;
                    CurrentItem.Link = Item.Element("link").Value;
                    CurrentItem.Description = Item.Element("description").Value;
                    CurrentItem.PublicationDate = Item.Element("pubDate").Value;
                    LoadedVirtualRSSXmlFile.ItemList.Add(CurrentItem);
                }
            }
            catch
            {

                LoadedVirtualRSSXmlFile = null;
            }
            return LoadedVirtualRSSXmlFile;
        }

        public int AddItem()
        {
            item NewItem = new item();
            ItemList.Add(NewItem);
            ItemCount = ItemList.Count;
            return (ItemList.Count-1);
        }
        public int DeleteItem(int ItemNumber)
        {
            ItemList.RemoveAt(ItemNumber);
            ItemCount = ItemList.Count;
            return ItemCount;
        }
        public int WriteToFile(string FilePath)
        {
            if (this.Title == "")
                this.Title = null;
            if (this.Link == "")
                this.Link = null;
            if (this.Description == "")
                this.Description = null;
            if (this.Generator == "")
                this.Generator = null;
            if (this.Docs == "")
                this.Docs = null;
            if (this.Language == "")
                this.Language = null;
            if (this.PublicationDate == "")
                this.PublicationDate = null;
            if (this.LastBuildDate == "")
                this.LastBuildDate = null;

            System.Xml.Linq.XElement ListElements = new System.Xml.Linq.XElement("channel",
                new System.Xml.Linq.XElement("title", this.Title),
                new System.Xml.Linq.XElement("link", this.Link),
                new System.Xml.Linq.XElement("description", this.Description),
                new System.Xml.Linq.XElement("generator", this.Generator),
                new System.Xml.Linq.XElement("docs", this.Docs),
                new System.Xml.Linq.XElement("language", this.Language),
                new System.Xml.Linq.XElement("pubDate", this.PublicationDate),
                new System.Xml.Linq.XElement("lastBuildDate", this.LastBuildDate));

            foreach (item Item in ItemList)
            {
                if (Item.Title == "")
                    Item.Title = null;
                if (Item.Link == "")
                    Item.Link = null;
                if (Item.Description == "")
                    Item.Description = null;
                if (Item.PublicationDate == "")
                    Item.PublicationDate = null;
                ListElements.Add(
                    new System.Xml.Linq.XElement("item",
                        new System.Xml.Linq.XElement("title",Item.Title),
                        new System.Xml.Linq.XElement("link",Item.Link),
                        new System.Xml.Linq.XElement("description",Item.Description),
                        new System.Xml.Linq.XElement("pubDate",Item.PublicationDate)));
            }

            System.Xml.Linq.XDocument XmlRSSFile = new System.Xml.Linq.XDocument(
                new System.Xml.Linq.XElement("rss",
                    new System.Xml.Linq.XAttribute("version","2.0"),
                    ListElements));

            XmlRSSFile.Declaration = new System.Xml.Linq.XDeclaration("1.0", "ISO-8859-15", "true");
            try
            {
                XmlRSSFile.Save(FilePath);
            }
            catch
            {

            }
            return 1;
        }
        public int GetItemCount()
        {
            return ItemCount;
        }
    }
}

