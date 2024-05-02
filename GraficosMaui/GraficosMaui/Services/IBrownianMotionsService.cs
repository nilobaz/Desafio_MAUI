namespace GraficosMaui.Services;

public interface IBrownianMotionsService
{
    Task<double[][]> GenerateMultipleBrownianMotionsAsync(BrownianMotionsParams parameters);
}
