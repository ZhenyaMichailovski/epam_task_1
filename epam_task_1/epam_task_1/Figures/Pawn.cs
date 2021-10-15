using System;
using System.Collections.Generic;
using System.Text;

namespace epam_task_1.Figures
{
    class Pawn : Figure
    {
        private bool IsFirtsMotion { get; set; }
        private bool IsEndOfField { get; set; }
        public Pawn(string name, string color, bool isFirstMotion, bool isEndOfField)
            : base(name, color)
        {
            IsFirtsMotion = false;
            IsEndOfField = false;
        }
    }
}
