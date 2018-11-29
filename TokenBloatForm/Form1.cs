using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using myClassLibrary;
using Newtonsoft.Json;

namespace TokenBloatForm
{
    public partial class formChubbyChecker : Form
    {

        LdapUser ldapUser;
        int alertAt;
        List<LdapGroup> ldapGroupList;
        List<string> sortbyOptions = new List<string>() { "Alphabetical", "Direct Group Count", "Nested Group Count" }; // if updated, update the switch statement lower down

        public formChubbyChecker()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            string domain;
            if (txtDomain.Text.Trim() == string.Empty)
            {
                domain = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName;
            }
            else
            {
                domain = txtDomain.Text.Trim();
            }

            lblStatus.Text = "Running";

            lblGetGroupMembership.Visible = false;
            btnGetGroupMembership.Visible = false;

            if (string.IsNullOrWhiteSpace(txtSamAccountName.Text))
            {
                lblStatus.Text = "Enter a samaccountname squinty bum";
                return;
            }
            else if( ldapUser != null && ldapUser.SamAccountName == lblStatus.Text)
            {
                return;
            }

            try
            {
                ldapUser = new LdapUser(domain, txtSamAccountName.Text);

                if (ldapUser.UserDn == null)
                {
                    lblStatus.Text = string.Format("User with samaccountname {0} not found in domain {1}", txtSamAccountName.Text, domain);
                    return;
                }
                else
                {
                    lblGetGroupMembership.Text = string.Format("User with samaccountname {0} found in domain {1}", txtSamAccountName.Text, domain);
                    lblStatus.Text = string.Format("User {0} found...", txtSamAccountName.Text);
                    lblGetGroupMembership.Visible = true;
                    btnGetGroupMembership.Visible = true;
                    
                }

            }
            catch
            {
                lblStatus.Text = "Something went wrong getting the LDAP user I'm afraid...";
                return;
            }


            // Configure drop down controls
            if (cbSortBy.Items.Count != sortbyOptions.Count)
            {
                foreach (var _option in sortbyOptions)
                {
                    cbSortBy.Items.Add(_option);
                }
                cbSortBy.SelectedIndex = 0;
                lblSortBy.Visible = true;
                cbSortBy.Visible = true;
            }

            if (cbAlertAt.Items.Count != 201)
            {
                for (int i = 0; i < 201; i++)
                {
                    cbAlertAt.Items.Add(i.ToString());
                }
                cbAlertAt.SelectedItem = "0";
                lbAlertAt.Visible = true;
                cbAlertAt.Visible = true;
            }

            chDirectlyNested.Visible = true;

        }

        private void btnGetGroupMembership_Click(object sender, EventArgs e)
        {

            tvGroups.Nodes.Clear();

            alertAt = int.Parse(cbAlertAt.Text) -1 ;

            // Check grouplist doesn't already exist - allows for resorting & running of treenode creation without LDAP query
            if (ldapGroupList == null)
            {
                AutoClosingMessageBox.Show("Running group membership Ldap query. Please be patient this may take some time...\nClick on Ok to run query", "Running Query", 2000);
                //MessageBox.Show("Running group membership Ldap query. Please be patient this may take some time...\nClick on Ok to run query");
                statusBar.Text = "Running query...";
                ldapGroupList = ldapUser.GroupDetails();
            }

            populdateTreeView(ldapUser);

            if (btnDownLoad.Visible == false)
                btnDownLoad.Visible = true;

        }

