using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using HappyMealsAPIs.Models;

namespace HappyMealsAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegistrationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public UserRegistrationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult getAllUsers()
        {
            string query = @"select RegistrationId,Prefix,LastName,FirstName,PhoneNumber,EmailAddress,AddressLine1,AddressLine2,ZipCode,CityId,StateId from tblUserRegistration";
            DataTable tbl = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("HappyMealAppCon");
            SqlDataReader objReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    objReader = myCommand.ExecuteReader();
                    tbl.Load(objReader);

                    objReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(tbl);
        }
        [HttpGet("{id}")]
        public JsonResult getUserById(int id)
        {
            string query = @"select RegistrationId,Prefix,LastName,FirstName,PhoneNumber,EmailAddress,AddressLine1,AddressLine2,ZipCode,CityId,StateId from tblUserRegistration where RegistrationId = " + id + @"";
            DataTable tbl = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("HappyMealAppCon");
            SqlDataReader objReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    objReader = myCommand.ExecuteReader();
                    tbl.Load(objReader);

                    objReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(tbl);
        }
        [HttpPost]
        public JsonResult addNewUser(UserRegistration ur)
        {
            string query = @"
                            insert into dbo.tblUserRegistration
                            (Prefix,LastName,FirstName,PhoneNumber,EmailAddress,AddressLine1,AddressLine2,ZipCode,CityId,StateId)
                            values('" + ur.Prefix + @"','" + ur.LastName + @"','" + ur.FirstName + @"','" + ur.PhoneNumber + @"','" + ur.EmailAddress + @"','" + ur.AddressLine1 + @"','" + ur.AddressLine2 + @"','" + ur.ZipCode + @"','" + ur.CityId + @"','" + ur.StateId + @"')";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("HappyMealAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Added Successfully");
        }
        [HttpPut]
        public JsonResult updateUserRegistration(UserRegistration ur)
        {
            string query = @"
                update dbo.tblUserRegistration set 
                Prefix = '" + ur.Prefix + @"',LastName='" + ur.LastName + @"'
                ,FirstName='" + ur.FirstName + @"',PhoneNumber='" + ur.PhoneNumber + @"'
                ,EmailAddress='" + ur.EmailAddress + @"',AddressLine1='" + ur.AddressLine1 +@"'
                ,AddressLine2='" + ur.AddressLine2 + @"',ZipCode='" + ur.ZipCode + @"'
                ,CityId='" + ur.CityId + @"',StateId='" + ur.StateId + @"' where RegistrationId = " + ur.RegistrationId + @""; 
           
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("HappyMealAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); 

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{id}")]
        public JsonResult deleteUserRegistration(int id)
        {
            string query = @"delete from dbo.tblUserRegistration
                            where RegistrationId = " + id + @"";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("HappyMealAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query,myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Delete Successfully");
        }

    }
}
