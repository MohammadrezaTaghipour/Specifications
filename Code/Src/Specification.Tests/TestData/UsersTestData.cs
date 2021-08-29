using System;

namespace Specification.Tests.TestData
{
    public static class UsersTestData
    {
        public static UserInfo Jack => new UserInfo
        {
            UserId = Guid.Parse("90bec152-19f5-4df2-8950-8e252ccbc732")
        };

        public static UserInfo Ferry => new UserInfo
        {
            UserId = Guid.Parse("80bec152-19f5-4df2-8950-8e252ccbc832")
        };
    }

    public class UserInfo
    {
        public Guid UserId { get; set; }
    }

    public static class UserPermission
    {
        public static string[] AdministrationPermissions => new[] { "Admin" };
        public static string[] ReadOnlyPermission => new[] { "Read" };
        public static string[] ModificationPermission => new[] { "Create", "Modify" };
    }
}
