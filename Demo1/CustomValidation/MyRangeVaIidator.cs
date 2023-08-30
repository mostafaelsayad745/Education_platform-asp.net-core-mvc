using System.ComponentModel.DataAnnotations;

namespace Demo1.CustomValidation
{
    public class MyRangeVaIidator : ValidationAttribute
    {
        public MyRangeVaIidator(int min, int max)
        {
            this.min = min;
            this.max = max;
        }

        public int min { get; set; }
        public int max { get; set; }
        public override bool IsValid(object? value)
        {
            int val = (int)value;
            if(val >= min&& val <=max)
                return true;
            return false;
        }
    }
}
