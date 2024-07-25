//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

namespace ManageMe.Core.Api.Brokers.DateTimes
{
    public interface IDateTimeBroker
    {
        DateTimeOffset GetCurrnetDateTimeOffset();
    }
}