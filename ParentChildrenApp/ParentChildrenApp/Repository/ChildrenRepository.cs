using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ParentChildrenApp.Models;
using ParentChildrenApp.Models.DTO;

namespace ParentChildrenApp.Repository
{
    public class ChildrenRepository : IChildrenRepository
    {
        private readonly IConfiguration _config;
        private readonly string _connStr;
        private SqlConnection con;
        public ChildrenRepository(IConfiguration config)
        {
            _config = config;
            _connStr = _config["ConnectionStrings:DefaultConnection"].ToString();
            con = new SqlConnection(_connStr);
        }
        public bool AddChildren(ChildDTO smodel)
        {
            SqlCommand cmd = new SqlCommand("CreateChild", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@parentid", smodel.ParentId);
            cmd.Parameters.AddWithValue("@noofchild", smodel.NoOfChild);
            cmd.Parameters.AddWithValue("@gender", smodel.Gender);
            cmd.Parameters.AddWithValue("@fname", smodel.FirstName);
            cmd.Parameters.AddWithValue("@lname", smodel.LastName);
            cmd.Parameters.AddWithValue("@age", smodel.Age);
            cmd.Parameters.AddWithValue("@photo", smodel.Photo);

            try
            {

                con.Open();
                int result = cmd.ExecuteNonQuery();

                if (result >=1)
                {
                    return true;
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                con.Close();
            }
            return false;
        }

        public bool DeleteChildren(int childId)
        {
            SqlCommand cmd = new SqlCommand("DeleteChild", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@childid", childId);
            try
            {

                con.Open();
                int result = cmd.ExecuteNonQuery();

                if (result >= 1)
                {
                    return true;
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                con.Close();
            }
            return false;
        }

      
        public bool EditChildren(ChildDTO smodel)
        {
            SqlCommand cmd = new SqlCommand("EditChild", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@childid", smodel.Id);
            cmd.Parameters.AddWithValue("@parentid", smodel.ParentId);
            cmd.Parameters.AddWithValue("@noofchild", smodel.NoOfChild);
            cmd.Parameters.AddWithValue("@gender", smodel.Gender);
            cmd.Parameters.AddWithValue("@fname", smodel.FirstName);
            cmd.Parameters.AddWithValue("@lname", smodel.LastName);
            cmd.Parameters.AddWithValue("@age", smodel.Age);
            cmd.Parameters.AddWithValue("@photo", smodel.Photo);

            try
            {

                con.Open();
                int result = cmd.ExecuteNonQuery();

                if (result >= 1)
                {
                    return true;
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                con.Close();
            }
            return false;
        }

        public List<ChildModel> GetMyChildren(int parentId)
        {
            List<ChildModel> childlist = new List<ChildModel>();
            SqlCommand cmd = new SqlCommand("GetChildren", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@parentid", parentId);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();


            foreach (DataRow dr in dt.Rows)
            {
                childlist.Add(new ChildModel
                {
                    NoOfChild    = Convert.ToInt32(dr["NoOfChildren"]),
                    Id= Convert.ToInt32(dr["ID"]),
                    ParentId= Convert.ToInt32(dr["ParentID"]),
                    FirstName    = dr["FirstName"].ToString(),
                    LastName    = dr["LastName"].ToString(),
                    Gender      = dr["Gender"].ToString(),
                    Age = dr["Age"].ToString(),
                    Photo = dr["Photo"].ToString()
                });
            }
            return childlist;
        }
    }
}
