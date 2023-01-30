namespace BookAPI.Application.Exceptions
{
    public class NotFoundCustomerException : Exception
    {
        public NotFoundCustomerException() : base("Kullanıcı adı veya şifre hatalı.")
        {
        }

        public NotFoundCustomerException(string? message) : base(message)
        {
        }

        public NotFoundCustomerException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
