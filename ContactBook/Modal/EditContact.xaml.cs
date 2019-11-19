using BookContactLibrary;
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
using System.Windows.Shapes;

namespace ContactBook.Modal
{
    /// <summary>
    /// Logique d'interaction pour EditContact.xaml
    /// </summary>
    public partial class EditContact : Window, INotifyPropertyChanged
    {
        private ViewContact vContact;

        public event PropertyChangedEventHandler PropertyChanged;

        public ViewContact VContact
        {
            get { return vContact; }
            set
            {
                if (vContact != value)
                {
                    vContact = value;
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(VContact)));
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

        public EditContact(ViewContact vc, List<Profession> _listP)
        {
            InitializeComponent();
            VContact = vc;
            ListProf = _listP;
            CBOX.SelectedIndex = listProf.FindIndex(x => x.Libele_Profession == vc.Profession.Libele_Profession);

        }
        private void Sauve_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;

        }
    }
}
