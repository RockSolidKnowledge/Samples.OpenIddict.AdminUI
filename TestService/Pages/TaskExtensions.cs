namespace TestService.Pages
{
    internal static class TaskExtensions
    {
        public static async Task<TOut> AndThen<TIn, TOut>(this Task<TIn> inputTask, Func<TIn, Task<TOut>> mapping)
        {
            var input = await inputTask;
            return await mapping(input);
        }
    }
}
