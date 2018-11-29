using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;

namespace myClassLibrary
{
    public class LdapUser
    {
        public string Domain;
        public string SamAccountName;
        public string UserDn;

        public LdapUser (string domain, string samaccountname)
        {
            Domain = domain;
            SamAccountName = samaccountname;

            var ldapUserAttribs = new List<string>();

            if (GetUserInfo(out ldapUserAttribs, SamAccountName))
                UserDn = ldapUserAttribs.Find(u => u.Contains("distinguishedname")).Replace("distinguishedname = ", "");
        }

            private bool GetUserInfo(out List<string> userInformation, string userName)
        {
            userInformation = new List<string>();
            var valueReturn = false;
            try
            {

                string pathNameDomain = string.Format("LDAP://{0}", Domain);

                var directoryEntry = new DirectoryEntry(pathNameDomain);

                var directorySearcher = new DirectorySearcher(directoryEntry)
                {
                    Filter = "(&(objectClass=user)(sAMAccountName=" + SamAccountName + "))"
                };

                var searchResults = directorySearcher.FindAll();

                valueReturn = searchResults.Count > 0;

                foreach (SearchResult searchResult in searchResults)
                {

                    foreach (var valueCollection in searchResult.Properties.PropertyNames)
                    {
                        userInformation.Add(valueCollection.ToString() + " = " + searchResult.Properties[valueCollection.ToString()][0].ToString());
                    }
                }

                directoryEntry.Dispose();
                directorySearcher.Dispose();
                searchResults.Dispose();
            }
            catch (InvalidOperationException iOe)
            {
            }
            catch (NotSupportedException nSe)
            {
            }
            finally
            {
            }
            return valueReturn;
        }

        // Gets group details for the user
        public List<LdapGroup> GroupDetails()
        {
            var groupMembership = new List<LdapGroup>();

            try
            {

                string pathNameDomain = string.Format("LDAP://{0}", Domain);

                var directoryEntry = new DirectoryEntry(pathNameDomain);

                var directorySearcher = new DirectorySearcher(directoryEntry);
                directorySearcher.Filter = string.Format("(&(objectClass=group)(member:1.2.840.113556.1.4.1941:={0}))", UserDn);
                directorySearcher.PropertiesToLoad.Add("memberof");
                directorySearcher.PropertiesToLoad.Add("member");
                directorySearcher.PropertiesToLoad.Add("name");

                var searchResults = directorySearcher.FindAll();
  
                foreach (SearchResult searchResult in searchResults)
                {
                    var group = new LdapGroup();
                    var _membersList = new List<string>();
                    var _memberOfList = new List<string>();
                    group.GroupDn = searchResult.Properties["ADSPath"][0].ToString().Replace(pathNameDomain, "").Substring(1);
                    group.GroupName = searchResult.Properties["Name"][0].ToString();

                    if (searchResult.Properties["member"].Count > 0)
                        foreach (var _member in searchResult.Properties["member"]) { _membersList.Add(_member.ToString()); }

                    if (searchResult.Properties["memberof"].Count > 0)
                        foreach (var _memberOf in searchResult.Properties["memberof"]) {
                            _memberOfList.Add(_memberOf.ToString());
                        }

                    // SG code...  set
                    group.Members = _membersList.Count > 0 ? _membersList : new List<string>();
                    group.MemberOf = _memberOfList.Count > 0 ? _memberOfList : new List<string>();

                    groupMembership.Add(group);
                }
                

                directoryEntry.Dispose();
                directorySearcher.Dispose();
                searchResults.Dispose();
            }
            catch (InvalidOperationException iOe)
            {
            }
            catch (NotSupportedException nSe)
            {
            }
            finally
            {
            }

            foreach (var _group in groupMembership)
            {
                // Troubleshooting mip09 issue
                if (_group.GroupDn.StartsWith("CN=APP-CTX") == true)
                {
                    var stop = "stop";
                }
                // End troubleshooting mip09 issue

                // Get direct group count
                _group.DirectGroupMembershipCount = _group.MemberOf.Count();
                _group.NestedGroupMembershipCount = GetGroupMembershipCount(groupMembership, _group.GroupDn, true);
            }


            return groupMembership;

        }

        // Gets the group nesting count for a group from a list of groups (obtained from an ldap query).
        // Either direct or recursive (i.e. nested groups) can be returned
        private int GetGroupMembershipCount(List<LdapGroup> LdapGroupList, string GroupDn, bool Recurse)
        {
            // Troubleshooting mip09 issue
            if (GroupDn.StartsWith("CN=APP-CTX") == true)
            {
                var stop = "stop";
            }
            // End troubleshooting mip09 issue

            // try used to support groups nested in remote domains
            // Remote groups assumed to have 0 group nesting
            int _directNestedGroupsCount;
            try { 
                LdapGroup _ldapgroup = LdapGroupList.FirstOrDefault(g => g.GroupDn == GroupDn);
                _directNestedGroupsCount = _ldapgroup.MemberOf.Count();

                if (Recurse == true)
                {
                    foreach (string _groupDn in _ldapgroup.MemberOf)
                        _directNestedGroupsCount += GetGroupMembershipCount(LdapGroupList, _groupDn, true);
                }
            }
            catch
            {
                _directNestedGroupsCount = 0;
            }
            return _directNestedGroupsCount;


        }


        // Returns the groups the ldapUser is directly nested in
        public IEnumerable<LdapGroup> UserDirectGroups (List<LdapGroup> LdapGroupList, string UserDn)
        {
            var _return = LdapGroupList.Where(g => g.Members.Contains(UserDn));
            return _return;
        }

    }


 }

