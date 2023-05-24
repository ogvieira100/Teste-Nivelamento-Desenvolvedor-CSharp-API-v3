namespace Questao5.Infrastructure.CrossCutting
{
    public static class CommonMethodsExtensions
    {

        #region " Enums "

        public static T GetEnumToName<T>(this string value, T def) => CommonMethods.GetEnumToName<T>(value, def);

        public static string GetAttributeDescription<T>(this T source) => CommonMethods.GetAttributeDescription<T>(source);

        public static Dictionary<int, string> EnumToDictionaryName<T>() => CommonMethods.EnumToDictionaryName<T>();

        public static Dictionary<int, string> EnumToDictionaryDescription<T>() => CommonMethods.EnumToDictionaryDescription<T>();


        #endregion

        #region " String "

        public static string removeAccents(this string texto) => CommonMethods.removeAccents(texto);

        public static string GetQueryString<T>(this T obj, bool usingEncode = false, IEnumerable<string> propsExcluded = null) where T : class => CommonMethods.GetQueryString(obj, usingEncode, propsExcluded);

        public static bool IsGuid(this string numero) => CommonMethods.IsGuid(numero);

        /// <summary>
        /// Formatar uma string CNPJ
        /// </summary>
        /// <param name="CNPJ">string CNPJ sem formatacao</param>
        /// <returns>string CNPJ formatada</returns>
        /// <example>Recebe '99999999999999' Devolve '99.999.999/9999-99'</example>

        public static string FormatCNPJ(this string CNPJ) => CommonMethods.FormatCNPJ(CNPJ);

        /// <summary>
        /// Formatar uma string CPF
        /// </summary>
        /// <param name="CPF">string CPF sem formatacao</param>
        /// <returns>string CPF formatada</returns>
        /// <example>Recebe '99999999999' Devolve '999.999.999-99'</example>

        public static string FormatCPF(this string CPF) => CommonMethods.FormatCPF(CPF);

        public static bool IsValidEmail(this string email) => CommonMethods.IsValidEmail(email);

        public static bool IsCnpj(this string cnpj) => CommonMethods.IsCnpj(cnpj);

        public static bool IsCpf(this string cpf) => CommonMethods.IsCpf(cpf);

        public static string FormatRG(this string texto) => CommonMethods.FormatRG(texto);

        public static string OnlyNumbers(this string numeros) => CommonMethods.OnlyNumbers(numeros);

        #endregion

        #region  " DateTime "
        public static DateTime InitialDayMonthYear(this DateTime data) => CommonMethods.InitialDayMonthYear(data);

        public static DateTime FinalDayMonthYear(this DateTime data) => CommonMethods.FinalDayMonthYear(data);

        //

        #endregion

    }
}
