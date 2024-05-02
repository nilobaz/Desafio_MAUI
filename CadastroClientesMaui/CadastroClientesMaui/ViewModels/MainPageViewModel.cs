namespace CadastroClientesMaui.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    private IClientService _clientService;

    public MainPageViewModel(IClientService clientService)
    {
        Clientes = new ObservableCollection<Cliente>();
        _clientService = clientService;

        LoadClients();
    }

    [ObservableProperty]
    private ObservableCollection<Cliente> clientes;

    [RelayCommand]
    private void AddClient()
    {
        var newWindow = new Window
        {
            Page = new ClientPage(new ClientViewModel(_clientService))
        };

        newWindow.Destroying += NewWindowClosing;

        CenterWindow(newWindow);
        Application.Current.OpenWindow(newWindow);
    }

    [RelayCommand]
    private void EditClient(Cliente Client)
    {
        var newWindow = new Window
        {
            Page = new ClientPage(new ClientViewModel(_clientService, Client))
        };

        newWindow.Destroying += NewWindowClosing;

        CenterWindow(newWindow);
        Application.Current.OpenWindow(newWindow);
    }

    [RelayCommand]
    private async Task RemoveClient(Cliente Client)
    {
        bool result = await Shell.Current.DisplayAlert(
            "Remover", 
            $"Deseja mesmo remover o cliente {Client.FullName}?",
            "Sim", 
            "Não" );

        if (result)
        {
            await _clientService.DeleteClientAsync(Client.Id);
            await LoadClients();
        }
    }

    private void CenterWindow(Window window)
    {
        var displayInfo = DeviceDisplay.Current.MainDisplayInfo;
        window.X = (displayInfo.Width / displayInfo.Density - window.Width) / 2;
        window.Y = (displayInfo.Height / displayInfo.Density - window.Height) / 2;
    }

    private async Task LoadClients()
    {
        var clients = await _clientService.GetClientsAsync();
        Clientes.Clear();

        foreach (var client in clients)
        {
            Clientes.Add(client);
        }
    }

    private async void NewWindowClosing(object? sender, EventArgs e) => await LoadClients();
}
