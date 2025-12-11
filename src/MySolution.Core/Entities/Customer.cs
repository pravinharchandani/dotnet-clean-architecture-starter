namespace MySolution.Core.Entities;
public class Customer
{
    public System.Guid Id { get; private set; } = System.Guid.NewGuid();
    public string Name { get; private set; }
    public Customer(string name) => Name = name;
}
