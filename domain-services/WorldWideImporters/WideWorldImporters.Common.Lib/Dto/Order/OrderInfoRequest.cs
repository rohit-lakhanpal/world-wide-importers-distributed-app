﻿using WideWorldImporters.Common.Lib.Dto.Base;

namespace WideWorldImporters.Common.Lib.Dto.Order
{
    public class OrderInfoRequestDto
    {
        /// <summary>
        /// Gets or sets the header.
        /// </summary>
        /// <value>
        /// The header.
        /// </value>
        public RequestBaseDto Header { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>
        /// The body.
        /// </value>
        public OrderInfoRequestBodyDto Body { get; set; }
    }
}
