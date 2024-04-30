namespace CadastroClientesMaui.Services;

public class ClientService : IClientService
{
    private const string ClientsKey = "Clients";

    public async Task<IEnumerable<Cliente>> GetClientsAsync()
    {
        try
        {
            var json = await SecureStorage.GetAsync(ClientsKey);
            return json != null 
                ? JsonConvert.DeserializeObject<IEnumerable<Cliente>>(json) 
                : Enumerable.Empty<Cliente>();
        }
        catch (Exception ex)
        {
            return Enumerable.Empty<Cliente>();
        }
    }

    public async Task<Cliente> GetClientAsync(Guid id)
    {
        var clients = await GetClientsAsync();
        return clients.FirstOrDefault(c => c.Id == id);
    }

    public async Task AddClientAsync(Cliente client)
    {
        var clients = (await GetClientsAsync()).ToList();
        clients.Add(client);
        await SaveClientsAsync(clients);
    }

    public async Task UpdateClientAsync(Cliente client)
    {
        var clients = (await GetClientsAsync()).ToList();
        var existingClient = clients.FirstOrDefault(c => c.Id == client.Id);
        if (existingClient != null)
        {
            clients.Remove(existingClient);
            clients.Add(client);
            await SaveClientsAsync(clients);
        }
    }

    public async Task DeleteClientAsync(Guid id)
    {
        var clients = (await GetClientsAsync()).ToList();
        var clientToRemove = clients.FirstOrDefault(c => c.Id == id);
        if (clientToRemove != null)
        {
            clients.Remove(clientToRemove);
            await SaveClientsAsync(clients);
        }
    }

    private async Task SaveClientsAsync(IEnumerable<Cliente> clients)
    {
        var json = JsonConvert.SerializeObject(clients);
        await SecureStorage.SetAsync(ClientsKey, json);
    }
}
