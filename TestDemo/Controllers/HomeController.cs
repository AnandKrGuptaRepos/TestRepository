using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestDemo.Models;
using Microsoft.AspNetCore.Http;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using Newtonsoft.Json;

namespace TestDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            String constring = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521) ) ) (CONNECT_DATA=(SERVER=DEDICATED)(SID=xe)));User id=Cyme_net; Password=Cyme_net; enlist=false; pooling=false;Connection Timeout=120;";
            DataTable dt = null;
            var serializedata = "";
            using (OracleConnection con = new OracleConnection(constring))
            {
                using (OracleCommand cmd = con.CreateCommand())
                {
                    try
                    {
                        con.Open();
                        cmd.BindByName = true;
                        cmd.CommandText = "CYMLOADNETWORK"; //USP_LOADNETWORK
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("P_NETWORKID", OracleDbType.Clob).Value = "02/14221/201,02/14016/201,02/14221/201,02/14221/202,02/14221/203,02/14221/204,02/14223/202,02/14016/201,02/14016/202,02/14016/203";
                        cmd.Parameters.Add("P_RECORDSET", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                        cmd.Parameters.Add("P_INTERMEDIATESET", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                        OracleDataAdapter oda = new OracleDataAdapter(cmd);
                        OracleCommandBuilder ocb = new OracleCommandBuilder(oda);
                        DataSet ds = new DataSet();
                        oda.Fill(ds);
                        dt = ds.Tables[0];
                        int count = dt.Rows.Count;
                        serializedata = JsonConvert.SerializeObject(ds);

                    }
                    catch (Exception ex)
                    {

                        HttpContext.Response.WriteAsync(ex.Message);
                    }
                }
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
