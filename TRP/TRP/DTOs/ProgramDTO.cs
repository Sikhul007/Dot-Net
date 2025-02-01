using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TRP.DTOs
{
    public class ProgramDTO
    {
        public int ProgramId { get; set; }

        [Required(ErrorMessage = "Program name is required.")]
        [StringLength(150, ErrorMessage = "Program name cannot be longer than 150 characters.")]
        public string ProgramName { get; set; }

        [Required(ErrorMessage = "TRP Score is required.")]
        [Range(0.0, 10.0, ErrorMessage = "TRP Score must be between 0.0 and 10.0.")]
        public decimal TRPScore { get; set; }
        public int ChannelId { get; set; }

        [Required(ErrorMessage = "Air time is required.")]
        public TimeSpan AirTime { get; set; }

    }
}