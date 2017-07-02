using WideWorldImporters.Common.Lib.Dto.Base;

namespace WideWorldImporters.Common.Lib.Dto.Order
{
    public class OrderInfoRequestDto: RequestBaseDto
    {
        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>
        /// The body.
        /// </value>
        public OrderInfoRequestBodyDto Body { get; set; }
    }
}
