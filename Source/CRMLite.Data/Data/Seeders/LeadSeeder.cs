using PropznetCommon.Features.CRM.Entities;
using System.Collections.Generic;

namespace CRMLite.Data.Data.Seeders
{
    public static class LeadSeeder
    {
        public static void Seed(DataContext context)
        {

            var leadsource = new List<LeadSource>
            {
               new LeadSource{ Name = "User / Staff"},
               new LeadSource{ Name = "Direct Enquiry"},
               new LeadSource{ Name = "Website"},
               new LeadSource{ Name = "Reference"},
               new LeadSource{ Name = "Other "}
            };
            leadsource.ForEach(s => context.LeadSourceMaster.Add(s));
            context.SaveChanges();
            var leadstatus = new List<LeadStatus>
            {
               new LeadStatus{ Name = "New"},
               new LeadStatus{ Name = "Contacted"},
               new LeadStatus{ Name = "Contacted - Follow up required"},
               new LeadStatus{ Name = "Contact in Future"},
               new LeadStatus{ Name = "Cold"},
               new LeadStatus{ Name = "Hot"},
               new LeadStatus{ Name = "Dead"}
            };
            leadstatus.ForEach(s => context.LeadStatusMaster.Add(s));
            context.SaveChanges();

            //var lead = new List<Lead>
            //{
            //    new Lead{UserId=1,Comments="Nice",Company="Logiticks",CommunicationDetailId=1,FirstName="Anu",LastName="Shastri",LeadSourceId=2,LeadSourceName="MMM",LeadStatusId=2,RefId="L01",CreatedBy=1,UpdatedBy=1},
            //    new Lead{UserId=2,Comments="Good",Company="Wipro",CommunicationDetailId=2,FirstName="Anju",LastName="Shastri",LeadSourceId=1,LeadSourceName="MMM",LeadStatusId=5,RefId="L02",CreatedBy=1,UpdatedBy=1},
            //    new Lead{UserId=3,Comments="Need improvement",Company="Infosys",CommunicationDetailId=3,FirstName="Manu",LastName="Shastri",LeadSourceId=3,LeadSourceName="MMM",LeadStatusId=3,RefId="L03",CreatedBy=1,UpdatedBy=1},
            //    new Lead{UserId=1,Comments="Nice",Company="Logiticks",CommunicationDetailId=1,FirstName="Anu",LastName="Shastri",LeadSourceId=2,LeadSourceName="MMM",LeadStatusId=2,RefId="L04",CreatedBy=1,UpdatedBy=1},
            //    new Lead{UserId=2,Comments="Good",Company="Wipro",CommunicationDetailId=2,FirstName="Anju",LastName="Shastri",LeadSourceId=1,LeadSourceName="MMM",LeadStatusId=1,RefId="L05",CreatedBy=1,UpdatedBy=1},
            //    new Lead{UserId=3,Comments="Need improvement",Company="Infosys",CommunicationDetailId=3,FirstName="Manu",LastName="Shastri",LeadSourceId=3,LeadSourceName="MMM",LeadStatusId=3,RefId="L06",CreatedBy=1,UpdatedBy=1},
            //    new Lead{UserId=1,Comments="Nice",Company="Logiticks",CommunicationDetailId=1,FirstName="Anu",LastName="Shastri",LeadSourceId=2,LeadSourceName="MMM",LeadStatusId=2,RefId="L07",CreatedBy=2,UpdatedBy=2},
            //    new Lead{UserId=2,Comments="Good",Company="Wipro",CommunicationDetailId=2,FirstName="Anju",LastName="Shastri",LeadSourceId=1,LeadSourceName="MMM",LeadStatusId=1,RefId="L08",CreatedBy=2,UpdatedBy=2},
            //    new Lead{UserId=3,Comments="Need improvement",Company="Infosys",CommunicationDetailId=3,FirstName="Manu",LastName="Shastri",LeadSourceId=3,LeadSourceName="MMM",LeadStatusId=3,RefId="L09",CreatedBy=2,UpdatedBy=2},
            //    new Lead{UserId=3,Comments="Need improvement",Company="Infosys",CommunicationDetailId=3,FirstName="Manu",LastName="Shastri",LeadSourceId=3,LeadSourceName="MMM",LeadStatusId=4,RefId="L10",CreatedBy=1,UpdatedBy=1},
            //    new Lead{UserId=1,Comments="Nice",Company="Logiticks",CommunicationDetailId=1,FirstName="Anu",LastName="Shastri",LeadSourceId=2,LeadSourceName="MMM",LeadStatusId=4,RefId="L11",CreatedBy=1,UpdatedBy=1},
            //    new Lead{UserId=2,Comments="Good",Company="Wipro",CommunicationDetailId=2,FirstName="Anju",LastName="Shastri",LeadSourceId=1,LeadSourceName="MMM",LeadStatusId=6,RefId="L12",CreatedBy=1,UpdatedBy=1},
            //    new Lead{UserId=3,Comments="Need improvement",Company="Infosys",CommunicationDetailId=3,FirstName="Manu",LastName="Shastri",LeadSourceId=3,LeadSourceName="MMM",LeadStatusId=6,RefId="L13",CreatedBy=1,UpdatedBy=1},
            //    new Lead{UserId=1,Comments="Nice",Company="Logiticks",CommunicationDetailId=1,FirstName="Anu",LastName="Shastri",LeadSourceId=2,LeadSourceName="MMM",LeadStatusId=7,RefId="L14",CreatedBy=1,UpdatedBy=1},
            //    new Lead{UserId=2,Comments="Good",Company="Wipro",CommunicationDetailId=2,FirstName="Anju",LastName="Shastri",LeadSourceId=1,LeadSourceName="MMM",LeadStatusId=7,RefId="L15",CreatedBy=1,UpdatedBy=1},
            //    new Lead{UserId=3,Comments="Need improvement",Company="Infosys",CommunicationDetailId=3,FirstName="Manu",LastName="Shastri",LeadSourceId=3,LeadSourceName="MMM",LeadStatusId=6,RefId="L16",CreatedBy=1,UpdatedBy=1}
            //};
            //lead.ForEach(s => context.Leads.Add(s));
            //context.SaveChanges();


        }
    }
}
