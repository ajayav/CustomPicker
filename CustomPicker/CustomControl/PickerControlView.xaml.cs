using MauiPopup;
using MauiPopup.Views;
using System.Collections;

namespace CustomPicker.CustomControl;

public partial class PickerControlView : BasePopupPage
{
	public PickerControlView(IEnumerable itemSource, DataTemplate itemTemplate, double pickerHeight = 200)
	{
		InitializeComponent();

		clPicker.ItemsSource = itemSource;
		clPicker.ItemTemplate = itemTemplate;
		clPicker.HeightRequest = pickerHeight;
	}

	private void clPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		var currentOutlet = e.CurrentSelection.FirstOrDefault();
		PopupAction.ClosePopup(currentOutlet);
	}
}