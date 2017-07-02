using WideWorldImporters.Common.Lib.Dto.Base;

namespace WideWorldImporters.Common.Lib.Dtp.Order
{
    public class OrderInfoRequest
    {
        public RequestBase Header { get; set; }

        public OrderInfoRequestBody Body { get; set; }
    }
}
