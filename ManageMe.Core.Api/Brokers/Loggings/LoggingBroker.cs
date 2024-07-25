//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

namespace ManageMe.Core.Api.Brokers.Loggings
{
    public class LoggingBroker : ILoggingBroker
    {
        private readonly ILogger<LoggingBroker> loggingBroker;

        public LoggingBroker(ILogger<LoggingBroker> loggingBroker)
        {
            this.loggingBroker = loggingBroker;
        }

        public void LogCritical(Exception exception) =>
            this.loggingBroker.LogCritical(exception.Message);

        public void LogError(Exception exception) =>
            this.loggingBroker.LogError(exception.Message);
    }
}
