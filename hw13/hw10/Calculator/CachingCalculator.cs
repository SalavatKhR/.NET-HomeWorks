#nullable enable
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using hw10.ExpressionTree;
using hw10.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace hw10.Calculator
{
    public class CachingCalculator: ICachingCalculator
    {
        private IMemoryCache cache;

        public CachingCalculator(IMemoryCache memoryCache)
        {
            cache = memoryCache;
        }
        
        public string CalculateWithCache(string input)
        {
            if (cache.TryGetValue(input, out string result))
            {
                return $"{result} (from cache)";
            }
            result = Calculate(input);
            cache.Set(input, result,
                new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));
            return $"{result} (new)";
        } 
        
        public string Calculate(string expression)
        {
            var expressionTree = ExpressionTreeBuilder.BuildTree(expression);
            return CalclateAsync(expressionTree).Result.ToString();
        }

        public async Task<double> CalclateAsync(Expression node)
        {
            if (node is ConstantExpression constant)
            {
                if (constant.Value != null) 
                    return await Task.FromResult((double) constant.Value);
            }
            
            var binaryNode = (BinaryExpression) node;
            var left = CalclateAsync(binaryNode.Left);
            var right = CalclateAsync(binaryNode.Right);
            Task.WaitAll(left, right);
            
            return binaryNode.NodeType switch
            {
                ExpressionType.Add => left.Result + right.Result,
                ExpressionType.Subtract => left.Result - right.Result,
                ExpressionType.Multiply => left.Result * right.Result,
                ExpressionType.Divide => left.Result / right.Result,
            };
        }
    }
}