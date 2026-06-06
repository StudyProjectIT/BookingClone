using Application.Common.Mappings;
using Domain.Entities;

namespace Application.MediatR.BankCards.Queries.Shared;

public class BankCardVm : IMapWith<BankCard> {
	public long Id { get; set; }

	public string Number { get; set; } = null!;

	public DateOnly ExpirationDate { get; set; }

	public string Cvv { get; set; } = null!;

	public string OwnerFullName { get; set; } = null!;
}
