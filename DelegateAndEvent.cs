using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    class DelegateAndEvent
    {
        #region  Custom delegate and Event
        public delegate void CalculationDelegate(double a, double b, string op);

        public event EventHandler ProcessWhenClickEvent;

        private event CalculationDelegate _CalculationEvent;
        public event CalculationDelegate CalculationEvent
        {
            add
            {
                _CalculationEvent += value;
            }
            remove
            {
                _CalculationEvent -= value;
            }
        }
        #endregion

        #region  Method active event - Phương thức kích hoạt sự kiện
        public void OnCalculation(double a, double b, string op)
        {

            if (_CalculationEvent != null)
                _CalculationEvent(a, b, op);
        }

        public void OnProcessWhenClickEvent()
        {
            if (ProcessWhenClickEvent != null)
                ProcessWhenClickEvent(this, EventArgs.Empty);
        }
        #endregion

    }
}
