using System.Windows;

namespace DomainComputersInfo.Windows
{
    public partial class Credentials : Window
    {
        public Credentials()
        {
            InitializeComponent();
        }

        //===============================================================================================
        private void ok_Click(object sender, RoutedEventArgs e)
        {
            Logics.Credentials.Login = login.Text;
            Logics.Credentials.Password = password.Password;
            Logics.Credentials.Domain = domain.Text;
            if (Logics.Credentials.Login != "" && Logics.Credentials.Password != "" && Logics.Credentials.Domain != "")
                this.DialogResult = true;
            else
                this.DialogResult = false;
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
