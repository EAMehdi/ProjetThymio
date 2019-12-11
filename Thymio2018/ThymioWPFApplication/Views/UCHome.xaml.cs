using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ThymioWPFApplication.ViewModels;

namespace ThymioWPFApplication.Views
{
    /// <summary>
    /// Logique d'interaction pour UCHome.xaml
    /// </summary>
    public partial class UCHome : UserControl
    {
        public UCHome()
        {
            InitializeComponent();
            DataContext = new HomeViewModel();
        }
    }
}
