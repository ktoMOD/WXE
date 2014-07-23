using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XML_Editor_WPF
{
    public class Saver
    {
        public void SaveChanges(string filePath, List<Weapon> listOfWeapon)
        {

            XmlDocument emptyDocument = new XmlDocument();
            emptyDocument.Load(new StringReader("<Prototypes></Prototypes>"));
            XmlDeclaration xmldecl = emptyDocument.CreateXmlDeclaration("1.0", null, null);
            xmldecl.Encoding = "windows-1251";
            xmldecl.Standalone = "yes";
            XmlElement root = emptyDocument.DocumentElement;
            emptyDocument.InsertBefore(xmldecl, root);
            emptyDocument.Save(filePath);

            XmlDocument documentWithParameters = new XmlDocument();
            documentWithParameters.Load(filePath);

            foreach (var weapon in listOfWeapon)
            {
                XmlNode element = documentWithParameters.CreateElement("Prototype");
                documentWithParameters.DocumentElement.AppendChild(element);

                var allName = weapon.GetType().GetProperties().Select(x => x.Name);
                foreach (var name in allName)
                {
                    if (name != "Item")
                    {
                        var property = weapon.GetType().GetProperty(name);
                        string value = (string)property.GetValue(weapon);
                        if (!string.IsNullOrEmpty(value))
                        {
                            XmlAttribute attribute = documentWithParameters.CreateAttribute(property.Name);
                            attribute.Value = value;
                            element.Attributes.Append(attribute);
                        }
                    }
                }
            }
            documentWithParameters.Save(filePath);
        }
    }
}
