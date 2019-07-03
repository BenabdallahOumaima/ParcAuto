using System;
using System.Linq;
using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.BaseImpl;

using System.Drawing;

using DevExpress.DataAccess.Sql;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.ExpressApp.Security;
using GestParcAuto.Module.BusinessObjects;

using GestParcAuto.Module.BusinessObjects.ChauffeurNS;

namespace GestParcAuto.Module.DatabaseUpdate
{
    public class Updater : ModuleUpdater
    {



        public Updater(IObjectSpace objectSpace, Version currentDBVersion) : base(objectSpace, currentDBVersion) { }
        //la méthode UpdateDtaBaseAfterUpdateSchema est spécifie pour la code de mise à jour à exécuter 
        //aprés la mise à jour de la schéma da la BD
        public override void UpdateDatabaseAfterUpdateSchema()

        {
            base.UpdateDatabaseAfterUpdateSchema();
            // Startégie d'autorisation : détermine le comportement de système de sécurité lorsqu'il n'existe aucune autorisation spécifié
            //pour une membre spcéfique 
            //créer une nouvelle instance de la classe binaryOperator


          

            PermissionPolicyRole adminRole = ObjectSpace.FindObject<PermissionPolicyRole>(
                new BinaryOperator("Name", SecurityStrategy.AdministratorRoleName));
            if (adminRole == null)
            {
                adminRole = ObjectSpace.CreateObject<PermissionPolicyRole>();
                adminRole.Name = SecurityStrategy.AdministratorRoleName;
                adminRole.IsAdministrative = true;
            }
            PermissionPolicyUser adminUser = ObjectSpace.FindObject<PermissionPolicyUser>(
                new BinaryOperator("UserName", "Administrator"));
            if(adminUser == null)
            {
                adminUser = ObjectSpace.CreateObject<PermissionPolicyUser>();
                adminUser.UserName = "Administrator";
                adminUser.SetPassword("");
                adminUser.Roles.Add(adminRole);

            }
            PermissionPolicyUser user1 = ObjectSpace.FindObject<PermissionPolicyUser>(
           new BinaryOperator("UserName", "oumaima"));
            if (user1 == null)
            {
                user1 = ObjectSpace.CreateObject<PermissionPolicyUser>();
                user1.UserName = "oumaima";
                // Set a password if the standard authentication type is used. 
                user1.SetPassword("");
            }
            //la métthode CommitChanges utilisé pour enregistré les changement apportes sur les objets appartenant 
            //à l'espace actuelle de la base de données.
            user1.Save();
            ObjectSpace.CommitChanges();

        }


    }

    }
    


