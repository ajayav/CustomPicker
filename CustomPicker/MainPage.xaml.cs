using CustomPicker.Model;
using CustomPicker.ViewModel;

namespace CustomPicker;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		
		InitializeComponent();
		this.BindingContext = new MainPageViewModel();
	}

	//private async void dropDownControl_OpenPickerEvent(object sender, EventArgs e)
	//{
	//	dropDownControl.IsLoading = true;
 //       var outlets = new List<Outlet>();
 //       outlets.Add(new Outlet { Name = "Smart Infotech" });
 //       outlets.Add(new Outlet { Name = "Shopwel" });
 //       outlets.Add(new Outlet { Name = "All Market" });
 //       outlets.Add(new Outlet { Name = "All Season" });
 //       outlets.Add(new Outlet { Name = "Mint Super Bazar" });
 //       outlets.Add(new Outlet { Name = "Mint Hebbal" });
 //       outlets.Add(new Outlet { Name = "Mint Wtf" });
 //       dropDownControl.ItemSource = outlets;

 //       await Task.Delay(1000);
	//	dropDownControl.IsLoading = false;
	//	dropDownControl.IsDisplayPickerControl = true;

 //   }
}

