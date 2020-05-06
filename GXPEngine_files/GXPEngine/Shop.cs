using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class Shop:GameObject
    {
        List<Fish> fishList;
        public Shop(List<Fish> fishListOfTank)
        {
            int i = 1;
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
        void Update()
        {
            foreach (Fish fish in fishList)
            {
                if (Input.GetMouseButtonDown(button: 0))
                {
                    if (Input.mouseX > fish.buyToUnlock.x &&
                        Input.mouseX < fish.buyToUnlock.x + fish.buyToUnlock.width &&
                        Input.mouseY > fish.buyToUnlock.y &&
                        Input.mouseY < fish.buyToUnlock.y + fish.buyToUnlock.height)
                    {
                        fish.Unlock();
                    }
                }

            }
        }

    }
}
