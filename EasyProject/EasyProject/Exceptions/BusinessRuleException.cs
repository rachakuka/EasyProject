
using System;

namespace EasyProject.Exceptions
{
    public class BusinessRuleException : Exception
    {
        public ExceptionHandlerSeverity Severity { get; set; } = ExceptionHandlerSeverity.ALERTA;

        public BusinessRuleException(string message) : base(message) { }
        public BusinessRuleException(string message, ExceptionHandlerSeverity Severity) : base(message)
        {
            this.Severity = Severity;
        }
        public BusinessRuleException(string message, Exception inner) : base(message, inner) { }
        public BusinessRuleException(string message, Exception inner, ExceptionHandlerSeverity Severity) : base(message, inner)
        {
            this.Severity = Severity;
        }
    }

    public enum ExceptionHandlerSeverity
    {
        ERRO, ALERTA, INFO, SUCESSO
    }
}

