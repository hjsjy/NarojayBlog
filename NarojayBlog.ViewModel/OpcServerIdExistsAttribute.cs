using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace NarojayBlog.ViewModel
{
    public class OpcServerIdExistsAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                var serverId = value.ToString();
                var error = new
                {
                    Code = "asdasda",
                    Content = $"The OpcServer Id does not exist."
                };
                return new ValidationResult(JsonConvert.SerializeObject(error));
            }
            catch (Exception e)
            {
                return new ValidationResult(e.Message);
            }
        }
    }
}
