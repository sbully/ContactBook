using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ContactBookViewModel
{
    public class ViewContact : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        private bool isOk;
        public bool IsOk
        {
            get { return isOk; }
            set
            {
                if (isOk != value)
                {
                    isOk = value;
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(IsOk)));
                }
            }
        }

        private string nom_Contact;
        public string Nom_Contact
        {
            get { return nom_Contact; }
            set
            {
                if (nom_Contact != value)
                {
                    nom_Contact = value;
                    GetSomeChanged(nameof(Nom_Contact), this, value);
                }
            }
        }

        private string prenom_Contact;
        public string Prenom_Contact
        {
            get { return prenom_Contact; }
            set
            {
                if(prenom_Contact != value)
                {
                    prenom_Contact = value;
                    GetSomeChanged(nameof(Prenom_Contact), this, value);
                }
            }
        }

        private string rue_Contact;
        public string Rue_Contact
        {
            get { return rue_Contact; }
            set
            {
                if (rue_Contact != value)
                {
                    rue_Contact = value;
                    GetSomeChanged(nameof(Rue_Contact), this, value);
                }
            }
        }

        private string codePostal_Contact;
        public string CodePostal_Contact
        {
            get { return codePostal_Contact; }
            set
            {
                if (codePostal_Contact != value)
                {
                    codePostal_Contact = value;
                    GetSomeChanged(nameof(CodePostal_Contact), this, value);
                }
            }
        }

        private string ville_Contact;
        public string Ville_Contact
        {
            get { return ville_Contact; }
            set
            {
                if (ville_Contact != value)
                {
                    ville_Contact = value;
                    GetSomeChanged(nameof(Ville_Contact), this, value);
                }
            }
        }


        public bool HasErrors {
            get
            {
                bool HaveError = false;
                lock (ErrorList)
                {
                    if(string.IsNullOrEmpty(nom_Contact) || string.IsNullOrEmpty(prenom_Contact) ||
                        string.IsNullOrEmpty(rue_Contact) || string.IsNullOrEmpty(codePostal_Contact) || string.IsNullOrEmpty(ville_Contact))
                    {
                        HaveError = true;

                    }

                    foreach(string key in ErrorList.Keys)
                    {
                        if(ErrorList[key] != null)
                        {
                            HaveError = true;
                            break;
                        }
                    }
                }

                IsOk = !HaveError;

                return HaveError;
            }
        }

        public ViewContact()
        {
            ErrorList = new Dictionary<string, List<string>>();
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        private Dictionary<string, List<string>> ErrorList;


        public IEnumerable GetErrors(string propertyName)
        {
            lock (ErrorList)
            {
                if (ErrorList.ContainsKey(propertyName))
                {
                    return ErrorList[propertyName];
                }
                return null;
            }
        }

        private void GetSomeChanged(string propertyname, object sender, object value)
        {
            PropertyChanged(sender, new PropertyChangedEventArgs(propertyname));

            if(propertyname == "Nom_Contact" || propertyname == "Prenom_Contact" || propertyname == "Rue_Contact" 
                || propertyname == "CodePostal_Contact" || propertyname == "Ville_Contact")
            {
                GetErrorProperty(value, propertyname).ContinueWith(task =>
                {
                    ErrorList[propertyname] = (task.Result.ContainsKey(propertyname)) ? task.Result[propertyname] : null;
                    ErrorsChanged(sender, new DataErrorsChangedEventArgs(propertyname));
                });
            }
        }

        Task<Dictionary<string, List<string>>> GetErrorProperty(object value, string property)
        {
            return Task.Factory.StartNew<Dictionary<string, List<string>>>(() =>
           {
               Dictionary<string, List<string>> listError = new Dictionary<string, List<string>>();
               switch (property)
               {
                   case "Nom_Contact":
                       if (!Regex.IsMatch((string)value, @"^[a-zA-ZÀÁÂÆÇÈÉÊËÌÍÎÏÑÒÓÔŒÙÚÛÜÝŸàáâæçèéêëìíîïñòóôœùúûüýÿ \s\-]{2,}$"))
                       {
                           listError.Add("Nom_Contact", new List<string> { "Le nom ne peut contenir que des lettres, des espaces et des tirets" });
                       }
                       break;
                   case "Prenom_Contact":
                       if (!Regex.IsMatch((string)value, @"^[a-zA-ZÀÁÂÆÇÈÉÊËÌÍÎÏÑÒÓÔŒÙÚÛÜÝŸàáâæçèéêëìíîïñòóôœùúûüýÿ \s\-]{2,}$"))
                       {
                           listError.Add("Prenom_Contact", new List<string> { "Le prenom ne peut contenir que des lettres, des espaces et des tirets" });
                       }
                       break;

                   case "Rue_Contact":
                       if (!Regex.IsMatch((string)value, @"^[a-zA-Z\s\-]{5,}$"))
                       {
                           listError.Add("Rue_Contact", new List<string> { "L'adresse ne peut contenir que des lettres, des espaces et des tirets" });
                       }
                       break;

                   case "CodePostal_Contact":
                       if (!Regex.IsMatch((string)value, @"^[0-9]{5,5}$"))
                       {
                           listError.Add("CodePostal_Contact", new List<string> { "le code postal ne peut contenir que des chiffres" });
                       }
                       break;

                   case "Ville_Contact":
                       if (!Regex.IsMatch((string)value, @"^[a-zA-Zéèçëêï\s\-]{5,}$"))
                       {
                           listError.Add("Ville_Contact", new List<string> { "L'adresse ne peut contenir que des lettres, des espaces et des tirets" });
                       }
                       break; 
               }
               return listError;
           });


        }

    }
}
