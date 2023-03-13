using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using static WpfApplication1.AppClass;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }
        private string pathPhoto;
        private void addPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                profilePic.Source = new BitmapImage(new Uri(openFileDialog.FileName));

                pathPhoto = openFileDialog.FileName;

            }
        }

        private void endRegistr_Click(object sender, RoutedEventArgs e)
        {
            if (EmptyCheck() == true &&
                PasswordMatching() == true &&
                DateCheck() == true)
            {               
                entities.Person.Add(new Person
                {
                    namePerson = nameTxt.Text,
                    fNamePerson = lastnameTxt.Text,
                    sNamePerson = srnameTxt.Text,
                    dob = dobPicker.DisplayDate,
                    idGender = ChoosingGender(),
                    email = elmailTxt.Text,
                    password = passwdBx.Password                   
                });
                entities.SaveChanges();
            }



            //    private void AddAccount()
            //    {
            //        Users.Users users = new Users.Users(name_txt.Text, lastname_txt.Text, 
            //            srname_txt.Text, dob_picker.DisplayDate, 
            //            passwd_bx.Password, elmail_txt.Text);

            //    }
        }
        private bool EmptyCheck()
        {
            if (nameTxt.Text == string.Empty ||
             lastnameTxt.Text == string.Empty ||
             srnameTxt.Text == string.Empty ||
             elmailTxt.Text == string.Empty ||
             passwdBx.Password == string.Empty ||       // 00:56 я всрал уйму времени на поиск возможности проверки паролей для метода, в котором допусти логическую ошибку, помянем
             reppasswdBx.Password == string.Empty ||
             (genf_rb.IsChecked == false && genm_rb.IsChecked == false) ||
             dobPicker.SelectedDate == null) 
            {
                MessageBox.Show("Вы указали не все данные", "Регистрация пользователя", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            }
            else
             
            return true;
            
        }
        private bool PasswordMatching() 
        {
            if (passwdBx.Password == reppasswdBx.Password)
            {
                return true;
            }
            MessageBox.Show("Пароли не совпадают", "Регистрация пользователя", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            return false;
        }
        private bool DateCheck()
        {
            //Дописать проверку даты. Дата должна быть не позднее "сегодняшнееЧисло - 6 лет"
            return true;
        }
        private int ChoosingGender()
        {            
            if (genm_rb.IsChecked == true)
                return 1;
            else return 2;
        }
    }
}
