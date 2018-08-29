namespace Common.Api.Messaging
{
    public class UserCompledEvent
    {
        public int UserId { get; set; }

        public UserCompledEvent(int userId)
        {
            this.UserId = userId;
        }
    }
}
