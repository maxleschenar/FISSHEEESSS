using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class Shop:GameObject
    {
        List<Fish> fishList;
        Level _level;
        public Shop(List<Fish> fishListOfTank,Level level)
        {
            int i = 1;
            _level = level;
            fishList = fishListOfTank;
            foreach(Fish fish in fishListOfTank)
            {
                if (fish.isUnlocked == false)
                {
                    AddChild(fish.buyToUnlock);
                    fish.buyToUnlock.y = i * 100;
                    i++;
                }
            }
        }
        void makeShop()
        {

        }
        void Update()
        {
            foreach (Fish fish in fishList)
            {
                //if (Input.GetMouseButtonDown(button: 0))
                //{
                    if (MyGame.CheckMouseInRectClick(fish.buyToUnlock))
                    {
                        if (_level.currencySystem.money >= fish.coinValue)
                        {

                            if (fish.isUnlocked == false)
                            {
                                _level.currencySystem.RemoveMoney(fish.coinValue);
                                fish.Unlock();
                                _level.journal.AddFish(fish);

                            }

                        }
                    }
                //}

            }
        }

    }
}
