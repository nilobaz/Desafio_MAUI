namespace GraficosMaui.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    private readonly IBrownianMotionsService _brownianMotionsService;

    public MainPageViewModel(IBrownianMotionsService brownianMotionsService) 
    {
        _brownianMotionsService = brownianMotionsService;
    }

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

        BrownianMotionData = await _brownianMotionsService.GenerateMultipleBrownianMotionsAsync(
            convertedSigma, 
            convertedMean, 
            InitialPrice, 
            NumDays, 
            NumberLines);
    }
}
