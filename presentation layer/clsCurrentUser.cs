using System.Windows.Forms;
using Users;
using BusinessLayer;


namespace DVLD
{
    public static class clsCurrentUser
    {
        public static clsUser CurrentUser;
        private static void GetUser(string UserName,string Password)
        {
            CurrentUser=clsUser.FindUserByUserName_Password(UserName, Password);

        }

        public static bool Login(string UserName, string Password)
        {
            GetUser(UserName, Password);
            if (CurrentUser!=null)
            {
                if (!CurrentUser.IsActive)
                {
                        MessageBox.Show("This User Is Not Active");
                    return false; 
                }
                else 
                    return true;
               
            }
            else
            {
                MessageBox.Show("Check Username Or Password");
                return false;
            }
        }

        //internal static void Logout()
        //{
        //  CurrentUser=null;
           
        //}
    }
}
