using System;

namespace EasyProject.Exceptions
{
    public class ExceptionHandler
    {
        public static string HandleException(Exception ex)
        {
            if (ex is BusinessRuleException)
            {
                var regraexception = ex as BusinessRuleException;
                return $"{regraexception.Severity.ToString()}|{ex.Message}";
            }
            else if (ex is ArgumentNullException)
            {
                var ex2 = ex as ArgumentNullException;
                return "ERRO|" + ex2.ParamName;
            }
            else
            {
                return "ERRO|" + ex.Message;
            }
        }
    }
}


