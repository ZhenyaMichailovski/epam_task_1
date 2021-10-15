using System;
using System.Collections.Generic;
using System.Text;

namespace epam_task_1.Figures
{
    class Pawn : Figure
    {
        public bool IsFirtsMotion { get; set; }

        public Pawn(string name, string color, bool isFirstMotion)
            : base(name, color)
        {
            IsFirtsMotion = isFirstMotion;
        }
    }
}
