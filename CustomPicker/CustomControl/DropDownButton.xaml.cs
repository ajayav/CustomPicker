using MauiPopup;
using System.Collections;
using System.Windows.Input;

namespace CustomPicker.CustomControl;

public partial class DropDownButton : Frame
{
    public DropDownButton()
    {
        InitializeComponent();
    }

    

  

   public static readonly BindableProperty ItemSourceProperty = BindableProperty.Create(
   propertyName: nameof(ItemSource),
   returnType: typeof(IEnumerable),
   declaringType: typeof(DropDownButton),
   defaultBindingMode: BindingMode.OneWay
   );

    public IEnumerable ItemSource
    {
        get => (IEnumerable)GetValue(ItemSourceProperty);
        set => SetValue(ItemSourceProperty, value);
    }

    public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
    propertyName: nameof(Placeholder),
    returnType: typeof(string),
    declaringType: typeof(DropDownButton),
    defaultBindingMode: BindingMode.OneWay,
    propertyChanged: PlaceholderPropertyChanged
    );

    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }

    private static void PlaceholderPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var controls = (DropDownButton)bindable;
        if(controls.CurrentItem != null)
        {
            if(newValue != null)
            {
                controls.lblDropDown.Text = newValue.ToString();
            }
        }
    }

    public static readonly BindableProperty CurrentItemProperty = BindableProperty.Create(
        propertyName: nameof(CurrentItem),
        returnType: typeof(object),
        declaringType: typeof(DropDownButton),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanged: CurrentItemPropertyChanged
        );

    public object CurrentItem
    {
        get => (object)GetValue(CurrentItemProperty);
        set => SetValue(CurrentItemProperty, value);
    }
    private static void CurrentItemPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var controls = (DropDownButton)bindable;
        if(newValue != null)
        {
            if (!string.IsNullOrWhiteSpace(controls.DisplayMember))
                controls.lblDropDown.Text = newValue.GetType().GetProperty(controls.DisplayMember).GetValue(newValue, null).ToString();
        }
    }


 

    public static readonly BindableProperty IsLoadingProperty = BindableProperty.Create(
        propertyName: nameof(IsLoading),
        returnType: typeof(bool),
        declaringType: typeof(DropDownButton),
        defaultBindingMode: BindingMode.OneWay
        );

    public bool IsLoading
    {
        get => (bool)GetValue(IsLoadingProperty);
        set => SetValue(IsLoadingProperty, value);
    }

    public static readonly BindableProperty OpenPickerCommandProperty = BindableProperty.Create(
    propertyName: nameof(OpenPickerCommand),
    returnType: typeof(ICommand),
    declaringType: typeof(DropDownButton),
    defaultBindingMode: BindingMode.OneWay
    );

    public ICommand OpenPickerCommand
    {
        get => (ICommand)GetValue(OpenPickerCommandProperty);
        set => SetValue(OpenPickerCommandProperty, value);
    }

    public static readonly BindableProperty IsDisplayPickerControlProperty = BindableProperty.Create(
        propertyName: nameof(IsDisplayPickerControl),
        returnType: typeof(bool),
        declaringType: typeof(DropDownButton),
        defaultBindingMode: BindingMode.TwoWay,
        propertyChanged: IsDisplayPickerControlPropertyChanged
        );

    private async static void IsDisplayPickerControlPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var controls = (DropDownButton)bindable;
        if (newValue != null)
        {
            if ((bool)newValue)
            {
                var response = await PopupAction.DisplayPopup<object>(new PickerControlView(controls.ItemSource, controls.ItemTemplate, controls.PickerHeight));
                if (response != null)
                {
                    controls.CurrentItem = response;
                }
                controls.IsDisplayPickerControl = false;
            }
        }
    }

    public bool IsDisplayPickerControl
    {
        get => (bool)GetValue(IsDisplayPickerControlProperty);
        set => SetValue(IsDisplayPickerControlProperty, value);
    }

    public event EventHandler<EventArgs> OpenPickerEvent;
    public DataTemplate ItemTemplate { get; set; }
    public double PickerHeight { get; set; }
    public string DisplayMember { get; set; }

    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        OpenPickerCommand?.Execute(null);
        //IsDisplayPickerControl = true;
        //OpenPickerEvent.Invoke(sender, e);
    }
}