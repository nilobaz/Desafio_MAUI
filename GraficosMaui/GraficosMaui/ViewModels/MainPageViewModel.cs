namespace GraficosMaui.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    public MainPageViewModel() { }

    [ObservableProperty]
    private double sigma;

    [ObservableProperty]
    private double mean;

    [ObservableProperty]
    private double initialPrice;

    [ObservableProperty]
    private int numDays = 1;

    [ObservableProperty]
    private int numberLines = 1;

    [ObservableProperty]
    private double[][] brownianMotionData;

    [RelayCommand]
    private async Task GenerateData()
    {
        var convertedSigma = Sigma * 0.01;
        var convertedMean = Mean * 0.01;

        BrownianMotionData = await GenerateMultipleBrownianMotionsAsync(convertedSigma, convertedMean, InitialPrice, NumDays, NumberLines);
    }

    private async Task<double[][]> GenerateMultipleBrownianMotionsAsync(double sigma, double mean, double initialPrice, int numDays, int numLines)
    {
        double[][] data = new double[numLines][];
        Random random = new Random();

        await Task.WhenAll(
            Enumerable.Range(0, numLines).Select(async sim =>
            {
                double[] prices = new double[numDays];
                prices[0] = initialPrice;

                for (int i = 1; i < numDays; i++)
                {
                    double u1 = 1.0 - random.NextDouble();
                    double u2 = 1.0 - random.NextDouble();
                    double z = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Cos(2.0 * Math.PI * u2);

                    double dailyReturn = mean + sigma * z;

                    prices[i] = prices[i - 1] * Math.Exp(dailyReturn);
                }

                data[sim] = prices;
            }));

        return data;
    }
}
