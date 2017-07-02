using System;
using System.Net;

namespace WideWorldImporters.Common.Lib.Dto.Base
{
    public class ResponseBase
    {
        public string ResponsetId { get; set; }

        public DateTime RespondedAt { get; set; }

        public string RespondedBy { get; set; }

        public HttpStatusCode StatusCode { get; set; }
    }
}
