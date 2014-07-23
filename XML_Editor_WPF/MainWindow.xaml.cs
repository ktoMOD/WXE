using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;


namespace XML_Editor_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ILoader<Weapon> _loaderService;
        List<Weapon> listOfWeapon;
        Saver saveService;
        const string filePath = "C:\\Program Files (x86)\\Ex Machina\\data\\gamedata\\gameobjects";
        const string fileFormat = "xml files (*.xml)|*.xml";

        public MainWindow()
        {
            InitializeComponent();
            _loaderService = new Loader();
            saveService = new Saver();
        }

        private void SelectClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog selectFileOpenFileDialog = new OpenFileDialog();
            selectFileOpenFileDialog.InitialDirectory = filePath;
            selectFileOpenFileDialog.Filter = "xml files (*.xml)|*.xml";

            if (selectFileOpenFileDialog.ShowDialog().Value)
            {
                SelectFile_textBox.Text = selectFileOpenFileDialog.FileName;
                LoadFile_btn.IsEnabled = true;
                saveBTN.IsEnabled = false;
            }
        }

        private void LoadClick(object sender, RoutedEventArgs e)
        {
            listOfWeapon = _loaderService.GetWeaponsFromFile(SelectFile_textBox.Text);
            selectWeapon_comboBox.IsEnabled = false;
            editArgument.IsEnabled = false;
            addNewWeapon.IsEnabled = false;
            saveBTN.IsEnabled = false;
            deleteBTN.IsEnabled = false;
            if (listOfWeapon != null && listOfWeapon.Any())
            {
                selectWeapon_comboBox.ItemsSource = listOfWeapon.Select<Weapon, string>(x => x.Name).ToArray<string>();
                selectWeapon_comboBox.SelectedIndex = 0;
                selectWeapon_comboBox.IsEnabled = true;
                editArgument.IsEnabled = true;
                addNewWeapon.IsEnabled = true;
                saveBTN.IsEnabled = true;
                deleteBTN.IsEnabled = true;
                DataGridFill();
            }
        }
        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            if (selectWeapon_comboBox.Items.Count != 0)
            {
                if (!deleteCheckBox.IsChecked.Value)
                {
                    MessageBoxResult result = MessageBox.Show("Вы уверены?", "Подтверждение удаления записи", MessageBoxButton.OKCancel);
                    if (result == MessageBoxResult.OK)
                    {
                        listOfWeapon.Remove(listOfWeapon.First(x => x.Name == selectWeapon_comboBox.Text));
                        ReloadInf();
                    }
                }
                else
                {
                    listOfWeapon.Remove(listOfWeapon.First(x => x.Name == selectWeapon_comboBox.Text));
                    ReloadInf();
                }

            }
            else
            {
                MessageBox.Show("Нет записей в выбранном списке.");
                editArgument.IsEnabled = false;
            }
        }

        private void EditClick(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddWindow();
            addWindow.LoadInformation(listOfWeapon.First(x => x.Name == selectWeapon_comboBox.Text));
            if ((bool)addWindow.ShowDialog())
            {
                ReloadInf();
            }
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddWindow();
            Weapon defaultListOfWeapon = new Weapon();
            addWindow.LoadInformation(defaultListOfWeapon);
            if ((bool)addWindow.ShowDialog())
            {
                listOfWeapon.Add(defaultListOfWeapon);
                editArgument.IsEnabled = true;
                ReloadInf();
            }
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            saveService.SaveChanges(SelectFile_textBox.Text, listOfWeapon);
            MessageBox.Show("Успешно сохранено.");
        }

        private void selectWeapon_comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGridFill();
        }

        private void DataGridFill()
        {
            if (listOfWeapon != null)
            {
                this.DataContext = listOfWeapon.Where(x => x.Name == (string)selectWeapon_comboBox.SelectedValue).ToList();
            }
        }

        private void ReloadInf()
        {
            var rememberPosition = selectWeapon_comboBox.SelectedIndex;
            selectWeapon_comboBox.ItemsSource = listOfWeapon.Select<Weapon, string>(x => x.Name).ToArray<string>();
            selectWeapon_comboBox.SelectedIndex = rememberPosition;
            if (selectWeapon_comboBox.SelectedIndex == -1)
            {
                selectWeapon_comboBox.SelectedIndex = (rememberPosition - 1);
            }
            DataGridFill();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
