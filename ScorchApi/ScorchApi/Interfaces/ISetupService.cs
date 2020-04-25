using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ScorchApi.Models.ViewModels;

namespace ScorchApi.Interfaces
{
    public interface ISetupService
    {
        Task<SearchOptionsDto> GetSearchSettings(string userId);
        Task SetSearchSetting(string userId, SearchOptionsModel obj);
        Task SetSearchDistanceSetting(string userId, double distance);
    }
}