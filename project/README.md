# Brownian Graph Generator
#### Video Demo: <URL HERE>
#### Description:

The application, built using .NET MAUI, leverages .NET 8 and the SkiaSharp library to generate graphs based on [Brownian motion](https://en.wikipedia.org/wiki/Brownian_motion). The project follows the MVVM architecture and uses dependency injection.

The `MainPage.xaml` file defines the structure of the application's main page. It contains a grid layout with two columns. The first column houses a custom control, `SkiaGraphView`, which displays the graph. The second column includes several input controls for configuring the graph parameters, such as initial price, average volatility, average return, time in days, and the number of lines. There is also a button to generate the graph simulation.

The `MainPageViewModel` class is responsible for managing the data and logic of the main page. It includes properties for storing values such as `sigma` (average volatility), `mean` (average return), `initialPrice` (initial price), `numDays` (time in days), and `numberLines` (number of lines to display on the graph). Additionally, it features an asynchronous method, `GenerateData`, which generates the data for the Brownian motion graph.

The `SkiaGraphView` class is a custom control that extends the `SKCanvasView` class from the SkiaSharp library. It is responsible for rendering the graph on the screen. It has properties to store the graph data (`SkiaGraphData`) and the number of lines (`NumberLines`). The OnPaintSurface method is overridden to draw the graph using the provided data.

The `Usings.cs` file consolidates the namespaces used in the application, including those for the classes mentioned above, as well as other namespaces related to SkiaSharp and the `CommunityToolkit.Mvvm` toolkit.

The `GenerateBrownianMotion` code has been designed to enhance its extensibility and performance and is used as the `IBrownianMotionsService`.

[Application Screenshot](/project/screen.png)
