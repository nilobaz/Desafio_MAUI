namespace CadastroClientesMaui.Views;

public partial class ClientPage : ContentPage
{
    public ClientPage(ClientViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;

        viewModel.RequestCloseWindow += OnRequestCloseWindow;
    }

    private void OnRequestCloseWindow(object sender, EventArgs e)
    {
        var window = GetParentWindow();
        if (window != null)
        {
            Application.Current.CloseWindow(window);
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        if (BindingContext is ClientViewModel viewModel)
        {
            viewModel.RequestCloseWindow -= OnRequestCloseWindow;
        }

        // TODO
        //var window = GetParentWindow();
        //if (window != null)
        //{
        //    window.Destroying -= mainPageViewModel.NewWindowClosing;
        //}
    }
}