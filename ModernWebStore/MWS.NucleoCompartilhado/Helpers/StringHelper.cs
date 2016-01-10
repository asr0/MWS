#region

using System.Security.Cryptography;
using System.Text;

#endregion

namespace MWS.NucleoCompartilhado.Helpers
{
    public class StringHelper
    {
        public static string Encriptar(string valor)
        {
            if (string.IsNullOrEmpty(valor))
                return "";


            valor += "|Q9W8E7R6T5Y-A1S2D3F4G-Z!X@C#V$B";
            var md5 = MD5.Create();
            var data = md5.ComputeHash(Encoding.Default.GetBytes(valor));
            var sb = new StringBuilder();
            for (var i = 0; i < data.Length; i++)
                sb.Append(data[i].ToString("x2"));


            return sb.ToString();
        }
    }
}