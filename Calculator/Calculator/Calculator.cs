using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calculator<T>
    {
        public event EventHandler DivideByZero;

        T value1;
        T value2;

        public Calculator(T a, T b)
        {
            value1 = a;
            value2 = b;
        }

        public T Add()
        {
            dynamic A = value1;
            dynamic B = value2;
            return A + B;
        }

        public T Sub()
        {
            dynamic A = value1;
            dynamic B = value2;
            return A - B;
        }

        public T Mul()
        {
            dynamic A = value1;
            dynamic B = value2;
            return A * B;
        }

        public T Div()
        {
            dynamic A = value1;
            dynamic B = value2;

            if (B == 0)
            {
                OnDivideByZero();
            }

            return A / B;
        }

        void OnDivideByZero()
        {
            DivideByZero?.Invoke(this, EventArgs.Empty);
        }
    }
}
