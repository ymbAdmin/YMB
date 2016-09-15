using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YMB.Extensions
{
    public class ContainsUppsercase : RegularExpressionAttribute
    {
        public ContainsUppsercase()
            : base(@"^(?=.*[A-Z]).+$")
        {
        }
    }
    public class ContainsLowercase : RegularExpressionAttribute
    {
        public ContainsLowercase()
            : base(@"^(?=.*[a-z]).+$")
        {
        }
    }

    public class ContainsDigit : RegularExpressionAttribute
    {
        public ContainsDigit() : base(@"^[0-9]+$")
        {
        }
    }

    public class ContainsSymbol : RegularExpressionAttribute
    {
        public ContainsSymbol() : base(@"^(?=.*[@!#_*$-]).+$")
        {
        }
    }
}