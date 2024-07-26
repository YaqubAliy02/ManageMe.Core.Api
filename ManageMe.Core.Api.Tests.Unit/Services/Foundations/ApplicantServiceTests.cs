//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using System.Linq.Expressions;
using System.Runtime.Serialization;
using ManageMe.Core.Api.Brokers.DateTimes;
using ManageMe.Core.Api.Brokers.Loggings;
using ManageMe.Core.Api.Brokers.Storages;
using ManageMe.Core.Api.Models.Applicants;
using ManageMe.Core.Api.Services.Foundations.Applicants;
using Microsoft.Data.SqlClient;
using Moq;
using Tynamix.ObjectFiller;
using Xeptions;

namespace ManageMe.Core.Api.Tests.Unit.Services.Foundations
{
    public partial class ApplicantServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
        private readonly IApplicantService applicantService;

        public ApplicantServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();
            this.dateTimeBrokerMock = new Mock<IDateTimeBroker>();

            this.applicantService = new ApplicantService(
               storageBroker: this.storageBrokerMock.Object,
               loggingBroker: this.loggingBrokerMock.Object,
               dateTimeBroker: this.dateTimeBrokerMock.Object
                );
        }

        private Expression<Func<Xeption, bool>> SameExceptionAs(Xeption expectedException) =>
            actualException => actualException.SameExceptionAs(expectedException);

        private Applicant CreateRandomApplicant() =>
            CreateApplicantFiller(GetRandomDateTime()).Create();

        private static DateTimeOffset GetRandomDateTime() =>
            new DateTimeRange(earliestDate: DateTime.UnixEpoch).GetValue();

        private static SqlException GetSqlError() =>
            (SqlException)FormatterServices.GetUninitializedObject(typeof(SqlException));

        private static Filler<Applicant> CreateApplicantFiller(DateTimeOffset dates)
        {
            var filler = new Filler<Applicant>();

            filler.Setup()
                .OnType<DateTimeOffset>().Use(dates);

            return filler;
        }   
    }
}
