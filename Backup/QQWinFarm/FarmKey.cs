using System;
using System.Collections.Generic;
using System.Text;

namespace QQWinFarm
{
    public class FarmKey
    {
        public static double NetworkDelay = 0;
        #region 获得FarmTime
        /// <summary> 
        /// 获得FarmTime 
        /// </summary> 
        /// <returns></returns> 
        public static string GetFarmTime()
        {
            return Math.Floor((DateTime.Now - new DateTime(1970, 1, 1, 8, 0, 0)).TotalSeconds - NetworkDelay).ToString();
        }
        #endregion

        #region 获得FarmKey
        /// <summary> 
        /// 获得FarmKey 
        /// </summary> 
        /// <param name="farmTime">farmTime</param> 
        /// <returns></returns> 
        public static string GetFarmKey(string farmTime)
        {
            return Utils.getMd5Hash2(farmTime + "sdoit78sdopig7w34057".Substring(Convert.ToInt32(farmTime) % 10));
        }
        #endregion
    }
}
