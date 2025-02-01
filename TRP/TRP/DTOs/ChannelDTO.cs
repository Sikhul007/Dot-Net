using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TRP.DTOs
{
    public class ChannelDTO
    {
        public int ChannelId { get; set; }

        [Required(ErrorMessage = "Channel name is required.")]
        [StringLength(100, ErrorMessage = "Channel name cannot be longer than 100 characters.")]
        public string ChannelName { get; set; }

        [YearRange(1900, ErrorMessage = "Established year must be between 1900 and the current year.")]
        public int EstablishedYear { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        [StringLength(50, ErrorMessage = "Country name cannot be longer than 50 characters.")]
        public string Country { get; set; }
    }
}