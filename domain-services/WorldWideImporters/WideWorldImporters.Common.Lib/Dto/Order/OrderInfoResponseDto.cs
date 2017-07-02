using WideWorldImporters.Common.Lib.Dto.Base;

namespace WideWorldImporters.Common.Lib.Dto.Order
{
    /// <summary>
    /// 
    /// </summary>
    public class OrderInfoResponseDto: ResponseBaseDto
    {
        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>
        /// The body.
        /// </value>
        public OrderInfoResponseBodyDto Body { get; set; }
    }
}
