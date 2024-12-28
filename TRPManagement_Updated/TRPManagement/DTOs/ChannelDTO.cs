using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TRPManagement.EF;
using static TRPManagement.Validation.ChannelAnnotation;

namespace TRPManagement.DTOs
{
    public class ChannelDTO
    {
        public int ChannelId { get; set; }

        [Required(ErrorMessage = "Channel Name is Required")]
        [StringLength(100,ErrorMessage = "Name cannot exceed 100 characters.")]
        public string ChannelName { get; set; }
        [Required(ErrorMessage = "Establish Year is Required")]
        [EstablishYear]
        public int EstablishedYear { get; set; }
        [Required(ErrorMessage = "Country is Required")]
        [StringLength(50, ErrorMessage = "Country cannot exceed 100 characters.")]
        public string Country { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Program> Programs { get; set; }
    }
}