namespace Core.Authorization
{
    public class JwtAuthResult
    {
        public string UserName { get; set; }

        public string Role { get; set; }

        public string AccessToken { get; set; }
    }
}
