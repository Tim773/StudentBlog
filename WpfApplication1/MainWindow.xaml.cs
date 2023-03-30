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
            if (EmptyCheck() == true && //условие проверки всех значений согласно методам валидации
                PasswordMatching() == true &&
                DateCheck() == true)
            {
                Entities entities = new Entities(); //создание экземпляра класса вашей базы данных (у вас он может называться иначе)
                //обращение к классу Person, вызов метода Add, аргументом которого является созданный экземпляр класса
                //Person из введённых в форму значений
                entities.Person.Add(new Person  
                {
                    namePerson = nameTxt.Text,
                    fNamePerson = lastnameTxt.Text,
                    sNamePerson = srnameTxt.Text,
                    dob = dobPicker.DisplayDate,
                    idGender = ChoosingGender(), //обращение к методу, который определяет выбранный на форме гендер
                    email = elmailTxt.Text,
                    password = passwdBx.Password                   
                });
                entities.SaveChanges(); //сохранение изменений в таблице БД
            }
        }
        private bool EmptyCheck() //проверка на заполнене всех полей при реггистрации
        {
            if (nameTxt.Text == string.Empty ||
             lastnameTxt.Text == string.Empty ||
             srnameTxt.Text == string.Empty ||
             elmailTxt.Text == string.Empty ||
             passwdBx.Password == string.Empty ||       
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
        private bool PasswordMatching() //проверка на совпадение поля пароля и повтора пароля
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
            //создаём bool переменную, которая содержит информацию, раньше или позднее выбранная в
            //datePicker-e дата относительно (ТекущаяДата - шесть лет)
            bool answer = dobPicker.SelectedDate < DateTime.Today.AddYears(-6);
            if (answer == true)
            {
                return answer;
            }
            else 
            {
                MessageBox.Show("Неверная дата рождения", "Регистрация пользователя", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return answer;                
            }             
        }
        private int ChoosingGender() //выбор отправляемого значения гендера в базу данных в зависимости от отмеченного RadioButton
        {            
            if (genm_rb.IsChecked == true)
                return 1;
            else return 2;
        }
    }
}
