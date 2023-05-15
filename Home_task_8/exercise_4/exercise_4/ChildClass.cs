using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_4
{
    public class ChildClass : ParentClass
    {
        public void DoSomething()
        {
            // Виклик події у дочірньому класі
            OnEventOccurred(EventArgs.Empty);
        }
    }
}
