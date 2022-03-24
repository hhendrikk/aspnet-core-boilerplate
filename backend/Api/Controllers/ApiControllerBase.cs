namespace Api.Controllers;

using System;
using System.Threading.Tasks;
using Infrastructure;
using LanguageExt;
using Microsoft.AspNetCore.Mvc;
using static LanguageExt.Prelude;

public class ApiControllerBase : ControllerBase
{
    private const string NOT_FOUND_MESSAGE = "No records found";

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
            () => this.Ok(NOT_FOUND_MESSAGE));

    public Task<IActionResult> BuildResponseAsync<T>(OptionAsync<T> option) =>
        this.BuildResponseAsync(option, _ => { });

    public Task<IActionResult> BuildResponseAsync<T>(OptionAsync<T> option, Action<T> action) =>
        match(
            option,
            data =>
            {
                action(data);
                return this.Ok(data) as IActionResult;
            },
            () => this.Ok(NOT_FOUND_MESSAGE));

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

    public Task<IActionResult> BuildResponseAsync<T>(EitherAsync<Notification, T> either) =>
        this.BuildResponseAsync(either, _ => { });

    public Task<IActionResult> BuildResponseAsync<T>(EitherAsync<Notification, T> either, Action<T> action) =>
        match(
            either,
            data =>
            {
                action(data);
                return (IActionResult)this.Ok(data);
            },
            notification => this.BadRequest(notification.Messages));
}
