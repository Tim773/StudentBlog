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
using System.Windows.Shapes;
using static WpfApplication1.AppClass;

namespace WpfApplication1
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();

        }


        private void enter_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                if (EmptyCheck() == true) 
                
                {
                    var authUser = entities.Person.Where(i => i.email == login.Text && i.password == passw.Password).FirstOrDefault();
                    if (authUser != null)
                    {
                        //Вызов окна профиля, создание его экземпляра
                        MyProfile myProfile = new MyProfile(authUser);
                        //Вызов метода ShowDialog из созданного экземпляра
                        myProfile.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Пользователь не найден!", "Авторизация пользователя", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        passw.Password = string.Empty;

                    }
                }                
            }
            catch (Exception exeption)
            {                
                MessageBox.Show($"{exeption}");
                throw;
            }
        }
        private bool EmptyCheck()
        {
            if (login.Text != string.Empty && passw.Password != string.Empty)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Вы указали не все данные!", "Авторизация пользователя", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return false;
            } 
        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {

            //Вызов окна регистрации, создание его экземпляра
            MainWindow mainWindow = new MainWindow();
            //Вызов метода ShowDialog из созданного экземпляра
            mainWindow.ShowDialog();
        }





    }
}
