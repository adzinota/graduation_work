using System;
using System.Collections.Generic;
using System.Windows;

namespace DomainComputersInfo.Windows
{
    public partial class ManualWindow : Window
    {
        public ManualWindow()
        {
            InitializeComponent();
            PCNames.Names = new();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {

            if (pcname.Text != "" && domain.Text != "")
            {
              PCNames.Names = GetComputers.GetManual(domain.Text, pcname.Text, PCNames.Names);
            }

        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            Credentials credentials = new();
            if (credentials.ShowDialog() == true)
            {
                if (PCNames.Names.Count > 0)
                {
                    DomainComputersInfo.WorkWithDB.GetAllInfo(PCNames.Names, Logics.Credentials.Login, Logics.Credentials.Password);
                    MessageBox.Show("База заполнена");
                }
                else MessageBox.Show("Список компьютеров пуст");

            }
            else MessageBox.Show("Введите учетные данные!");
        }

        private static class PCNames
        {
            public static List<String> Names { get; set; }

        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
