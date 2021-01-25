namespace Api.Controllers
{
    using Api.Infrastructure;
    using LanguageExt;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using static LanguageExt.Prelude;

    public class ApiControllerBase : ControllerBase
    {
        public IActionResult BuildResponse<T>(Either<Notification, T> either) => BuildResponse<T>(either, _ => {});

        public IActionResult BuildResponse<T>(Either<Notification, T> either, Action<T> action) =>
            match(
                either,
                data => {
                    action(data);
                    return (IActionResult)Ok(data);
                },
                notification => BadRequest(notification.Messages));

        public Task<IActionResult> BuildResponse<T>(EitherAsync<Notification, T> either) => BuildResponse<T>(either, _ => { });


        public Task<IActionResult> BuildResponse<T>(EitherAsync<Notification, T> either, Action<T> action) =>
           match(
               either,
               data => {
                   action(data);
                   return (IActionResult)Ok(data);
               },
               notification => BadRequest(notification.Messages));
    }
}
