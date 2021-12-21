using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace hw7
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
            var inputType = property.PropertyType.IsValueType ? "number" : "text";
            var val = property.GetValue(model);
            if (attribute == null && !property.PropertyType.IsEnum)
                return
                    $"<div class=\"editor-field\">" +
                    $"<input type=\"{inputType}\" class=\"text-box single-line\" placeholder=\"{property.Name}\"" +
                    $" min=\"10\" max=\"110\" minlength=\"2\" maxlength=\"10\" name=\"{property.Name}\" " +
                    $"id=\"{property.Name}\" value=\"{val}\">";

            if (attribute != null && attribute.IsValid(val))
                return 
                    $"<div class=\"editor-field\">" +
                    $"<input type=\"{inputType}\" class=\"text-box single-line\" placeholder=\"{property.Name}\" min=\"10\" max=\"110\" minlength=\"2\" maxlength=\"10\"" +
                    $"name=\"{property.Name}\"" +
                    $"id=\"{property.Name}\" value=\"{val}\">";

            return
                $"<div class=\"editor-field\"> <input class=\"input-validation-error text-box single-line\"" +
                $" name=\"{property.Name}\" type=\"{inputType}\" value=\"{val}\" min=\"10\" max=\"110\" minlength=\"2\" maxlength=\"10\">";
        }
    }
}