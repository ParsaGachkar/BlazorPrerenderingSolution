using Microsoft.AspNetCore.Components;

namespace BlazorApp4
{
    public class HydratingComponent:ComponentBase
    {
        [Inject] private IHttpContextAccessor HttpContextAccessor { get; set; } = default!;

        protected sealed override void OnInitialized()
        {
            base.OnInitialized();
            if (!HttpContextAccessor.HttpContext!.Response.HasStarted) PreRendering();
            else Hydrating();
        }

        protected virtual void Hydrating()
        {
        }

        protected virtual void PreRendering()
        {
        }

        protected sealed override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            if (!HttpContextAccessor.HttpContext!.Response.HasStarted) await PreRenderingAsync();
            else await HydratingAsync();
        }

        protected virtual Task HydratingAsync()
        {
            return Task.CompletedTask;
        }

        protected virtual Task PreRenderingAsync()
        {
            return Task.CompletedTask;
        }
    }
}
