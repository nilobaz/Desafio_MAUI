namespace GraficosMaui.Views;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private void OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
    {
       
    }
}
