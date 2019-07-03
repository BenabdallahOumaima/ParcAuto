using DevExpress.Xpo;
using System.ComponentModel;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;

namespace GestParcAuto.Module.BusinessObjects
{
    [DefaultClassOptions, DefaultProperty("UserName")]

    [ImageName("BO_Employee")]
  
    public class Administrateur : XPObject

    {
       
    public Administrateur(Session session) : base(session) { }
        // Ce constructeur est utilisé lorsqu'un objet est chargé à partir d'un stockage persistant.
     
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
        // L'implémentation de la méthode AfterConstruction de base 
        //inclut uniquement les fonctionnalités pertinentes pour les objets persistants.
        private string _nom;
        private string _prenom;
        private int _cin;
        private int _tel;
        private string _UserName;
        private int _password;
        [RuleRequiredField("RuleRequiredField for Administrateur.Nom",DefaultContexts.Save)]
        [RuleRegularExpression("", DefaultContexts.Save, "^[a-zA-Z]+$")]

        public string Nom
        {
            get
            {
                return _nom;
            }
            set
            {
                SetPropertyValue("Nom", ref _nom, value);
            }

        }

        [RuleRequiredField("RuleRequiredField for Administrateur.Prenom",DefaultContexts.Save)]
        [RuleRegularExpression("", DefaultContexts.Save, "^[a-zA-Z]+$")]

        public string Prenom
        {
            get
            {
                return _prenom;
            }
            set
            {
                SetPropertyValue("Prenom", ref _prenom, value);
            }

        }
        [RuleRequiredField("RuleRequiredField for Administrateur.CIN",DefaultContexts.Save)]
        [RuleRange("", DefaultContexts.Save,10000000,99999999)]


        public int CIN
        {
            get
            {
                return _cin;
            }
            set
            {
                SetPropertyValue("CIN", ref _cin, value);
            }

        }
        [RuleRequiredField("RuleRequiredField for Administrateur.Tel",DefaultContexts.Save)]
        [RuleRange("", DefaultContexts.Save,10000000,99999999)]

        public int Tel
        {
            get
            {
                return _tel;

            }
            set
            {
                SetPropertyValue("Tel", ref _tel, value);
            }
        }
        [RuleRequiredField("RuleRequiredField for Administrateur.UserName",DefaultContexts.Save)]
        [RuleRegularExpression("", DefaultContexts.Save, "^[a-zA-Z]+$")]

        public string UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                SetPropertyValue("UserName", ref _UserName, value);
            }
        }
        [RuleRequiredField("RuleRequiredField for Administrateur.Password",DefaultContexts.Save)]
        public int Password
        {
            get
            {
                return _password;
            }
            set
            {
                SetPropertyValue("Password", ref _password, value);
            }}

      
    }
}
