using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScorchApi.Models.EfModels
{
    public class UserScorchHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public Guid EntityId { get; set; }
        public string UserId { get; set; }
    }
}