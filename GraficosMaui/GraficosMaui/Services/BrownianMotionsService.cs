namespace GraficosMaui.Services;

public class BrownianMotionsService : IBrownianMotionsService
{
    public async Task<double[][]> GenerateMultipleBrownianMotionsAsync(BrownianMotionsParams parameters)
    {
        double[][] data = new double[parameters.NumLines][];
        Random random = new Random();

        await Task.WhenAll(
            Enumerable.Range(0, parameters.NumLines).Select(async sim =>
            {
                double[] prices = new double[parameters.NumDays];
                prices[0] = parameters.InitialPrice;

                for (int i = 1; i < parameters.NumDays; i++)
                {
                    double u1 = 1.0 - random.NextDouble();
                    double u2 = 1.0 - random.NextDouble();
                    double z = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Cos(2.0 * Math.PI * u2);

                    double dailyReturn = parameters.Mean + parameters.Sigma * z;

                    prices[i] = prices[i - 1] * Math.Exp(dailyReturn);
                }

                data[sim] = prices;
            }));

        return data;
    }
}
