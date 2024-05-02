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
        var brownianMotionsParams = new BrownianMotionsParams
        {
            Sigma = Sigma * 0.01,
            Mean = Mean * 0.01,
            InitialPrice = InitialPrice,
            NumDays = NumDays,
            NumLines = NumberLines
        };

        BrownianMotionData = await _brownianMotionsService.GenerateMultipleBrownianMotionsAsync(brownianMotionsParams);
    }
}
