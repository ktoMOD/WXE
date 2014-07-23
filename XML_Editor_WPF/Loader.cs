using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace XML_Editor_WPF
{
    public class Loader : ILoader<Weapon>
    {
        public List<Weapon> GetWeaponsFromFile(string SelectFile_textBox)
        {
            var xmlDoc = XDocument.Load(SelectFile_textBox);
            var values = (from first in xmlDoc.Descendants("Prototypes") //I need explanations 
                          from second in first.Elements("Prototype")
                          select second).ToList();

            List<Weapon> localListOfWeapon = new List<Weapon>();
            if (values.Any() && values[0].Attribute("BulletPrototype") != null)
            {
                foreach (var node in values)
                {
                    #region Dynamic initialize object

                    var allName = node.Attributes().Select(x => x.Name);
                    var t = new Weapon();
                    foreach (var name in allName)
                    {
                        var property = typeof(Weapon).GetProperty(name.ToString());
                        if (property != null)
                        {
                            property.SetValue(t, node.Attribute(name).Value);
                        }
                    }
                    #endregion

                    localListOfWeapon.Add(t);
                }
                return localListOfWeapon;
            }
            else
            {
                MessageBox.Show("Выбран неверный файл.");
                return null;
            }

        }
    }
}
