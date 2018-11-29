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

        [HttpGet("[action]/{answer}")]
        public QuestionResult NextTip(string answer)
        {
            var editedAnswer = answer.ToLower().Replace(" ", "");
            Dictionary<string, string> answerMap = new Dictionary<string, string>();
            answerMap["hurra"] = "YES! Da var vi igang. I ferden mot skatten m� vi finne ut av antall etasjer Risvollan blokka har";
            answerMap["16"] = "Kjempe bra. Vi begynner reise quizen med dette. Hva er navnet p� skobutikken der Adam Ondra klatret verdens vanskligste rute";
            answerMap["falkanger"] = "Konge, hopp i bilen, jeg lukter skatt. Da b�rer turen til Utehallen, jeg trenger � vite hvem utehallen har et opplegg for, b�r v�re mulig � finne ut av fra utsiden!";
            answerMap["firmaer"] = "Hurra! For � komme et skritt n�rmere skatten tror jeg at jeg trenger navnet p� den rosa 5+ ruta jeg klatret, n�r vi f�rst er her.";
            answerMap["firma"] = "Hurra! For � komme et skritt n�rmere skatten tror jeg at jeg trenger navnet p� den rosa 5+ ruta jeg klatret, n�r vi f�rst er her.";
            answerMap["rosa"] = "Tommel opp. For � komme oss videre g�r turen til Klatresenteret der de har ukas Bulder som vanligvis er veldig vanskelig, den st�r skrudd sammen med en annen mye enklere rute som heter Ukas...";
            answerMap["navnl�s"] = "Tommel opp. For � komme oss videre g�r turen til Klatresenteret der de har ukas Bulder som vanligvis er veldig vanskelig, den st�r skrudd sammen med en annen mye enklere rute som heter Ukas...";
            answerMap["pudding"] = "Fantastisk! Da n�rmer turen seg slutten og den gjemte skatten og som alle gode avslutninger ender den p� IKEA, For � komme oss i m�l trenger vi og vite hvilke avdeling som er nummer 5 p� oversiktskartet";
            answerMap["kj�kken"] = "Gratulerer skatten er din, den gjemmer seg der vi startet. Du m� finne den gjemte skatten der jeg gravde den ned i undergrunnen p� boden.";

            var qRes = new QuestionResult();
            qRes.Answer = answer;
            if (answerMap.ContainsKey(editedAnswer))
            {
                qRes.Hint = answerMap[editedAnswer];
                qRes.CorrectAnswer = true;
            }
            else
            {
                qRes.Hint = "� nei, jeg tror det forrige svaret ditt var galt, skriv inn forrige korrekte svar for � f� tilbake hintet";
                qRes.CorrectAnswer = false;
            }
            return qRes;
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
            public bool CorrectAnswer { get; set; }
        }
    }
}
