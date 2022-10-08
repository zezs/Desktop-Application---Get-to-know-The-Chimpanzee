using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using System.Collections.ObjectModel;

namespace WpfApp_Chimpanzee
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public static ObservableCollection<Content> _content;

        public static ObservableCollection<Gallery> _gallery;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            _content = MyStorage.ReadXml<ObservableCollection<Content>>("Content.xml");
            _gallery = MyStorage.ReadXml<ObservableCollection<Gallery>>("Gallery.xml");

            if (_content == null)
                _content = new ObservableCollection<Content>();

            if (_gallery == null)
                _gallery = new ObservableCollection<Gallery>();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            MyStorage.WriteXml<ObservableCollection<Content>>(_content, "Content.xml");
            MyStorage.WriteXml<ObservableCollection<Gallery>>(_gallery, "Gallery.xml");
        }
    }
}
