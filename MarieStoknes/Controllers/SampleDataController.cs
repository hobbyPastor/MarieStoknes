using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MarieStoknes.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
        public class QuestionResult
        {
            public string Answer { get; set; }
            public string Hint { get; set; }
        }

        [HttpGet("[action]/{answer}")]
        public QuestionResult NextTip(string answer)
        {
            var editedAnswer = answer.ToLower().Replace(" ", "");
            Dictionary<string, string> answerMap = new Dictionary<string, string>();
            answerMap["hipphurra"] = "Hvor mange etasjer har Risvollan blokka?";
            answerMap["15"] = "Butikken ved siden av Kitchen på torget?";
            answerMap["falkanger"] = "Navnet på 6er ruta jeg klatret";


            var qRes = new QuestionResult();
            qRes.Answer = answer;
            if (answerMap.ContainsKey(editedAnswer))
            {
                qRes.Hint = answerMap[editedAnswer];
            }
            else qRes.Hint = "Dette stemmer ikke!";

            return qRes;
        }
    }
}
