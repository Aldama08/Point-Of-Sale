using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace Point_of_Sale
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private NavigationViewItem _lastItem;
       private void NavigationFailed(NavigationView sender, NavigationViewItemInvokedEventArgs e)
        {

        }
        
        private void NagivationView_Invoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            var item = args.InvokedItemContainer as NavigationViewItem;
            if (item == null || item == _lastItem)
                return;
            var clickedView = item.Tag.ToString() ?? "SettingsView";
            if (!NavigateToView(clickedView)) return;
            _lastItem = item;
        }

        private bool NavigateToView(string clickView) //Metodo 
        {
            var view = Assembly.GetExecutingAssembly().GetType($"Point-of-Sale.Views.{clickView}");

            if(string.IsNullOrWhiteSpace(clickView) || view == null )
                return false;

            ContentFrame.Navigate(view, null, new EntranceNavigationTransitionInfo() );
            return true;

        }

        private void NagivationView_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void NagivationView_Changed(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {

        }
    }

    
    
}
 //Este es un comentario
