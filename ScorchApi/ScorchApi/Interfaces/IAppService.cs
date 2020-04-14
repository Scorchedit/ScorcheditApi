using System.Threading.Tasks;
using ScorchApi.Models.ViewModels;

namespace ScorchApi.Interfaces
{
    public interface IAppService
    {
        Task Scorch(UserScorchHistoryModel obj);
    }
}
