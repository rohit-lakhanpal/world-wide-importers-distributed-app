using System;

namespace WideWorldImporters.Common.Lib.Dto.Base
{
    public class RequestBaseDto
    {
        /// <summary>
        /// Gets or sets the request identifier.
        /// </summary>
        /// <value>
        /// The request identifier.
        /// </value>
        public string RequestId { get; set; }

        /// <summary>
        /// Gets or sets the requested at.
        /// </summary>
        /// <value>
        /// The requested at.
        /// </value>
        public DateTime RequestedAt { get; set; }

        /// <summary>
        /// Gets or sets the requested by.
        /// </summary>
        /// <value>
        /// The requested by.
        /// </value>
        public string RequestedBy { get; set; }
    }
}
