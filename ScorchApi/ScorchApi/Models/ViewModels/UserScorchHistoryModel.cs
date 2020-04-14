using System;
namespace ScorchApi.Models.ViewModels
{
    public class UserScorchHistoryModel
    {
        public DateTime TimeStamp { get; set; }
        public Guid EntityId { get; set; }
    }
}