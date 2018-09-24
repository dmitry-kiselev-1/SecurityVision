using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Order = SecurityVision.SilverlightClient.Model.Order;

namespace SecurityVision.SilverlightClient.ViewModel
{
    public class OrderViewModel : ViewModelBase
    {
        static private Order _selectedOrder;
        static private ObservableCollection<Order> _orders = new ObservableCollection<Order>();

        public ObservableCollection<Order> Orders
        {
            get
            {
                return _orders;
            }
            set
            {
                _orders = value;
                RaisePropertyChanged("Orders");
            }
        }

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

        #region SelectCommand

            private Select _selectCommand;

            public Select SelectCommand
            {
                get
                {
                    _selectCommand = new Select(this);
                    return _selectCommand;
                }
            }

            /// <summary>
            /// Извлекает коллекцию всех сущностей
            /// </summary>
            public class Select : ICommand
            {
                private readonly OrderViewModel _viewModel;

                internal Select(OrderViewModel orderViewModel)
                {
                    _viewModel = orderViewModel;
                }

                public void Execute(object parameter)
                {
                    _viewModel.Orders.Clear();
                    _viewModel.SelectAsync<Order>();
                    _viewModel.SelectedOrder = null;
                }

                public bool CanExecute(object parameter)
                {
                    return true;
                }

                public event EventHandler CanExecuteChanged;
            }

        #endregion

        #region DeleteCommand
        
            private Delete _deleteCommand;

            public Delete DeleteCommand
            {
                get
                {
                    _deleteCommand = new Delete(this);
                    return _deleteCommand;
                }
            }
            
            /// <summary>
            /// Удаляет сущность
            /// </summary>
            public class Delete : ICommand
            {
                private readonly OrderViewModel _viewModel;

                internal Delete(OrderViewModel orderViewModel)
                {
                    _viewModel = orderViewModel;
                }

                public void Execute(object parameter)
                {
                    if (_selectedOrder != null)
                    {
                        _viewModel.Orders.Remove(_viewModel.SelectedOrder);
                        _viewModel.DeleteAsync<Order>(_viewModel.SelectedOrder.Id);
                        _viewModel.SelectedOrder = null;
                    }
                }

                public bool CanExecute(object parameter)
                {
                    return _viewModel.SelectedOrder != null;
                }

                public event EventHandler CanExecuteChanged;
            }

        #endregion

        #region CreateCommand

            private Create _createCommand;

            public Create CreateCommand
            {
                get
                {
                    _createCommand = new Create(this);
                    return _createCommand;
                }
            }

            public class Create : ICommand
            {
                private readonly OrderViewModel _viewModel;

                internal Create(OrderViewModel orderViewModel)
                {
                    _viewModel = orderViewModel;
                }

                public void Execute(object parameter)
                {
                    var order = parameter as Order;
                    if (order != null)
                    {
                        _viewModel.CreateAsync<Order>(order);
                    }
                }

                public bool CanExecute(object parameter)
                {
                    return true;
                }

                public event EventHandler CanExecuteChanged;
            }
        
        #endregion

        #region UpdateCommand

            private Update _updateCommand;

            public Update UpdateCommand
            {
                get
                {
                    _updateCommand = new Update(this);
                    return _updateCommand;
                }
            }

            public class Update : ICommand
            {
                private readonly OrderViewModel _viewModel;

                internal Update(OrderViewModel orderViewModel)
                {
                    _viewModel = orderViewModel;
                }

                public void Execute(object parameter)
                {
                    var newOrder = parameter as Order;
                    if (newOrder != null)
                    {
                        if (newOrder.Id == 0)
                        {
                            // Добавить, если запись новая:
                            _viewModel.CreateCommand.Execute(newOrder);
                        }
                        else
                        {
                            // Обновить, если запись существующая:
                            _viewModel.UpdateAsync<Order>((Order) parameter);
                        }
                    }
                }

                public bool CanExecute(object parameter)
                {
                    return true;
                }

                public event EventHandler CanExecuteChanged;
            }

        #endregion
    }
}
