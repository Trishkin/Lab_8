using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_8
{
    public class Journal : PrintEdition
    {

        public string Period { get; set; }

        public override bool electronic_analogue()
        { return true; }
        public override string ToString()
        {

            return ($"Type = {GetType().Name}, Author = {Author}, Publisher = {Publisher}, Name = {NameOfBook}, Age = {Age}, Price = {Price}, Period = {Period}");

        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
