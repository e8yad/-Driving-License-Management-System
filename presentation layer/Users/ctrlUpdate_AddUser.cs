using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using BusinessLayer;
using Users;


using System.Windows.Forms;

namespace DVLD.Users
{
    public partial class ctrlUpdate_AddUser : UserControl
    {
        // if new user UserID=-1;
        clsUser _User;

       enum enMode { AddNew,Update}
        enMode _Mode= enMode.AddNew;


        public delegate void OnSaveFinish(bool result, long UserID);
        public event OnSaveFinish SaveResult;
        private long _PersonID;
        public long PersonID {
            get {
                return _PersonID;
                  }
            set 
            { 
                _PersonID = value; 
                lbPersonID.Text = _PersonID.ToString(); 
            } 
        }

        public ctrlUpdate_AddUser()
        {
            _User = new clsUser();
            InitializeComponent();
            _LoadImage();
            PersonID = -1;
        }


        public void LoadUserInformation(long UserID)
        {
    
            if (UserID == -1) 
            {  
                return;
            }
             _Mode = enMode.Update;
            lbTitle.Text = "Update User";
            txtUserName.ReadOnly = true;
            _User = clsUser.FindUserByUserID(UserID);
            txtUserName.Text= _User.UserName;
            lbUserID.Text=_User.UserID.ToString();
            lbPersonID.Text= _User.PersonID.ToString();
            chkIsActive.Checked = _User.IsActive;
            PersonID=_User.PersonID;
        }
        private bool _CheckDataInput()
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "This Can Not Be Empty");
                return false;
            }
            else if (string.IsNullOrEmpty(txtUserName.Text))
            {
                errorProvider1.SetError(txtUserName, "This Can Not Be Empty");
                return false;
            }
            else if (string.IsNullOrEmpty(txtRewritePassword.Text))
            {
                errorProvider1.SetError(txtRewritePassword, "This Can Not Be Empty");
                return false;

            }
            else if (txtRewritePassword.Text != txtPassword.Text)
            {
                MessageBox.Show("Passwords are not Identical!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            return true;

        }
        private bool IsPersonNotRelatedToUser()
        {
            if(clsUser.IsPersonRelatedToUser(Convert.ToInt64(lbPersonID.Text)))
            {
                MessageBox.Show("This Person Has Exist User","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

                return false;
            }
            return true;
        }

        public void Save()
        {
            if (_Mode == enMode.AddNew)
            {
               
                //_User.PersonID = long.Parse(lbPersonID.Text);
                if(PersonID!=-1)
                _User.PersonID=PersonID;
                if (!IsPersonNotRelatedToUser())
                    return;
            }
           

            if (!_CheckDataInput())
                 return;
            _User.UserName = txtUserName.Text;
            _User.Password = txtPassword.Text;
            _User.IsActive = chkIsActive.Checked;
            bool result= _User.Save();
            SaveResult?.Invoke(result, _User.UserID);
            if(result)
                lbUserID.Text = _User.UserID.ToString();
        }
        private void _LoadImage()
        {
            PicCheck.Image = imageList1.Images[2];
            PicPassword1.Image = imageList1.Images[1];
            PicPasswrod2.Image = imageList1.Images[1];
            PicUserName.Image = imageList1.Images[0];
        }
   

        private void txtRewritePassword_Leave(object sender, EventArgs e)
        {
            if(txtPassword.Text!=txtRewritePassword.Text)
            {
                errorProvider1.SetError(txtRewritePassword, "Passwords Are Not Identical ");
                SaveResult?.Invoke(false, -1);

            }
        }
    }
}
