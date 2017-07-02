using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WideWorldImporters.Common.Lib.Dto.Order;
using Newtonsoft.Json;

namespace WorldWideImporters.SalesService.App.Test
{
    [TestClass]
    public class GenerateJsonTests
    {
        [TestMethod]
        public void OrderInfo()
        {
            // Arrange
            var sut = new OrderInfoRequestDto()
            {
                Header = new WideWorldImporters.Common.Lib.Dto.Base.RequestBaseHeaderDto
                {
                    RequestedAt = DateTime.Now,
                    RequestedBy = "Ro",
                    RequestId = Guid.NewGuid().ToString()
                },
                Body = new OrderInfoRequestBodyDto
                {
                    RequestType = OrderInfoRequestType.REQUEST_BY_ID,
                    RequestQuery = "1"
                }
            };
            // Act
            var json = JsonConvert.SerializeObject(sut);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(json));
        }
    }
}
