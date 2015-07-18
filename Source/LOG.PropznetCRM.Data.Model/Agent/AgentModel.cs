﻿namespace LOG.PropznetCRM.Data.Model.Agent
{
    public class AgentModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public long CommunicationDetailID { get; set; }
        public string DEDLicenseNumber { get; set; }
        public string RERARegistrationNumber { get; set; }
        public bool IsListingMember { get; set; }
        public string Image { get; set; }
        public long? UserId { get; set; }
        public long CreatedBy { get; set; }
    }
}
