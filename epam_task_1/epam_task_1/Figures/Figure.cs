using System;
using System.Collections.Generic;
using System.Text;

namespace epam_task_1.Figures
{
    public class Figure
    {
        public string Name { get; set; }
        public string Color { get; set; }
        
        public Figure(string name, string color)
        {
            Name = name;
            Color = color;
        }
    }
}
