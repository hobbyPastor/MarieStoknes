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
            answerMap["hurra"] = "YES! Da var vi igang. I ferden mot skatten må vi finne ut av antall etasjer Risvollan blokka har";
            answerMap["16"] = "Kjempe bra. Vi begynner reise quizen med dette. Hva er navnet på skobutikken der Adam Ondra klatret verdens vanskligste rute";
            answerMap["falkanger"] = "Konge, hopp i bilen, jeg lukter skatt. Da bærer turen til Utehallen, jeg trenger å vite hvem utehallen har et opplegg for, bør være mulig å finne ut av fra utsiden!";
            answerMap["firmaer"] = "Hurra! For å komme et skritt nærmere skatten tror jeg at jeg trenger navnet på den rosa 5+ ruta jeg klatret, når vi først er her.";
            answerMap["firma"] = "Hurra! For å komme et skritt nærmere skatten tror jeg at jeg trenger navnet på den rosa 5+ ruta jeg klatret, når vi først er her.";
            answerMap["rosa"] = "Tommel opp. For å komme oss videre går turen til Klatresenteret der de har ukas Bulder som vanligvis er veldig vanskelig, den står skrudd sammen med en annen mye enklere rute som heter Ukas...";
            answerMap["navnløs"] = "Tommel opp. For å komme oss videre går turen til Klatresenteret der de har ukas Bulder som vanligvis er veldig vanskelig, den står skrudd sammen med en annen mye enklere rute som heter Ukas...";
            answerMap["pudding"] = "Fantastisk! Da nærmer turen seg slutten og den gjemte skatten og som alle gode avslutninger ender den på IKEA, For å komme oss i mål trenger vi og vite hvilke avdeling som er nummer 5 på oversiktskartet";
            answerMap["kjøkken"] = "Gratulerer skatten er din, den gjemmer seg der vi startet. Du må finne den gjemte skatten der jeg gravde den ned i undergrunnen på boden.";

            var qRes = new QuestionResult();
            qRes.Answer = answer;
            if (answerMap.ContainsKey(editedAnswer))
            {
                qRes.Hint = answerMap[editedAnswer];
                qRes.CorrectAnswer = true;
            }
            else
            {
                qRes.Hint = "Å nei, jeg tror det forrige svaret ditt var galt, skriv inn forrige korrekte svar for å få tilbake hintet";
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
