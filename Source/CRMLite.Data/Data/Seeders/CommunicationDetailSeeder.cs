using PropznetCommon.Features.CRM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMLite.Data.Data.Seeders
{
    public class CommunicationDetailSeeder
    {
        public static void Seed(DataContext context)
        {
            var communicationdetail = new List<CRMCommunicationDetail>
            {
               new CRMCommunicationDetail{ Address="The Business Centre\n61 Wellfield Road\nRoath\nCardiff\nCF24 3DG",Email="wilfred@gmail.com", Phone="9658741236",Website="www.wilfred.com"},
               new CRMCommunicationDetail{ Address="The Business Centre\n61 Wellfield Road\nRoath\nCardiff\nCF24 3DG",Email="john@gmail.com", Phone="9658741236",Website="www.abycorp.com"},
               new CRMCommunicationDetail{ Address="The Business Centre\n61 Wellfield Road\nRoath\nCardiff\nCF24 3DG",Email="smithjohn@gmail.com", Phone="9658741236",Website="www.focus.com"},
               new CRMCommunicationDetail{ Address="The Business Centre\n61 Wellfield Road\nRoath\nCardiff\nCF24 3DG",Email="burke@gmail.com", Phone="9658741236",Website="www.extend.com"}
            };
            communicationdetail.ForEach(s => context.CRMCommunicationDetails.Add(s));
            context.SaveChanges();
        }
    }
}
