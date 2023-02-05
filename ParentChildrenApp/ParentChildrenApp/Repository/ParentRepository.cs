using System.Data;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ParentChildrenApp.Models.DTO;
using System.Collections.Generic;
using ParentChildrenApp.Models;

namespace ParentChildrenApp.Repository
{
    public class ParentRepository : IParentRepository
    {

        private readonly IConfiguration _config;
        private readonly string _connStr;
        private SqlConnection con;
        public ParentRepository(IConfiguration config)
        {
            _config = config;
            _connStr = _config["ConnectionStrings:DefaultConnection"].ToString();
            con = new SqlConnection(_connStr);
        }
        public bool CreateUser(ParentRegistrationModel smodel)
        {
            SqlCommand cmd = new SqlCommand("CreateUsers", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@userName",    smodel.Username);
            cmd.Parameters.AddWithValue("@password",    smodel.Password);
            cmd.Parameters.AddWithValue("@gender",      smodel.Gender);
            cmd.Parameters.AddWithValue("@fname",       smodel.FirstName);
            cmd.Parameters.AddWithValue("@lname",       smodel.LastName);
            cmd.Parameters.AddWithValue("@emailid",     smodel.Email);
            cmd.Parameters.AddWithValue("@mobNo",       smodel.MobNo);
            cmd.Parameters.AddWithValue("@emiratesId",  smodel.EmiratesID);
            cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;

            try
            {

                con.Open();
                cmd.ExecuteNonQuery();
                int result = Convert.ToInt32(cmd.Parameters["@id"].Value);
               // int result = cmd.ExecuteNonQuery();

                if (result > 0)
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

        public bool UpdateUser(ParentDTO smodel)
        {
            SqlCommand cmd = new SqlCommand("UpdateUsers", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@parentid", smodel.Id);
            cmd.Parameters.AddWithValue("@userName", smodel.UserName);
            cmd.Parameters.AddWithValue("@fname", smodel.FirstName);
            cmd.Parameters.AddWithValue("@lname", smodel.LastName);
            cmd.Parameters.AddWithValue("@emailid", smodel.EmailId);
            cmd.Parameters.AddWithValue("@mobNo", smodel.MobNo);
            cmd.Parameters.AddWithValue("@emiratesId", smodel.EmiratesID);
            cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;

            try
            {

                con.Open();
                cmd.ExecuteNonQuery();
                int result = Convert.ToInt32(cmd.Parameters["@id"].Value);
                // int result = cmd.ExecuteNonQuery();

                if (result > 0)
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
        public ParentDTO GetUser(string username)
        {
            ParentDTO usersdata = new ParentDTO();
            SqlCommand cmd = new SqlCommand("GetUser", con);
            cmd.Parameters.AddWithValue("@userName", username);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            if (dt.Rows.Count == 1)
            {
                usersdata.UserName = dt.Rows[0]["Username"].ToString();
                usersdata.Id = Convert.ToInt32(dt.Rows[0]["ParentId"]);
                usersdata.Gender = dt.Rows[0]["Gender"].ToString();
                usersdata.FirstName = dt.Rows[0]["FirstName"].ToString();
                usersdata.LastName = dt.Rows[0]["LastName"].ToString();
                usersdata.MobNo = dt.Rows[0]["MobNo"].ToString();
                usersdata.EmailId = Convert.ToString(dt.Rows[0]["EmailId"]);
                usersdata.EmiratesID = dt.Rows[0]["EmiratesID"].ToString();


            }
            return usersdata;
        }

        public ParentDTO GetUserByID(int id)
        {
            ParentDTO usersdata = new ParentDTO();
            SqlCommand cmd = new SqlCommand("GetUserByID", con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            if (dt.Rows.Count == 1)
            {
                usersdata.UserName = dt.Rows[0]["Username"].ToString();
                usersdata.Id = Convert.ToInt32(dt.Rows[0]["ParentId"]);
                usersdata.Gender = dt.Rows[0]["Gender"].ToString();
                usersdata.FirstName = dt.Rows[0]["FirstName"].ToString();
                usersdata.LastName = dt.Rows[0]["LastName"].ToString();
                usersdata.MobNo = dt.Rows[0]["MobNo"].ToString();
                usersdata.EmailId = Convert.ToString(dt.Rows[0]["EmailId"]);
                usersdata.EmiratesID = dt.Rows[0]["EmiratesID"].ToString();


            }
            return usersdata;
        }

    }
}
