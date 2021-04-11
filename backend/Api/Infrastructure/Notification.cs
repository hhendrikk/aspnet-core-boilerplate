namespace Api.Infrastructure
{
    using LanguageExt;
    using System.Collections.Generic;

    public class Notification
    {
        public Lst<string> Messages { get; private set; }

        private Notification(IEnumerable<string> messages)
        {
            if (messages is null)
                Messages = new Lst<string>();

            Messages = messages.Freeze();
        }

        public Notification Notify(string message)
        {
            Messages = Messages.Add(message);
            return this;
        }

        public bool HasNotification => Messages.Count > 0;

        public static Notification Notify(params string[] message) => new Notification(message);
    }
}