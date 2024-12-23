# Brownian Graph Generator
#### Video Demo: <URL HERE>
#### Description:

The Brownian Graph Generator is a .NET MAUI application designed to generate and display graphs based on Brownian motion. This application leverages .NET 8 and the SkiaSharp library to render the graphs. The project follows the MVVM (Model-View-ViewModel) architecture and uses dependency injection to manage dependencies.

### Project Structure

The project is organized into several key directories and files:

- **App.xaml**: Defines the application resources.
- **App.xaml.cs**: Contains the application logic.
- **AppShell.xaml**: Defines the shell of the application.
- **AppShell.xaml.cs**: Contains the shell logic.
- **MauiProgram.cs**: Configures the MAUI application, including services and fonts.
- **Controls/SkiaGraphView.cs**: Custom control for rendering the graph using SkiaSharp.
- **Models/BrownianMotionsParams.cs**: Defines the parameters for the Brownian motion.
- **Services**: Contains service interfaces and implementations.
- **ViewModels**: Contains the view models for the application.
- **Views**: Contains the XAML views for the application.
- **Usings.cs**: Consolidates the namespaces used in the application.

### Key Components

#### MainPage.xaml

The `MainPage.xaml` file defines the structure of the application's main page. It contains a grid layout with two columns. The first column houses a custom control, `SkiaGraphView`, which displays the graph. The second column includes several input controls for configuring the graph parameters, such as initial price, average volatility, average return, time in days, and the number of lines. There is also a button to generate the graph simulation.

#### MainPageViewModel.cs

The `MainPageViewModel` class is responsible for managing the data and logic of the main page. It includes properties for storing values such as `sigma` (average volatility), `mean` (average return), `initialPrice` (initial price), `numDays` (time in days), and `numberLines` (number of lines to display on the graph). Additionally, it features an asynchronous method, `GenerateData`, which generates the data for the Brownian motion graph.

#### SkiaGraphView.cs

The `SkiaGraphView` class is a custom control that extends the `SKCanvasView` class from the SkiaSharp library. It is responsible for rendering the graph on the screen. It has properties to store the graph data (`SkiaGraphData`) and the number of lines (`NumberLines`). The `OnPaintSurface` method is overridden to draw the graph using the provided data.

### Services

The application uses a service-oriented architecture to handle the generation of Brownian motion data. The `IBrownianMotionsService` interface defines the contract for the service, and the `BrownianMotionsService` class implements this interface. The service is registered in the dependency injection container in `MauiProgram.cs`.

### Dependency Injection

Dependency injection is configured in the `MauiProgram.cs` file. The `CreateMauiApp` method sets up the MAUI application, registers services, and configures logging. The `IBrownianMotionsService` and `MainPageViewModel` are registered as transient services.

```cs
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseSkiaSharp()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddTransient<IBrownianMotionsService, BrownianMotionsService>();
        builder.Services.AddTransient<MainPage, MainPageViewModel>();

        return builder.Build();
    }
}
```

### Fonts

The application includes custom fonts, which are configured in the `MauiProgram.cs` file. The `OpenSans-Regular.ttf` and `OpenSans-Semibold.ttf` fonts are added to the application.

### Global Usings

The `Usings.cs` file consolidates the namespaces used in the application, including those for the classes mentioned above, as well as other namespaces related to SkiaSharp and the CommunityToolkit.Mvvm toolkit.

```cs
global using CommunityToolkit.Maui;
global using CommunityToolkit.Mvvm.ComponentModel;
global using CommunityToolkit.Mvvm.Input;
global using BrownianGraph.Models;
global using BrownianGraph.Services;
global using BrownianGraph.ViewModels;
global using BrownianGraph.Views;
global using Microsoft.Extensions.Logging;
global using SkiaSharp;
global using SkiaSharp.Views.Maui;
global using SkiaSharp.Views.Maui.Controls;
global using SkiaSharp.Views.Maui.Controls.Hosting;
global using System;
global using System.Linq;
global using System.Threading.Tasks;
```

### Running the Application

To run the application, ensure you have .NET 8 installed. Open the solution in Visual Studio and build the project. You can then run the application on your Windows platform.

### Conclusion

The Brownian Graph Generator is a robust application that demonstrates the power of .NET MAUI and SkiaSharp for creating applications with rich graphical capabilities. By following the MVVM architecture and leveraging dependency injection, the application is both modular and maintainable.

For more information on Brownian motion, you can refer to the [Wikipedia article](https://en.wikipedia.org/wiki/Brownian_motion).

<img src="/project/screen.png">
