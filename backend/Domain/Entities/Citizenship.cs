using Domain.Entities.Identity;

namespace Domain.Entities;

public class Citizenship {
	public long Id { get; set; }

	public string Name { get; set; } = null!;

	public ICollection<Realtor> Realtors { get; set; } = null!;
}
