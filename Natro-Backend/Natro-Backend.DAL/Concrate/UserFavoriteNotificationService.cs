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
    public class UserFavoriteNotificationService : IUserFavoriteNotificationService
    {
        private readonly IRepository<UserFavoriteNotificationEntity> _repo;

        public MssqlContext Context => this.Context;

        public UserFavoriteNotificationService(IRepository<UserFavoriteNotificationEntity> repo)
        {
            _repo = repo;
        }

        public void Add(UserFavoriteNotificationEntity entity) => _repo.Add(entity);

        public void Delete(UserFavoriteNotificationEntity entity) => _repo.Delete(entity);

        public IEnumerable<UserFavoriteNotificationEntity> Get() => _repo.Get();

        public IEnumerable<UserFavoriteNotificationEntity> Get(Expression<Func<UserFavoriteNotificationEntity, bool>> predicate) => _repo.Get(predicate);

        public void Update(UserFavoriteNotificationEntity entity) => _repo.Update(entity);
    }
}
