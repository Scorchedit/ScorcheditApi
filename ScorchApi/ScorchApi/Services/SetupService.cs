using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ScorchApi.Enums;
using ScorchApi.Interfaces;
using ScorchApi.Models;
using ScorchApi.Models.EfModels;
using ScorchApi.Models.ViewModels;

namespace ScorchApi.Services
{
    public class SetupService : ISetupService
    {
        private readonly ApplicationDbContext context;
        public SetupService(ApplicationDbContext applicationDbContext)
        {
            context = applicationDbContext;
        }
        public async Task<SearchOptionsDto> GetSearchSettings(string userId)
        {
            var searchOptions = context.SearchOptions.Where(x => x.UserId == userId).ToList();
            var categories = await context.Categories.ToListAsync();
            var tags = await context.Tags.ToListAsync();
            var userCategories = new List<SearchOptionsModel>();
            var userTags = new List<SearchOptionsModel>();
            double distance;
            var userDistance = await context.SearchConfigs.FirstOrDefaultAsync(x => x.UserId == userId && x.Key == "Distance");
            if (userDistance != null)
            {
                distance = Convert.ToDouble(userDistance.Value);
            }
            else
            {
                distance = 10;
            }
            foreach (var category in categories)
            {
                var userSearchOption = searchOptions.FirstOrDefault(x => x.Key == category.Name);
                if (userSearchOption != null)
                {
                    userCategories.Add(new SearchOptionsModel
                    {
                        Key = userSearchOption.Key,
                        Value = userSearchOption.Value,
                        Type = userSearchOption.Type
                    });
                }
                else
                {
                    userCategories.Add(new SearchOptionsModel
                    {
                        Key = category.Name,
                        Value = false,
                        Type = (int)SearchOptionTypeEnum.Category
                    });
                }
            }
            foreach (var tag in tags)
            {
                var userSearchOption = searchOptions.FirstOrDefault(x => x.Key == tag.Name);
                if (userSearchOption != null)
                {
                    userTags.Add(new SearchOptionsModel
                    {
                        Key = userSearchOption.Key,
                        Value = userSearchOption.Value,
                        Type = userSearchOption.Type
                    });
                }
                else
                {
                    userTags.Add(new SearchOptionsModel
                    {
                        Key = tag.Name,
                        Value = false,
                        Type = (int)SearchOptionTypeEnum.Tag
                    });
                }
            }
            return new SearchOptionsDto
            {
                Categories = userCategories,
                Tags = userTags,
                Distance = distance
            };
        }

        public async Task SetSearchSetting(string userId, SearchOptionsModel obj)
        {
            var setting = await context.SearchOptions
                .FirstOrDefaultAsync(x => x.UserId == userId && x.Key == obj.Key && x.Type == obj.Type);
            if (setting != null)
            {
                setting.Value = obj.Value;
            }
            else
            {
                var model = Mapper.Map<SearchOption>(obj);
                model.UserId = userId;
                context.SearchOptions.Add(model);
            }

            await context.SaveChangesAsync();
        }

        public async Task SetSearchDistanceSetting(string userId, double distance)
        {
            var config = await context.SearchConfigs
                .FirstOrDefaultAsync(x => x.UserId == userId && x.Key == "Distance");
            if (config != null)
            {
                config.Value = distance.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                context.SearchConfigs.Add(new SearchConfig
                {
                    Key = "Distance",
                    UserId = userId,
                    Value = "10"
                });
            }

            await context.SaveChangesAsync();
        }
    }
}