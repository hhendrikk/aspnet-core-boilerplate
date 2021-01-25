namespace Api.Services
{
    using Api.Infrastructure;
    using Api.Services.Contracts;
    using LanguageExt;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using static LanguageExt.Prelude;

    public class SampleService : ISampleService
    {
        public EitherAsync<Notification, string> HelloSample(Option<string> message) =>
            message.Match(
                value => RightAsync<Notification, string>(value),
                () => LeftAsync<Notification, string>(Notification.Notify("Message is required!"))
                );
    }
}
