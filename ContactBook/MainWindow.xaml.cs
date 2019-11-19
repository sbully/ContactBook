using BookContactLibraryPersistence;
using ContactBook.PageFolder;
using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ContactBook
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : NavigationWindow
    {
        PersistenceContact persi;
        PersistenceProf persiprof;
        public MainWindow()
        {
            
            Connection();         
            InitializeComponent();
            LoadingPage("ListContact");
        }

        public void LoadingPage(string page)
        {
            switch (page)
            {
                case "ListContact":
                    this.Navigate(new ViewListContact(persi,persiprof));
                    break;
                default:
                    this.Navigate(new ViewListContact(persi, persiprof));
                    break;
            }

        }

        private void Connection()
        {
            SqlConnection sqlco = new SqlConnection();
            ConnectionStringSettings strsqlco =(ConfigurationManager.ConnectionStrings["ContactBookConnectionString"]);
            sqlco.ConnectionString = strsqlco.ConnectionString;
            persi = new PersistenceContact(sqlco);
            persiprof = new PersistenceProf(sqlco);
        }

    }
}
