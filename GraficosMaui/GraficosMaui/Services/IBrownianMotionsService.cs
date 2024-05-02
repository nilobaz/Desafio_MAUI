namespace GraficosMaui.Services;

public interface IBrownianMotionsService
{
    Task<double[][]> GenerateMultipleBrownianMotionsAsync(double sigma, double mean, double initialPrice, int numDays, int numLines);
}
