namespace Infrastructure.Interfaces;

public interface IDbInicializer {
	Task InitializeAsync(CancellationToken cancellationToken = default);
}
