using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Globalization;

namespace CalculadoraRest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                decimal sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);

                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult Sub(string firstNumber, string secondNumber)
        {
            if(!IsNumeric(firstNumber) && !IsNumeric(secondNumber))
            {
                return BadRequest("Invalid Input");
            }

            decimal sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);

            return Ok(sub.ToString());
        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult Div(string firstNumber, string secondNumber)
        {
            if (!IsNumeric(firstNumber) && !IsNumeric(secondNumber))
            {
                return BadRequest("Invalid Input");
            }

            decimal div = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);

            return Ok(div.ToString());
        }

        [HttpGet("mult/{firstNumber}/{secondNumber}")]
        public IActionResult Mult(string firstNumber, string secondNumber)
        {
            if (!IsNumeric(firstNumber) && !IsNumeric(secondNumber))
            {
                return BadRequest("Invalid Input");
            }

            decimal mult = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);

            return Ok(mult.ToString());
        }

        [HttpGet("avg/{firstNumber}/{secondNumber}")]
        public IActionResult Avg(string firstNumber, string secondNumber)
        {
            if (!IsNumeric(firstNumber) && !IsNumeric(secondNumber))
            {
                return BadRequest("Invalid Input");
            }

            decimal avg = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;

            return Ok(avg.ToString());
        }

        [HttpGet("sqrt/{firstNumber}")]
        public IActionResult Sqrt(string firstNumber)
        {
            if (!IsNumeric(firstNumber))
            {
                return BadRequest("Invalid Input");
            }

            double sqrt = Math.Sqrt(Convert.ToDouble(firstNumber));

            return Ok(sqrt.ToString());
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(strNumber, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out number);

            return isNumber;            
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal value;

            return decimal.TryParse(strNumber, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out value) ? value : 0;
        }
    }
}
