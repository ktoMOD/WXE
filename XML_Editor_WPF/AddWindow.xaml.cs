using AutoMapper;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace XML_Editor_WPF
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        Weapon innerWeapon = new Weapon();
        Weapon copyWeapon = new Weapon();

        public AddWindow()
        {
            InitializeComponent();
        }

        public void LoadInformation(Weapon inner)
        {
            innerWeapon = inner;
            Mapper.CreateMap<Weapon, Weapon>();
            Mapper.Map(innerWeapon, copyWeapon);

            this.DataContext = copyWeapon;

        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            WeaponValidator validator = new WeaponValidator();
            ValidationResult results = validator.Validate(copyWeapon);
            if (results.IsValid)
            {
                Mapper.Map(copyWeapon, innerWeapon);
                this.DialogResult = true;
                this.Close();
            }
        }

    }
}
