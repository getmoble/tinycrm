﻿using System.Collections.Generic;
using LOG.PropznetCRM.Data.Entities;

namespace LOG.PropznetCRM.Data.Core.Interfaces.DAL
{
    public interface ILeadStatusRepository
    {
        IList<LeadStatus> GetAllLeadStatuses();
    }
}
