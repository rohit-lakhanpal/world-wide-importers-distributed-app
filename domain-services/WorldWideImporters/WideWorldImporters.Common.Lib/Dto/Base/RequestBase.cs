using System;

namespace WideWorldImporters.Common.Lib.Dto.Base
{
    public class RequestBase
    {
        public string RequestId { get; set; }

        public DateTime RequestedAt { get; set; }

        public string RequestedBy { get; set; }
    }
}
