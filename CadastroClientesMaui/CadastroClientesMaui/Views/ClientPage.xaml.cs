namespace CadastroClientesMaui.Views;

public partial class ClientPage : ContentPage
{
    public ClientPage(ClientViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}