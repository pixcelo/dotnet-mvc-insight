namespace InsightDDD.Services
{
    public class AccessTokenAccessor : IAccessTokenAccessor
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public AccessTokenAccessor(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string GetAccessToken()
        {
            return _contextAccessor.HttpContext.Session.GetString("AccessToken");
        }

        public void SetAccessToken(string accessToken)
        {
            _contextAccessor.HttpContext.Session.SetString("AccessToken", accessToken);

        }
    }
}
