using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace events.Models
{
    public class EventItem
    {
        public EventItem()
        {

        }
        public EventItem(EventItem s)
        {
            this.Title = s.Title;
            this.Description = s.Description;
            this.Id = s.Id;
            this.Price = s.Price;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public int Price { get; set; }


        [NotMapped]
        public Guid TrackerId { get; set; } = Guid.NewGuid();

        public ICollection<Order> Orders { get; set; }
    }
}
