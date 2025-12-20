using Microsoft.JSInterop;

namespace BlazorApp1.Services
{
    public class ClipBoardService
    {
        private readonly IJSRuntime _jsRuntime;

        public ClipBoardService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public ValueTask WriteTextAsync(string text)
        {
            return _jsRuntime.InvokeVoidAsync("navigator.clipboard.writeText", text);
        }
    }
}
