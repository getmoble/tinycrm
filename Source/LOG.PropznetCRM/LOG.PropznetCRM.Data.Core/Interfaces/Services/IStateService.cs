using System.Collections.Generic;
using Common.Data.Entities;

namespace LOG.PropznetCRM.Data.Core.Interfaces.Services
{
    public interface IStateService
    {
        IList<State> GetAllStates();
    }
}
