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
    public partial class AdminWindow : Window
    {
        private PraktikaDbContext _context;

        public AdminWindow()
        {
            InitializeComponent();
            _context = new PraktikaDbContext();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (var context = new PraktikaDbContext())
                {
                    ClientsDataGrid.ItemsSource = context.Clients.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}");
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new ClientEditWindow(null); // Assuming ClientEditWindow is your window for adding/editing clients
            window.ShowDialog();
            LoadData(); // Refresh data after adding
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (ClientsDataGrid.SelectedItem is Client client)
            {
                var window = new ClientEditWindow(client);
                window.ShowDialog();
                LoadData(); // Refresh data after editing
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (ClientsDataGrid.SelectedItem is Client client)
            {
                _context.Clients.Remove(client);
                _context.SaveChanges();
                LoadData(); // Refresh data after deletion
            }
        }
    }
}

