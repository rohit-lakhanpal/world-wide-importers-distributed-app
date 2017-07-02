using System.Threading.Tasks;

namespace WideWorldImporters.Common.Lib.Common
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRequestResolver
    {
        /// <summary>
        /// Processes the request asynchronous.
        /// </summary>
        /// <param name="requestMessage">The request message.</param>
        /// <param name="responderIdentity">The responder identity.</param>
        /// <returns></returns>
        Task<byte[]> ProcessRequestAsync(string requestMessage, string responderIdentity);

        /// <summary>
        /// Processes the request asynchronous.
        /// </summary>
        /// <param name="requestMessage">The request message.</param>
        /// <param name="responderIdentity">The responder identity.</param>
        /// <returns></returns>
        byte[] ProcessRequest(string requestMessage, string responderIdentity);
    }
}
