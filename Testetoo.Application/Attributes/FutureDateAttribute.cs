using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Testetoo.Application.Attributes
{
    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var date = ((DateTime)value).Date;
            var today = DateTime.Today;

            return value != null && date <= today;
        }
    }
}
