namespace Insight.Services
{
    public interface IAccessTokenAccessor
    {
        string GetAccessToken();
        void SetAccessToken(string accessToken);
    }
}