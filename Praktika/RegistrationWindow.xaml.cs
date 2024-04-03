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
using BCrypt.Net;

namespace Praktika
{
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameTextBox.Text.Trim();
            string password = passwordBox.Password;
            string confirmPassword = confirmPasswordBox.Password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || password != confirmPassword)
            {
                MessageBox.Show("Проверьте введенные данные.");
                return;
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            try
            {
                using (var context = new PraktikaDbContext())
                {
                    if (context.UserAccounts.Any(u => u.Username == username))
                    {
                        MessageBox.Show("Пользователь с таким именем уже существует.");
                        return;
                    }

                    // Создание новой записи в таблице клиентов
                    var newClient = new Client
                    {
                        FullName = username, // Используем имя пользователя как полное имя клиента
                        Gender = username.StartsWith("М", StringComparison.OrdinalIgnoreCase) ? "Male" : "Female", // Определяем пол на основе имени пользователя
                        Email = $"{username}@example.com", // Пример значения для поля Email
                        Age = 18, // Пример значения для поля Age
                        Interests = "None", // Пример значения для поля Interests
                        RelationshipType = "Single", // Пример значения для поля RelationshipType
                        PartnerPreferences = "None", // Пример значения для поля PartnerPreferences
                        Password = "default", // Пример значения для поля Password
                        CreatedAt = DateTime.Now // Устанавливаем текущую дату и время для поля CreatedAt
                                                 // Дополните остальные поля, если необходимо
                    };

                    context.Clients.Add(newClient);
                    context.SaveChanges(); // Сохраняем, чтобы получить ClientId для новой записи

                    // Создание нового пользователя с использованием ClientId из только что созданной записи клиента
                    var newUser = new UserAccount
                    {
                        Username = username,
                        HashedPassword = hashedPassword,
                        RoleId = context.Roles.FirstOrDefault(r => r.RoleName == "User")?.RoleId ?? 0,
                    };

                    context.UserAccounts.Add(newUser);
                    context.SaveChanges();

                    MessageBox.Show("Регистрация прошла успешно!");

                    var startWindow = new StartWindow();
                    startWindow.Show();

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при регистрации: {ex.InnerException?.Message ?? ex.Message}");
            }
        }


    }
}
