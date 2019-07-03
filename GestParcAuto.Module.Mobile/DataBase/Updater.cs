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


using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.ExpressApp.Security;
using GestParcAuto.Module.BusinessObjects;

using GestParcAuto.Module.BusinessObjects.ChauffeurNS;

namespace GestParcAuto.Module.DataBase
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppUpdatingModuleUpdatertopic.aspx
    public class Updater : ModuleUpdater
    {
      

        public Updater(IObjectSpace objectSpace, Version currentDBVersion) : base(objectSpace, currentDBVersion) { }
        public override void UpdateDatabaseAfterUpdateSchema()
        {
            base.UpdateDatabaseAfterUpdateSchema();
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
            if (adminUser == null)
            {
                adminUser = ObjectSpace.CreateObject<PermissionPolicyUser>();
                adminUser.UserName = "Administrator";
                adminUser.SetPassword("");
                adminUser.Roles.Add(adminRole);
            }
            PermissionPolicyUser user1 = ObjectSpace.FindObject<PermissionPolicyUser>(
           new BinaryOperator("UserName", "Oumaima"));
            if (user1 == null)
            {
                user1 = ObjectSpace.CreateObject<PermissionPolicyUser>();
                user1.UserName = "Oumaima";
                // Set a password if the standard authentication type is used. 
                user1.SetPassword("");
            }

            // If a user named 'John' does not exist in the database, create this user. 
            PermissionPolicyUser user2 = ObjectSpace.FindObject<PermissionPolicyUser>(
                 new BinaryOperator("UserName", "John"));
            if (user2 == null)
            {
                user2 = ObjectSpace.CreateObject<PermissionPolicyUser>();
                user2.UserName = "John";
                // Set a password if the standard authentication type is used. 
                user2.SetPassword("");
            }
           
            user1.Save();
            user2.Save();
            ObjectSpace.CommitChanges();
          
            ObjectSpace.CommitChanges();
        }
        private PermissionPolicyRole CreateAdministratorRole()
        {
           PermissionPolicyRole administratorRole = ObjectSpace.FindObject<PermissionPolicyRole>(
                new BinaryOperator("Name", SecurityStrategyComplex.AdministratorRoleName));
            if (administratorRole == null)
            {
                administratorRole = ObjectSpace.CreateObject<PermissionPolicyRole>();
                administratorRole.Name = SecurityStrategyComplex.AdministratorRoleName;
                administratorRole.IsAdministrative = true;
            }
            return administratorRole;
        }


        private PermissionPolicyRole CreateUserRole()
        {
           PermissionPolicyRole userRole = ObjectSpace.FindObject<PermissionPolicyRole>(
                new BinaryOperator("Name", "Default"));
            if (userRole == null)
            {
                userRole.PermissionPolicy = SecurityPermissionPolicy.AllowAllByDefault;
              
            }
            return userRole;
        }
    }

    }
    


