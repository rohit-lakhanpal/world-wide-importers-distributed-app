using System;
using System.Collections.Generic;
using WideWorldImporters.Common.Lib.Dto.Order;

namespace WideWorldImporters.SalesService.App.Helpers
{
    public static partial class Extensions
    {
        public static OrderInfoResponseDto ToDto(this OrderInfoRequestDto request, OrderDto responseDto, string responderIdentity)
        {
            var response = new OrderInfoResponseDto()
            {
                Header = new Common.Lib.Dto.Base.ResponseBaseHeaderDto
                {
                    Request = request.Header,
                    RespondedAt = DateTime.Now,
                    RespondedBy = responderIdentity,
                    ResponsetId = Guid.NewGuid().ToString(),
                    StatusCode = System.Net.HttpStatusCode.OK
                },
                Body = new OrderInfoResponseBodyDto
                {
                    Orders = new List<OrderDto>() { responseDto }
                }
            };

            return response;
        }
    }
}
