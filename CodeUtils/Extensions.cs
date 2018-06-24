using System;
using System.Text.RegularExpressions;

namespace CodeUtils
{
    public static class Extensions
    {

        public static string ToNumbersOnly(this string value)
        {
            var retorno = string.Empty;
            for (var i = 0; i < value.Trim().Length; i++)
                if (int.TryParse(value.Substring(i, 1), out var res))
                    retorno = retorno + res;

            return retorno;
        }

        public static string ToUpperFirstLetter(this string value)
        {
            if (value.Length <= 0) return value;

            var array = value.ToCharArray();
            array[0] = char.ToUpper(array[0]);

            return new string(array);
        }

        public static int DiffInYears(this DateTime start)
        {
            return (DateTime.Now.Year - start.Year - 1) +
                   (((DateTime.Now.Month > start.Month) ||
                     ((DateTime.Now.Month == start.Month) && (DateTime.Now.Day >= start.Day)))
                       ? 1
                       : 0);
        }

        public static bool IsValidText(this string value)
        {
            var objNotWholePattern = new Regex("[^0-9]");
            return !objNotWholePattern.IsMatch(value) && (!string.IsNullOrEmpty(value));
        }

        public static bool IsValidNumber(this string value)
        {
            var objNotWholePattern = new Regex("[^0-9]");
            return !objNotWholePattern.IsMatch(value) & (!string.IsNullOrEmpty(value));
        }

        public static bool IsValidCnpjcpf(this string cnpjOrCpf)
        {
            return Validations.ValidateCnpjOrCpf(cnpjOrCpf);
        }

        public static bool IsValidEmail(this string inputEmail)
        {
            const string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                    @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                    @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

            var re = new Regex(strRegex);

            return re.IsMatch(inputEmail);
        }

        public static decimal Truncate(this decimal value, int decimals)
        {
            var step = (decimal) Math.Pow(10, decimals);
            var tmp = (int) Math.Truncate(step * value);

            return tmp / step;
        }

        public static double Truncate(this double value, int decimals)
        {
            var step = Math.Pow(10, decimals);
            var tmp = (int) Math.Truncate(step * value);
            return tmp / step;
        }

        public static string ToChaveNFeFormat(this string chave, bool addpoint = false)
        {
            var c = 0;
            var chaveFormatada = "";
            for (var i = 0; i < chave.Trim().Length; i++)
            {
                c++;
                chaveFormatada += chave.Substring(i, 1);
                if (c != 4) continue;
                c = 0;
                if (addpoint)
                    chaveFormatada += ".";
                else
                    chaveFormatada += " ";
            }

            return string.IsNullOrEmpty(chaveFormatada) ? chave : chaveFormatada.Trim();
        }

        public static string ToFoneFormat(this string value)
        {
            var txt = string.Empty;
            try
            {
                txt = value;

                switch (txt.Length)
                {
                    case 2:
                        return $"({txt})";
                    case 8:
                        return $"{txt.Substring(0, 4)}-{txt.Substring(4)}";
                    case 9:
                        return $"{txt.Substring(0, 5)}-{txt.Substring(5)}";
                    case 10:
                        return $"({txt.Substring(0, 2)}){txt.Substring(2, 4)}-{txt.Substring(6)}";
                    case 11:
                        return
                            $"({txt.Substring(0, 2)}) {txt.Substring(2, 1)} {txt.Substring(3, 4)}-{txt.Substring(7)}";
                    default:
                        return txt;
                }
            }
            catch
            {
                return txt;
            }

        }
    }
}