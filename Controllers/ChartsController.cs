using Microsoft.AspNetCore.Mvc;
using Ceng423_WebApp_RestaurantProject.Models;

namespace Ceng423_WebApp_RestaurantProject.Controllers
{
    public class ChartsController : Controller
    {
         private static readonly List<Chart> charts = new List<Chart>()
          {
              new Chart {
                  Username = "test1",
                  Items = new Dictionary<string, double>
                    {
                       { "Item 1", 10 },
                       { "Item 2", 5 },
                       { "Item 3", 8 }
                    },
              }
          };

          public static List<Chart> GetAllCharts()
          {
              return charts;
          }

          public static void AddChart(Chart chart)
          {
            var existingChart = charts.FirstOrDefault(c => c.Username == chart.Username);

            if (existingChart != null)
            {
                foreach (var item in chart.Items)
                {
                    existingChart.Items[item.Key] = item.Value;
                }
            }
            else
            {
                charts.Add(chart);
            }
        }

        public static bool RemoveChart(string username, string item)
        {
            foreach (var chart in charts)
            {
                if (chart.Username.Equals(username))
                {
                    if (chart.Items.ContainsKey(item))
                    {
                        chart.Items.Remove(item);
                        return true;
                    }
                }
            }

            return false;
        }


        [HttpGet]
          public IActionResult GetAllChartsReq()
            {
            return Ok(charts);
            }

    }
}
