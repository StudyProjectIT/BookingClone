namespace Infrastructure.EntityInterfaces;

public interface ITimestamped {
	public DateTime CreatedAtUtc { get; set; }

	public DateTime? UpdatedAtUtc { get; set; }
}
