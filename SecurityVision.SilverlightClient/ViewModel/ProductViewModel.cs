using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Media.Animation;
using SecurityVision.SilverlightClient.Model;
using Product = SecurityVision.SilverlightClient.Model.Product;

namespace SecurityVision.SilverlightClient.ViewModel
{
    public class ProductViewModel: ViewModelBase
    {
        static private ObservableCollection<Product> _products = new ObservableCollection<Product>();
        public ObservableCollection<Product> Products
        {
            get
            {
                return _products;
            }
            set
            {
                _products = value;
                RaisePropertyChanged("Products");
            }
        }

        static private Product _selectedProduct;
        public Product SelectedProduct
        {
            get
            {
                return _selectedProduct;
            }
            set
            {
                if (_selectedProduct != value)
                {
                    _selectedProduct = value;
                    RaisePropertyChanged("SelectedProduct");
                }
            }
        }

        static private Order _selectedOrder;
        public Order SelectedOrder
        {
            get
            {
                return _selectedOrder;
            }
            set
            {
                if (_selectedOrder != value)
                {
                    _selectedOrder = value;
                    RaisePropertyChanged("SelectedOrder");
                }
            }
        }

        #region SelectByParentCommand

            private SelectByParent _selectByParentCommand;

            public SelectByParent SelectByParentCommand
            {
                get
                {
                    _selectByParentCommand = new SelectByParent(this);
                    return _selectByParentCommand;
                }
            }

            public class SelectByParent : ICommand
            {
                private readonly ProductViewModel _viewModel;

                internal SelectByParent(ProductViewModel viewModel)
                {
                    _viewModel = viewModel;
                }

                public void Execute(object parameter)
                {
                    _viewModel.SelectedProduct = null;
                    _viewModel.Products.Clear();
                    _viewModel.SelectByParentAsync<Order, Product>(_viewModel.SelectedOrder.Id);
                }

                public bool CanExecute(object parameter)
                {
                    return true; /*_viewModel.SelectedOrder != null*/;
                }

                public event EventHandler CanExecuteChanged;
            }

        #endregion
    }
}
