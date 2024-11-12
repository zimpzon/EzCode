namespace EzCodeProblems.Util
{
    public static class EzUtil
    {
        /// <summary>
        /// Converts generic type names like List`1 to user friendly names like List<int>.
        /// Got it from StackOverflow somewhere.
        /// Also converts names like String and Char to string and char (my addition).
        /// </summary>
        internal static string GetPrettyTypeName(Type type)
        {
            if (type.IsGenericType)
            {
                string genericArguments = type.GetGenericArguments()
                                    .Select(x => TypeCommonName(x.Name))
                                    .Aggregate((x1, x2) => $"{x1}, {x2}");
                return $"{type.Name[..type.Name.IndexOf('`')]}" // backtick in generic type names
                     + $"<{genericArguments}>";
            }
            return TypeCommonName(type.Name);
        }

        /// <summary>
        /// Replace selected names like 'String' with 'string'.
        /// </summary>
        private static string TypeCommonName(string name)
        {
            return name switch
            {
                "String" => "string",
                "Char" => "char",
                "Int32" => "int",
                "Int64" => "long",
                _ => name,
            };
        }
    }
}
