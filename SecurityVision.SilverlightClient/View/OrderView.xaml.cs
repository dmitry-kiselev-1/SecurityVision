using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using SecurityVision.SilverlightClient.Model;
using SecurityVision.SilverlightClient.ViewModel;


namespace SecurityVision.SilverlightClient.View
{
    public partial class OrderView : UserControl
    {
        private OrderViewModel viewModel;
        private PagedCollectionView viewModelPagedCollection;

        public OrderView()
        {
            InitializeComponent();
            viewModel = (OrderViewModel)this.Resources["OrderViewModelDataSource"];

            // Загрузка Orders при запуске приложения:
            this.Loaded += (sender, args) => viewModel.SelectCommand.Execute(null);

            // Обработка событий viewModel, извещающих о завершении асинхронных операций:
            viewModel.PropertyChanged += (sender, args) =>
                {
                    if (args.PropertyName == "SelectAsyncCompleted")
                    {
                        viewModelPagedCollection = new PagedCollectionView(viewModel.Orders);
                        this.Dispatcher.BeginInvoke(() =>
                        {
                            this.C1DataPagerOrder.Source = viewModelPagedCollection;
                            C1DataPagerOrder.Source = viewModelPagedCollection;
                        });
                    }
                    
                    if (args.PropertyName == "SelectedOrder")
                    {
                        ButtonDeleteOrder.Command = viewModel.DeleteCommand;
                    }
                };

            // Подписка на событие обновления (или добавления, если Id == 0) строки DataGrid - вызов команды viewModel:
            C1DataGridOrder.CommittedRowEdit += (sender, args) => viewModel.UpdateCommand.Execute(args.Row.DataItem);

            //ButtonSaveChanges.Click += SaveChanges;
        }

        /// <summary>
        /// Не используется - оставлен, как пример.
        /// Это обработчик пакетного сохранения данных, введённых и удалённых на клиенте (в DataGrid).
        /// Данный обработчик может быть задействован, если будет включён режим привязки OneWay
        /// и закомментированы привязки на события единичных добавлений и обновлений строк DataGrid.
        /// В этом случае изменения элементов DataGrid не синхронизируются с viewModel и возможно будет сравнить их,
        /// отправив в базу только изменения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveChanges(object sender, RoutedEventArgs e)
        {
            // Исключение служебной строки:
            var rows = C1DataGridOrder.Rows.Where(r => r.DataItem != null).ToList();

            // Добавление новых:
            foreach (var row in rows.Where(r => ((Order)r.DataItem).Id == 0))
            {
                try
                {
                    viewModel.CreateCommand.Execute(row.DataItem);
                }
                catch (Exception)
                {}
            }

            // Обновление изменённых:
            foreach (var row in rows.Where(r => ((Order)r.DataItem).Id != 0))
            {
                Order orderNew = (Order)row.DataItem;
                Order orderOld = viewModel.Orders.First(o => o.Id == orderNew.Id);

                if (!orderNew.Equals(orderOld))
                {
                    try
                    {
                        viewModel.UpdateCommand.Execute(row.DataItem);
                    }
                    catch (Exception)
                    {}
                }
            }
        }
    }
}
