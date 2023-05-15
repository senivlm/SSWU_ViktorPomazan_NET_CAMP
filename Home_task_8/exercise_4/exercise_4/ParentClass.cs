using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_4
{
    public class ParentClass
    {
        // Подія, яку можна генерувати
        public event EventHandler EventOccurred;

        // Метод, що генерує подію
        protected virtual void OnEventOccurred(EventArgs e)
        {
            EventHandler handler = EventOccurred;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
