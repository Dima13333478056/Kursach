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
using MySql.Data.MySqlClient;

namespace WPF_Distant
{
    /// <summary>
    /// Логика взаимодействия для Enter.xaml
    /// </summary>
    public partial class Enter : Window
    {
        public Enter()
        {
            InitializeComponent();
            
        }
        private string Check_access(string pass, string log)
        {
            string access = "0";
            DB dB = new DB();
            MySqlCommand command = new MySqlCommand("select access from db_distant.user where login = @login AND password =@password", dB.getConnection());
            command.Parameters.AddWithValue("@login", log);// Добавление значений в @login и @password
            command.Parameters.AddWithValue("@password", pass);
            dB.openConnection();
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                access = reader["access"].ToString(); // чтение столбца access
            }

            dB.closeConnection();
            return access;
        }
        private void EnterButt_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTB.Text != "" && PasswordTB.Password != "")
            {
                try
                {

                    DB dB = new DB();
                    MySqlCommand command = new MySqlCommand("SELECT Role_idrole FROM db_distant.user WHERE login= @login AND password = @password;", dB.getConnection());
                    command.Parameters.AddWithValue("@login", LoginTB.Text);// Добавление значений в @login и @password
                    command.Parameters.AddWithValue("@password", PasswordTB.Password);// чтоб не было SQL инъекций

                    dB.openConnection();//открытие соединения с DB

                    MySqlDataReader reader = command.ExecuteReader();//чтение данных из DB
                    if (reader.Read())
                    {
                        reader.Close();
                        switch (command.ExecuteScalar().ToString()) // чтение значение которое лежит в ячейке Role_idrole
                        {
                            case "2":
                                if (Check_access(PasswordTB.Password, LoginTB.Text) == "0")
                                {
                                    MessageBox.Show("Ваша заявка в обработке ожидайте!");
                                }
                                else
                                {
                                    //this.Hide();
                                    //var teacher_Forms = new Teacher_Forms();              //Открытие формы для преподователей
                                    //                                                      //Teacher_Forms.log = login.Text;
                                    //teacher_Forms.Closed += (s, args) => this.Close();
                                    //teacher_Forms.Show();
                                }

                                break;
                            case "3":
                                if (Check_access(PasswordTB.Password, LoginTB.Text) == "0")
                                {
                                    MessageBox.Show("Ваша заявка в обработке ожидайте!");
                                }
                                else
                                {
                                    //this.Hide();
                                    //var students_Form = new Students_Form();        //Открытие формы для студентов
                                    //                                                //Students_Form.log = login.Text;
                                    //students_Form.Closed += (s, args) => this.Close();
                                    //students_Form.Show();
                                }
                                break;
                            case "1":
                                if (Check_access(PasswordTB.Password, LoginTB.Text) == "0")
                                {
                                    MessageBox.Show("Ваша заявка в обработке ожидайте!");
                                }
                                else
                                {
                                    this.Hide();
                                    var adminForm = new MainWindow();        //Открытие формы для студентов
                                    //AdminForm.log = login.Text;
                                    adminForm.Closed += (s, args) => this.Close();
                                    adminForm.Show();
                                }
                                break;
                            default:

                                //this.Hide();
                                //Confirmces_form reg_Forms = new Confirmces_form();    //Открытие формы для подачи заявки
                                //Confirmces_form.log = login.Text;
                                //reg_Forms.Closed += (s, args) => this.Close();
                                //reg_Forms.Show();

                                break;
                        }
                        dB.closeConnection();// Закрытие соединения для чтения
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка {ex.Message}");
                }

            }
            else
            {
                MessageBox.Show("Заполните все поля!", "Ошибка",MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private Register registerWindow;

        private void RegisterButt_Click(object sender, RoutedEventArgs e)
        {
            if (registerWindow == null)
            {
                registerWindow = new Register();
                this.Hide(); // Скрываем текущее окно
                registerWindow.Closed += (s, args) =>
                {
                    registerWindow = null; // Обнуляем ссылку на окно
                    this.Show(); // Возвращаем текущее окно
                };
                registerWindow.Show(); // Показываем новое окно
            }
            else
            {
                registerWindow.Activate(); // Активируем окно, если оно уже существует
            }
        }
    }
}
