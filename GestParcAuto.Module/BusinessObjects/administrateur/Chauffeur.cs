using DevExpress.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;

namespace GestParcAuto.Module.BusinessObjects.ChauffeurNS
{




    [DefaultClassOptions, ImageName("BO_Employee")]
    public class Chauffeur : XPObject

    {

        private string nom;
        private string prenom;
        private string _UserName;
        private int password;
        private int tel;

        public Chauffeur(Session session) : base(session)
        {


        }
       

        public override void AfterConstruction()
        {
            base.AfterConstruction();

        }



        [RuleRequiredField("RuleRequiredField for Chauffeur.Nom",
       DefaultContexts.Save)]
        [RuleRegularExpression("", DefaultContexts.Save, "^[a-zA-Z]+$")]

        public string Nom
        {
            get { return nom; }
            set { SetPropertyValue("Nom", ref nom, value); }
        }
        [RuleRequiredField("RuleRequiredField for Chauffeur.Prenom",
        DefaultContexts.Save)]
        [RuleRegularExpression("", DefaultContexts.Save, "^[a-zA-Z]+$")]

        public string Prenom
        {
            get { return prenom; }
            set { SetPropertyValue("Prenom", ref prenom, value); }
        }
        [RuleRequiredField("RuleRequiredField for Chauffeur.UserName",
        DefaultContexts.Save)]
        [RuleRegularExpression("", DefaultContexts.Save, "^[a-zA-Z]+$")]
        public string UserName
        {
            get { return _UserName ; }
            set { SetPropertyValue("UserName", ref _UserName, value); }
        }
        [RuleRequiredField("RuleRequiredField for Chauffeur.Password",
        DefaultContexts.Save)]
        public int Password
        {
            get { return password; }
            set { SetPropertyValue("Password", ref password, value); }
        }
        private int _cin;
        [RuleRequiredField("RuleRequiredField for Chauffeur.CIN",
     DefaultContexts.Save)]
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
        [RuleRequiredField("RuleRequiredField for Chauffeur.Tel",
        DefaultContexts.Save)]
       [RuleRange("", DefaultContexts.Save,10000000,99999999)]
        public int Tel
        {
            get { return tel; }
            set { SetPropertyValue("Tel", ref tel, value); }
        }
       
       
        [Association("Chauffeur-Mission")]
        public XPCollection<Mission> Missions
        {
            get { return GetCollection<Mission>("Missions"); }
        }
        [Association("Rapport_chauffeur-Chauffeur")]
        public XPCollection<Rapport_chauffeur> Rapport_Chauffeurs
        {
            get { return GetCollection<Rapport_chauffeur>("Rapport_Chauffeurs"); }
        }
       
        
    }
}