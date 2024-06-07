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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IT_Solutions
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = pbLogin.Text.ToString(); /// Объявление переменной логина
            string pass = pbPassword.Password.ToString(); /// Объявление переменной пароля
            DataSetClass dataBaseClass = new DataSetClass(); 
            string QAuth = String.Format("select * from [dbo].[Client] where [Login] = '{0}' and [Password] = '{1}'",
                login, pass);
            dataBaseClass.sqlExecute(QAuth, DataSetClass.act.select); /// Выполнение срипта
            if (dataBaseClass.resultTable.Rows.Count > 0) /// Проверка есть ли данные в базе данных
            {
                WindowsCRUD window = new WindowsCRUD();
                window.Show();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль клиента");
                pbLogin.Clear();
                pbPassword.Clear();
            }
        }
    }
}
