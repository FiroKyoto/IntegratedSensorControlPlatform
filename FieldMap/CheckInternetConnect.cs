
namespace FieldMap
{
    using System.Runtime;
    using System.Runtime.InteropServices;

    public class CheckInternetConnect
    {
        ///<summary>
        /// Check internet connection
        /// </summary>
        /// <returns>bool</returns>

        //creating the extern function
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReserveValue);

        //creatin a function that uses the API function
        public static bool IsConnectedToInternet()
        {
            int Desc;
            return InternetGetConnectedState(out Desc, 0);
        }

    }
}
