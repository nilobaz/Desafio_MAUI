namespace CadastroClientesMaui.Models;

public class Cliente
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string Address { get; set; }

    public string FullName { get; set; }

    public Cliente(string name, string lastName, int age, string address)
    {
        Id = Guid.NewGuid();
        Name = name;
        LastName = lastName;
        Age = age;
        Address = address;
        FullName = $"{Name} {LastName}";
    }

    public Cliente()
    {
        Id = Guid.NewGuid();
    }
}
