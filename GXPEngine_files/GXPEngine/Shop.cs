﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class Shop:GameObject
    {
        List<Fish> fishList;
        Level _level;
        Sound buyFish;
        public Shop(List<Fish> fishListOfTank,Level level)
        {

            _level = level;
            fishList = fishListOfTank;
            buyFish = new Sound("buying_fish_sound.mp3", false, true);
            makeShop();
            
        }
        void makeShop()
        {
            int i = 1;
            int j = 1;
            makeBackground();
            foreach (Fish fish in fishList)
            {
                if (fish.isUnlocked == false)
                {
                    AddChild(fish.buyToUnlock);
                    fish.buyToUnlock.x = i * game.width / 4 - fish.buyToUnlock.width / 2;
                    fish.buyToUnlock.y = j * game.height / 3;

                    makeIconsForFish(i, j, fish);
                    i++;
                    if (i >= 4)
                    {
                        j++;
                        i = 1;
                    }
                }
            }
        }

        private void makeIconsForFish(int i, int j, Fish fish)
        {
            Sprite fishIcon = new Sprite(fish.fishName + "-icon.png");
            AddChild(fishIcon);
            fishIcon.SetOrigin(fishIcon.width / 2, fishIcon.height / 2);
            fishIcon.width /= 8;
            fishIcon.height /= 8;
            fishIcon.x = i * game.width / 4;
            fishIcon.y = j * game.height / 3 - fishIcon.height / 2;
        }

        private void makeBackground()
        {
            Sprite backgroundShop = new Sprite("backgroundShop.png");
            AddChild(backgroundShop);
            backgroundShop.width = game.width - game.width / 5;
            backgroundShop.height = game.height - game.height / 5;
            backgroundShop.x = game.width / 10;
            backgroundShop.y = game.height / 10;
        }

        void Update()
        {
            if (visible == true)
            {
                foreach (Fish fish in fishList)
                {

                    if (MyGame.CheckMouseInRectClick(fish.buyToUnlock))
                    {
                        if (_level.currencySystem.money >= fish.coinValue)
                        {

                            if (fish.isUnlocked == false)
                            {
                                buyFish.Play();
                                _level.currencySystem.RemoveMoney(fish.coinValue);
                                fish.Unlock();
                                _level.journal.AddFish(fish);

                            }

                        }
                    }

                }
            }
        }

    }
}
