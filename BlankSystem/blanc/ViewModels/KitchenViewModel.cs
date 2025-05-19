using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using blanc.Models;
using blanc.ViewModels.Commands;
using blanc.Views;
using Newtonsoft.Json;

namespace blanc.ViewModels
{
    public class KitchenViewModel : ViewModelBase
    {
        const string ordersJsn = "Orders.json";

        private ObservableCollection<Orders> _orders;
        private Orders _selectedOrder;

        public ObservableCollection<Orders> _Orders 
        {
            get {  return _orders; } 
            set { _orders = value; OnPropertyChanged(nameof(_Orders)); }
        }

        private Orders _selectedorder;
        public Orders SelectedOrder
        {
            get { return _selectedorder; }
            set
            {
                _selectedorder = value;
                OnPropertyChanged(nameof(SelectedOrder));

            }
        }



        public ICommand OpenOrderWindowCommand { get; private set; }
       
   
        public KitchenViewModel() 
        {
           
            _orders = new ObservableCollection<Orders>();
            OpenOrderWindowCommand = new RelayCommand(OpenOrderWindow);
            LoadOrders();
        }

        

        private Dictionary<int, OrderWindow> openOrders = new Dictionary<int, OrderWindow>();
        private void OpenOrderWindow()
        {
            if (this.SelectedOrder != null)
            {
                // Зареждате всички маси от JSON файла
                string json = File.ReadAllText(ordersJsn);
                List<Orders> tables = JsonConvert.DeserializeObject<List<Orders>>(json);

                // Ако съответната маса е намерена
                if (SelectedOrder != null && !openOrders.ContainsKey(SelectedOrder.OrderID))
                {
                    // Create the window and add it to the dictionary
                    var orderWindowView = new OrderWindow(SelectedOrder);
                    orderWindowView.Closed += (sender, args) => openOrders.Remove(SelectedOrder.OrderID);
                    openOrders[SelectedOrder.OrderID] = orderWindowView;
                    orderWindowView.Show();
                }
            }
        }


        private void LoadOrders()
        {
            string rawJson = File.ReadAllText(ordersJsn);
            List<Orders>? orders = JsonConvert.DeserializeObject<List<Orders>>(rawJson);

            if (orders != null)
            {
                foreach (var order in orders)
                {
                    _Orders.Add(order);
                }
            }
        }
    }

    
}
