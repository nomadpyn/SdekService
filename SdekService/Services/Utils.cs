
namespace SdekService.Services
{
    public static class Utils
    {

        // метод для преобразования веса из грамм в кг ( сдэк апи принимает кг)
        public static float MakeWeightFromGrammToKG(int weight)
        {                      
          return (float)((Convert.ToDouble(weight) / 1000));
        }

        // метод для преобразование параметров посылки из мм в см (сдэк апи принимает см)
        public static int MakeParamFromMmToCm(int param)
        {
            double paramInCm = Convert.ToDouble(param)/1000;

            return (int)Math.Ceiling(paramInCm);
        }

        // метод проверки параметров на корректность данных (параметры из запроса)
        public static bool CheckAllParameters(int weight_gr, int lenght_mm, int width_mm, int height_mm)
        {
            if(CheckOneParameter(weight_gr) && CheckOneParameter(lenght_mm) && CheckOneParameter(width_mm) && CheckOneParameter(height_mm))
            {
                return false;
            }
            return true;
        }

        // метод проверки одного параметра
        
        private static bool CheckOneParameter(int param)
        {
            if(param <= 0)
                return false;
            return true;
        }
    }
}