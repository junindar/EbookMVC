using System.Web;
using System.Web.Mvc;

namespace MVCPerpustakaan.Helpers
{
    public static class CustomHelperBase
    {
        public static IHtmlString GambarBuku(this HtmlHelper helper,string imageName, string width, string height)
        {

            string result = $"<img src = {GetUrlImage(imageName)} style =\"width: {width}; height: {height}\"/>";

            return new HtmlString(result);
        }

        public static string GetUrlImage(string imageName)
        {
            var img = string.IsNullOrEmpty(imageName) ? "default.jpg" : imageName;
            string resultUrl = $"/Images/{img}";

            return resultUrl;
        }


    }
}