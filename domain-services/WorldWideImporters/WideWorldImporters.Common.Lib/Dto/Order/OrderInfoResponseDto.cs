using WideWorldImporters.Common.Lib.Dto.Base;

namespace WideWorldImporters.Common.Lib.Dto.Order
{
    /// <summary>
    /// 
    /// </summary>
    public class OrderInfoResponseDto
    {
        /// <summary>
        /// Gets or sets the header.
        /// </summary>
        /// <value>
        /// The header.
        /// </value>
        public ResponseBaseDto Header { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>
        /// The body.
        /// </value>
        public OrderInfoResponseBodyDto Body { get; set; }
    }
}
