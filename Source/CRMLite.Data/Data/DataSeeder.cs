using System.Data.Entity;
using CRMLite.Data.Data.Seeders;

namespace CRMLite.Data.Data
{
    public class DataSeeder : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            SettingsSeeder.Seed(context);
            //MenuSeeder.Seed(context);
            CommunicationDetailSeeder.Seed(context);
            UserSeeder.Seed(context);
            AgentSeeder.Seed(context);
            AccountSeeder.Seed(context);         
            ContactSeeder.Seed(context);
            CRMToDoSeeder.Seed(context);
            LeadSeeder.Seed(context);
            PropertyCategorySeeder.Seed(context);
            RolePermissionSeeder.Seed(context);
            SalesStageSeeder.Seed(context);
        }
    }
}