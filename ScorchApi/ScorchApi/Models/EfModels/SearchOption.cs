using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScorchApi.Models.EfModels
{
    public class SearchOption
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Key { get; set; }
        public bool Value { get; set; }
        public int Type { get; set; }
        public string UserId { get; set; }
    }
}