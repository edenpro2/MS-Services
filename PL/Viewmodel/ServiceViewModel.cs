using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ServiceHandler;

namespace PL;

public class ServiceViewModel : INotifyPropertyChanged
{
    private bool DspNameAscending { get; set; } = false;

    private ObservableCollection<Service> _services;
    public ObservableCollection<Service> Services
    {
        get => _services;
        set
        {
            if (_services != value)
            {
                _services = value;
                OnPropertyChanged();
            }
        }
    }

    // Constructor 
    public ServiceViewModel(IEnumerable<Service> services)
    {
        _services = new ObservableCollection<Service>(services);
    }

    #region PropertyChanged
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    #endregion
}
