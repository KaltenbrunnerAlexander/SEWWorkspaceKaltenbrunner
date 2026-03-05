using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20_MVVM
{
    internal class NumberViewModel
    {
        private NumberModel model = new NumberModel();
        public int Number 
        {
            get
            {
                return model.Number;
            }
            set
            {
                model.Number = value;
            }
            
        }

    }
}
