﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace events.Models
{
    public class Events
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int VenueId { get; set; }
        public int GenreId { get; set; }
        public int Price { get; set; }
    }
}