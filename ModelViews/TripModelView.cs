using System;
using System.ComponentModel.DataAnnotations;

namespace logTrip.ModelViews
{
    public class TripModelView
    {
        [Required(ErrorMessage ="The Destination is required")]
        public string Destination { get; set; }
        [Required(ErrorMessage = "The Start Date is required")]
        public DateTime StartDate { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "The End Date is required")]
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(1);
        public string Accommodation { get; set; }
    }
}