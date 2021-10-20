using PropznetCommon.Features.ERP.Entities.Enum;

namespace PropznetCommon.Features.ERP.Entities
{
    public class ImageGallery : ERPEntityBase
    {
        public string ImageName { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
    }
}
