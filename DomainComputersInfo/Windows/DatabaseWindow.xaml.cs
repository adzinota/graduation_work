using System.Windows;

namespace DomainComputersInfo.Windows
{
    public partial class DatabaseWindow : Window
    {
        public DatabaseWindow()
        {
            InitializeComponent();
        }

        //===============================================================================================
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            Windows.AcceptDeletion acceptDeletion = new();
            if (acceptDeletion.ShowDialog() == true)
            {
                DomainComputersInfo.WorkWithDB.RecreateDB();
            }
            else MessageBox.Show("Действие отменено");
        }

        //===============================================================================================
        private void Fill_Click(object sender, RoutedEventArgs e)
        {
            SelectionWindow selectionWindow = new();
            selectionWindow.Show();
        }
    }
}

