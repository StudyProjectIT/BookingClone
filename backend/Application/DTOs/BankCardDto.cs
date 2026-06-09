namespace Application.DTOs;

public class BankCardDto
{
    public long Id { get; set; }
    public string Number { get; set; } = string.Empty;
    public DateOnly ExpirationDate { get; set; }
    public string OwnerFullName { get; set; } = string.Empty;
    public long? CustomerId { get; set; }
}