        private void populdateTreeView(LdapUser _ldapUser)
        {
            var _userDirectlyNestedGroups = ldapGroupList.Where(g => g.Members.Contains(ldapUser.UserDn));

            tvGroups.Nodes.Clear();
            var rootNode = tvGroups.Nodes.Add(_ldapUser.SamAccountName, string.Format("{0} ({1} {2})", _ldapUser.SamAccountName, _userDirectlyNestedGroups.Count(), ldapGroupList.Count()) );

            IEnumerable<LdapGroup> _sortedList = Enumerable.Empty<LdapGroup>();
            //List<string> sortbyOptions = new List<string>() { "Alphabetical", "Direct Group Count", "Nested Group Count" };
            switch (cbSortBy.Text)
            {
                case "Direct Group Count":
                    _sortedList = _userDirectlyNestedGroups.OrderByDescending(c => c.DirectGroupMembershipCount);
                    break;
                case "Nested Group Count":
                    _sortedList = _userDirectlyNestedGroups.OrderByDescending(c => c.NestedGroupMembershipCount);
                    break;
                default:
                    _sortedList = _userDirectlyNestedGroups.OrderBy(c => c.GroupName);
                    break;
            }

            //var _sortedList = _userDirectlyNestedGroups.OrderBy(c => c.GroupName);

            foreach (var _group in _sortedList)
            {

                var _thisNode = rootNode.Nodes.Add(_group.GroupName, string.Format("{0} ({1} {2})", _group.GroupName, _group.DirectGroupMembershipCount, _group.NestedGroupMembershipCount));

                if ((_group.DirectGroupMembershipCount > alertAt || _group.NestedGroupMembershipCount > alertAt) && alertAt != -1)
                {
                    _thisNode.ForeColor = Color.Red;
                }

                if (_group.MemberOf.Count != 0 && chDirectlyNested.Checked == false)
                {
                    RecurseNode(_group, _thisNode);
                }
                
            }

        }

        // Recursively adds treenodes
        private bool RecurseNode(LdapGroup _ldapGroup, TreeNode _parentNode)
        {

            if (_ldapGroup.MemberOf.Count() ==0)
            {
                return true;
            }

            //Get memberof to list<group> so it can be sorted on counts
            List<LdapGroup> _memberofGroupList = new List<LdapGroup>();
            foreach (string _memberof in _ldapGroup.MemberOf.OrderBy(g => g).ToList())
            {
                // try catch used to drop issues with groups not in foreign domains
                try
                {
                    _memberofGroupList.Add(ldapGroupList.Single(g => g.GroupDn == _memberof));
                }
                catch
                {

                }
                
            }

            // Sort list by selected value
            IEnumerable<LdapGroup> _sortedList = Enumerable.Empty<LdapGroup>();
            //List<string> sortbyOptions = new List<string>() { "Alphabetical", "Direct Group Count", "Nested Group Count" };
            switch (cbSortBy.Text)
            {
                case "Direct Group Count":
                    _sortedList = _memberofGroupList.OrderByDescending(c => c.DirectGroupMembershipCount);
                    break;
                case "Nested Group Count":
                    _sortedList = _memberofGroupList.OrderByDescending(c => c.NestedGroupMembershipCount);
                    break;
                default:
                    _sortedList = _memberofGroupList.OrderBy(c => c.GroupName);
                    break;
            }

            foreach (LdapGroup _memberofGroup in _sortedList)
            {

                var _thisNode = _parentNode.Nodes.Add(_memberofGroup.GroupName, string.Format("{0} ({1} {2})", _memberofGroup.GroupName, _memberofGroup.DirectGroupMembershipCount, _memberofGroup.NestedGroupMembershipCount));

                if ((_memberofGroup.DirectGroupMembershipCount > alertAt || _memberofGroup.NestedGroupMembershipCount > alertAt) && alertAt != -1)
                {
                    _thisNode.ForeColor = Color.Red;
                }

                if (_memberofGroup.MemberOf.Count != 0)
                {
                    RecurseNode(_memberofGroup, _thisNode);
                }
            }

            return true;
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnDownLoad_Click(object sender, EventArgs e)
        {
            string _filename = string.Format(@"c:\temp\{0}", ldapUser.SamAccountName);

            // Browse for file
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                _filename = string.Format(@"{0}\{1}.json", folderBrowserDialog1.SelectedPath, ldapUser.SamAccountName);
            }

            myTreeView myTreeView = new myTreeView();
            var jsonSourceList = myTreeView.GetTreeViewToList(tvGroups, ldapGroupList);


            string json = JsonConvert.SerializeObject(jsonSourceList, Formatting.Indented);
            System.IO.File.WriteAllText(_filename, json);
        }

        private void btnImportJsonFile_Click(object sender, EventArgs e)
        {
            // TBC
        }

        private void tvGroups_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
