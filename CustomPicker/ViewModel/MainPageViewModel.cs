using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CustomPicker.Model;
using System.Collections.ObjectModel;

namespace CustomPicker.ViewModel
{
    public partial class MainPageViewModel : ObservableObject
    {
        public ObservableCollection<Outlet> Outlets { get; set; } = new ObservableCollection<Outlet>();
       
        [ObservableProperty]
        private bool _isLoading;

        [ObservableProperty]
        private bool _isDisplayPicker;

        [ObservableProperty]
        private bool _currentOutlet;

        public MainPageViewModel()
        {

        }

        [RelayCommand]
        public void OpenPicker()
        {
            IsLoading = true;

            Outlets.Add(new Outlet { Name = "Mint Super Bazar" });
            Outlets.Add(new Outlet { Name = "Mint Hebbal" });
            Outlets.Add(new Outlet { Name = "Mint Wtf" });
            Outlets.Add(new Outlet { Name = "Smart Infotech" });
            Outlets.Add(new Outlet { Name = "Shopwel" });
            Outlets.Add(new Outlet { Name = "All Market" });
            Outlets.Add(new Outlet { Name = "All Season" });
            
            IsLoading = false;
            IsDisplayPicker = true;
        }
    }
}
