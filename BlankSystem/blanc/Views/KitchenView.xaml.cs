using blanc.Models;
using blanc.ViewModels;
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

namespace blanc.Views
{
    
    public partial class KitchenView : UserControl
    {
        public KitchenView()
        {
            InitializeComponent();
            this.DataContext = new KitchenViewModel();
        }

        private void Orders_Click(object sender, RoutedEventArgs e)
        {

        }

        private void History_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Ready_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OpenMiniWindow_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Orders order)
            {

                OrderWindow miniWindow = new OrderWindow();
                miniWindow.ShowDialog();
            }
        }
    }
}
