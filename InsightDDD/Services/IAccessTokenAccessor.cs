namespace InsightDDD.Services
{
    public interface IAccessTokenAccessor
    {
        string GetAccessToken();
        void SetAccessToken(string accessToken);
    }
}