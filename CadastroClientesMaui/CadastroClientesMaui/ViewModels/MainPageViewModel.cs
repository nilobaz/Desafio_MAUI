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
        //ir para pagina de adição de cliente
        var secondWindow = new Window
        {
            Page = new ClientPage(new ClientViewModel()),
        };

        Application.Current.OpenWindow(secondWindow);
    }

    [RelayCommand]
    private void EditClient(Cliente Client)
    {
        //abrir pagina de edição de cliente
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
            //Clientes.Remove(Client);
        }
    }
}
