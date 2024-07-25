//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

namespace ManageMe.Core.Api.Brokers.Loggings
{
    public interface ILoggingBroker
    {
        void LogError(Exception exception);
        void LogCritical(Exception exception);
    }
}