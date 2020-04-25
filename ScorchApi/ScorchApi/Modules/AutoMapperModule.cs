using AutoMapper;
using ScorchApi.Models.EfModels;
using ScorchApi.Models.ViewModels;

namespace ScorchApi.Modules
{
    public class AutoMapperModule
    {
        [System.Obsolete]
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<UserScorchHistory, UserScorchHistoryModel>().ReverseMap();
                config.CreateMap<SearchOption, SearchOptionsModel>()
                    .ReverseMap()
                    .ForMember(x => x.UserId, ops => ops.Ignore())
                    .ForMember(x => x.Id, ops => ops.Ignore());
            });
        }
    }
}