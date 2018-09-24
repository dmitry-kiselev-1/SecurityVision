using System;
using System.Windows;
using System.Windows.Controls;
using SecurityVision.SilverlightClient.Model;
using SecurityVision.SilverlightClient.ViewModel;


namespace SecurityVision.SilverlightClient
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ProductView_Loaded(object sender, RoutedEventArgs e)
        {
            // Передача выбранного Order из OrderViewControl в ProductViewModel:
            OrderViewControl.C1DataGridOrder.SelectionChanged += (s, a) =>
            {
                var selectedItem = ((C1.Silverlight.DataGrid.C1DataGrid)s).SelectedItem;

                if (selectedItem != null)
                {
                    var selectedOrder = (Order)selectedItem;

                    ProductViewModel productViewModel = new ProductViewModel()
                                        {
                                            SelectedOrder = selectedOrder
                                        };
                }
            };
        }
    }
}
