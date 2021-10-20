using System.Collections.Generic;
using System.Linq;
using Common.Auth.SingleTenant.Interfaces.Services;
using Common.Data.Interfaces;
using Common.Data.Models;
using PropznetCommon.Features.ERP.Entities;
using PropznetCommon.Features.ERP.Interfaces.DAL;
using PropznetCommon.Features.ERP.Interfaces.Services;
using PropznetCommon.Features.ERP.Model.Owner;

namespace PropznetCommon.Features.ERP.Services
{
    public class OwnerService : IOwnerService
    {
        public readonly IOwnerRepository _ownerRepository;
        public readonly IAccountService _accountService;
        public readonly IRoleService _roleService;
        public readonly IUserService _userService;
        readonly IUnitOfWork _iUnitOfWork;
        public OwnerService(
            IOwnerRepository ownerRepository,
            IUnitOfWork iUnitOfWork,
            IAccountService accountService,
            IRoleService roleService,
            IUserService userService)
        {
            _ownerRepository = ownerRepository;
            _iUnitOfWork = iUnitOfWork;
            _accountService = accountService;
            _roleService = roleService;
            _userService = userService;
        }

        public IList<Owner> GetAllOwners()
        {
            return _ownerRepository.GetAllOwners().ToList();
        }
        public IList<Owner> GetAllOwnersById(IList<long> ownersId)
        {
            return _ownerRepository.GetAllOwnersById(ownersId);


        }
        public Owner GetOwnerByUserId(long userId)
        {
            return _ownerRepository.GetOwnerByUserId(userId);
        }
        public Owner CreateOwner(OwnerModel ownerModel)
        {
            var password = "12345";//Guid.NewGuid().ToString("N");
            var roles = _roleService.GetAllRoles().Where(p => p.Name == "User").ToArray();
            long[] roleIds = new long[roles.Count()];
            for (int i = 0; i < roles.Count(); i++)
            {
                roleIds[i] = roles[i].Id;
            }
            var user = _userService.GetUserByUsername(ownerModel.Email);
            if (user == null)
            {
                //user = _accountService.CreateAccount(ownerModel.FirstName+" "+ ownerModel.LastName, ownerModel.Email, password, roleIds, avatar, ownerModel.EnableOwnerPortal);
                //user = _accountService.CreateAccount(ownerModel.FirstName + " " + ownerModel.LastName, ownerModel.Email, password, roleIds, ownerModel.EnableOwnerPortal);
                //CreateAccount(string firstName, string lastName, string userName, string password, long[] selectedRoleIds, string phoneNumber, string address, string avatar, string city, string state, long countryId, long? zip, bool isApproved, long createdbyUserId);
                user = _accountService.CreateAccount(ownerModel.FirstName,ownerModel.LastName,ownerModel.Email,password,roleIds,ownerModel.Phone,ownerModel.Address,"",ownerModel.City,ownerModel.State,ownerModel.CountryId,ownerModel.Zip,ownerModel.Company,ownerModel.EnableOwnerPortal,ownerModel.CreatedBy);
                //BackgroundJob.Enqueue(() => EmailHelper.SendEmailForRegistration(agentmodel.FirstName + " " + agentmodel.LastName, agentmodel.Email, agentmodel.Phone,password));
            }
            var owner = new Owner()
            {
                //Address = ownerModel.Address,
                Bank = ownerModel.Bank,
                BankAccountNumber = ownerModel.BankAccountNumber,
                BankIFSC = ownerModel.BankIFSC,
                Branch = ownerModel.Branch,
                //Company = ownerModel.Company,
                CreatedBy = ownerModel.CreatedBy,
                Description = ownerModel.Description,
                EmailAlerts = ownerModel.EmailAlerts,
                EmailStatements = ownerModel.EmailStatements,
                //FirstName = ownerModel.FirstName,
                //LastName = ownerModel.LastName,
                Mobile = ownerModel.Mobile,
                OfficePhone = ownerModel.OfficePhone,
                Ownership = ownerModel.Ownership,
                OwnerType = ownerModel.OwnerType,
                CashPaymentMode = ownerModel.CashPaymentMode,
                ChequePaymentMode = ownerModel.ChequePaymentMode,
                OnlinePaymentMode = ownerModel.OnlinePaymentMode,
                //Phone = ownerModel.Phone,
                SecondaryEmail = ownerModel.SecondaryEmail,
                TaxEligible = ownerModel.TaxEligible,
                TaxId = ownerModel.TaxId,
                TaxPayerName = ownerModel.TaxPayerName,
                UserId = user.Id
                //Zip = ownerModel.Zip,
                //EnableOwnerPortal = ownerModel.EnableOwnerPortal
            };
            var newOwner = _ownerRepository.Create(owner);
            if (!ownerModel.EnableOwnerPortal)
            {
                user.AccessRule.IsLockedOut = true;
            }
            _iUnitOfWork.Commit();
            return newOwner;
        }
        public Owner EditOwner(long id)
        {
            return _ownerRepository.GetOwner(id);
        }
        public Owner UpdateOwner(OwnerModel ownerModel)
        {
            var owner = _ownerRepository.Get(ownerModel.Id);
            _accountService.UpdateAccount(ownerModel.FirstName, ownerModel.LastName, ownerModel.Email, owner.UserId, ownerModel.Phone, ownerModel.Address, "", ownerModel.City, ownerModel.State, ownerModel.CountryId, ownerModel.Zip, ownerModel.Company, ownerModel.EnableOwnerPortal);

            owner.Bank = ownerModel.Bank;
            owner.BankAccountNumber = ownerModel.BankAccountNumber;
            owner.BankIFSC = ownerModel.BankIFSC;
            owner.Branch = ownerModel.Branch;
            owner.CreatedBy = ownerModel.UserId;
            owner.Description = ownerModel.Description;
            owner.EmailAlerts = ownerModel.EmailAlerts;
            owner.EmailStatements = ownerModel.EmailStatements;
            owner.Mobile = ownerModel.Mobile;
            owner.OfficePhone = ownerModel.OfficePhone;
            owner.Ownership = ownerModel.Ownership;
            owner.OwnerType = ownerModel.OwnerType;
            owner.CashPaymentMode = ownerModel.CashPaymentMode;
            owner.ChequePaymentMode = ownerModel.ChequePaymentMode;
            owner.OnlinePaymentMode = ownerModel.OnlinePaymentMode;
            owner.SecondaryEmail = ownerModel.SecondaryEmail;
            owner.TaxEligible = ownerModel.TaxEligible;
            owner.TaxId = ownerModel.TaxId;
            owner.TaxPayerName = ownerModel.TaxPayerName;
            owner.UserId = ownerModel.UserId;

            _ownerRepository.Update(owner);
            _iUnitOfWork.Commit();
            return owner;
        }
        public bool DeleteOwner(long ownerId)
        {
            var result = _ownerRepository.DeleteOwner(ownerId);
            _iUnitOfWork.Commit();
            return result;
        }
        public SearchResult<Owner> SearchOwner(OwnerSearchFilter searchargument, int pagesize, int count)
        {
            return _ownerRepository.SearchOwners(searchargument, pagesize, count);
        }
    }
}