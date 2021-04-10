namespace Api.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using Api.Infrastructure;

    using LanguageExt;

    using static LanguageExt.Prelude;

    public class ApiControllerBase : ControllerBase
    {
        public IActionResult BuildResponse<T>(Either<Notification, T> either) => BuildResponse<T>(either, _ => { });

        public IActionResult BuildResponse<T>(Either<Notification, T> either, Action<T> action) =>
            match(
                either,
                data =>
                {
                    action(data);
                    return (IActionResult)Ok(data);
                },
                notification => BadRequest(notification.Messages));

        public Task<IActionResult> BuildResponse<T>(EitherAsync<Notification, T> either) => BuildResponse<T>(either, _ => { });


        public Task<IActionResult> BuildResponse<T>(EitherAsync<Notification, T> either, Action<T> action) =>
           match(
               either,
               data =>
               {
                   action(data);
                   return (IActionResult)Ok(data);
               },
               notification => BadRequest(notification.Messages));
    }
}
