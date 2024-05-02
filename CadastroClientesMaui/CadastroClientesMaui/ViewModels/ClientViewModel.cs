namespace CadastroClientesMaui.ViewModels;

public partial class ClientViewModel : ObservableObject
{
    private readonly IClientService _clientService;

    public ClientViewModel(IClientService clientService, Cliente cliente = null)
    {
        _clientService = clientService;
        clienteData = cliente ?? new Cliente();
    }

    public event EventHandler RequestCloseWindow;

    [ObservableProperty]
    private Cliente clienteData;

    [RelayCommand]
    private async Task SaveClient()
    {
        var existingClient = await _clientService.GetClientAsync(clienteData.Id);
        clienteData.FullName = $"{clienteData.Name} {clienteData.LastName}";

        if (existingClient != null)
        {
            await _clientService.UpdateClientAsync(clienteData);
        }
        else
        {
            await _clientService.AddClientAsync(clienteData);
        }

        OnRequestCloseWindow();
    }

    private void OnRequestCloseWindow() => RequestCloseWindow?.Invoke(this, EventArgs.Empty);
}
