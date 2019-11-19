using BookContactInterface;
using BookContactLibrary;
using BookContactStructure;
using ContactBookViewModel;
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
    /// Logique d'interaction pour CreateContact.xaml
    /// </summary>
    public partial class CreateContact : Page, INotifyPropertyChanged
    {
        IPersistance<CONTACTS> persi;
        public event PropertyChangedEventHandler PropertyChanged;


        private ViewContact vContact;
        public ViewContact VContact
        {
            get { return vContact; }
            set
            {
                if (vContact != value)
                {
                    vContact = value;
                }
            }
        }

        
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
        public CreateContact(IPersistance<CONTACTS> _p)
        {
            persi = _p;
            VContact = new ViewContact();
            DataContext = VContact;
            InitializeComponent();
        }


    }
}
