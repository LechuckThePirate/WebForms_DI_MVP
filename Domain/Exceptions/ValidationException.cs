using System;

namespace ITCR.Domain.Exceptions
{
    /// <summary>
    /// Used when the entity has non-acceptable values...
    /// </summary>
    public class ValidationException : BaseException
    {
        public string Entity { get; set; }
        public string Field { get; set; }
        public object OffendingValue { get; set; }

        public ValidationException(string message, string entity, string field, object offendingValue, Exception innerException) :
            base(message, innerException)
        {
            this.Entity = entity;
            this.Field = field;
            this.OffendingValue = offendingValue;
        }

        public ValidationException(string message, string entity, string field)
            : this(message, entity,field, string.Empty,null) { }

        public ValidationException(string message)
            : this(message, string.Empty, string.Empty, string.Empty, null) { }
    }
}
