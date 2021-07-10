using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace day1._1.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class RemController : ControllerBase
    {
        private readonly ILogger<RemController> _logger;

        public RemController(ILogger<RemController> logger)
        {
            _logger = logger;
        }
        public void Main(string[] args)
        {
            JObject result = new JObject();//创建一个json对象
            JArray arr = new JArray(); //创建一个可以放进json里面的列表arr[]

            Console.WriteLine(result.ToString()); //将json字符串变成String然后输出到控制台上
            Console.ReadKey();//等待按下按钮结束程序
        }
        /// <summary>
        /// 获取明日天气
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns></returns>
        [HttpGet]
        public List<WeatherForecast> Get(string city_name)
        {
            var result = new List<WeatherForecast>();
            var a = new WeatherForecast { city_name = city_name };
            result.Add(a);
            JObject obj = Newtonsoft.Json.Linq.JObject.Parse(city_name);
            string freSpaceNum = obj["data"][0]["freSpaceNum"].ToString();
            string resMag = obj["resMag"].ToString();
            return result;
        }
    }
}
