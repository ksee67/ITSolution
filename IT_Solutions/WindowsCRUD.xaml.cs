using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace IT_Solutions
{
    /// <summary>
    /// Логика взаимодействия для WindowsCRUD.xaml
    /// </summary>
    public partial class WindowsCRUD : Window
    {
        public WindowsCRUD()
        {
            InitializeComponent();
        }
        private void OrdersFill()
        {
            try
            {
                Action action = () =>
                {
                    DataSetClass dataBaseClass = new DataSetClass(); /// Обращение к классу с подключением базы данных
                    dataBaseClass.sqlExecute("SELECT ID_Order, Name_Order, Date_of_issue, OborudovanieID, Name_Oborudovanie, ClientID, FirstName+' '+LastName, StatusID, Name_Status FROM [dbo].[Orders] INNER JOIN [dbo].Client ON [ClientID] = ID_Client INNER JOIN [dbo].Oborudovanie ON [OborudovanieID] = ID_Oborudovanie  INNER JOIN [dbo].Status ON [StatusID] = ID_Status ", DataSetClass.act.select);
                    dataBaseClass.dependency.OnChange += DependancyOnChangeTask;
                    dgOrders.ItemsSource = dataBaseClass.resultTable.DefaultView;
                    dgOrders.Columns[0].Visibility = Visibility.Hidden; /// Скрытие шапки
                    dgOrders.Columns[1].Header = "Номер заявки";
                    dgOrders.Columns[2].Header = "Дата оформления";
                    dgOrders.Columns[3].Visibility = Visibility.Hidden; /// Скрытие шапки
                    dgOrders.Columns[4].Header = "Оборудование";
                    dgOrders.Columns[5].Visibility = Visibility.Hidden; /// Скрытие шапки
                    dgOrders.Columns[6].Header = "Клиент";
                    dgOrders.Columns[7].Visibility = Visibility.Hidden; /// Скрытие шапки
                    dgOrders.Columns[8].Header = "Статус";
                };
                Dispatcher.Invoke(action);
            }
            catch { }
        }

        private void DependancyOnChangeTask(object sender, SqlNotificationEventArgs e)
        {
            if (e.Info != SqlNotificationInfo.Invalid)
            {
                OrdersFill(); /// Вызов метода для загрузки данных
            }
        }

        private void dgOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OrdersFill(); /// Вызов метода для загрузки данных
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowsCRUD window = new WindowsCRUD(); 
            window.Show(); /// Открытие окна
            this.Close(); /// Закрытие текущего окна
        }

        private void dgOrders_Loaded(object sender, RoutedEventArgs e)
        {
            OrdersFill(); /// Вызов метода для загрузки данных
        }

        private void searchNumber_SelectionChanged(object sender, RoutedEventArgs e)
        {
                try
                {
                    Action action = () =>
                    {
                        string searchText = searchNumber.Text; /// Объявление пременных
                        DataSetClass dataBaseClass = new DataSetClass();
                        dataBaseClass.sqlExecute("SELECT ID_Order, Name_Order, Date_of_issue, OborudovanieID, Name_Oborudovanie, ClientID, FirstName+' '+LastName, StatusID, Name_Status FROM [dbo].[Orders] INNER JOIN [dbo].Client ON [ClientID] = ID_Client INNER JOIN [dbo].Oborudovanie ON [OborudovanieID] = ID_Oborudovanie  INNER JOIN [dbo].Status ON [StatusID] = ID_Status WHERE Name_Order LIKE '%" + searchText + "%'", DataSetClass.act.select);
                        dataBaseClass.dependency.OnChange += DependancyOnChangeTask;
                        dgOrders.ItemsSource = dataBaseClass.resultTable.DefaultView;
                        dgOrders.Columns[0].Visibility = Visibility.Hidden; /// Скрытие шапки
                        dgOrders.Columns[1].Header = "Номер заявки";
                        dgOrders.Columns[2].Header = "Дата оформления";
                        dgOrders.Columns[3].Visibility = Visibility.Hidden; /// Скрытие шапки
                        dgOrders.Columns[4].Header = "Оборудование";
                        dgOrders.Columns[5].Visibility = Visibility.Hidden; /// Скрытие шапки
                        dgOrders.Columns[6].Header = "Клиент";
                        dgOrders.Columns[7].Visibility = Visibility.Hidden; /// Скрытие шапки
                        dgOrders.Columns[8].Header = "Статус";
                    };
                    Dispatcher.Invoke(action);
                }
                catch { }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show(); /// Открытие окна
            this.Close(); /// Закрытие текущего окна
        }
    }
}
