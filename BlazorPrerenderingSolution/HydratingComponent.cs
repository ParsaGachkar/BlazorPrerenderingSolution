using Microsoft.AspNetCore.Components;

namespace BlazorApp4
{
    public class HydratingComponent:ComponentBase,IDisposable
    {
        [Inject] private IHttpContextAccessor HttpContextAccessor { get; set; } = default!;

        protected sealed override void OnInitialized()
        {
            base.OnInitialized();
            if (!HttpContextAccessor.HttpContext!.Response.HasStarted) OnPreRendering();
            else OnHydrating();
        }

        protected virtual void OnHydrating()
        {
        }

        protected virtual void OnPreRendering()
        {
        }

        protected sealed override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            if (!HttpContextAccessor.HttpContext!.Response.HasStarted) await OnPreRenderingAsync();
            else await OnHydratingAsync();
        }

        protected virtual Task OnHydratingAsync()
        {
            return Task.CompletedTask;
        }

        protected virtual Task OnPreRenderingAsync()
        {
            return Task.CompletedTask;
        }


        public void Dispose()
        {
            OnDisposeAsync().RunSynchronously();
        }

        public async Task OnDisposeAsync()
        {

        }
    }
}
