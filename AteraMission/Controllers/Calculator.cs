using AteraMission.Models.Calculator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AteraMission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Calculator : ControllerBase
    {
        [HttpGet]
        public ActionResult Get(string exp)
        {
            try
            {
                double res = ParserExperssion.Parser(Uri.UnescapeDataString(exp));
                return Ok(res);
            }
            catch(Exception ex) when(ex is InvalidInputException)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                string errMsg = "Sorry an error occurred";

                return StatusCode(StatusCodes.Status500InternalServerError, errMsg);
            }
        }
    }
}
