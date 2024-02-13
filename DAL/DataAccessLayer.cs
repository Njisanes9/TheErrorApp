using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class DataAccessLayer
    {
        static string connString = "Data Source=localhost;Initial Catalog= ErrorsApplicationDB ;Integrated Security=True;";
        SqlConnection dbConn = new SqlConnection(connString);
        SqlDataAdapter dbAdapter;
        DataTable dt;
        SqlCommand dbComm;
        DataSet ds;
        User user = new User();
        Modules module = new Modules();

        public DataTable GetLogin(string email, string password)
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_Login", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;


            dbComm.Parameters.AddWithValue("@Email", email);
            dbComm.Parameters.AddWithValue("@Password", password);
            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbConn.Close();
            return dt;
        }
        public DataTable Userforms(string roleID)
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_GetUserID", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            //dbComm.Parameters.AddWithValue("@Email", email);
            //dbComm.Parameters.AddWithValue("@Password", password);
            dbComm.Parameters.AddWithValue("@RoleID", roleID);
            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbConn.Close();
            return dt;
        }
        public int InsertUser(User user)
        {
            try
            {
                dbConn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_InsertUser", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@Username", user.Username);
            dbComm.Parameters.AddWithValue("@Surname", user.Surname);
            dbComm.Parameters.AddWithValue("@Email", user.Email);
            dbComm.Parameters.AddWithValue("@Password", user.Password);
            dbComm.Parameters.AddWithValue("@RoleID", user.RoleID);
            dbComm.Parameters.AddWithValue("@UserStatus", user.UserStatus);

            int x = dbComm.ExecuteNonQuery();
            dbConn.Close();
            return x;
        }
        public int UpdateUser(User user)
        {
            try
            {
                dbConn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_UpdateUser", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@Username", user.Username);
            dbComm.Parameters.AddWithValue("@Surname", user.Surname);
            dbComm.Parameters.AddWithValue("@Email", user.Email);
            dbComm.Parameters.AddWithValue("@Password", user.Password);
            dbComm.Parameters.AddWithValue("@UserStatus", user.UserStatus);
            dbComm.Parameters.AddWithValue("@UserID", user.UserID);


            int x = dbComm.ExecuteNonQuery();
            dbConn.Close();
            return x;
        }
        public int DeleteUser(User user)
        {
            try
            {
                dbConn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_DeleteUser", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@UserID", user.UserID);
            int x = dbComm.ExecuteNonQuery();
            return x;
        }
        public DataTable GetUser()
        {
            try
            {
                dbConn.Open();
            }
            catch
            {

            }
            dbComm = new SqlCommand("sp_GetUser", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            return dt;
        }
        public DataTable GetRole()
        {
            try
            {
                dbConn.Open();
            }
            catch
            {

            }
            dbComm = new SqlCommand("sp_GetRole", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;


            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbConn.Close();
            return dt;
        }
        public DataTable GetByRoleID(int roleID)
        {
            try
            {
                dbConn.Open();
            }
            catch
            {

            }
            dbComm = new SqlCommand("sp_GetByRoleID", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@RoleID", roleID);
            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbConn.Close();
            return dt;
        }
        public int InsertModule(Modules module)
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_InsertModule", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("ModuleDescription", module.ModuleDescription);
            dbComm.Parameters.AddWithValue("YearID", module.YearID);

            int x = dbComm.ExecuteNonQuery();
            dbConn.Close();
            return x;
        }
        public int UpdateModule(Modules module)
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_UpdateModule", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@ModuleID", module.ModuleID);
            dbComm.Parameters.AddWithValue("@ModuleDescription", module.ModuleDescription);
           


            int x = dbComm.ExecuteNonQuery();
            dbConn.Close();
            return x;
        }
        public DataTable GetYear()
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_GetYear", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbConn.Close();
            return dt;
        }
        public DataTable GetYearByID(int yearID)
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_GetYearByID", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@YearID", yearID);
            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbConn.Close();
            return dt;
        }
        public int DeleteModule(Modules module)
        {
            try
            {
                dbConn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_DeleteModule", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@ModuleID", module.ModuleID);
            int x = dbComm.ExecuteNonQuery();
            dbConn.Close();
            return x;
        }
        public DataTable GetModule()
        {
            try
            {
                dbConn.Open();
            }
            catch
            {

            }
            dbComm = new SqlCommand("sp_GetModules", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            return dt;
        }
        public int InsertLanguage(Programming_Language progLang)
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_InsertLanguage", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;


            dbComm.Parameters.AddWithValue("@ProgLanguageDesc", progLang.ProgLanguageDesc);
            int x = dbComm.ExecuteNonQuery();
            dbConn.Close();
            return x;
        }
        public int UpdateLanguage(Programming_Language progLang)
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_UpdateLanguage", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@ProgLanguageID", progLang.ProgLanguageID);
            dbComm.Parameters.AddWithValue("@ProgLanguageDesc", progLang.ProgLanguageDesc);

            int x = dbComm.ExecuteNonQuery();
            dbConn.Close();
            return x;
        }
        public int DeleteLanguage(Programming_Language progLang)
        {
            try
            {
                dbConn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_DeleteProgLanguage", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@ProgLanguageID", progLang.ProgLanguageID);
            int x = dbComm.ExecuteNonQuery();
            dbConn.Close();
            return x;
        }
        public DataTable GetLanguage()
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_GetProgLanguage", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbConn.Close();
            return dt;
        }
        public DataTable GetLecturerModuleTopic()
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_GetLecturerModuleTopic", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbConn.Close();
            return dt;
        }
        public DataTable GetEmail(string email)
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_GetEmail", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@Email", email);
            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbConn.Close();
            return dt;
        }
        public DataTable GetProgLanguageByID(int progLanguageID)
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_GetProgLanguageByID", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@ProgLanguageID", progLanguageID);
            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbConn.Close();
            return dt;
        }
        public DataTable GetStudent()
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_GetStudent", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;



            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbConn.Close();
            return dt;
        }
        public DataTable GetByStudentID(int studID)
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_GetByStudentID", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@StudentID", studID);
            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbConn.Close();
            return dt;
        }
        public int InsertError(Error error)
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_InsertError", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;


            dbComm.Parameters.AddWithValue("@ErrorDescription", error.ErrorDescription);
            dbComm.Parameters.AddWithValue("@StudentID", error.StudentID);
            dbComm.Parameters.AddWithValue("@ProgLanguageID", error.ProgLanguageID);
            dbComm.Parameters.AddWithValue("@ModuleTopicID", error.ModuleTopicID);
            dbComm.Parameters.AddWithValue("@ErrorStatus", error.ErrorStatus);

            int x = dbComm.ExecuteNonQuery();
            dbConn.Close();
            return x;
        }
        public int UpdateError(Error error)
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_UpdateError", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;


            dbComm.Parameters.AddWithValue("@ErrorDescription", error.ErrorDescription);
            dbComm.Parameters.AddWithValue("@ProgLanguageID", error.ProgLanguageID);
            dbComm.Parameters.AddWithValue("@ModuleTopicID", error.ModuleTopicID);
            dbComm.Parameters.AddWithValue("@ErrorStatus", error.ErrorStatus);
            dbComm.Parameters.AddWithValue("@ErrorID", error.ErrorID);

            int x = dbComm.ExecuteNonQuery();
            dbConn.Close();
            return x;
        }
        public int DeleteError(Error error)
        {
            try
            {
                dbConn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_DeleteError", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@ErrorID", error.ErrorID);
            int x = dbComm.ExecuteNonQuery();
            dbConn.Close();
            return x;
        }
        public DataTable GetError(int userID)
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_GetError", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@UserID", userID);
            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbConn.Close();
            return dt;
        }
        public int InsertSolution(Lecturer lecturer)
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_InsertSolution", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;


            dbComm.Parameters.AddWithValue("@SolutionDescription", lecturer.SolutionDescription);
            dbComm.Parameters.AddWithValue("@LecturerID", lecturer.LecturerID);



            int x = dbComm.ExecuteNonQuery();
            dbConn.Close();
            return x;
        }
        public int UpdateSolution(Lecturer lecturer)
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_UpdateSolution", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@SolutionDescription", lecturer.SolutionDescription);
            dbComm.Parameters.AddWithValue("@SolutionID", lecturer.SolutionID);




            int x = dbComm.ExecuteNonQuery();
            dbConn.Close();
            return x;
        }
        public int DeleteSolution(Lecturer lecture)
        {
            try
            {
                dbConn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_DeleteSolution", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@SolutionID", lecture.SolutionID);
            int x = dbComm.ExecuteNonQuery();
            dbConn.Close();
            return x;
        }
        public DataTable GetSolution()
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_GetSolution", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbConn.Close();
            return dt;
        }
        public DataTable GetLecture()
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_GetLecturer", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;



            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbConn.Close();
            return dt;
        }
        public DataTable GetByLectureID(int userID)
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_GetLecturerByID", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@UserID", userID);
            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbConn.Close();
            return dt;
        }
        public int InsertTopic(Topics topics)
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_InsertTopic", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;


            dbComm.Parameters.AddWithValue("@TopicDescription", topics.TopicDescription);
            int x = dbComm.ExecuteNonQuery();
            dbConn.Close();
            return x;
        }
        public int UpdateTopic(Topics topics)
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_UpdateTopic", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@TopicDescription", topics.TopicDescription);


            int x = dbComm.ExecuteNonQuery();
            dbConn.Close();
            return x;
        }
        public DataTable GetTopics()
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_GetTopic", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbConn.Close();
            return dt;
        }
        public DataTable GetByErrorID(int errorID)
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_GetByErrorID", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@ErrorID", errorID);
            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbConn.Close();
            return dt;
        }
        public int DeleteTopic(Topics topic)
        {
            try
            {
                dbConn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_DeleteTopic", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@TopicID", topic.TopicID);
            int x = dbComm.ExecuteNonQuery();
            dbConn.Close();
            return x;
        }
        public int InsertModuleTopic(ModuleTopic moduleTopic)
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_InsertModuleTopic", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;


            dbComm.Parameters.AddWithValue("@ModuleID", moduleTopic.ModuleID);
            dbComm.Parameters.AddWithValue("@topicID", moduleTopic.TopicID);


            int x = dbComm.ExecuteNonQuery();
            dbConn.Close();
            return x;
        }
        public int UpdateModuleTopic(ModuleTopic moduleTopic)
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_UpdateModuleTopic", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@ModuleTopicID", moduleTopic.ModuleTopicID);
            dbComm.Parameters.AddWithValue("@ModuleID", moduleTopic.ModuleID);
            dbComm.Parameters.AddWithValue("@TopicID", moduleTopic.TopicID);

            int x = dbComm.ExecuteNonQuery();
            dbConn.Close();
            return x;
        }
        public int DeleteModuleTopic(ModuleTopic moduleTopic)
        {
            try
            {
                dbConn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_DeleteModuleTopic", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@ModuleTopicID", moduleTopic.ModuleTopicID);
            int x = dbComm.ExecuteNonQuery();
            dbConn.Close();
            return x;
        }
        public DataTable GetModuleTopic(int userID)
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_GetModuleTopic", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@UserID", userID);
            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbConn.Close();
            return dt;
        }
        public DataTable GetByModuleID(int moduleId)
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_GetModuleID", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@ModuleID", moduleId);
            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbConn.Close();
            return dt;
        }
        public DataTable GetByTopicID(int topicID)
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_GetTopicByID", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@TopicID", topicID);
            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbConn.Close();
            return dt;
        }
        public int InsertErrorSolution(ErrorSolution errorSolution)
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_InsertErrorSol", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;


            dbComm.Parameters.AddWithValue("@ErrorID", errorSolution.ErrorID);
            dbComm.Parameters.AddWithValue("@SolutionID", errorSolution.SolutionID);
            dbComm.Parameters.AddWithValue("@Date", errorSolution.Date);


            int x = dbComm.ExecuteNonQuery();
            dbConn.Close();
            return x;
        }
        public int UpdateErrorSolution(ErrorSolution errorSolution)
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_UpdateErrorSol", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@ErrorSolutionID", errorSolution.ErrorSolutionID);
            dbComm.Parameters.AddWithValue("@SolutionID", errorSolution.SolutionID);
            dbComm.Parameters.AddWithValue("@ErrorID", errorSolution.ErrorID);
            dbComm.Parameters.AddWithValue("@Date", errorSolution.Date);


            int x = dbComm.ExecuteNonQuery();
            dbConn.Close();
            return x;
        }
        public int DeleteErrorSolution(ErrorSolution errorSolution)
        {
            try
            {
                dbConn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_DeleteErrorSolution", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@ErrorSolutionID", errorSolution.ErrorSolutionID);


            int x = dbComm.ExecuteNonQuery();
            dbConn.Close();
            return x;
        }
        public DataTable GetErrorSolution()
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_GetErrorSolution", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbConn.Close();
            return dt;
        }
        public DataTable GetBySolutionID(int solutionID)
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_GetByErrorID", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@SolutionID", solutionID);
            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbConn.Close();
            return dt;
        }
        public int InsertModuleStudent(ModuleStudent moduleStudent)
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_InsertModuleStudent", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;


            dbComm.Parameters.AddWithValue("@StudentID", moduleStudent.StudentID);
            dbComm.Parameters.AddWithValue("@ModuleID", moduleStudent.ModuleID);



            int x = dbComm.ExecuteNonQuery();
            dbConn.Close();
            return x;
        }
        public int UpdateModuleStudent(ModuleStudent moduleStudent)
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_UpdateModuleStudent", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;


            dbComm.Parameters.AddWithValue("@StudentID", moduleStudent.StudentID);
            dbComm.Parameters.AddWithValue("@ModuleID", moduleStudent.ModuleID);
            dbComm.Parameters.AddWithValue("@ModuleStudentID", moduleStudent.ModuleStudentID);


            int x = dbComm.ExecuteNonQuery();
            dbConn.Close();
            return x;
        }
        public int DeleteModuleStudent(ModuleStudent moduleStudent)
        {
            try
            {
                dbConn.Open();
            }
            catch
            {

            }

            dbComm = new SqlCommand("sp_DeleteModuleStudent", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@ModuleStudentID", moduleStudent.ModuleStudentID);


            int x = dbComm.ExecuteNonQuery();
            dbConn.Close();
            return x;
        }
        public DataTable GetModuleByStudent(int userID)
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_GetModuleByStudent", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@UserID", userID);

            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbConn.Close();
            return dt;
        }
        public DataTable GetModuleStudent()
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_GetModuleStudent", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbConn.Close();
            return dt;
        }
        public int InsertModuleError(ModuleError moduleError)
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_InsertModuleError", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;


            dbComm.Parameters.AddWithValue("@ModuleID", moduleError.ModuleID);
            dbComm.Parameters.AddWithValue("@ErrorID", moduleError.ErrorID);



            int x = dbComm.ExecuteNonQuery();
            dbConn.Close();
            return x;
        }
        public int UpdateModuleError(ModuleError moduleError)
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_UpdateModuleError", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@ModuleErrorID", moduleError.ModuleID);
            dbComm.Parameters.AddWithValue("@ModuleID", moduleError.ModuleID);
            dbComm.Parameters.AddWithValue("@ErrorID", moduleError.ErrorID);



            int x = dbComm.ExecuteNonQuery();
            dbConn.Close();
            return x;
        }
        public int DeleteModuleError(ModuleError moduleError)
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_DeleteModuleError", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@ModuleErrorID", moduleError.ModuleID);
            int x = dbComm.ExecuteNonQuery();
            dbConn.Close();
            return x;
        }
        public DataTable GetModuleError()
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_GetModuleError", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbConn.Close();
            return dt;
        }
        public DataTable GetErrorByModule(int moduleID)
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_GetErrorByModule", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("ModuleID", moduleID);

            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbConn.Close();
            return dt;
        }
        public DataTable GetSolutionError(int moduleID)
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_GetSolutionError", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@ModuleID", moduleID);
            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbConn.Close();
            return dt;
        }

        public int ChangePassword(ChangePassword changePW)
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_ChangePassword", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@Email", changePW.Email);
            dbComm.Parameters.AddWithValue("@Password", changePW.Password);

            int x = dbComm.ExecuteNonQuery();
            dbConn.Close();
            return x;
        }
        public DataTable GetAdmin()
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_GetAdmin", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbConn.Close();
            return dt;
        }
        public DataTable GetAdminByID(int userID)
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_GetByAdminID", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@UserID", userID);
            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbConn.Close();
            return dt;
        }
        public DataTable GetStudentDetails(int userID)
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_GetStudentDetails", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;


            dbComm.Parameters.AddWithValue("@UserID", userID);
            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbConn.Close();
            return dt;
            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbConn.Close();
            return dt;
        }
        public DataTable GetByUserID(int userID)
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_GetByUserID", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@UserID", userID);
            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbConn.Close();
            return dt;
        }
        public DataTable SearchUser()
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_SearchUser", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;


            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbConn.Close();
            return dt;
        }
        public DataTable GetSolutionDate(SolutionDate solutionDate)
        {

            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_DateSolution", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;


            dbComm.Parameters.AddWithValue("@From", solutionDate.From);
            dbComm.Parameters.AddWithValue("@To", solutionDate.To);
            dbComm.Parameters.AddWithValue("@UserID", solutionDate.UserID);


            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbConn.Close();
            return dt;

        }
        public DataTable GetTopicByModule(int moduleID)
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_GetTopicByModule", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@ModuleID", moduleID);
            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbConn.Close();
            return dt;
        }
        public DataTable GetErrorByTopic(int topicID)
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_GetErrorByTopic", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@TopicID", topicID);
            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbConn.Close();
            return dt;
        }
        public DataTable GetErrorByProgLanguage(int proglanguageID)
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_GetProgLanguageByID", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@ProgLanguageID", proglanguageID);
            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbConn.Close();
            return dt;
        }
        public DataTable GetErrorSol()
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_GetErrorSol", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;


            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbConn.Close();
            return dt;
        }
        public DataTable GetLecturerError()
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_GetLecturerError", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;


            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbConn.Close();
            return dt;
        }
        public DataTable GetLectureModuleTopic()
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_GetModuleTopicLecturer", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;


            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbConn.Close();
            return dt;
        }
        public DataTable GetErrorStatus(int userID)
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_GetErrorStatus", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@UserID", userID);
            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbConn.Close();
            return dt;
        }
        public DataTable ErrorStatus(int errorID)
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_ErrorStatus", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@ErrorID", errorID);
            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbConn.Close();
            return dt;
        }
        public DataTable GetStudentByYear(int yearID)
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_GetStudentByYear", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@YearID", yearID);
            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            dbConn.Close();
            return dt;
        }
        public DataTable GetInAcive()
        {
            try
            {
                dbConn.Open();
            }
            catch
            {

            }
            dbComm = new SqlCommand("sp_GetInActiveUser", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            return dt;
        }
        public DataTable GetUserStatus()
        {
            try
            {
                dbConn.Open();
            }
            catch
            {

            }
            dbComm = new SqlCommand("sp_GetUserStatus", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            return dt;
        }
        public DataTable GetUserByStatus(int userID)
        {
            try
            {
                dbConn.Open();
            }
            catch
            {

            }
            dbComm = new SqlCommand("sp_GetUserByStatus", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@UserID", userID);
            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            return dt;
        }
        public DataTable GetLecturerSolution()
        {
            try
            {
                dbConn.Open();
            }
            catch
            {

            }
            dbComm = new SqlCommand("sp_GetLecturerSolution", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            
            dt = new DataTable();
            dbAdapter = new SqlDataAdapter(dbComm);
            dbAdapter.Fill(dt);
            return dt;
        }
        public int UpdateTopics(Topics topic)
        {
            try
            {
                dbConn.Open();
            }
            catch { }

            dbComm = new SqlCommand("sp_UpdateTopic", dbConn);
            dbComm.CommandType = CommandType.StoredProcedure;

            dbComm.Parameters.AddWithValue("@TopicDescription", topic.TopicDescription);
            dbComm.Parameters.AddWithValue("@TopicID", topic.TopicID);

            int x = dbComm.ExecuteNonQuery();
            dbConn.Close();
            return x;
        }

    }
}
