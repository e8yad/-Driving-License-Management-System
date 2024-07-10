using System;
using System.Data;
using System.Windows.Forms;
using BusinessLayer;

namespace DVLD
{
    public partial class fmWrittenTest : Form
    {
        clsQuiz qz;
        private DataTable _QuizQuestions;
        private short _PersonPoints = 0;
        private short _CurrentQuestion = 0;
        clsTests test;
        
        
        public fmWrittenTest(long TestID)
        {
       
            qz = new clsQuiz(1);
            InitializeComponent();
            lbCurrntQustion.Text = "1";
            _QuizQuestions =qz.getAllQuizQuestion();
            test = clsTests.Find(TestID);
            if(test==null)
            {
               MessageBox.Show( "Error in test id ","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.Close();
            }
        }
        private void _showNextQustion()
        {

           
            
            if (_CurrentQuestion < _QuizQuestions.Rows.Count)
            {
                lbQuestionDescription.Text = (string)_QuizQuestions.Rows[_CurrentQuestion]["Description"];
                DataTable Choices = qz.GetAllChoicesByQuetionID((long)_QuizQuestions.Rows[_CurrentQuestion]["id"]);
                if (Choices.Rows.Count < 4)
                {
                    MessageBox.Show("Error In loading Choices");
                   this.Close();
                }
                rdA.Text = (string)Choices.Rows[0]["DES"];
                rdB.Text = (string)Choices.Rows[1]["DES"];
                rdC.Text = (string)Choices.Rows[2]["DES"];
                rdD.Text = (string)Choices.Rows[3]["DES"];
               
            }
        }
        private void _CalculatePoint()

        {
            if(rdA.Checked)
            {
                _PersonPoints += qz.IsChoiceCorrect(Convert.ToByte(rdA.Tag)) ? Convert.ToInt16(_QuizQuestions.Rows[_CurrentQuestion]["Points"]) :(short)0;
                rdA.Checked = false;
          
            }
           else if (rdB.Checked)
            {
                _PersonPoints += qz.IsChoiceCorrect(Convert.ToByte(rdB.Tag)) ? Convert.ToInt16(_QuizQuestions.Rows[_CurrentQuestion]["Points"]) : (short)0;
                rdB.Checked = false;
               

            }
          else  if (rdC.Checked)
            {
                _PersonPoints += qz.IsChoiceCorrect(Convert.ToByte(rdC.Tag)) ? Convert.ToInt16(_QuizQuestions.Rows[_CurrentQuestion]["Points"]) : (short)0;
                rdC.Checked= false;
                

            }
           else if (rdD.Checked)
            {
                _PersonPoints += qz.IsChoiceCorrect(Convert.ToByte(rdD.Tag)) ? Convert.ToInt16(_QuizQuestions.Rows[_CurrentQuestion]["Points"]) : (short)0;
                rdD.Checked = false;
               


            }
            else
            {
                _PersonPoints += 0;
            }
            _CurrentQuestion++;
            _showNextQustion();
           

            if (_CurrentQuestion == _QuizQuestions.Rows.Count )
            {

                MessageBox.Show($"Result :{_PersonPoints} / {qz.QuizGrade}");
                btnNext_Submit.Enabled = false;
                qz.SaveResult(test.PersonID, test.TestID, _PersonPoints);
                return;

            }
            lbCurrntQustion.Text = (_CurrentQuestion + 1).ToString();
        }

        private void fmTest_Load(object sender, EventArgs e)
        {
            if(_QuizQuestions.Rows.Count<=0 )
            {
                MessageBox.Show("There is an error in connection ","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            lbTotalNumberOfQuestion.Text = _QuizQuestions.Rows.Count.ToString();
            _showNextQustion();
        }

        private void btnNext_Submit_Click(object sender, EventArgs e)
        {
            _CalculatePoint();
           

            if (_CurrentQuestion ==_QuizQuestions.Rows.Count-1)
            {

                btnNext_Submit.Text = "Submit";
       
            }
            return;
        }

       // add log for every qeution 

    }
}
