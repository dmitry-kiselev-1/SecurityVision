using System.Windows.Controls;
using System.Windows.Data;
using SecurityVision.SilverlightClient.ViewModel;


namespace SecurityVision.SilverlightClient.View
{
    public partial class ProductView : UserControl
    {
        private ProductViewModel viewModel;
        private PagedCollectionView viewModelPagedCollection;

        public ProductView()
        {
            InitializeComponent();
            viewModel = (ProductViewModel)this.Resources["ProductViewModelDataSource"];

            // Обработка событий viewModel, извещающих о завершении асинхронных обработчиков:
            viewModel.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == "SelectByParentAsyncCompleted")
                {
                    viewModelPagedCollection = new PagedCollectionView(viewModel.Products);
                    this.Dispatcher.BeginInvoke(() =>
                                                {
                                                    this.C1DataPagerProduct.Source = viewModelPagedCollection;
                                                });
                }

            };
        }
    }
}
