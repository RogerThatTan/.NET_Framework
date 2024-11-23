using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TRPManagement.EF;
using static TRPManagement.Validation.ChannelAnnotation;

namespace TRPManagement.DTOs
{
    public class ChannelDTO
    {
        
        
        public int ChannelId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Maximum length of 100 characters")]
        public string ChannelName { get; set; }
        [Required]
        [EstablishedYear]
        public int EstablishedYear { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Maximum length of 50 characters")]
        public string Country { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Program> Programs { get; set; }
    }
}