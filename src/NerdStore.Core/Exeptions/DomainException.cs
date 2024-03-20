namespace NerdStore.Core.Exeptions
{
    public class DomainException : Exception
    {
        public DomainException()
        {

        }
        public DomainException(string message)
            : base(message)
        {

        }
        public DomainException(string message, Exception innerExpection)
            : base(message, innerExpection)
        {

        }
    }
}
