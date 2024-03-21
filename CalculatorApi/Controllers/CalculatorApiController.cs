using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using Newtonsoft.Json;
using System.Data;

namespace CalculatorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorApiController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetLog()
        {
            string connection = "datasource=localhost;port=3306;username=root;password=''";
            string qurey = "SELECT * FROM `calculator_log`.`log`";

            MySqlConnection mySqlConnection = new MySqlConnection(connection);
            MySqlCommand mySqlCommand = new MySqlCommand(qurey, mySqlConnection);
            mySqlConnection.Open();

            MySqlDataAdapter myDataAdaptor = new MySqlDataAdapter();
            myDataAdaptor.SelectCommand = mySqlCommand;
            DataTable dt = new DataTable();
            myDataAdaptor.Fill(dt);
            mySqlConnection.Close();

            if(dt.Rows.Count > 0)
            {
             string jsonString = JsonConvert.SerializeObject(dt, Formatting.Indented);
             return Ok(jsonString);
            }else
            {
                return BadRequest();
            }
          
        }

    }
}
