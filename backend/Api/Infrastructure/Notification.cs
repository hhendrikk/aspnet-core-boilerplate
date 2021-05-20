namespace Api.Infrastructure
{
    using System.Collections.Generic;
    using LanguageExt;

    public class Notification
    {
        private Notification(IEnumerable<string> messages)
        {
            if (messages is null)
            {
                this.Messages = default;
            }

            this.Messages = messages.Freeze();
        }

        public Lst<string> Messages { get; private set; }

        public bool HasNotification => this.Messages.Count > 0;

        public static Notification Notify(params string[] message) => new Notification(message);

        public Notification Notify(string message)
        {
            this.Messages = this.Messages.Add(message);
            return this;
        }
    }
}