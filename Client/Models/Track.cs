// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace MeyerCorp.Usps.Client.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class Track
    {
        /// <summary>
        /// Initializes a new instance of the Track class.
        /// </summary>
        public Track()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Track class.
        /// </summary>
        public Track(string trackSummary = default(string), string id = default(string), string error = default(string))
        {
            TrackSummary = trackSummary;
            Id = id;
            Error = error;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "trackSummary")]
        public string TrackSummary { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }

    }
}
