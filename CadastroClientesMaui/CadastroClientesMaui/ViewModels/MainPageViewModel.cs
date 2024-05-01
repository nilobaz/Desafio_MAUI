namespace CadastroClientesMaui.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
    private IClientService _clientService;

    public MainPageViewModel(IClientService clientService)
    {
        Clientes = new ObservableCollection<Cliente>();

        Clientes.Add(new Cliente("John", "Doe", 30, "123 Main St, jardim jorge atalla, 17211290, jau SP"));
        Clientes.Add(new Cliente("Jane", "Doe", 25, "456 Elm St"));
        Clientes.Add(new Cliente("Sam", "Smith", 40, "789 Oak St"));
        _clientService = clientService;
    }

    [ObservableProperty]
    private ObservableCollection<Cliente> clientes;

    [RelayCommand]
    private void AddClient()
    {
        var newWindow = new Window
        {
            Page = new ClientPage(new ClientViewModel())
        };

        CenterWindow(newWindow);

        Application.Current.OpenWindow(newWindow);
    }

    [RelayCommand]
    private void EditClient(Cliente Client)
    {
        // enviar o cliente para a pagina de edição
        var newWindow = new Window
        {
            Page = new ClientPage(new ClientViewModel())
        };

        CenterWindow(newWindow);

        Application.Current.OpenWindow(newWindow);
    }

    [RelayCommand]
    private async void RemoveClient(Cliente Client)
    {
        bool result = await Shell.Current.DisplayAlert(
            "Remover", 
            $"Deseja mesmo remover o cliente {Client.FullName}?",
            "Sim", 
            "Não" );

        if (result)
        {
            await _clientService.DeleteClientAsync(Client.Id);
        }
    }
    
    private async void LoadClients()
    {
        var clients = await _clientService.GetClientsAsync();
        Clientes.Clear();
        foreach (var client in clients)
        {
            Clientes.Add(client);
        }
    }

    private void CenterWindow(Window window)
    {
        var displayInfo = DeviceDisplay.Current.MainDisplayInfo;
        window.X = (displayInfo.Width / displayInfo.Density - window.Width) / 2;
        window.Y = (displayInfo.Height / displayInfo.Density - window.Height) / 2;
    }
}
