using Microsoft.EntityFrameworkCore;
namespace Common.Extensions
{
    public static class StringExtensionMethod
    {
        [DbFunction(Name = "SOUNDEX", IsBuiltIn = true)]
        public static string SoundsLike(string query) => throw new NotImplementedException();
    }
}
