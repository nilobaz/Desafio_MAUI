namespace CadastroClientesMaui.Views;

public partial class MainPage : ContentPage
{

    public  List<Cliente> Clientes { get; set; }

    public MainPage()
    {
        InitializeComponent();

        Clientes = new List<Cliente>
        {
            new Cliente("John", "Doe", 30, "123 Main St, jardim jorge atalla, 17211290, jau SP"),
            new Cliente("Jane", "Doe", 25, "456 Elm St"),
            new Cliente("Sam", "Smith", 40, "789 Oak St")
        };

        collecview.ItemsSource = Clientes;
    }
}
