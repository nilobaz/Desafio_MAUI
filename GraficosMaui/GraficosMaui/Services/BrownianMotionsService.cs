namespace GraficosMaui.Services;

public class BrownianMotionsService: IBrownianMotionsService
{
    public async Task<double[][]> GenerateMultipleBrownianMotionsAsync(double sigma, double mean, double initialPrice, int numDays, int numLines)
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
