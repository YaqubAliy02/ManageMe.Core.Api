//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using ManageMe.Core.Api.Models.Applicants;

namespace ManageMe.Core.Api.Models.Groups
{
    public class Group
    {
        public Guid GroupId { get; set; }
        public string GroupName { get; set; }
        public List<Applicant> Applicants { get; set; }
    }
}
