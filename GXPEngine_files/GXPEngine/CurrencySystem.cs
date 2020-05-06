using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class CurrencySystem:GameObject
    {
        int money=0;
        public CurrencySystem()
        {

        }

        public void AddMoney(int addition)
        {
            money += addition;
        }
        public void RemoveMoney(int subtraction)
        {
            money -= subtraction;
        }
    }
}
