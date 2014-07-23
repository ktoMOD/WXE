using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML_Editor_WPF
{
    public class Weapon : IDataErrorInfo
    {
        public string Class { get; set; }
        public string Name { get; set; }
        public string ModelFile { get; set; }
        public string ResourceType { get; set; }
        public string NodeScale { get; set; }
        public string Mass { get; set; }
        public string ActionDist { get; set; }
        public string InitialVelocity { get; set; }
        public string TracerEffect { get; set; }
        public string TracerRange { get; set; }
        public string BulletPrototype { get; set; }
        public string ExplosionType { get; set; }
        public string FiringEffect { get; set; }
        public string Damage { get; set; }
        public string FiringRate { get; set; }
        public string GroupingAngle { get; set; }
        public string NumBulletsInShot { get; set; }
        public string FiringRange { get; set; }
        public string RecoilForce { get; set; }
        public string DamageType { get; set; }
        public string FiringType { get; set; }
        public string CanBeUsedInAutogenerating { get; set; }
        public string Price { get; set; }
        public string Decal { get; set; }
        public string ShellsPoolSize { get; set; }
        public string WithShellsPoolLimit { get; set; }
        public string ChargeSize { get; set; }
        public string RechargingTime { get; set; }
        public string MaxCharges { get; set; }
        public string TurningSpeed { get; set; }
        public string Durability { get; set; }
        public string BlastWavePrototype { get; set; }
        public string VisibleInEncyclopedia { get; set; }
        public string CanBeDroppedFromEnemies { get; set; }
        public string Damageable { get; set; }



        public string this[string propertyName]
        {
            get
            {
                string msg = null;
                switch (propertyName)
                {
                    case "Class":
                        if (string.IsNullOrEmpty(this.Class))
                            msg = "Должно быть заполнено.";
                        break;
                    case "Name":
                        if (string.IsNullOrEmpty(this.Name))
                            msg = "Должно быть заполнено.";
                        break;
                    case "ModelFile":
                        if (string.IsNullOrEmpty(this.ModelFile))
                            msg = "Должно быть заполнено.";
                        break;
                    case "ResourceType":
                        if (string.IsNullOrEmpty(this.ResourceType))
                            msg = "Должно быть заполнено.";
                        break;
                    case "NodeScale":
                        if (string.IsNullOrEmpty(this.NodeScale))
                            msg = "Должно быть заполнено.";
                        break;
                    case "Mass":
                        if (string.IsNullOrEmpty(this.Mass))
                            msg = "Должно быть заполнено.";
                        break;
                    case "BulletPrototype":
                        if (string.IsNullOrEmpty(this.BulletPrototype))
                            msg = "Должно быть заполнено.";
                        break;
                    case "ExplosionType":
                        if (string.IsNullOrEmpty(this.ExplosionType))
                            msg = "Должно быть заполнено.";
                        break;
                    case "Damage":
                        if (string.IsNullOrEmpty(this.Damage))
                            msg = "Должно быть заполнено.";
                        break;
                    case "FiringRate":
                        if (string.IsNullOrEmpty(this.FiringRate))
                            msg = "Должно быть заполнено.";
                        break;
                    case "GroupingAngle":
                        if (string.IsNullOrEmpty(this.GroupingAngle))
                            msg = "Должно быть заполнено.";
                        break;
                    case "FiringRange":
                        if (string.IsNullOrEmpty(this.FiringRange))
                            msg = "Должно быть заполнено.";
                        break;
                    case "RecoilForce":
                        if (string.IsNullOrEmpty(this.RecoilForce))
                            msg = "Должно быть заполнено.";
                        break;
                    case "FiringType":
                        if (string.IsNullOrEmpty(this.FiringType))
                            msg = "Должно быть заполнено.";
                        break;
                    case "Price":
                        if (string.IsNullOrEmpty(this.Price))
                            msg = "Должно быть заполнено.";
                        break;
                    case "Decal":
                        if (string.IsNullOrEmpty(this.Decal))
                            msg = "Должно быть заполнено.";
                        break;
                    case "ChargeSize":
                        if (string.IsNullOrEmpty(this.ChargeSize))
                            msg = "Должно быть заполнено.";
                        break;
                    case "RechargingTime":
                        if (string.IsNullOrEmpty(this.RechargingTime))
                            msg = "Должно быть заполнено.";
                        break;
                    case "Durability":
                        if (string.IsNullOrEmpty(this.Durability))
                            msg = "Должно быть заполнено.";
                        break;

                    default:
                        throw new ArgumentException(
                        "Неизвестный параметр: " + propertyName);
                }
                return msg;
            }
        }

        public string Error
        {
            get
            {
                return null;
            }
        }
    }
}
