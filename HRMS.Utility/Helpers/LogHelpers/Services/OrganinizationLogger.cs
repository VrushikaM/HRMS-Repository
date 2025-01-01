using Microsoft.Extensions.Logging;


namespace HRMS.Utility.Helpers.LogHelpers.Services
{
    public class OrganinizationLogger : IOrganizationLogger
    {
        private readonly ILogger _logger;

        public OrganinizationLogger(ILogger<OrganinizationLogger> logger) // Injecting ILogger
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void LogDebug(string message)
        {
            _logger.LogDebug(message);
        }

        public void LogInformation(string message)
        {
            _logger.LogInformation(message);
        }

        public void LogWarning(string message)
        {
            _logger.LogWarning(message);
        }

        public void LogError(Exception ex, string message)
        {
            _logger.LogError(ex, message);
        }

        public void LogFatal(Exception ex, string message)
        {
            _logger.LogCritical(ex, message);  // Critical is used instead of Fatal in this case
        }
    }
}

