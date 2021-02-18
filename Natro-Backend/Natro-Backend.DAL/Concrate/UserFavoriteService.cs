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
    public class UserFavoriteService : IUserFavoriteService
    {
        private readonly IRepository<UserFavoriteEntity> _repo;

        public MssqlContext Context => this.Context;

        public UserFavoriteService(IRepository<UserFavoriteEntity> repo)
        {
            _repo = repo;
        }

        public void Add(UserFavoriteEntity entity) => _repo.Add(entity);

        public void Delete(UserFavoriteEntity entity) => _repo.Delete(entity);

        public IEnumerable<UserFavoriteEntity> Get() => _repo.Get();

        public IEnumerable<UserFavoriteEntity> Get(Expression<Func<UserFavoriteEntity, bool>> predicate) => _repo.Get(predicate);

        public void Update(UserFavoriteEntity entity) => _repo.Update(entity);
    }
}
