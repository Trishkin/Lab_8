using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_8
{
    public abstract class PrintEdition
    {
        public string Author, Publisher;
        private string _nameOfBook;
        public string NameOfBook
        {
            get
            {
                return _nameOfBook;
            }
            set
            {
                if (value == "")
                {
                    throw new NoNameOfBookException("You should write the name of Book");
                }

                else
                {
                    _nameOfBook = value;
                }
            }
        }

        public int Age { get; set; }
        private double _price;
        public double Price
        {
            get
            {
                return _price;
            }

            set
            {
                if (value < 0)
                {
                    throw new PriceShouldBePositiveException("Price should be positive");
                }
                else
                {
                    _price = value;
                }
            }
        }
        //public virtual void info()
        //{
        //    Console.WriteLine($"Author = {Author}, Publisher = {Publisher}, Name = {NameOfBook}, Age = {Age}, Price = {Price}");
        //}
        public abstract bool electronic_analogue();
        public override string ToString()
        {
            return $"Author = {Author}, Publisher = {Publisher}, Name = {NameOfBook}, Age = {Age}, Price = {Price}";
        }
    }
}
