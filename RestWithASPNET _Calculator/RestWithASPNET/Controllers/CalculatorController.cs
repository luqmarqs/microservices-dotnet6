using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNET.Controllers;

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
        if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
            return Ok(sum.ToString());
        }
        return BadRequest("Invalid input");
    }

    [HttpGet("sub/{firstNumber}/{secondNumber}")]
    public IActionResult Sub(string firstNumber, string secondNumber)
    {
        if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
            return Ok(sub.ToString());
        }
        return BadRequest("Invalid input");
    }

    [HttpGet("mult/{firstNumber}/{secondNumber}")]
    public IActionResult Mult(string firstNumber, string secondNumber)
    {
        if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var mult = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
            return Ok(mult.ToString());
        }
        return BadRequest("Invalid input");
    }

    [HttpGet("media/{firstNumber}/{secondNumber}")]
    public IActionResult Media(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var media = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber))/2;
            return Ok(media.ToString());
        }
        return BadRequest("Invalid input");
    }

    [HttpGet("sqroot/{firstNumber}")]
    public IActionResult Sqroot(string firstNumber)
    {
        if (IsNumeric(firstNumber))
        {
            var sqrt = Math.Sqrt((double)ConvertToDecimal(firstNumber));
            return Ok(sqrt.ToString());
        }
        return BadRequest("Invalid input");
    }

    [HttpGet("division/{firstNumber}/{secondNumber}")]
    public IActionResult Division(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var division = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
            return Ok(division.ToString());
        }
        return BadRequest("Invalid input");
    }

    private decimal ConvertToDecimal(string strNumber)
    {
        decimal decimalValue;
        if(decimal.TryParse(strNumber, out decimalValue))
        {
            return decimalValue;
        }
        return 0;
    }

    private bool IsNumeric(string strNumber)
    {
        double number;
        bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);
        return isNumber;
    }
}
