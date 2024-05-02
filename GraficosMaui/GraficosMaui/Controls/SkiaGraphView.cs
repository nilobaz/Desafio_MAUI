namespace GraficosMaui.Controls;

public class SkiaGraphView : SKCanvasView
{
    private Random random;

    public SkiaGraphView()
    {
        random = new Random();
    }

    public static readonly BindableProperty NumberLinesProperty =
        BindableProperty.Create(nameof(NumberLines), typeof(int), typeof(SkiaGraphView), 1);

    public int NumberLines
    {
        get => (int)GetValue(NumberLinesProperty);
        set => SetValue(NumberLinesProperty, value);
    }

    public static readonly BindableProperty SkiaGraphDataProperty =
        BindableProperty.Create(nameof(SkiaGraphData), typeof(double[][]), typeof(SkiaGraphView), null,
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                (bindable as SkiaGraphView)?.InvalidateSurface();
            });

    public double[][] SkiaGraphData
    {
        get => (double[][])GetValue(SkiaGraphDataProperty);
        set => SetValue(SkiaGraphDataProperty, value);
    }

    protected override void OnPaintSurface(SKPaintSurfaceEventArgs args)
    {
        base.OnPaintSurface(args);

        try
        {
            var canvas = args.Surface.Canvas;
            canvas.Clear();

            if (SkiaGraphData != null && SkiaGraphData.Length > 0)
            {
                int numberOfGraphs = SkiaGraphData.Length;
                var dataLength = SkiaGraphData[0].Length;

                // Calculate the scale factors for x and y axes
                var scaleX = args.Info.Width / (dataLength - 1);
                var scaleY = args.Info.Height / (SkiaGraphData.SelectMany(data => data).Max());

                // Draw x-axis
                using (var xPaint = new SKPaint
                {
                    Style = SKPaintStyle.Stroke,
                    StrokeWidth = 7,
                    Color = SKColors.Red
                })
                {
                    canvas.DrawLine(0, args.Info.Height, args.Info.Width, args.Info.Height, xPaint);
                }

                // Draw y-axis
                using (var yPaint = new SKPaint
                {
                    Style = SKPaintStyle.Stroke,
                    StrokeWidth = 7,
                    Color = SKColors.Red
                })
                {
                    canvas.DrawLine(0, 0, 0, args.Info.Height, yPaint);
                }

                for (int s = 0; s < numberOfGraphs; s++)
                {
                    double[] data = SkiaGraphData[s];

                    // Draw the graph
                    using (var paint = new SKPaint
                    {
                        Style = SKPaintStyle.Stroke,
                        StrokeWidth = 2,
                        StrokeCap = SKStrokeCap.Round,
                        Color = GetRandomColor()
                    })
                    {
                        var path = new SKPath();
                        path.MoveTo(0, (float)(args.Info.Height - data[0] * scaleY));

                        for (int i = 1; i < dataLength; i++)
                        {
                            var x = i * scaleX;
                            var y = (float)(args.Info.Height - data[i] * scaleY);
                            path.LineTo(x, y);
                        }

                        canvas.DrawPath(path, paint);
                        InvalidateMeasure();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private SKColor GetRandomColor()
    {
        return new SKColor((byte)random.Next(256), (byte)random.Next(256), (byte)random.Next(256));
    }
}
