namespace Api.Services
{
    using Api.Infrastructure;
    using Api.Services.Contracts;
    using Data.Context;
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
                RightAsync<Notification, string>,
                () => LeftAsync<Notification, string>(Notification.Notify("Message is required!")));
    }
}
