namespace CadastroClientesMaui.Services;

public interface IClientService
{
    Task<IEnumerable<Cliente>> GetClientsAsync();
    Task<Cliente> GetClientAsync(Guid id);
    Task AddClientAsync(Cliente client);
    Task UpdateClientAsync(Cliente client);
    Task DeleteClientAsync(Guid id);

}
