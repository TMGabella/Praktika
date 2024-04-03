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
using Microsoft.EntityFrameworkCore;

namespace Praktika
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordBox.Password;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите имя пользователя и пароль.");
                return;
            }

            using (var context = new PraktikaDbContext())
            {
                var userAccount = context.UserAccounts
                    .Include(ua => ua.Role)
                    .SingleOrDefault(ua => ua.Username == username);

                if (userAccount != null && BCrypt.Net.BCrypt.Verify(password, userAccount.HashedPassword))
                {
                    this.Hide(); // Скрываем текущее окно

                    // Определение и открытие окна в зависимости от роли пользователя
                    Window windowToOpen;
                    switch (userAccount.Role.RoleName)
                    {
                        case "Admin":
                            windowToOpen = new AdminWindow();
                            break;
                        case "Employee":
                            windowToOpen = new EmployeeWindow();
                            break;
                        case "User":
                            windowToOpen = new UserWindow();
                            break;
                        default:
                            MessageBox.Show("Неизвестная роль пользователя.");
                            this.Show(); // Показываем окно входа обратно
                            return;
                    }

                    windowToOpen.Show(); // Открываем нужное окно
                    this.Close(); // Закрываем окно авторизации
                }
                else
                {
                    MessageBox.Show("Неверное имя пользователя или пароль.");
                }
            }
        }

    }
}

