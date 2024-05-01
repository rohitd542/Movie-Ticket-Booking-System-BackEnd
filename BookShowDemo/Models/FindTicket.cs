using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SaveUrShowUsingCFA.models
{
    public class FindTicket
    {
        [Key]
        public int MovieId { get; set; }
        public string Location { get; set; }
        public string Theatrename { get; set; }
        [Required(ErrorMessage = "Movie name is required")]
        public string Moviename { get; set; }

        public string Slot { get; set; }
        public int charges { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime? date { get; set; }
        public string MovieLink { get; set; }
    }
}
