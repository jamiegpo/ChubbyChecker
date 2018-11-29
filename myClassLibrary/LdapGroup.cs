using System.Collections.Generic;

namespace myClassLibrary
{

    public class LdapGroup
    {
        public string GroupName { get; set; }
        public string GroupDn { get; set; }
        public List<string> MemberOf { get; set; }
        public List<string> Members { get; set; }
        public int DirectGroupMembershipCount { get; set; }
        public int NestedGroupMembershipCount { get; set; }

    }

}

