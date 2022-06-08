using System.Windows;

namespace DomainComputersInfo.Windows
{
    public partial class DetailedInfoWindow : Window
    {
        public DetailedInfoWindow()
        {
            InitializeComponent();
            this.Title = CommonInfoWindow.ComputerName;
            Logics.GetFromDB.GetAllInfo(ListBoxProcessor, ListBoxBaseBoard, ListBoxOperatingSystem, ListBoxUserProfile, ListBoxNetworkAdapter, ListBoxLogicalDisks, ListBoxPhysicalDisks, ListBoxMemory);
        }
    }
}