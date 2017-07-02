using System;
using System.Net;

namespace WideWorldImporters.Common.Lib.Dto.Base
{
    public class ResponseBaseHeaderDto
    {
        public ResponseBaseHeaderDto()
        {
            RespondedAt = DateTime.Now;
        }

        /// <summary>
        /// Gets or sets the responset identifier.
        /// </summary>
        /// <value>
        /// The responset identifier.
        /// </value>
        public string ResponsetId { get; set; }

        /// <summary>
        /// Gets or sets the responded at.
        /// </summary>
        /// <value>
        /// The responded at.
        /// </value>
        public DateTime RespondedAt { get; set; }

        /// <summary>
        /// Gets or sets the responded by.
        /// </summary>
        /// <value>
        /// The responded by.
        /// </value>
        public string RespondedBy { get; set; }

        /// <summary>
        /// Gets or sets the status code.
        /// </summary>
        /// <value>
        /// The status code.
        /// </value>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the error.
        /// </summary>
        /// <value>
        /// The error description.
        /// </value>
        public string ErrorDescription { get; set; }

        /// <summary>
        /// Gets or sets the request.
        /// </summary>
        /// <value>
        /// The request.
        /// </value>
        public RequestBaseHeaderDto Request { get; set; }
    }
}
