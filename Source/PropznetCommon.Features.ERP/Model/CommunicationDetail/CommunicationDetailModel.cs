namespace PropznetCommon.Features.ERP.Model.CommunicationDetail
{
    public class CommunicationDetailModel
    {
        public long Id { get; set; }
        public string Address { get; set; }
        public string Area { get; set; }
        public long CountryId { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public long Zip { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
    }
}
