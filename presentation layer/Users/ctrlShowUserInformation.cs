using System.Windows.Forms;
using Users;

using BusinessLayer;

namespace DVLD.Users
{
    public partial class ctrlShowUserInformation : UserControl
    {
        private clsUser _user;
        public long UserID { get; set; }   

        public ctrlShowUserInformation()
        {
            InitializeComponent();
        }

        public void LoadUserInformation(long UserID)
        {

            _user = clsUser.FindUserByUserID(UserID);
            ctrlPersonInformation2.LoadPersonByPersonID(_user.PersonID);

            if (_user == null)
                return;
            UserID=_user.UserID;
            lbUserID.Text = _user.UserID.ToString();
            lbUserName.Text = _user.UserName.ToString();
            if(_user.IsActive ==false) { lbIsActive.Text = "NO";return; }
            lbIsActive.Text = "Yes";
        }






    }
}
