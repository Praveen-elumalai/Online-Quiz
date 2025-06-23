using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace adminpro.Models
{
    public class promodal
    {
        public entity getdata(string email, string password)
        { 
            SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["values"].ToString());
            SqlCommand command = new SqlCommand("admin_data", connect);
            command.CommandType = CommandType.StoredProcedure;
            entity enti = new entity();
            connect.Open();
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@password", password);
             SqlDataReader read = command.ExecuteReader();
             while (read.Read())
             {
                 enti.AdminId = int.Parse(read["AdminId"].ToString());
                 enti.Name = read["Name"].ToString();
                 enti.Email = read["Email"].ToString();
                 enti.Username = read["UserName"].ToString();
                 enti.Password = read["Password"].ToString();


             }
             connect.Close();

             return enti;

        }

        public void subjectinfo(string subject)
        {
            SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["values"].ToString());
            SqlCommand command = new SqlCommand("get_subject", connect);
            command.CommandType = CommandType.StoredProcedure;
            connect.Open();
            command.Parameters.AddWithValue("@subject_name", subject);
            command.ExecuteNonQuery();
            connect.Close();
        }
        public List<subject_info> webgrid()
        {
            SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["values"].ToString());
            SqlCommand command = new SqlCommand("sub_webgrid", connect);
            command.CommandType = CommandType.StoredProcedure;
            List<subject_info> list = new List<subject_info>();
            connect.Open();
              SqlDataReader reader = command.ExecuteReader();
              while (reader.Read())
              {
                  subject_info enti = new subject_info();
                  enti.subject_id = int.Parse(reader["subject_id"].ToString());
                  enti.subject_name = reader["subject_name"].ToString();
                  list.Add(enti);
              }
              connect.Close();
              return list;

        }


        public List<subject_info> getsubject()
        {
            SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["values"].ToString());
            SqlCommand command = new SqlCommand("GetSubjects", connect);
            command.CommandType = CommandType.StoredProcedure;
            List<subject_info> list = new List<subject_info>();
            connect.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                subject_info enti = new subject_info();
                enti.subject_id = int.Parse(reader["subject_id"].ToString());
                enti.subject_name = reader["subject_name"].ToString();
                list.Add(enti);
            }
            connect.Close();
            return list;

        }

        public void question_insert(questionwithoptions entity)
        {
            SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["values"].ToString());
            SqlCommand command = new SqlCommand("questionwithoptions", connect);
            command.CommandType = CommandType.StoredProcedure;
            connect.Open();

            command.Parameters.AddWithValue("@QuestionId", entity.questionid);
            command.Parameters.AddWithValue("@SubjectId", entity.SubjectId);
            command.Parameters.AddWithValue("@QuestionText", entity.QuestionText);
            command.Parameters.AddWithValue("@Option1Label",entity.Option1);
            command.Parameters.AddWithValue("@Option1Text",entity.Option1Text);
            command.Parameters.AddWithValue("@IsCorrect1",entity.IsCorrect1);
            command.Parameters.AddWithValue("@Option2Label",entity.Option2);
            command.Parameters.AddWithValue("@Option2Text",entity.Option2Text);
            command.Parameters.AddWithValue("@IsCorrect2",entity.IsCorrect2);
            command.Parameters.AddWithValue("@Option3Label",entity.Option3);
            command.Parameters.AddWithValue("@Option3Text",entity.Option3Text);
            command.Parameters.AddWithValue("@IsCorrect3",entity.IsCorrect3);
            command.Parameters.AddWithValue("@Option4Label",entity.Option4);
            command.Parameters.AddWithValue("@Option4Text",entity.Option4Text);
            command.Parameters.AddWithValue("@IsCorrect4",entity.IsCorrect4);
         }
        public List<questionwithoptions> view_question(int ? SubjectId)
        {

            SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["values"].ToString());
            SqlCommand command = new SqlCommand("subjectwithquestions", connect);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@SubjectId", SubjectId);
            List<questionwithoptions> list = new List<questionwithoptions>();
            connect.Open();
            SqlDataReader reader = command.ExecuteReader(); 
            while (reader.Read())
            {
                
                questionwithoptions enti = new questionwithoptions(); 
                enti.questionid = int.Parse(reader["question_id"].ToString());
                enti.QuestionText = reader["Question_Text"].ToString();
                list.Add(enti);
            }
            connect.Close();
            return list;


        }

        public questionwithoptions Delete(int questionid)
        {
            SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["values"].ToString());
            SqlCommand command = new SqlCommand("delete_question", connect);
            command.CommandType = CommandType.StoredProcedure;
            questionwithoptions enti = new questionwithoptions();
            command.Parameters.AddWithValue("@QuestionId", questionid);
            connect.Open();
            command.ExecuteNonQuery();
            connect.Close();
            return enti;
            
        }

        public void SaveQuiz(string quizz, string duration, string count) 
        {


            SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["values"].ToString());
            SqlCommand command = new SqlCommand("InsertQuizz", connect);
            command.CommandType = CommandType.StoredProcedure;
            connect.Open();
            
            command.Parameters.AddWithValue("@QuizName", quizz);
            command.Parameters.AddWithValue("@Duration", duration);
            command.Parameters.AddWithValue("@Questions_Count", count);
            command.ExecuteNonQuery();
            connect.Close();
        
        
        }

        public List<QuizzView> View_quizz()  
        {
            SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["values"].ToString());
            SqlCommand command = new SqlCommand("View_quizz", connect);
            command.CommandType = CommandType.StoredProcedure;
            List<QuizzView> list = new List<QuizzView>();
            connect.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                QuizzView enti = new QuizzView();
                enti.QuizName = reader["QuizName"].ToString();
                enti.Duration = reader["Duration"].ToString();
                enti.Questions_Count = reader["Questions_Count"].ToString();
                list.Add(enti);
            }
            return list;
           
        }










        //public void SaveQuizData(string quizName, int? SubjectId, int[] selectedQuestionid)
        //{
        //    SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["values"].ToString());
        //    SqlCommand command = new SqlCommand("SaveQuiz", connect);
        //    command.CommandType = CommandType.StoredProcedure;
          
        //    foreach (var questionid in selectedQuestionid)
        //    {
        //        command.Parameters.Clear();
        //        command.Parameters.AddWithValue("@QuizName", quizName);
        //        command.Parameters.AddWithValue("@SubjectId", SubjectId);
        //        command.Parameters.AddWithValue("@Question_id", questionid);

        //        connect.Open();
        //        command.ExecuteNonQuery();
        //        connect.Close();
        //    }
        //}





    }
}