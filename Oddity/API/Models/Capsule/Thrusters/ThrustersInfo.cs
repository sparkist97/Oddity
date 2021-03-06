﻿using Newtonsoft.Json;
using Oddity.API.Models.Common;

namespace Oddity.API.Models.Capsule.Thrusters
{
    public class ThrustersInfo
    {
        public ThrusterType? Type { get; set; }
        public uint? Amount { get; set; }
        public uint? Pods { get; set; }

        [JsonProperty("fuel_1")]
        public string FirstPropellant { get; set; }

        [JsonProperty("fuel_2")]
        public string SecondPropellant { get; set; }

        public ThrustInfo Thrust { get; set; }
    }
}
