﻿using System.Net.Http;
using Oddity.API.Builders;
using Oddity.API.Builders.DetailedCores;

namespace Oddity.API
{
    /// <summary>
    /// Represents a set of methods to get detailed cores information.
    /// </summary>
    public class DetailedCores
    {
        private HttpClient _httpClient;
        private DeserializationError _deserializationError;

        /// <summary>
        /// Initializes a new instance of the <see cref="DetailedCores"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="deserializationError">The deserialization error delegate.</param>
        public DetailedCores(HttpClient httpClient, DeserializationError deserializationError)
        {
            _httpClient = httpClient;
            _deserializationError = deserializationError;
        }

        /// <summary>
        /// Gets information about the specified capsule. This method returns only builder which doesn't retrieve data from API itself, so after apply
        /// all necessary filters you should call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/> to
        /// get the data from SpaceX API.
        /// </summary>
        /// <param name="coreSerial">The core serial.</param>
        /// <returns>The capsule builder.</returns>
        public DetailedCoreBuilder GetAbout(string coreSerial)
        {
            return new DetailedCoreBuilder(_httpClient, _deserializationError).WithSerial(coreSerial);
        }

        /// <summary>
        /// Gets detailed information about all cores. This method returns only builder which doesn't retrieve data from API itself, so after apply
        /// all necessary filters you should call <see cref="BuilderBase{TReturn}.Execute"/> or <see cref="BuilderBase{TReturn}.ExecuteAsync"/> to
        /// get the data from SpaceX API.
        /// </summary>
        /// <returns>The all detailed core builder.</returns>
        public AllDetailedCoresBuilder GetAll()
        {
            return new AllDetailedCoresBuilder(_httpClient, _deserializationError);
        }
    }
}
