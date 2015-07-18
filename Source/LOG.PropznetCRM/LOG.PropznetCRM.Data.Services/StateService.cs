using Common.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using LOG.PropznetCRM.Data.Core.Interfaces.DAL;
using LOG.PropznetCRM.Data.Core.Interfaces.Services;

namespace LOG.PropznetCRM.Data.Services
{
    public class StateService : IStateService
    {
        readonly IStateRepository _stateRepository;

        public StateService(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }
        public IList<State> GetAllStates()
        {
            return _stateRepository.GetAll().ToList();
        }
    }
}
