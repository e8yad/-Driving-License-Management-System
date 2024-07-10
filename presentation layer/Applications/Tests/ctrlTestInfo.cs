using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BusinessLayer;


namespace DVLD.Applications.Tests
{

    public partial class ctrlTestInfo : UserControl
    {
        //public event Action<bool, long, long> OnReleaseFinish;

        public bool EnableRetakeTestSection { get { return groupBox2.Enabled; } set { groupBox2.Enabled = value; } }

        public enum enMode {Edit, Add }
        private enMode _Mode=default;
        private clsTests.TestType _testType;
        public clsTests.TestType TestType {

            get
            {
                return _testType;
            }

            set
            {
                _testType = value;
                switch (TestType)
                {
                    case clsTests.TestType.Vision:
                        lbAddress.Text = "Vision Test";
                        break;
                    case clsTests.TestType.Written:
                        lbAddress.Text = "Written Test";
                        break;
                    case clsTests.TestType.Practical:
                        lbAddress.Text = "Practical Test";
                        break;
                    default:
                        break;
                }
            }

            }
        clsLocalDrivingLicenseApplication localDrivingLicenseApplication = null;
        private clsRetakeTestApplication _RetakeTestApplication=null;
        private delegate void ctrlBehaviorDelegate(long LDLAID,long PersonID,DateTime TestDate,long UserID,long RetakeTestAppID);
        private Dictionary<int, ctrlBehaviorDelegate> CtrlActions = new Dictionary<int, ctrlBehaviorDelegate>();
        //private long _RetakeTestApplicationID = default;
        public event Action<bool, long> OnSaveFinish;
  

        public ctrlTestInfo()
        {
            InitializeComponent();
            groupBox2.Enabled = false;
            CtrlActions.Add(1, _SaveVisionTestType);
            CtrlActions.Add(2, _SaveWrittenTestType);
            CtrlActions.Add(3, _SavePracticalTestType);
        }
        //clsRetakeTestApplication RetakeTestApplication /*,enMode Mode*/
 
        public void AddNewTest(clsTests.TestType TestType,long TestID,long LDLAID,bool IsFailBefore)
        {
            this.TestType = TestType;
            _Mode = enMode.Add;

            if (TestID != -1)
                return;
               
            FindLDLA( LDLAID);
            if (localDrivingLicenseApplication == null)
                return;
            lbLDLAID.Text=LDLAID.ToString();
            clsTestType testType = clsTestType.Find((int)TestType);
            lbClass.Text = localDrivingLicenseApplication.LocalDrivingLicenseClass.ClassName;
            lbApplicant.Text = clsPerson.FindByPersonID(localDrivingLicenseApplication.PersonID).FullName;
            lbFees.Text= testType.Fees.ToString();
            dtTestDate.Value = DateTime.Now;
            lbApplicationFees.Text = 0.ToString();
            lbTotalFees.Text = (Convert.ToSingle(lbApplicationFees.Text)+ testType.Fees).ToString();

            if (!IsFailBefore)  
                return;

            _RetestApplication(localDrivingLicenseApplication.PersonID);

            if (_RetakeTestApplication == null)
              return;
          groupBox2.Enabled = true;
          lbApplicationFees.Text=_RetakeTestApplication.ApplicationType.Fees.ToString();
          lbTotalFees.Text = (testType.Fees + _RetakeTestApplication.ApplicationType.Fees).ToString();
        }
        private void _RetestApplication(long PersonID)
        {
            _RetakeTestApplication = new clsRetakeTestApplication(DateTime.Now, clsCurrentUser.CurrentUser.UserID, PersonID);
        }

        public void LoadTestInfo(long TestID)
        {
            _Mode = enMode.Edit;
            groupBox2.Visible = false;
            clsTests Test=clsTests.Find(TestID);
            if (Test == null)
                return;
            if (Test.IsLocked)
                return;
            lbLDLAID.Text = Test.LDLAID.ToString();
            // this is bad solution it take long time in database
            lbClass.Text = clsLocalDrivingLicenseApplication.Find(Test.LDLAID).LocalDrivingLicenseClass.ClassName;
            lbApplicant.Text = clsPerson.FindByPersonID(Test.PersonID).FullName;
            lbFees.Text = Test.Fees.ToString();
            dtTestDate.Value = Test.TestDate;
        }
        public  bool EditTestDate(long TestID)
        {
            bool result = _UpdateTestDate(dtTestDate.Value, TestID );
            OnSaveFinish?.Invoke(result,TestID);
            return result;
        }


       

        void FindLDLA(long LDLAID)
        {
            localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.Find(LDLAID);

        }
        public void Save()
        {

            _SaveRetakeTestApplication();
            if (localDrivingLicenseApplication != null && CtrlActions.ContainsKey((int)TestType))
                CtrlActions[(int)TestType].Invoke(localDrivingLicenseApplication.LDLApplicationID, localDrivingLicenseApplication.PersonID,
                    dtTestDate.Value, clsCurrentUser.CurrentUser.UserID, _RetakeTestApplication!=null?_RetakeTestApplication.ApplicationID : default);
        }
        
        void _SaveVisionTestType(long LDAID,long PersonID,DateTime TestDate,long UserID, long RetakeTestAppID)
        {
            clsVisionTest visionTest = new clsVisionTest(LDAID, PersonID, TestDate, UserID, RetakeTestAppID);
            bool Result = visionTest.AddNewVisionTest();
            if (Result)
                OnSaveFinish?.Invoke(Result, visionTest.TestID);
            else

                OnSaveFinish?.Invoke(Result,-1);
        }
        void _SaveWrittenTestType(long LDAID, long PersonID, DateTime TestDate, long UserID, long RetakeTestAppID)
        {
            clsWrittenTest writtenTest=new clsWrittenTest(LDAID,PersonID, TestDate, UserID, RetakeTestAppID);   

            bool Result = writtenTest.AddNewWrittenTest();
            if (Result)
                OnSaveFinish?.Invoke(Result, writtenTest.TestID);
            else

                OnSaveFinish?.Invoke(Result, -1);
        }

        void _SavePracticalTestType(long LDAID, long PersonID, DateTime TestDate, long UserID, long RetakeTestAppID)
        {
            clsPracticalTest practicalTest=new clsPracticalTest(LDAID, PersonID, TestDate, UserID, RetakeTestAppID);
            bool Result = practicalTest.AddNewPracticalTest();
            if (Result)
                OnSaveFinish?.Invoke(Result, practicalTest.TestID);
            else

                OnSaveFinish?.Invoke(Result, -1);
        }

        private bool _UpdateTestDate(DateTime TestDate,long TestID)
        {
            return clsTests.UpdateTestDate(TestDate, TestID);
        }
        private void _SaveRetakeTestApplication()
        {
            if(_RetakeTestApplication!=null)
            {
                _RetakeTestApplication.RetakeTestApplicationSave();
            }
            return;
        }





    }
}
