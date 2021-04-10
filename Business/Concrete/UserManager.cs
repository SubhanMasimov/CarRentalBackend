using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Business.Constants;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        //[SecuredOperation("admin")]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserRegistered);
        }

        //[SecuredOperation("admin")]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        //[SecuredOperation("admin")]
        public IDataResult<User> Get(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == userId), Messages.UserDetailListed);
        }

        //[SecuredOperation("admin")]
        [CacheAspect]
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UsersListed);
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user), Messages.UserClaimsListed);
        }

        [ValidationAspect(typeof(UserValidator))]
        //[SecuredOperation("admin")]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
