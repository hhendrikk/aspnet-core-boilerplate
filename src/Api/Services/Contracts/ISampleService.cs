namespace Api.Services.Contracts
{
    using Api.Infrastructure;
    using LanguageExt;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface ISampleService
    {
        EitherAsync<Notification, string> HelloSample(Option<string> message);
    }
}
