using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{

    public class BusinessLogicLayer
    {
        DataAccessLayer dal = new DataAccessLayer();
        public DataTable GetLogin(string email, string password)
        {
            return dal.GetLogin(email, password);
        }
        public int InsertUsers(User user)
        {
            return dal.InsertUser(user);
        }
        public DataTable GetUser()
        {
            return dal.GetUser();
        }
        public int UpdateUser(User user)
        {
            return dal.UpdateUser(user);
        }
        public DataTable GetRole()
        {
            return dal.GetRole();
        }
        public DataTable GetByRoleID(int roleID)
        {
            return dal.GetByRoleID(roleID);
        }
        public int DeleteUser(User user)
        {
            return dal.DeleteUser(user);
        }
        public int InsertModule(Modules module)
        {
            return dal.InsertModule(module);
        }
        public DataTable GetYear()
        {
            return dal.GetYear();
        }
        public DataTable GetYearByID(int yearId)

        {
            return dal.GetYearByID(yearId);
        }
        public DataTable GetModule()
        {
            return dal.GetModule();
        }
        public int DeleteModule(Modules module)
        {
            return dal.DeleteModule(module);
        }
        public int UpdateModule(Modules module)
        {
            return dal.UpdateModule(module);
        }
        public int InsertProgLang(Programming_Language progLang)
        {
            return dal.InsertLanguage(progLang);
        }
        public int DeleteProgLang(Programming_Language progLang)
        {
            return dal.DeleteLanguage(progLang);
        }
        public int UpdateProgLang(Programming_Language progLang)
        {
            return dal.UpdateLanguage(progLang);
        }
        public DataTable GetProgLang()
        {
            return dal.GetLanguage();
        }
        public DataTable GetLecturerModuleTopic()
        {
            return dal.GetLectureModuleTopic();
        }
        public DataTable GetEmail(string email)
        {
            return dal.GetEmail(email);
        }
        public DataTable GetProgLanguageByID(int progLanguageID)
        {
            return dal.GetProgLanguageByID(progLanguageID);
        }
        public DataTable GetStudent()
        {
            return dal.GetStudent();
        }
        public DataTable GetByStudentID(int studID)
        {
            return dal.GetByStudentID(studID);

        }
        public int InsertError(Error error)
        {
            return dal.InsertError(error);
        }
        public int UpdateError(Error error)
        {
            return dal.UpdateError(error);
        }
        public int DeleteError(Error error)
        {
            return dal.DeleteError(error);
        }
        public DataTable GetError(int userID)
        {
            return dal.GetError(userID);
        }
        public int InsertSolution(Lecturer lecturer)
        {
            return dal.InsertSolution(lecturer);
        }
        public int UpdateSolution(Lecturer lecturer)
        {
            return dal.UpdateSolution(lecturer);
        }
        public int DeleteSolution(Lecturer lecture)
        {
            return dal.DeleteSolution(lecture);
        }
        public DataTable GetSolution()
        {
            return dal.GetSolution();
        }
        public DataTable GetLecturer()
        {
            return dal.GetLecture();
        }
        public DataTable GetByLectureID(int lecturerID)
        {
            return dal.GetByLectureID(lecturerID);
        }
        public int InsertTopic(Topics topics)
        {
            return dal.InsertTopic(topics);
        }
        public int UpdateTopic(Topics topics)
        {
            return dal.UpdateTopic(topics);
        }
        public DataTable GetTopics()
        {
            return dal.GetTopics();
        }
        public DataTable GetByErrorID(int errorID)
        {
            return dal.GetByErrorID(errorID);
        }
        public int DeleteTopic(Topics topics)
        {
            return dal.DeleteTopic(topics);
        }
        public int InsertModuleTopic(ModuleTopic modTopic)
        {
            return dal.InsertModuleTopic(modTopic);
        }
        public int UpdateModuleTopic(ModuleTopic moduleTopic)
        {
            return dal.UpdateModuleTopic(moduleTopic);
        }
        public int DeleteModuleTopic(ModuleTopic moduleTopic)
        {
            return dal.DeleteModuleTopic(moduleTopic);

        }
        public DataTable GetModuleTopic(int userID)
        {
            return dal.GetModuleTopic(userID);

        }
        public DataTable GetByModuleID(int moduleId)
        {

            return dal.GetByModuleID(moduleId);
        }
        public DataTable GetErrorSolu()
        {
            return dal.GetErrorSol();
        }
        public DataTable GetLecturerError()
        {
            return dal.GetLecturerError();
        }
        public DataTable GetLectureModuleTopic()
        {
            return dal.GetLectureModuleTopic();
        }
        public DataTable GetByTopicID(int topicID)
        {
            return dal.GetByTopicID(topicID);
        }
        public int InsertErrorSol(ErrorSolution errorSolution)
        {
            return dal.InsertErrorSolution(errorSolution);
        }
        public int UpdateErrorSol(ErrorSolution errorSolution)
        {
            return dal.UpdateErrorSolution(errorSolution);
        }
        public int DeleteErrorSol(ErrorSolution errorSolution)
        {
            return dal.DeleteErrorSolution(errorSolution);
        }
        public DataTable GetErrorSol()
        {
            return dal.GetErrorSolution();
        }
        public DataTable GetBySolutionID(int solutionID)
        {
            return dal.GetBySolutionID(solutionID);
        }
        public int InsertModuleStudent(ModuleStudent moduleStudent)
        {
            return dal.InsertModuleStudent(moduleStudent);
        }
        public int UpdateModuleStudent(ModuleStudent moduleStudent)
        {
            return dal.UpdateModuleStudent(moduleStudent);
        }
        public int DeleteModuleStudent(ModuleStudent moduleStudent)
        {
            return dal.DeleteModuleStudent(moduleStudent);
        }
        public DataTable GetModuleByStudent(int userID)
        {
            return dal.GetModuleByStudent(userID);
        }
        public DataTable GetModuleStudent()
        {
            return dal.GetModuleStudent();
        }
        public int InsertModuleError(ModuleError moduleError)
        {
            return dal.InsertModuleError(moduleError);
        }
        public int UpdateModuleError(ModuleError moduleError)
        {
            return dal.UpdateModuleError(moduleError);
        }
        public int DeleteModuleError(ModuleError moduleError)
        {
            return dal.DeleteModuleError(moduleError);
        }
        public DataTable GetModuleError()
        {
            return dal.GetModuleError();
        }
        public DataTable GetErrorByModule(int moduleID)
        {
            return dal.GetErrorByModule(moduleID);
        }
        public DataTable GetSolutionError(int moduleID)
        {
            return dal.GetSolutionError(moduleID);
        }
        public DataTable GetRoleID(string roleID)
        {
            return dal.Userforms(roleID);
        }
        public int ChangePassword(ChangePassword changePW)
        {
            return dal.ChangePassword(changePW);
        }
        public DataTable GetAdmin()
        {
            return dal.GetAdmin();
        }
        public DataTable GetByAdminID(int userID)
        {
            return dal.GetAdminByID(userID);
        }
        public DataTable GetStudentDetails(int userID)
        {
            return dal.GetStudentDetails(userID);
        }
        public DataTable GetByUserID(int userID)
        {
            return dal.GetByUserID(userID);
        }
        public DataTable SearchUser()
        {
            return dal.SearchUser();
        }
        public DataTable GetSolutionDate(SolutionDate solutionDate)
        {

            return dal.GetSolutionDate(solutionDate);

        }
        public DataTable GetTopicByModule(int moduleID)
        {
            return dal.GetTopicByModule(moduleID);
        }
        public DataTable GetErrorByProgLanguage(int proglanguageID)
        {
            return dal.GetErrorByProgLanguage(proglanguageID);
        }
        public DataTable GetErrorByTopic(int topicID)
        {
            return dal.GetErrorByTopic(topicID);
        }
        public DataTable GetErrorStatus(int userID)
        {
            return dal.GetErrorStatus(userID);

        }
        public DataTable ErrorStatus(int errorID)
        {
            return dal.ErrorStatus(errorID);

        }
        public DataTable GetStudentByYear(int yearID)
        {
            return dal.GetStudentByYear(yearID);
        }
        public DataTable GetInActive()
        {

            return dal.GetInAcive();
        }
        public DataTable GetStatus()
        {
            return dal.GetUserStatus();
        }
        public DataTable GetUserByStatus(int status)
        {
            return dal.GetUserByStatus(status);
        }
        public DataTable GetLecturerSolution()
        {
            return dal.GetLecturerSolution();
        }
        public int UpdateTopics(Topics topic)
        {
            return dal.UpdateTopics(topic);
        }
      
    }
}
