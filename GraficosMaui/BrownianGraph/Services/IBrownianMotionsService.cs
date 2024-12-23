namespace BrownianGraph.Services;

public interface IBrownianMotionsService
{
    Task<double[][]> GenerateMultipleBrownianMotionsAsync(BrownianMotionsParams parameters);
}
