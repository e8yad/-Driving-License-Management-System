using System;
using System.IO;
using System.Windows.Forms;
using Utility;
using System.Configuration;
namespace DVLD
{
    public partial class fmLoginScreen : Form
    {
        string _UserName;
        string _Password;
        fmMainForm fm = new fmMainForm();
        ~fmLoginScreen()
        {
            fm.AfterLogOut -= _AfterLogOut;
        }
        public fmLoginScreen()
        {
            InitializeComponent();
            _ReadUserName_PasswordFromRegistry();
             if(!string.IsNullOrEmpty(_UserName))
                    checkBox1.Checked = true;
            if(_UserName!=null&&_Password!=null)
            {
                txtUserName.Text = _UserName;
                txtPassword.Text = _Password;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (clsCurrentUser.Login(txtUserName.Text, txtPassword.Text))
            {
                this.Hide();
                fm.AfterLogOut += _AfterLogOut;
                if (checkBox1.Checked)
                {
                    _SaveIntoRegistry(txtUserName.Text, txtPassword.Text);
                }
                else
                    _SaveIntoRegistry(null, null);
                fm.Show();
            };
        }
        private void _AfterLogOut()
        {
            fm.Hide();
            this.Show();
            clsCurrentUser.CurrentUser=null;
            if(!checkBox1.Checked)
            {
                txtPassword.Text = null;
                txtUserName.Text = null;
            }
            
        }
        void _SaveIntoRegistry(string UserName, string Password)
        {
            if (UserName == null || Password == null)
            {
                return;
            }

            bool r1 = clsUtil.WriteOnRegistryCurrentMachine("Username", UserName);
            string EncrptedPasswore = clsUtil.Encrypt(Password, ConfigurationManager.AppSettings["EncrptionKey"]);
            bool r2 = clsUtil.WriteOnRegistryCurrentMachine("Password", EncrptedPasswore);
            if (!r1 && !r2)
            {
                MessageBox.Show("Can Not Remember your UserName and password");
            }
        }

        void _ReadUserName_PasswordFromRegistry()
        {
            
             _UserName = clsUtil.ReadFromRegistryCurrentMachine("Username") as string;
            string EncyrptiedPassword = clsUtil.ReadFromRegistryCurrentMachine("Password") as string;
             
            if (_UserName == null|| EncyrptiedPassword == null)
            {
                _UserName=string.Empty;
                _Password=string.Empty;
                return;
            }
            _Password = clsUtil.Decrypt(EncyrptiedPassword, ConfigurationManager.AppSettings["EncrptionKey"]);

        }
        void _SaveIntoFile(string UserName, string Password)
        {
            string line = string.Join(@"/#/", UserName, Password);
            // RetakeTestApplicationSave File to .txt
            StreamWriter sw = new StreamWriter("C:\\LastUser.txt");
            sw.WriteLine(line);
            sw.Close();

        }
        void _readFromFile()
        {
      
            StreamReader sr = new StreamReader("C:\\LastUser.txt");
            string line = sr.ReadLine();
            if (line != null)
            {
                string[] sub = line.Split('/', '#', '/');
                _UserName = sub[0];
                _Password = sub[3];
            }
            sr.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
