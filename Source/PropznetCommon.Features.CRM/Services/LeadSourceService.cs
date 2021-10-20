using System.Collections.Generic;
using System.Linq;
using PropznetCommon.Features.CRM.Entities;
using PropznetCommon.Features.CRM.Interfaces.DAL;
using PropznetCommon.Features.CRM.Interfaces.Services;
using PropznetCommon.Features.CRM.Model.LeadSource;
using System;
using Common.Data.Interfaces;

namespace PropznetCommon.Features.CRM.Services
{
    public class LeadSourceService : ILeadSourceService
    {
        readonly ILeadSourceRepository _leadSourceRepository;
        readonly IUnitOfWork _unitOfWork;

        public LeadSourceService(ILeadSourceRepository leadSourceRepository, IUnitOfWork unitOfWork)
        {
            _leadSourceRepository = leadSourceRepository;
            _unitOfWork = unitOfWork;
        }
        public IList<LeadSource> GetAllLeadSources()
        {
            //return _leadSourceRepository.GetAllLeadSources().ToList();
            return _leadSourceRepository.GetAllBy(i => i.DeletedOn == null).ToList();
        }
        public LeadSource CreateLeadSource(LeadSourceModel leadSourceModel)
        {
            if (leadSourceModel != null)
            {
                LeadSource leadSource = new LeadSource()
                {
                    Name = leadSourceModel.Name,
                    CreatedByUserId = leadSourceModel.CreatedByUserId,
                    CreatedOn = DateTime.UtcNow,
                };
                var createLeadSource = _leadSourceRepository.Create(leadSource);
                _unitOfWork.Commit();
                return createLeadSource;
            }
            return null;
        }
        public bool UpdateLeadSource(LeadSourceModel leadSourceModel)
        {
            if (leadSourceModel != null)
            {
                var getLeadSource = _leadSourceRepository.GetBy(i => i.Id == leadSourceModel.Id && i.DeletedOn == null);
                {
                    getLeadSource.Name = leadSourceModel.Name;
                    getLeadSource.UpdatedByUserId = leadSourceModel.UpdatedByUserId;
                    getLeadSource.UpdatedOn = DateTime.UtcNow;
                }
                _leadSourceRepository.Update(getLeadSource);
                _unitOfWork.Commit();
                return true;
            }
            return false;
        }
        public bool DeleteLeadSource(long id)
        {
            if (id != null)
            {
                var getLeadSourceById = _leadSourceRepository.GetBy(i => i.Id == id && i.DeletedOn == null);
                {
                    getLeadSourceById.DeletedOn = DateTime.UtcNow;
                }
                _leadSourceRepository.Update(getLeadSourceById);
                _unitOfWork.Commit();
                return true;
            }
            return false;
        }
    }
}