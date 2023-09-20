
namespace SdekService.Services
{
    #region Class Utils
    /// <summary>
    /// Класс утилит для работы со значениями
    /// </summary>
    public static class Utils
    {
        #region Public Methods
        /// <summary>
        /// Возвоащает вес посылки в килограммах
        /// </summary>
        /// <param name="weight"></param>
        /// <returns></returns>
        public static float MakeWeightFromGrammToKG(int weight)
        {                      
          return (float)((Convert.ToDouble(weight) / 1000));
        }

        /// <summary>
        /// Возвращает вес параметра (длина, высота, ширина) в сантиметрах
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static int MakeParamFromMmToCm(int param)
        {
            double paramInCm = Convert.ToDouble(param)/1000;

            return (int)Math.Ceiling(paramInCm);
        }

        /// <summary>
        /// Возвращает true, если все параметры заданны корректно
        /// </summary>
        /// <param name="weight_gr"></param>
        /// <param name="lenght_mm"></param>
        /// <param name="width_mm"></param>
        /// <param name="height_mm"></param>
        /// <returns></returns>
        public static bool CheckAllParameters(int weight_gr, int lenght_mm, int width_mm, int height_mm)
        {
            if(CheckOneParameter(weight_gr) && CheckOneParameter(lenght_mm) && CheckOneParameter(width_mm) && CheckOneParameter(height_mm))
            {
                return false;
            }
            return true;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Возвращает true, если параметр задан корректно 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>        
        private static bool CheckOneParameter(int param)
        {
            if(param <= 0)
                return false;
            return true;
        }
        #endregion
    }
    #endregion
}