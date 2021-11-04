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
                if (property.PropertyType == typeof(string))
                {
                    builder.AppendHtml(
                        "<div class = \"editor-field\">" +
                        $"<label for=\"{property.Name} \">{property.Name}</label>" +
                        $"<p><input  type = \"text \" id=\"{property.Name}\"></p>" +
                        "</div>"
                        );
                }
                
                if (property.PropertyType == typeof(int))
                {
                    builder.AppendHtml(
                        "<div class = \"editor-field\">" +
                        $"<label for=\"{property.Name} \">{property.Name}</label>" +
                        $"<p><input type=\"number\" min=\"1\" max=\"100\" step=\" id=\"{property.Name}\"></p>" +
                        "</div>"
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
                        $"<label for=\"{property.Name}\">{property.Name}</label>" +
                        "<p><select class=\"form-select form-select-lb mb-3\">" +
                        $"{options}" +
                        "</select><p></div>"
                        );
                }
            }

            builder.AppendHtml("</fieldset><input type=\"submit\" class=\"btn btn-primary\"> </form>");
            return builder;
        }
    }
}