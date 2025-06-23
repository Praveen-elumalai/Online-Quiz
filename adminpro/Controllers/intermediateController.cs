using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using adminpro.Models;
using System.Web.Security;


namespace adminpro.Controllers
{
    public class intermediateController : Controller
    {
        //
        // GET: /intermediate/

        public ActionResult adminpanel()
        {


            return View();
        }
        public ActionResult login(FormCollection get)
        {

            string mail = get["mail"];
            string password = get["password"];
            promodal obj = new promodal();
            entity enti = obj.getdata(mail, password);
            if (enti.Email == mail && enti.Password == password)
            {

                FormsAuthentication.SetAuthCookie(enti.Username.ToString(), false);
                Session["Username"] = enti.Username;
                return RedirectToAction("welcomeview");

            }

            else
            {

                ViewBag.Message = "Invalid username";
                return View("adminpanel");
            }



        }

        public ActionResult welcomeview()
        {

            return View();


        }
        public ActionResult Logout()
        {
            Session["Username"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("adminpanel");
        }

        public ActionResult post(FormCollection get)
        {
            string subject = get["subjectname"];
            promodal obj = new promodal();
            obj.subjectinfo(subject);
            return RedirectToAction("subjectpanel");

        }
        public ActionResult subjectpanel()
        {
            promodal obj = new promodal();
            List<subject_info> list = obj.webgrid();
            return View(list);
        }
        public ActionResult question_panel()
        {
            promodal obj = new promodal();
            List<subject_info> list = new List<subject_info>();
            list = obj.getsubject();
            ViewBag.data = new SelectList(list, "subject_id", "subject_name");

            return View(list);
        }

        public ActionResult add(FormCollection get)
        {
            questionwithoptions enti = new questionwithoptions();

            enti.SubjectId = int.Parse(get["subject"]);
            enti.QuestionText = get["questions"];
            enti.Option1 = get["option1"];
            enti.Option1Text = get["opttext"];
            enti.IsCorrect1 = bool.Parse(get["iscorrect"]);
            enti.Option2 = get["option2"];
            enti.Option2Text = get["opttext1"];
            enti.IsCorrect2 = bool.Parse(get["iscorrect1"]);
            enti.Option3 = get["option3"];
            enti.Option3Text = get["opttext2"];
            enti.IsCorrect3 = bool.Parse(get["iscorrect2"]);
            enti.Option4 = get["option4"];
            enti.Option4Text = get["opttext3"];
            enti.IsCorrect4 = bool.Parse(get["iscorrect3"]);

            promodal obj = new promodal();
            obj.question_insert(enti);

            return RedirectToAction("question_panel");


        }


        public ActionResult View_question(int? SubjectId)
        {
            promodal obj = new promodal();
            List<subject_info> subjectList = obj.getsubject();
            List<questionwithoptions> questions = obj.view_question(SubjectId);
            ViewBag.subjectList = new SelectList(subjectList, "subject_id", "subject_name");
            return View(questions);
        }


        public ActionResult Delete(int id)
        {
            promodal obj = new promodal();
            questionwithoptions enti = obj.Delete(id);
            return RedirectToAction("View_question");

        }
        public ActionResult Quizz()
        {

            return View();
        }


        public ActionResult savequiz(FormCollection Add)
        {
            string quizz = Add["quiz"];
            string duration = Add["duration"];
            string count = Add["count"];

            promodal obj = new promodal();
            obj.SaveQuiz(quizz, duration, count);
            return RedirectToAction("Quizz");



        }


        public ActionResult ViewQuizz()
        {
            promodal obj = new promodal();
            List<QuizzView> list = new List<QuizzView>();                    
            list = obj.View_quizz();
            return View(list);
        }

        public ActionResult AddQuestions(int quizId)
        {
            promodal obj = new promodal();
            List<subject_info> list = obj.getsubject();
            ViewBag.data = new SelectList(list, "subject_id", "subject_name");

             
            return View("question_panel");
        }






        //public ActionResult Quizz(int? SubjectId)
        //{
        //   promodal obj = new promodal();
        //   List<subject_info> list = obj.getsubject();
        //   List<questionwithoptions> quest = obj.view_question(SubjectId);
        //   ViewBag.subjectList = new SelectList(list, "subject_id", "subject_name");
        //   return View(quest);
        //}

                                   
        //public ActionResult SaveQuiz(string quiz,int? SubjectId, int[] SelectedQuestions)
        //{
        //    if (SelectedQuestions != null && SelectedQuestions.Length > 0)
        //    {
        //        promodal obj = new promodal();
        //        obj.SaveQuizData(quiz, SubjectId, SelectedQuestions);
        //    }

        //    return RedirectToAction("Quizz", new { SubjectId = SubjectId });
        //}
    }
}
