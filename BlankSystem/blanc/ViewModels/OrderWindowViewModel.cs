using blanc.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace blanc.ViewModels
{
     
    public class OrderWindowViewModel : ViewModelBase
    {
        const string ordersJsn = "Orders.json";
        private Orders _selectedorder;
        public Orders SelectedOrder
        {
            get { return _selectedorder; }
            set
            {
                _selectedorder = value;
                OnPropertyChanged(nameof(SelectedOrder));
                LoadOrderItems();
            }
        }

        private ObservableCollection<OrderItem> _orderItems;

        public ObservableCollection<OrderItem> OrderItems
        {
            get { return _orderItems; }
            set { _orderItems = value; OnPropertyChanged(nameof(OrderItems)); }
        }

        public OrderWindowViewModel()
        {
            _orderItems = new ObservableCollection<OrderItem>();
        }

        private void LoadOrderItems()
        {
            if (SelectedOrder != null)
            {
                // Clear existing items
                OrderItems.Clear();

                // Add items for the selected order
                foreach (var orderItem in SelectedOrder.Items)
                {
                    OrderItems.Add(orderItem);
                }
            }
        }

    }
}
