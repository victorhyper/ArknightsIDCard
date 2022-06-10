using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDCardMaker
{
    class JsObject
    {
        //皮肤
        public string Skin { get; set; }
        //名字
        public string Name { get; set; }
        //精英等级
        public int Elite { get; set; }
        //等级
        public int Level { get; set; }
        //星级
        public int Star { get; set; }
        //潜能
        public int Potential { get; set; }
        //技能
        public int Skill1 { get; set; }
        public int Skill2 { get; set; }
        public int Skill3 { get; set; }
        //模组
        public string Mod { get; set; }
        //是否拥有
        public int Enable { get; set; }
    }
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

        public static string ExportJson(List<Operator>ops)
        {
            var jsData = (from row in ops
                          select new JsObject
                          {
                              Name = row.Name,
                              Star = row.Star,
                              Potential = row.Potential,
                              Elite = row.Elite,
                              Level = row.Level,
                              Skill1 = row.Skill1,
                              Skill2 = row.Skill2,
                              Skill3 = row.Skill3,
                              Mod = row.Mod,
                              Skin = row.Skin,
                              Enable = Convert.ToInt32(row.Enable)
                          }).ToList();
            var json = JsonConvert.SerializeObject(jsData);
            return json;
        }
    }
}
