namespace WideWorldImporters.Common.Lib.Dto.Order
{
    public class OrderInfoRequestBodyDto
    {
        /// <summary>
        /// Gets or sets the type of the request.
        /// </summary>
        /// <value>
        /// The type of the request.
        /// </value>
        public OrderInfoRequestType RequestType { get; set; }

        /// <summary>
        /// Gets or sets the request query.
        /// </summary>
        /// <value>
        /// The request query.
        /// </value>
        public string RequestQuery { get; set; }
    }


}
