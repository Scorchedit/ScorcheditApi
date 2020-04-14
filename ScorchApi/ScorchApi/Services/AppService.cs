using System;
using System.Data.Entity;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using ScorchApi.Controllers;
using ScorchApi.Interfaces;
using ScorchApi.Models;
using ScorchApi.Models.EfModels;
using ScorchApi.Models.ViewModels;

namespace ScorchApi.Services
{
    public class AppService: IAppService
    {
        private readonly ApplicationDbContext dbContext;
        public AppService(ApplicationDbContext applicationDbContext)
        {
            dbContext = applicationDbContext;
        }
        public async Task Scorch(UserScorchHistoryModel obj)
        {
                var accountController = new AccountController();
                var userInfo = accountController.GetUserInfo();
                var user = await dbContext.Users.FirstAsync(x => x.Email == userInfo.Email);
                dbContext.UserScorchHistories.Add(new UserScorchHistory
                {
                    TimeStamp = obj.TimeStamp,
                    UserId = user.Id
                });
                await dbContext.SaveChangesAsync();
        }
    }
}