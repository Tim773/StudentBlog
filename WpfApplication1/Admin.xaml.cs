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
            
            try //конструкция try-catch на случай непредвиденных ошиибок
            {
                if (EmptyCheck() == true) //проверка введены ли все данные на форме
                
                {
                    Entities entities = new Entities(); //создание экземпляра класса вашей базы данных (у вас он может называться иначе)
                    Person authUser = entities.Person.Where(i => i.email == login.Text && i.password == passw.Password).FirstOrDefault();
                    //в строке выше объявляется переменная типа var, которая хранит строку пользователя из таблицы в БД, логин и пароль которого совпадают с
                    //введёнными значениями в форму авторизации
                    if (authUser != null) //проверка на наличие пользователя с введёнными данными. Если в базе данных нет пользователя с такими данными переменная = NULL               
                    {
                        //Вызов окна профиля, создание его экземпляра и передача окну профиля информации о вошедшем пользователе
                        MyProfile myProfile = new MyProfile(authUser);
                        //Вызов метода ShowDialog из созданного экземпляра
                        myProfile.ShowDialog();
                    }
                    else
                    {
                        //Сообщение пользователю в случае, если в базе данных нет пользователей с введёнными логином и паролем
                        MessageBox.Show("Пользователь не найден!", "Авторизация пользователя", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        passw.Password = string.Empty; //очищение поля пароля на форме авторизации

                    }
                }                
            }
            catch (Exception exeption)
            {                
                MessageBox.Show($"{exeption}"); //возврат текста ошибки без остановки приложения
                throw;
            }
        }
        private bool EmptyCheck()
        {
            if (login.Text != string.Empty && passw.Password != string.Empty) //проверка, не пустые ли поля логина и пароля
            {
                return true; 
            }
            else
            {
                //сообщение, появляющееся в случае, если не все поля заполнены
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
