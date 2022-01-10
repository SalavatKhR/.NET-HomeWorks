using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace UiServer.Models
{
    public static class EditorForModelExtension
    {
        public static IHtmlContent MyEditorForModel(this IHtmlHelper htmlHelper)
        {
            var model = htmlHelper.ViewData.Model;
            var properties = model.GetType().GetProperties();
            var builder = new HtmlContentBuilder();

            builder.AppendHtml("<form><fieldset><legend>User's Information</legend>");
            
            foreach (var property in properties)
            {
				var validationResult = ValidateProperty(property, model);
                var name = property.GetCustomAttribute<DisplayAttribute>()?.GetName() 
                           ?? Parser.SplitCamelCase(property.Name);
    
                if (property.PropertyType == typeof(int) || property.PropertyType == typeof(string))
                {
                    builder.AppendHtml(
                        "<div class = \"editor-field\">" +
                        $"<label for=\"{property.Name} \">{name}</label>" +
                        $"{validationResult}" +
                        "</div>"
                    );
                }
                 
                else if (property.PropertyType.IsEnum)
                {
                    var fields = property.PropertyType.GetFields();
                    var options = new StringBuilder();
                    var val = property.GetValue(model);
                    foreach (var field in fields)
                    {   
                        if ("value__" == field.Name) continue;
                        options.Append($"<option value=\"{field.Name}\">{field.Name}</option>");
                    }

                    builder.AppendHtml( 
                        "<div class=\"editor-field\">" + 
                        $"<label for=\"{property.Name}\">{name}</label>" +
                        $"<p><select class=\"form-select form-select-lb mb-3\" name=\"{property.Name}\" value=\"{val}\">" +
                        $"{options}" +
                        "</select><p></div>"
                        );
                }
            }
            
            return builder;
        }

		private static string ValidateProperty(PropertyInfo property, object model)
        {
            var attribute = property.GetCustomAttribute<ValidationAttribute>();
            var rangeAttribute = property.GetCustomAttribute<RangeAttribute>();
            var inputType = property.PropertyType.IsValueType ? "number" : "text";
            var val = property.GetValue(model);
            int min;
            int max;
            if (rangeAttribute != null)
            {
                min = Convert.ToInt32(rangeAttribute.Minimum);
                max = Convert.ToInt32(rangeAttribute.Maximum);
            }
            else
            {
                min = 0;
                max = 100;
            }
            
            if (attribute == null && !property.PropertyType.IsEnum)
                return
                    $"<div class=\"editor-field\">" +
                    $"<input type=\"{inputType}\" class=\"text-box single-line\" required placeholder=\"{property.Name}\"" +
                    $" min=\"{min}\" max=\"{max}\" minlength=\"2\" maxlength=\"15\" name=\"{property.Name}\" " +
                    $"id=\"{property.Name}\" value=\"{val}\">";

            if (attribute != null && attribute.IsValid(val))
                return 
                    $"<div class=\"editor-field\">" +
                    $"<input type=\"{inputType}\" class=\"text-box single-line\" required placeholder=\"{property.Name}\" " +
                    $"min=\"{min}\" max=\"{max}\" minlength=\"2\" maxlength=\"15\"" +
                    $"name=\"{property.Name}\"" +
                    $"id=\"{property.Name}\" value=\"{val}\">";

            return
                $"<div class=\"editor-field\"> " +
                $"<input class=\"input-validation-error text-box single-line\" required " +
                $"name=\"{property.Name}\" type=\"{inputType}\" value=\"{val}\" " +
                $"min=\"{min}\" max=\"{max}\" minlength=\"2\" maxlength=\"15\">";
        }
    }
}