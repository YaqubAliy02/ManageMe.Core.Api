//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================


namespace ManageMe.Core.Api.Brokers.DateTimes
{
    public class DateTimeBroker : IDateTimeBroker
    {
        public DateTimeOffset GetCurrnetDateTimeOffset() =>
            DateTimeOffset.UtcNow;
    }
}
