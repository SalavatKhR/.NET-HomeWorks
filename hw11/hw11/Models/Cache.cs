using System.ComponentModel.DataAnnotations;

namespace hw11.Models
{
    public class Cache
    {
        [Key]
        public string Expression { get; set; }
        public string Value { get; set; }

        public Cache(string expression, string value)
        {
            Expression = expression;
            Value = value;
        }
    }
}