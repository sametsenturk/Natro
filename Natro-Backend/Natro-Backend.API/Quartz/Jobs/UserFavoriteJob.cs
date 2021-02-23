using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Natro_Backend.DAL.Abstract;
using Natro_Backend.Entity.Context;
using Natro_Backend.Entity.Entities;
using Natro_Backend.Models.Integration.RDAP.Response.Domain;
using Natro_Backend.RDAP.Abstract;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Natro_Backend.API.Quartz.Jobs
{
    public class UserFavoriteJob : IJob
    {
        private IServiceProvider _serviceProvider;

        public UserFavoriteJob(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    MssqlContext db = scope.ServiceProvider.GetService<MssqlContext>();
                    IDomainHelper _domainHelper = scope.ServiceProvider.GetService<IDomainHelper>();

                    foreach (var favorite in db.UserFavorites.AsNoTracking().ToList())
                    {
                        CheckDomainResponseModel response = await _domainHelper.CheckDomainAsync(favorite.Domain);

                        UserFavoriteEntity entity = new UserFavoriteEntity();
                        entity.ID = favorite.ID;
                        entity.UserID = favorite.UserID;
                        entity.Domain = response.Domain;
                        entity.ExpireDate = response.ExpireDate;
                        entity.IsAvailableToBuy = response.IsAvailableToBuy;
                        entity.LastChange = response.LastChange;
                        entity.Nameserver1 = response.Nameserver1;
                        entity.Nameserver2 = response.Nameserver2;
                        db.Entry(entity).State = EntityState.Modified;
                        db.SaveChanges();

                        if (response.IsAvailableToBuy != favorite.IsAvailableToBuy && response.IsAvailableToBuy)
                        {
                            UserFavoriteNotificationEntity notification = new UserFavoriteNotificationEntity()
                            {
                                UserFavoriteID = favorite.ID
                            };                            
                            db.UserFavoriteNotifications.Add(notification);
                            db.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string a = ex.ToString();
            }

        }

    }
}
