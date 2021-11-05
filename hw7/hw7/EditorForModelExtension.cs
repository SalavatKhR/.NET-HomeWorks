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
                if (property.PropertyType == typeof(string))
                {
                    builder.AppendHtml(
                        "<div class = \"editor-field\">" +
                        $"<label for=\"{property.Name} \">{name}</label>" +
                        "</div>" + validationResult
                        );
                }
                
                if (property.PropertyType == typeof(int))
                {
                    builder.AppendHtml(
                        "<div class = \"editor-field\">" +
                        $"<label for=\"{property.Name} \">{name}</label>" +
                        "</div>" + validationResult
                    );
                }
                 
                if (property.PropertyType.IsEnum)
                {
                    var fields = property.PropertyType.GetFields();
                    var options = new StringBuilder();
                    foreach (var field in fields)
                    {   
                        if ("value__" == field.Name) continue;
                        options.Append($"<option value=\"{field.Name}\">{field.Name}</option>");
                    }

                    builder.AppendHtml( 
                        "<div class=\"editor-field\">" + 
                        $"<label for=\"{property.Name}\">{name}</label>" +
                        "<p><select class=\"form-select form-select-lb mb-3\">" +
                        $"{options}" +
                        "</select><p></div>"
                        );
                }
            }

            builder.AppendHtml("</fieldset><input type=\"submit\" class=\"btn btn-primary\"> </form>");
            return builder;
        }

		private static string ValidateProperty(PropertyInfo property, object model)
        {
            var builder = new StringBuilder();
            var attribute = property.GetCustomAttribute<ValidationAttribute>();
            var inputType = property.PropertyType.IsValueType ? "number" : "text";
            var val = property.GetValue(model);
            if (attribute == null && !property.PropertyType.IsEnum)
                return
                    $"<div class=\"editor-field\"><input class=\"text-box single-line\" id=\"{property.Name}\"" +
                    $" name=\"{property.Name}\"" +
                    $" type=\"{inputType}\" value=\"{val}\"> <span class=\"field-validation-valid\" " +
                    "data-valmsg-for=\"FirstName\" " +
                    "data-valmsg-replace=\"true\"></span></div>";
            if (attribute != null && attribute.IsValid(val)) 
                return 
                    "<div class=\"editor-field\"> <input class=\"text-box single-line\"" +
                    $"data-val=\"true\" data-val-length={attribute.ErrorMessage}" +
                    $"data-val-length-max=\"10\" data-val-length-min=\"2\" id=\"{property.Name}\""+
                    $"maxlength=\"10\" name=\"{property.Name}\" type=\"{inputType}\" value=\"{val}\"> " +
                    "<span class=\"field-validation-valid\"" +
                    $"data-valmsg-for=\"{property.Name}\" data-valmsg-replace=\"{true}\"></span></div>";
                
            return 
                    "<div class=\"editor-field\"> <input class=\"input-validation-error text-box single-line\"" +
                    $"data-val=\"true\" data-val-length={attribute?.ErrorMessage}" +
                    $"data-val-length-max=\"10\" data-val-length-min=\"2\" id=\"{property.Name}\""+
                    $"maxlength=\"10\" name=\"{property.Name}\" type=\"{inputType}\" value=\"{val}\"> <span class=\"field-validation-error\"" +
                    $"data-valmsg-for=\"{property.Name}\" data-valmsg-replace=\"{true}\">{attribute?.ErrorMessage}</span></div>";
        }
    }
}