using System.Windows;

namespace DomainComputersInfo.Windows
{
    public partial class SelectionWindow : Window
    {
        public SelectionWindow()
        {
            InitializeComponent();
        }

        private void Automatic_Click(object sender, RoutedEventArgs e)
        {
            Windows.Credentials credentials = new();
            if (credentials.ShowDialog() == true)
            {
                DomainComputersInfo.WorkWithDB.GetAllInfo(GetComputers.GetFromAD(Logics.Credentials.Domain), Logics.Credentials.Login, Logics.Credentials.Password);
                MessageBox.Show("База заполнена");

            }
            else MessageBox.Show("Введите учетные данные!");
        }

        private void Manual_Click(object sender, RoutedEventArgs e)
        {
            ManualWindow manualWindow = new();
            manualWindow.Show();
        }
    }
}
