using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstazioneOrdini
{
    public static class Func
    {

        public static float StringToFloat(string c)
        {
            try
            {
                float f = float.Parse(c);
                return f;
            }
            catch (Exception)
            {

                return 0;
            }

        }

        public static int StringToInt(string c)
        {
            try
            {
                int f = int.Parse(c);
                return f;
            }
            catch (Exception)
            {

                return 0;
            }

        }

        //public static string StringToString(string c)
        //{
        //    try
        //    {
        //        string f = Convert.ToString(c);
        //        return f;
        //    }
        //    catch (Exception)
        //    {

        //        return "0";
        //    }

        //}

    }
}
