namespace Api.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Api.Infrastructure;
    using LanguageExt;
    using Microsoft.AspNetCore.Mvc;
    using static LanguageExt.Prelude;

    public class ApiControllerBase : ControllerBase
    {
        public async Task<IActionResult> BuildResponse<T>(Task<T> task) => this.Ok(await task);

        public IActionResult BuildResponse<T>(Option<T> option) =>
            this.BuildResponse(option, _ => { });

        public IActionResult BuildResponse<T>(Option<T> option, Action<T> action) =>
            match(
                option,
                data =>
                {
                    action(data);
                    return this.Ok(data);
                },
                () => this.Ok("No records found"));

        public Task<IActionResult> BuildResponse<T>(OptionAsync<T> option) =>
            this.BuildResponse(option, _ => { });

        public Task<IActionResult> BuildResponse<T>(OptionAsync<T> option, Action<T> action) =>
            match(
                option,
                data =>
                {
                    action(data);
                    return this.Ok(data) as IActionResult;
                },
                () => this.Ok("No records found"));

        public IActionResult BuildResponse<T>(Either<Notification, T> either) =>
            this.BuildResponse(either, _ => { });

        public IActionResult BuildResponse<T>(Either<Notification, T> either, Action<T> action) =>
            match(
                either,
                data =>
                {
                    action(data);
                    return (IActionResult)this.Ok(data);
                },
                notification => this.BadRequest(notification.Messages));

        public Task<IActionResult> BuildResponse<T>(EitherAsync<Notification, T> either) =>
            this.BuildResponse(either, _ => { });

        public Task<IActionResult> BuildResponse<T>(EitherAsync<Notification, T> either, Action<T> action) =>
            match(
                either,
                data =>
                {
                    action(data);
                    return (IActionResult)this.Ok(data);
                },
                notification => this.BadRequest(notification.Messages));
    }
}
