using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminpro.Models
{
    public class entity
    {
        public int    AdminId {get; set;}
        public string Name  {get; set;}
        public string Email {get; set;}
        public string Username { get; set; }
        public string Password { get; set; }
         
    }


    public class subject_info
    {
        public int subject_id { get; set; }
        public string subject_name { get; set; }

    }
    public class  questionwithoptions
    {
        public int questionid { get; set; }
    public int    SubjectId          { get; set; }
    public string QuestionText       { get; set; }
    public string Option1            { get; set; }
    public string Option1Text        { get; set; }
    public bool   IsCorrect1         { get; set; }
    public string Option2            { get; set; }
    public string Option2Text        { get; set; }
    public bool   IsCorrect2         { get; set; }
    public string Option3            { get; set; }
    public string Option3Text        { get; set; }
    public bool   IsCorrect3         { get; set; }
    public string Option4            { get; set; }
    public string Option4Text        { get; set; }
    public bool   IsCorrect4         { get; set; }
}
    public class QuizzView
    {
        public int QuizId { get; set; }
        public string QuizName { get; set; }
        public string Duration { get; set; }
        public string Questions_Count { get; set; }
    }
   


    }

