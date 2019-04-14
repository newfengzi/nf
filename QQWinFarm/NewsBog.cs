using System;
using System.Collections;
using Json;
namespace QQWinFarm
{
    public class NewsBog
    {

        public JsonObject FruitPicking = new JsonObject("{}");
        public void AddFruit(string cid,string cname ,string cnum)
        {
            string num = cnum;
            if (num == null) num = "0";
            if (FruitPicking.ContainsKey(cid))
            {
                JsonObject objjson = FruitPicking.GetJson(cid);
                objjson["num"] = (Convert.ToInt32(objjson["num"]) + Convert.ToInt32(num)).ToString();
                FruitPicking[cid] = objjson.ToString();
                return;
            }
            FruitPicking.Add(cid, "{\"name\":\"" + cname + "\",\"num\":" + num + "}");
        }
    }
}
