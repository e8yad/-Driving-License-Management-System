using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QuizData;

namespace BusinessLayer
{
    public class clsQuiz
    {
        public int QuizID { private set; get; }
        public string QuizDescription { private set; get; }
        public short QuizGrade {  private set; get; }
        

        public clsQuiz(int QuizID)
        {
            // hard coded for now
            this.QuizID = QuizID;
            QuizDescription = "Multiple Choice questions";
            QuizGrade = 10;
        }

        private DataTable _LastQuestionChoices;
        public DataTable GetAllChoicesByQuetionID(long quetionID)
        {
            _LastQuestionChoices= clsQuizData.GetAllChoicesByQuetionID(quetionID);
            return _LastQuestionChoices;
        }
       
        // return is user choced correct answer of last question  depend on question order
        // count from 1;
        public bool IsChoiceCorrect(byte ChoiceOrder)
        {
            // exception
            if (ChoiceOrder <= 0 || ChoiceOrder >_LastQuestionChoices.Rows.Count)
                return false;

            return (bool)_LastQuestionChoices.Rows[ChoiceOrder-1]["IsCorrect"];
        }

        

        public DataTable getAllQuizQuestion()
        {
            return clsQuizData.GetAllQustionByQuizID(QuizID);
        }


       public long SaveResult(long PersonID,long TestID,short PersonGrade)
       {
            long id = default;
            clsQuizData.SaveExameResult(id, PersonID, QuizID, PersonGrade, DateTime.Now.Date,DateTime.Now.TimeOfDay,TestID);
             return id;
       }

        
            
        
                       


    }
}
