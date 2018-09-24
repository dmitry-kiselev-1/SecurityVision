using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ProductDescriptor = SecurityVision.SilverlightClient.Model.ProductDescriptor;

namespace SecurityVision.SilverlightClient.ViewModel
{
    public class ProductDescriptorViewModel: ViewModelBase
    {
        static private ProductDescriptor _selectedProductDescriptor;
        static private ObservableCollection<ProductDescriptor> _productDescriptors = new ObservableCollection<ProductDescriptor>();

        public ObservableCollection<ProductDescriptor> ProductDescriptors
        {
            get
            {
                return _productDescriptors;
            }
            set
            {
                _productDescriptors = value;
                RaisePropertyChanged("ProductDescriptors");
            }
        }

        public ProductDescriptor SelectedProductDescriptor
        {
            get
            {
                return _selectedProductDescriptor;
            }
            set
            {
                if (_selectedProductDescriptor != value)
                {
                    _selectedProductDescriptor = value;
                    RaisePropertyChanged("SelectedProductDescriptor");
                }
            }
        }

        public void Load(int? id = null)
        {
            base.SelectAsync<ProductDescriptor>(id);
        }

    }
}
