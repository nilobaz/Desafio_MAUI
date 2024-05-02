namespace GraficosMaui.Models;

public class BrownianMotionsParams
{
    public double Sigma { get; set; }
    public double Mean { get; set; }
    public double InitialPrice { get; set; }
    public int NumDays { get; set; }
    public int NumLines { get; set; }
}
