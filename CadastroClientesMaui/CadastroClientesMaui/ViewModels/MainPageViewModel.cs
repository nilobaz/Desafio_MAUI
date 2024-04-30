namespace CadastroClientesMaui.ViewModels;

public  class MainPageViewModel
{
    public ObservableCollection<Cliente> Clientes { get; set; }

    public MainPageViewModel()
    {
        Clientes = new ObservableCollection<Cliente>
        {
            new Cliente("John", "Doe", 30, "123 Main St"),
            new Cliente("Jane", "Doe", 25, "456 Elm St"),
            new Cliente("Sam", "Smith", 40, "789 Oak St")
        };
    }
}
