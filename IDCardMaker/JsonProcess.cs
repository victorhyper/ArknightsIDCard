using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDCardMaker
{
    internal class JsonProcess
    {
        public static List<Operator> LoadJson(string jstr)
        {
            List<Operator> operators = new List<Operator>();
            JArray jArray = (JArray)JsonConvert.DeserializeObject(jstr);
            foreach(var it in jArray)
            {
                JObject jObject = JObject.Parse(it.ToString());
                Operator op = new Operator();
                op.Name = jObject["Name"].ToString();
                op.Star = Convert.ToInt32(jObject["Star"].ToString());
                op.Potential = Convert.ToInt32(jObject["Potential"].ToString());
                op.Elite = Convert.ToInt32(jObject["Elite"].ToString());
                op.Level = Convert.ToInt32(jObject["Level"].ToString());
                op.Skill1 = Convert.ToInt32(jObject["Skill1"].ToString());
                op.Skill2 = Convert.ToInt32(jObject["Skill2"].ToString());
                op.Skill3 = Convert.ToInt32(jObject["Skill3"].ToString());
                op.Mod = jObject["Mod"].ToString();
                op.Skin = jObject["Skin"].ToString();
                if (jObject["Enable"].ToString() == "1")
                    op.Enable = true;
                else
                    op.Enable = false;
                operators.Add(op);
            }
            return operators;
        }
    }
}
