// unset

namespace Api.Infrastructure.Extensions
{
    using System;

    public static class StringExtensions
    {
        public static string GetEnv(this string value) =>
            Environment.GetEnvironmentVariable(value)
            ?? Environment.GetEnvironmentVariable(value, EnvironmentVariableTarget.User)
            ?? Environment.GetEnvironmentVariable(value, EnvironmentVariableTarget.Machine);

        public static T GetEnv<T>(this string value) => (T)Convert.ChangeType(value.GetEnv(), typeof(T));
    }
}