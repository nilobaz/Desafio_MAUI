namespace CadastroClientesMaui.Models;

public class Cliente
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string Address { get; set; }

    public string FullName => $"{Name} {LastName}";

    public Cliente(string name, string lastName, int age, string address)
    {
        Id = new Guid();
        Name = name;
        LastName = lastName;
        Age = age;
        Address = address;
    }
}
