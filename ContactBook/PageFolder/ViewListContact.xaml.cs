using BookContactInterface;
using BookContactLibrary;
using BookContactLibraryPersistence;
using BookContactStructure;
using ContactBook.Modal;
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
            //Button b = (Button)sender;
            //MainWindow parent = Window.GetWindow(this) as MainWindow;
            //parent.LoadingPage(b.Tag.ToString());
            Create create = new Create(ListProf);
            create.ShowDialog();
            
            if (create.DialogResult == true)
            {
                Contact c = create.VContact.GetContact();
                c.SaveContact(persi);
            }

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedContact != null)
            {
                EditContact editC = new EditContact(selectedContact, ListProf);
                editC.ShowDialog();
                Contact c = editC.VContact.GetContact();
                if (editC.DialogResult == true)
                {
                    string toto = "toto";
                }
            }
            
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if(SelectedContact != null)
            {
                Contact c = this.SelectedContact;
                c.DeleteContact(persi);
            }
            ListContact listC = new ListContact();
            Listcon = listC.GetListContacts(persi);
        }

    }
}
