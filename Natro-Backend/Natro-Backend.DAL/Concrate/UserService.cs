using Natro_Backend.Core.Abstract;
using Natro_Backend.DAL.Abstract;
using Natro_Backend.Entity.Context;
using Natro_Backend.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Natro_Backend.DAL.Concrate
{
    public class UserService : IUserService
    {
        private readonly IRepository<UserEntity> _repo;

        public MssqlContext Context => this.Context;

        public UserService(IRepository<UserEntity> repo)
        {
            _repo = repo;
        }

        public void Add(UserEntity entity) => _repo.Add(entity);

        public void Delete(UserEntity entity) => _repo.Delete(entity);

        public IEnumerable<UserEntity> Get() => _repo.Get();

        public IEnumerable<UserEntity> Get(Expression<Func<UserEntity, bool>> predicate) => _repo.Get(predicate);

        public void Update(UserEntity entity) => _repo.Update(entity);
    }
}
