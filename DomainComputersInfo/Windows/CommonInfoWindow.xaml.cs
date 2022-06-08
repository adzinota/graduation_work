using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
namespace DomainComputersInfo.Windows
{
    public partial class CommonInfoWindow : Window
    {

        public static String ComputerName;
        public static CollectionView view;
        //===============================================================================================
        public CommonInfoWindow()
        {
            InitializeComponent();
            this.Loaded += CommonInfoWindow_Loaded;
        }
        //===============================================================================================
        private bool GetPCName()
        {
            if (MainInfoListView.SelectedItems.Count > 0)
            {
                var value = (Logics.DisplayData)MainInfoListView.SelectedItem;
                ComputerName = value.PCname;
                return true;
            }
            else return false;

        }
        //===============================================================================================
        private void CommonInfoWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Logics.GetFromDB.GetMainInfo(MainInfoListView);
            view = (CollectionView)CollectionViewSource.GetDefaultView(MainInfoListView.ItemsSource);
        }
        //===============================================================================================
        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            if (GetPCName())
            {
                Clipboard.SetText(ComputerName);
            }
        }
        //===============================================================================================
        private void Details_Click(object sender, RoutedEventArgs e)
        {
            if (GetPCName())
            {
                Windows.DetailedInfoWindow detailedInfoWindow = new();
                detailedInfoWindow.Show();
            }
        }
        //===============================================================================================
        private bool PCNameFilter(object item)
        {
            if (String.IsNullOrEmpty(PCName_Filter.Text))
                return true;
            else
                return (item as Logics.DisplayData).PCname.IndexOf(PCName_Filter.Text, StringComparison.OrdinalIgnoreCase) >= 0;
        }
        //===============================================================================================
        private void PCName_Filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            view.Filter = PCNameFilter;
            CollectionViewSource.GetDefaultView(MainInfoListView.ItemsSource).Refresh();
        }
        //===============================================================================================
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (GetPCName())
            {

                Windows.AcceptDeletion acceptDeletion = new();
                if (acceptDeletion.ShowDialog() == true)
                {
                    DomainComputersInfo.WorkWithDB.DeleteEntry();
                }
                else MessageBox.Show("Действие отменено");
            }
        }
        //===============================================================================================
    }
}
