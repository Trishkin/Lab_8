using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_8
{
    public class PriceShouldBePositiveException : ArgumentOutOfRangeException
    {
        public PriceShouldBePositiveException(String message) : base(message)
        {

        }
    }
}
