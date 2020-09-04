using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace angularApp.models
{
    public class paymentDetails
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CardOwnerName { get; set; }
        [Required]
        public string CardNumber { get; set; }
        [Required]
        public string ExpiryDate { get; set; }
        [Required]
        public string CVV { get; set; }
    }
}
