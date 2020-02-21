using System.ComponentModel.DataAnnotations;

namespace ContaSimples.WebApi.CustomValidator
{
    public class RequiredGreaterThanZero : ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            bool valid = false; 

            if(value.GetType() == typeof(int))
            {
                valid = value != null && int.TryParse(value.ToString(), out int i) && i > 0;
           
            }else if(value.GetType() == typeof(decimal))
            {
                valid = value != null && decimal.TryParse(value.ToString(), out decimal i) && i > 0;
            }

            return valid;
        }
    }
}
