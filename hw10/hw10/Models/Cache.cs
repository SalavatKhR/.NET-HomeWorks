using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace hw10.Models
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