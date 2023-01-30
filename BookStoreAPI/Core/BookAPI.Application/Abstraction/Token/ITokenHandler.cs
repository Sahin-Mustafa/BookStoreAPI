namespace BookAPI.Application.Abstraction.Token
{
    public interface ITokenHandler
    {
        DTOs.Token CreateAccessToken();
    }
}
