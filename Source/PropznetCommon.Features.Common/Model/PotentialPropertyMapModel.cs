using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropznetCommon.Features.Common.Model
{
    public class PotentialPropertyMapModel
    {
        public long Id { get; set; }
        public long PotentialId { get; set; }
        public IList<long> PropertyId { get; set; }
    }
}
