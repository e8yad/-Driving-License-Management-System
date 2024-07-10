
using PersonsData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Utility;

namespace Users
{
    public class clsUser
    {
        enum enMode { AddNew, Update }
        enMode Mode;
        public long UserID { get; private set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public long PersonID { get; set; }
        public int Permissions { get; set; }
        private delegate bool Update_AddDelegate();
        private Dictionary<enMode, Update_AddDelegate> onMode = new Dictionary<enMode, Update_AddDelegate>();

        private clsUser(long UserID, long PersonID, string UserName, string Password, bool IsActive)
        {
            Mode = enMode.Update;
            this.PersonID = PersonID;
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;
            this.UserID = UserID;
            onMode.Add(Mode, UpdateUser);
        }
        public clsUser()
        {
            Mode = enMode.AddNew;
            this.PersonID = default;
            this.UserName = default;
            this.Password = default;
            this.IsActive = default;
            this.Permissions = 0;
            this.UserID = -1;
            onMode.Add(Mode, AddNewUser);
        }

        public static bool DeleteUser(long UserID)
        {
            return clsUsersData.DeleteUser(UserID);
        }
        public static DataTable GetAllUsers()
        {
            return clsUsersData.GerAllUsers();
        }
        public static bool IsUserExist(long PersonID)
        {
            return clsUsersData.IsUserExist(PersonID);
        }

        public static clsUser FindUserByUserID(long UserID)
        {
            long PersonID = default;
            string UserName = default;
            string Password = default;
            bool IsActive = default;
            int Permissions = 0;
            if (clsUsersData.FindUserByUserID(UserID, ref UserName, ref Password, ref PersonID, ref IsActive, ref Permissions))
            {

                return new clsUser(UserID, PersonID, UserName, Password, Convert.ToBoolean(IsActive));
            }
            else
                return null;


        }

        public static clsUser FindUserByUserName_Password(string UserName, string Password)
        {
            long PersonID = default;
            long UserID = default;
            bool IsActive = default;
            int Permissions = 0;
            string HashedPassword=clsUtil.ComuteHash(Password);
            if (clsUsersData.FindUserByUserName_Password(ref UserID, UserName, HashedPassword, ref IsActive, ref PersonID, ref Permissions))
            {

                return new clsUser(UserID, PersonID, UserName, Password, Convert.ToBoolean(IsActive));
            }
            else
                return null;


        }

        private bool AddNewUser()
        {
            long UserID = default;
            if (IsUserNameExist(UserName))
            {
                this.UserID = -111;
                return false;
            }
            string HasedPassword=clsUtil.ComuteHash(this.Password);
            bool Result = clsUsersData.AddNewUser(ref UserID, UserName, HasedPassword, IsActive, PersonID);
            if (Result) { this.UserID = UserID; }
            return Result;
        }

        /// <summary>
        /// This methode to hash old password as old password not hashed 
        /// </summary>
        [Conditional("DEBUG")]
        private static void UpdateUser(long UserID, string Password,int IsActive)
        {
            string HashedPassword = clsUtil.ComuteHash(Password.TrimEnd());
             clsUsersData.UpdateUser(UserID, HashedPassword, Convert.ToInt32(IsActive));
        }
        private bool UpdateUser()
        {
            string HashedPassword = clsUtil.ComuteHash(this.Password);
            return clsUsersData.UpdateUser(UserID, HashedPassword, Convert.ToInt32(IsActive));
        }

        public bool Save()
        {
            // i need event to tell me is it saved or not 
            if (onMode.ContainsKey(Mode))
            {
                return onMode[Mode]();
            }
            else
                return false;
        }

        public static bool IsPersonRelatedToUser(long PersonID)
        {
            return clsUsersData.IsPersonRelatedToUser(PersonID);
        }

        public static bool IsUserNameExist(string UserName)
        {
            return clsUsersData.IsUserNameExist(UserName);
        }
        /// <summary>
        /// This methode to hash old password as old password not hashed 
        /// </summary>
        [Conditional("DEBUG")]
        public static void UpdateAllUsersPassword()
        {
            DataTable AllUser = clsUsersData.GerAllUsers();
            foreach(DataRow user in AllUser.Rows)
            {
                UpdateUser((long)user["UserID"], (string)user["Password"], Convert.ToInt32( user["IsActive"]));
            }
        }


    }
}
