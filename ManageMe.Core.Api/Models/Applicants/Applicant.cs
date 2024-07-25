//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

namespace ManageMe.Core.Api.Models.Applicants
{
    public class Applicant
    {
        public Guid ApplicantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string GroupName { get; set; }
        public Guid GroupId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}
