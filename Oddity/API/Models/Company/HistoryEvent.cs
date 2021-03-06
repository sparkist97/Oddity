﻿using System;
using Newtonsoft.Json;

namespace Oddity.API.Models.Company
{
    public class HistoryEvent
    {
        public string Title { get; set; }

        [JsonProperty("event_date_utc")]
        public DateTime? EventDate { get; set; }

        [JsonProperty("flight_number")]
        public uint? FlightNumber { get; set; }

        public string Details { get; set; }
        public EventLinks Links { get; set; }
    }
}
