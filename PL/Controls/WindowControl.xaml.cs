﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace PL.Controls
{
    public partial class WindowControl : INotifyPropertyChanged
    {
        public WindowControl()
        { 
            InitializeComponent();
            // Set Previous to Current
            PreviousWindow = Window;
        }

        #region PreviousWindow

        private static readonly DependencyProperty PreviousWindowProperty =
            DependencyProperty.Register(nameof(PreviousWindow), typeof(Window), typeof(WindowControl));

        public Window PreviousWindow
        {
            get => (Window)GetValue(PreviousWindowProperty);
            set
            {
                SetValue(PreviousWindowProperty, value);
                OnPropertyChanged();
            }
        }

        #endregion

        #region Window

        public Window Window
        {
            get => (Window)GetValue(WindowProperty);
            set
            {
                SetValue(WindowProperty, value);
                OnPropertyChanged();
            }
        }

        public static readonly DependencyProperty WindowProperty =
            DependencyProperty.Register(nameof(Window), typeof(Window), typeof(WindowControl));

        #endregion

        #region Events

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Window.Close();
            Window = PreviousWindow;
        }

        private void RestoreBtn_Click(object sender, RoutedEventArgs e)
        {
            Window.WindowState = (Window.WindowState == WindowState.Normal) ? WindowState.Maximized : WindowState.Normal;
        }

        private void MinimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            Window.WindowState = WindowState.Minimized;
        }

        #endregion

        #region PropertyChangedHandling

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}