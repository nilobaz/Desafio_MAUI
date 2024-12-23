namespace GraficosMaui.Services;

public class BrownianMotionsService : IBrownianMotionsService
{
    // Generates multiple Brownian motion simulations asynchronously
    public async Task<double[][]> GenerateMultipleBrownianMotionsAsync(BrownianMotionsParams parameters)
    {
        // Initialize the data array to hold the simulation results
        double[][] data = new double[parameters.NumLines][];
        Random random = new();

        // Run simulations in parallel
        await Task.WhenAll(
            Enumerable.Range(0, parameters.NumLines).Select(async sim =>
            {
                // Initialize the prices array for the current simulation
                double[] prices = new double[parameters.NumDays];
                prices[0] = parameters.InitialPrice;

                // Generate prices for each day
                for (int i = 1; i < parameters.NumDays; i++)
                {
                    // Generate random variables using the Box-Muller transform
                    double u1 = 1.0 - random.NextDouble();
                    double u2 = 1.0 - random.NextDouble();
                    double z = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Cos(2.0 * Math.PI * u2);

                    // Calculate the daily return
                    double dailyReturn = parameters.Mean + parameters.Sigma * z;

                    // Update the price for the current day
                    prices[i] = prices[i - 1] * Math.Exp(dailyReturn);
                }

                // Store the simulation result
                data[sim] = prices;
            }));

        // Return the simulation results
        return data;
    }
}
