using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_8
{
    public class NoNameOfBookException : Exception
    {
        public NoNameOfBookException(String message) : base(message)
        {

        }
    }
}
