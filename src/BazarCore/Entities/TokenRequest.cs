namespace BazarCore.Entities
{
    public class TokenRequest : BaseEntity
    {
        public TokenRequest(string token, bool alreadyUsed, int userId)
        {
            Token = token;
            AlreadyUsed = alreadyUsed;
            UserId = userId;
        }

        public string Token { get; set; }
        public bool AlreadyUsed { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
