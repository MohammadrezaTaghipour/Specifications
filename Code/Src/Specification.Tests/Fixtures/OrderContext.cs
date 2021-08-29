using System;
using System.Linq;

namespace Specification.Tests.Fixtures
{
    public class OrderContext
    {
        public Guid OrderIssuedBy { get; set; }
        public Guid CurrentUserId { get; set; }
        public string[] CurrentUserPermission { get; set; }
        public bool IsAdminUser => CurrentUserPermission.Any(a => a == "Admin");
    }
}
 