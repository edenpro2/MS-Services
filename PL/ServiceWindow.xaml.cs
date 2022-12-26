using MaterialDesignThemes.Wpf;
using PL.View;
using ServiceHandler;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace PL;

public partial class ServiceWindow : Window, INotifyPropertyChanged
{
    public static double MinScreenWidth => UserInterfaceMethods.MinScreenWidth(0.1);
    public static double MinScreenHeight => UserInterfaceMethods.MinScreenHeight(0.1);

    public ServiceViewModel ServiceViewModel { get; set; }

    private Service? _selectedService;
    public Service? SelectedService
    {
        get => _selectedService;
        set
        {
            if (_selectedService != value)
            {
                _selectedService = value;
                OnPropertyChanged();
            }
        }
    }

    public ServiceWindow()
    {
        var services = ServiceHandler.ServiceHandler.GetAllServices();
        services.Sort();
        ServiceViewModel = new(services);
        InitializeComponent();
    }

    public void UpdateServices()
    {
        ServiceViewModel = new ServiceViewModel(ServiceHandler.ServiceHandler.GetAllServices());
    }

    protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
    {
        DragMove();
    }

    private void ServiceList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        SelectedService = (Service)((System.Windows.Controls.DataGrid)sender).SelectedItem;
    }

    #region PropertyChanged
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion

    private void ServiceDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        if (SelectedService == null)
            return;

        new PropertiesPopup().Show();
    }
}

