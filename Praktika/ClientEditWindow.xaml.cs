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

namespace Praktika
{
    /// <summary>
    /// Логика взаимодействия для ClientEditWindow.xaml
    /// </summary>
    public partial class ClientEditWindow : Window
    {
        private readonly PraktikaDbContext _context = new PraktikaDbContext();
        public Client Client { get; set; }

        public ClientEditWindow(Client client)
        {
            InitializeComponent();
            Client = client ?? new Client();
            this.DataContext = Client;

            if (Client != null && Client.Gender != null)
            {
                GenderComboBox.SelectedValue = Client.Gender;
            }
        }

        //private void SaveButton_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        if (Client.ClientId == 0) // Проверка, новый ли это клиент (ClientId не установлен)
        //        {
        //            // Создание нового клиента
        //            var newClient = new Client
        //            {
        //                FullName = FullNameTextBox.Text,
        //                Age = int.Parse(AgeTextBox.Text),
        //                Gender = GenderComboBox.SelectedItem.ToString(),
        //                Email = EmailTextBox.Text,
        //                Interests = InterestsTextBox.Text,
        //                RelationshipType = RelationshipTypeTextBox.Text,
        //                PartnerPreferences = PartnerPreferencesTextBox.Text,
        //            };
        //            _context.Clients.Add(newClient);
        //        }
        //        else
        //        {
        //            // Обновление существующего клиента
        //            var clientToUpdate = _context.Clients.FirstOrDefault(client => client.ClientId == Client.ClientId);
        //            if (clientToUpdate != null)
        //            {
        //                clientToUpdate.FullName = FullNameTextBox.Text;
        //                clientToUpdate.Age = int.Parse(AgeTextBox.Text);
        //                clientToUpdate.Gender = GenderComboBox.SelectedItem.ToString();
        //                clientToUpdate.Email = EmailTextBox.Text;
        //                clientToUpdate.Interests = InterestsTextBox.Text;
        //                clientToUpdate.RelationshipType = RelationshipTypeTextBox.Text;
        //                clientToUpdate.PartnerPreferences = PartnerPreferencesTextBox.Text;
        //            }
        //        }
        //        _context.SaveChanges();
        //        MessageBox.Show("Информация о клиенте успешно обновлена!");
        //        this.Close(); // Закрыть текущее окно
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"An error occurred while saving: {ex.Message}");
        //        Console.WriteLine(ex.ToString());

        //        if (ex.InnerException != null)
        //        {
        //            MessageBox.Show($"InnerException: {ex.InnerException.Message}");
        //            Console.WriteLine(ex.InnerException.ToString());
        //        }
        //    }

        //}




        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(FullNameTextBox.Text))
                {
                    MessageBox.Show("Пожалуйста, введите полное имя клиента.");
                    return; // Прерывание сохранения, если поле не заполнено
                }

                if (string.IsNullOrWhiteSpace(AgeTextBox.Text))
                {
                    MessageBox.Show("Пожалуйста, введите возраст клиента.");
                    return; // Прерывание сохранения, если поле не заполнено
                }

                if (GenderComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Пожалуйста, выберите пол клиента.");
                    return; // Прерывание сохранения, если поле не выбрано
                }

                if (string.IsNullOrWhiteSpace(EmailTextBox.Text))
                {
                    MessageBox.Show("Пожалуйста, введите электронную почту клиента.");
                    return; // Прерывание сохранения, если поле не заполнено
                }

                if (string.IsNullOrWhiteSpace(InterestsTextBox.Text))
                {
                    MessageBox.Show("Пожалуйста, введите интересы клиента.");
                    return; // Прерывание сохранения, если поле не заполнено
                }

                if (string.IsNullOrWhiteSpace(RelationshipTypeTextBox.Text))
                {
                    MessageBox.Show("Пожалуйста, введите тип отношений клиента.");
                    return; // Прерывание сохранения, если поле не заполнено
                }

                if (string.IsNullOrWhiteSpace(PartnerPreferencesTextBox.Text))
                {
                    MessageBox.Show("Пожалуйста, введите предпочтения в партнере клиента.");
                    return; // Прерывание сохранения, если поле не заполнено
                }

                if (Client.ClientId == 0) // Проверка, новый ли это клиент (ClientId не установлен)
                {
                    // Создание нового клиента
                    var newClient = new Client
                    {
                        FullName = FullNameTextBox.Text,
                        Age = int.Parse(AgeTextBox.Text),
                        Gender = (string)((ComboBoxItem)GenderComboBox.SelectedItem).Content,
                        Email = EmailTextBox.Text,
                        Interests = InterestsTextBox.Text,
                        RelationshipType = RelationshipTypeTextBox.Text,
                        PartnerPreferences = PartnerPreferencesTextBox.Text,
                    };
                    _context.Clients.Add(newClient);
                }
                else
                {
                    // Обновление существующего клиента
                    var clientToUpdate = _context.Clients.FirstOrDefault(client => client.ClientId == Client.ClientId);
                    if (clientToUpdate != null)
                    {
                        clientToUpdate.FullName = FullNameTextBox.Text;
                        clientToUpdate.Age = int.Parse(AgeTextBox.Text);
                        clientToUpdate.Gender = (string)((ComboBoxItem)GenderComboBox.SelectedItem).Content;
                        clientToUpdate.Email = EmailTextBox.Text;
                        clientToUpdate.Interests = InterestsTextBox.Text;
                        clientToUpdate.RelationshipType = RelationshipTypeTextBox.Text;
                        clientToUpdate.PartnerPreferences = PartnerPreferencesTextBox.Text;
                    }
                }
                _context.SaveChanges();
                MessageBox.Show("Информация о клиенте успешно обновлена!");
                this.Close(); // Закрыть текущее окно
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving: {ex.Message}");
                Console.WriteLine(ex.ToString());

                if (ex.InnerException != null)
                {
                    MessageBox.Show($"InnerException: {ex.InnerException.Message}");
                    Console.WriteLine(ex.InnerException.ToString());
                }
            }
        }





    }
}
