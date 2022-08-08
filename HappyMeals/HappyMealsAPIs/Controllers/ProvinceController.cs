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
    public class ProvinceController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ProvinceController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"SELECT StateId,StateName,Abbreviation FROM dbo.tblStates";
            DataTable tblProvince = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("HappyMealAppCon");
            SqlDataReader objReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    objReader = myCommand.ExecuteReader();
                    tblProvince.Load(objReader);

                    objReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(tblProvince);
        }
    }
}
