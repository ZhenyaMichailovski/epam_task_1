using System;
using System.Collections.Generic;
using System.Text;

namespace epam_task_1.Figures
{
    class Rook : Figure
    {
        public bool IsFirstMotion { get; set; }
        public Rook(string name, string color, bool isFirstMotion)
            : base(name, color)
        {
            IsFirstMotion = isFirstMotion;
        }
    }
}
