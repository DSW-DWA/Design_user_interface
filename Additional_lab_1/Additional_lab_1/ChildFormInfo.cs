using System.Collections.Generic;
using System.Security.Policy;

namespace Additional_lab_1
{
    public class ChildFormInfo
    {
        public string Name;
        public readonly int Number;
        public readonly ChildForm Child;
        public List<ChildForm> Children; 
        public ChildFormInfo(int num, ChildForm child)
        {
            Number = num;
            Name = $"Детка {num}";
            Child = child;
        }

        public ChildFormInfo(List<ChildForm> children)
        {
            Name = $"Все детки";
            Number = -1;
            Children = children;
        }
    }
}