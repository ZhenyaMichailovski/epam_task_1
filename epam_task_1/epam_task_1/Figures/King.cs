using System;
using System.Collections.Generic;
using System.Text;

namespace epam_task_1.Figures
{
    class King : Figure
    {
        public bool IsFirstMotion { get; set; }

        public King(string name, string color, bool isFirstMotion)
            : base(name, color)
        {
            IsFirstMotion = isFirstMotion;
        }
    }
}
