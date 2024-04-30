using Microsoft.Maui.LifecycleEvents;

namespace CadastroClientesMaui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

#if WINDOWS
        builder.ConfigureLifecycleEvents(events =>
        {
            events.AddWindows(wndLifeCycleBuilder =>
            {
                wndLifeCycleBuilder.OnWindowCreated(window =>
                {
                    //window.ExtendsContentIntoTitleBar = false;  
                    IntPtr hWnd = WinRT.Interop.WindowNative.GetWindowHandle(window);
                    WindowId myWndId = Win32Interop.GetWindowIdFromWindow(hWnd);
                    var _appWindow =AppWindow.GetFromWindowId(myWndId);
                    (_appWindow.Presenter as OverlappedPresenter).Maximize();                     
                });
            });
        });
#endif

        builder.Services.AddTransient<MainPage, MainPageViewModel>();
        builder.Services.AddTransient<ClientPage, ClientViewModel>();
        builder.Services.AddSingleton<IClientService, ClientService>();

        return builder.Build();
    }
}
