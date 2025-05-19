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
using System.Windows.Shapes;

namespace blanc.Views
{
   
    public partial class OrderWindow : Window
    {
        public OrderWindow()
        {
            InitializeComponent();
            OrderWindowViewModel viewModel = new OrderWindowViewModel();
            this.DataContext = viewModel;
        }

        public OrderWindow(Orders selectedOrder):this()
        {
            var viewModel = this.DataContext as OrderWindowViewModel;
            if (viewModel != null)
            {
                viewModel.SelectedOrder = selectedOrder;
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Check if left mouse button is pressed
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                // Begin dragging the window
                this.DragMove();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
