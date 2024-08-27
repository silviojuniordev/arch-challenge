using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Financial.Entries.Domain.Queries
{
    public class EntrieQueryRequest
    {
        [Required]
        public DateTime InitialDate { get; set; }

        [Required]
        public DateTime FinalDate { get; set; }
    }
}
