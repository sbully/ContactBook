using BookContactInterface;
using BookContactLibrary;
using BookContactLibraryPersistence;
using BookContactStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace ContactBook.PageFolder
{
    /// <summary>
    /// Logique d'interaction pour ViewListContact.xaml
    /// </summary>
    public partial class ViewListContact : Page, INotifyPropertyChanged
    {
        IPersistance<CONTACTS> persi;
        IPersistance<PROFESSIONS> persiProf;

        public event PropertyChangedEventHandler PropertyChanged;

        private List<Profession> listProf;
        public List<Profession> ListProf
        {
            get { return listProf; }
            set
            {
                if (listProf != value)
                {
                    listProf = value;
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(ListProf)));
                }
            }
        }

        private List<Contact> listcon;
        public List<Contact> Listcon
        {
            get { return listcon; }
            set
            {
                if (listcon != value)
                {
                    listcon = value;
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(Listcon)));
                }
            }
        }

        private Contact selectedContact;
        public Contact SelectedContact
        {
            get { return selectedContact; }
            set
            {
                if (selectedContact != value)
                {
                    selectedContact = value;
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(SelectedContact)));
                }


            }
        }

        public ViewListContact(IPersistance<CONTACTS> _pCont, IPersistance<PROFESSIONS> _pProf)
        {
            persi = _pCont;
            persiProf = _pProf;
            InitializeComponent();

            ListContact listC = new ListContact();
            Listcon = listC.GetListContacts(persi);

            ListProfession listP = new ListProfession();
            ListProf = listP.GetListProfessions(persiProf);
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            MainWindow parent = Window.GetWindow(this) as MainWindow;
            parent.LoadingPage(b.Tag.ToString());
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
