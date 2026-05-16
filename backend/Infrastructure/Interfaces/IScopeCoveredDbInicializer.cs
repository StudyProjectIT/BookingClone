namespace Infrastructure.Interfaces;

public interface IScopeCoveredDbInicializer {
	Task InitializeAsync(CancellationToken cancellationToken = default);
}
