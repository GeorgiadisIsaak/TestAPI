using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace Types.Requests
{
    public record ItemRequest
    {
        [Required]
        [Range(0, 100)]
        [DefaultValue(11)]
        [FromQuery(Name = "titleId")]
        public int ItemId { get; init; }
    }
}