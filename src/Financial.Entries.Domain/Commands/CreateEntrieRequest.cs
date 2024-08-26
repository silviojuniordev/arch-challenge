using Financial.Entries.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Financial.Entries.Domain.Commands
{
    public class CreateEntrieRequest
    {
        [Required]
        public DateTime EffectiveDate { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public EntriesEnum EntrieType { get; set; }
        [Required]
        public decimal Value { get; set; }
    }
}
