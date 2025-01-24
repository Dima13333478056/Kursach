using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessageBox = System.Windows.Forms.MessageBox;

namespace WPF_Distant
{
    /// <summary>
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }
        private void RegisterButt_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTB.Text != "" && PasswordTB.Password != "" && RepeatPasswordTB.Password != "" && PasswordTB.Password == RepeatPasswordTB.Password)
            {
                try
                {
                    DB db = new DB();
                    db.openConnection();//открытие соединения с DB
                    MySqlCommand command = new MySqlCommand("SELECT COUNT(*) FROM User WHERE login = @login", db.getConnection());//создание команды для проверки есть ли такой логин или нет 
                    command.Parameters.AddWithValue("@login", LoginTB.Text); //внесение inputuser данных в @login
                    int count = Convert.ToInt32(command.ExecuteScalar());//проверяем уникален ли логин который ввел пользователь 
                    if (count > 0)
                    {
                        MessageBox.Show("Такой логин уже существует. Пожалуйста, выберите другой.");
                        db.closeConnection();//закрытие соединения с DB для исключения утечки информации
                        return;
                    }
                    command = new MySqlCommand("INSERT INTO User (login, password) VALUES (@login, @password)", db.getConnection());//создание команды для внесение данных логина и пароля
                    command.Parameters.AddWithValue("@login", LoginTB.Text);//внесение inputuser данных в @login
                    command.Parameters.AddWithValue("Password", PasswordTB.Password);//внесение inputuser данных в @password
                    command.ExecuteNonQuery();
                    db.closeConnection();//закрытие соединения с DB для исключения утечки информации
                    MessageBox.Show("Регистрация прошла успешно", "Удачно!", MessageBoxButtons.OK);
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка!{ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Проверьте корректность ввода!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
