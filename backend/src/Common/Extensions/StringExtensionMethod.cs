using Microsoft.EntityFrameworkCore;
namespace Common.Extensions
{
    public static class StringExtensionMethod
    {
        [DbFunction(Name = "SOUNDEX", IsBuiltIn = true)]
        public static string SoundsLike(string query) => throw new NotImplementedException();

        public static List<int> ConvertToListInt(this string query)
        {
            var list = new List<int>();

            if (!string.IsNullOrWhiteSpace(query))
            {
                list.AddRange(query.Split(",").Select(x => Convert.ToInt32(x)));
            }


            return list;
        }

        public static List<Guid> ConvertToListGuid(this string query)
        {
            var list = new List<Guid>();

            if (!string.IsNullOrWhiteSpace(query))
            {
                list.AddRange(query.Split(",").Select(x => Guid.Parse(x)));
            }


            return list;
        }
    }
}
