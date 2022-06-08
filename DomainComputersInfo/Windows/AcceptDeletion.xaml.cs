using System.Windows;

namespace DomainComputersInfo.Windows
{
    public partial class AcceptDeletion : Window
    {
        public AcceptDeletion()
        {
            InitializeComponent();
        }

        //===============================================================================================
        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Действие выполнено");
            this.DialogResult = true;
        }

        private void No_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}

