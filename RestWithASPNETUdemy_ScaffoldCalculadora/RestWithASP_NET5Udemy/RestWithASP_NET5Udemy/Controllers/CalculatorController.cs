using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASP_NET5Udemy.Controllers
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

        #region Rotas

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = OperacaoSum(firstNumber, secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid input");
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult Sub(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sub = OperacaoSub(firstNumber, secondNumber);
                return Ok(sub.ToString());
            }
            return BadRequest("Invalid input");
        }

        [HttpGet("mult/{firstNumber}/{secondNumber}")]
        public IActionResult Mult(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                decimal mult = OperacaoMult(firstNumber, secondNumber);
                return Ok(mult.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult Div(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                decimal div = OperacaoDiv(firstNumber, secondNumber);
                return Ok(div.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("med/{firstNumber}/{secondNumber}")]
        public IActionResult Med(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                decimal med = OperacaoMed(firstNumber, secondNumber);
                return Ok(med.ToString());
            }

            return BadRequest("Invalid Input");
        }

        [HttpGet("raiz/{firstNumber}")]
        public IActionResult Raiz(string firstNumber)
        {
            if (IsNumeric(firstNumber))
            {
                var raiz = OperacaoRaiz(firstNumber);
                return Ok(raiz.ToString());
            }

            return BadRequest("Invalid Input");
        }

        #endregion

        #region Private

        #region Operações

        private decimal OperacaoSum(string firstNumber, string secondNumber)
        {
            return ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
        }

        private decimal OperacaoSub(string firstNumber, string secondNumber)
        {
            return ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
        }

        private decimal OperacaoMult(string firstNumber, string secondNumber)
        {
            return ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
        }

        private decimal OperacaoDiv(string firstNumber, string secondNumber)
        {
            return ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
        }

        private decimal OperacaoMed(string firstNumber, string secondNumber)
        {
            return (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber) / 2);
        }

        private double OperacaoRaiz(string firstNumber)
        {
            return Math.Sqrt((double)ConvertToDecimal(firstNumber));
        }

        #endregion

        #region Uteis

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);
            return isNumber;

        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if (decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }

            return 0;
        }

        #endregion

        #endregion

    }
}
