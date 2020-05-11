﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{

    public class Scene : GameObject
    {
        Sprite tank, downArrow;
        Level level;
        int timer = 1000;
        public bool isActive;
        bool canMakeFood;
        Sponge sponge;
        Sprite foodCan;
        public List<Food> foodList;
        List<Fish> fishListPerScene;
        Shop shop;
        Inventory inv;
        public CurrencySystem _currency;
        int cleanMeter = 0;
        int scene;
        int priceOfAquarium;
        bool isBought = false;
        bool isOneFishShown = false;
        Sprite clickToBuy;
        //Tutorial _tutorial;
        Sound cleanDirtWithSponge;
        SoundChannel spongeClean;
        Sound repairAquarium;
        Sound makeFoodSound;
        Sound openShop;
        SoundChannel openShopSoundChannel;

        public Scene(string path, CurrencySystem currency, Level level, int scene, int price = 400,Tutorial tutorial=null) : base()
        {
          //  _tutorial = tutorial;

            this.scene = scene;
            _currency = currency;
            visible = false;
            this.level = level;
            isActive = false;
            canMakeFood = true;
            tank = new Sprite(path);
            downArrow = new Sprite("downarrow.png");

            downArrow.SetXY(game.width / 2, game.height - 200);
            downArrow.SetScaleXY(0.2f);
            foodList = new List<Food>();
            AddChildAt(tank, 0);
            AddChild(downArrow);
            priceOfAquarium = price;

            fishListPerScene = new List<Fish>();
            DisplayFishInScene fishes = new DisplayFishInScene(scene, foodList, fishListPerScene);
            sponge = new Sponge(this);
            shop = new Shop(fishListPerScene, level);
            inv = new Inventory();
            clickToBuy = new Sprite("checkers.png");
            clickToBuy.width = 200;
            clickToBuy.height = 200;
            clickToBuy.y += 300;
            AddChild(clickToBuy);
            foodCan = new Sprite("fish_food.png");
            foodCan.SetOrigin(foodCan.width / 4, 0);
            foodCan.width /= 5;
            foodCan.height /= 5;
            for (int i = 0; i < 30; i++)
            {
                Dirt dirt = new Dirt(ref cleanMeter);
                sponge.addDirt(dirt);
                AddChild(dirt);
            }
            AddChild(shop);
            shop.visible = false;
            cleanDirtWithSponge = new Sound("sponge_use_sound.wav", true, true);
            //spongeClean = cleanDirtWithSponge.Play();
            //spongeClean.Stop();
            repairAquarium = new Sound("repair_aquarium_sound.wav", false, true);
            makeFoodSound = new Sound("fish_food_pick_sound.wav", false, true);
            openShop = new Sound("opening_journal_shop_sound.wav", false, true);
           // openShopSoundChannel = openShop.Play();

        }
        void addFish()
        {
            foreach (Fish fish in fishListPerScene)
            {
                if (fish.isUnlocked == true)
                {
                    if (fish.isAdded == false)
                    {
                        AddChildAt(fish, 1);
                        fish.isAdded = true;
                        if (isOneFishShown == false)
                        {
                            isOneFishShown = true;
                        }
                    }
                }
            }
        }
        void makeFood()
        {
            if (Input.GetMouseButtonDown(button: 0) && canMakeFood)
            {
                Food food = new Food();
                AddChildAt(food, 1);
                foodList.Add(food);
                makeFoodSound.Play();
            }
        }
        int tutorialIndex=2;
        void Update()
        {
            //if (_tutorial != null)
            //{
            //    _tutorial.visible = true;
            //}
            //if (_tutorial != null)
            //{
            //    Console.WriteLine("this is scene " + (_tutorial.visible));
            //}

            if (isActive)
            {
                if (isBought == true)
                {
                    //makeTutorialAppear();
                   // ChangeTutorialMaxFrame(4);
                    canMakeFood = true;
                    addFish();
                    //if (_tutorial == null)
                    //{
                        switch (inv.id)
                        {
                            case Inventory.Food:
                                if (inv.checkIfItemIsOverlapped() == false)
                                {
                                    makeFood();
                                }
                                displayFoodCan();
                                moveFoodCan();
                                RemoveShop();
                                RemoveSponge();
                                break;
                            case Inventory.Sponge:
                                displaySponge();
                                RemoveShop();
                                RemoveFoodCan();
                                break;
                            case Inventory.Shop:
                                displayShop();
                                RemoveSponge();
                                RemoveFoodCan();
                                break;
                            case 0:
                                RemoveShop();
                                RemoveSponge();
                                handleMoney();
                                RemoveFoodCan();
                                goBack();
                                break;
                        }
                        if (isOneFishShown == true)
                        {
                            makeDirt();
                        }
                    //}
                    //else
                    //{
                    //    switch (inv.id)
                    //    {
                    //        case Inventory.Food:
                    //            if (_tutorial.currentFrame == 7)
                    //            {
                    //                if (inv.checkIfItemIsOverlapped() == false)
                    //                {
                    //                    makeFood();
                    //                }
                    //                displayFoodCan();
                    //                moveFoodCan();
                    //                RemoveShop();
                    //                RemoveSponge();
                    //            }
                    //            break;
                    //        case Inventory.Sponge:
                    //            if (_tutorial.currentFrame >= 3)
                    //            {
                    //                displaySponge();
                    //                //Console.WriteLine("not clean");
                    //                //RemoveShop();
                    //                //RemoveFoodCan();
                    //                if (_tutorial.visible == true)
                    //                {
                    //                    _tutorial.currentFrame++;
                    //                }
                    //                if (cleanMeter == 0)
                    //                {
                    //                    Console.WriteLine("clean");
                    //                    tutorialIndex++;
                    //                    ChangeTutorialMaxFrame();
                    //                    inv.id = 0;
                    //                }
                    //                else Console.WriteLine("not clean");

                    //            }
                    //            break;
                    //        case Inventory.Shop:
                    //            if (_tutorial.currentFrame >= 4)
                    //            {
                    //                if (_tutorial.visible == true && _tutorial.currentFrame == 4)
                    //                {
                    //                    _tutorial.currentFrame++;
                    //                    tutorialIndex++;
                    //                    ChangeTutorialMaxFrame();
                    //                }
                    //                if (_tutorial.visible == false && _tutorial.currentFrame == 5)
                    //                {
                    //                    tutorialIndex++;
                    //                    ChangeTutorialMaxFrame();
                    //                }
                    //                displayShop();
                    //                RemoveSponge();
                    //                RemoveFoodCan();
                    //            }
                    //            break;
                    //        case 0:
                    //            //if (_tutorial.currentFrame == 7)
                    //            // {
                    //            RemoveShop();
                    //            RemoveSponge();
                    //            handleMoney();
                    //            RemoveFoodCan();
                    //            // }
                    //            goBack();
                    //            break;
                    //    }
                    //    if (isOneFishShown == true)
                    //    {
                    //        if (shop.visible == true && (_tutorial.currentFrame == 5 || _tutorial.currentFrame == 6))
                    //        {
                    //            if (_tutorial.currentFrame == 5)
                    //            {
                    //                _tutorial.currentFrame++;
                    //            }
                    //            tutorialIndex += 2;
                    //            ChangeTutorialMaxFrame();
                    //            inv.id = 0;
                    //        }
                    //    }
                    //    if (isOneFishShown == true)
                    //    {
                    //        makeDirt();
                    //    }
                    //}

                }
                else
                {
                    //makeTutorialAppear();
                   // ChangeTutorialMaxFrame();
                    goBack();
                    buyAquarium();
                }
   

            }
            //if (isBought == true)
            //{
            //    if (isOneFishShown == true)
            //    {
            //        makeDirt();
            //    }
            //}
            //if (_tutorial != null)
            //{
            //    Console.WriteLine("this is scene" + (_tutorial.visible));
            //}
        }
        //void makeTutorialDissapear()
        //{
        //    if (_tutorial != null)
        //    {
        //        _tutorial.BecomeInvisible();
        //    }
        //}
        //void makeTutorialAppear()
        //{
        //    if (_tutorial != null)
        //    {
        //        _tutorial.BecomeVisible();
        //      //  _tutorial.maxFrameToChange++;
        //    }
        //}
        //void ChangeTutorialMaxFrame()
        //{
        //    if (_tutorial != null)
        //    {
        //        _tutorial.maxFrameToChange=tutorialIndex;
        //    }
        //}
        //void ChangeTutorialFrame()
        //{
        //    if (_tutorial != null)
        //    {
        //        _tutorial.currentFrame++;
        //    }
        //}

        void buyAquarium()
        {

            //Console.WriteLine(_tutorial.visible);
            if (MyGame.CheckMouseInRectClick(clickToBuy))
            {
                if (level.currencySystem.money >= priceOfAquarium)
                {
                    clickToBuy.LateDestroy();
                    isBought = true;
                    AddChild(inv);
                    level.currencySystem.RemoveMoney(priceOfAquarium);
                    repairAquarium.Play();
                    //if (_tutorial.visible == true)
                    //{
                    //    ChangeTutorialFrame();
                    //}

                    //tutorialIndex += 1;
                    //ChangeTutorialMaxFrame();
                }

            }
        }

        void handleMoney()
        {
            foreach (Fish fish in fishListPerScene)
            {
                if (fish.isUnlocked == true)
                {

                    if (fish.isFishHungry > 3000 && cleanMeter < 75)
                    {
                        if (fish.FishProgrss >= 3000)
                        {
                            Coin coin = new Coin(fish, level);
                            AddChildAt(coin, 1);
                            fish.FishProgrss = 0;
                        }
                        else
                        {
                            fish.FishProgrss += Time.deltaTime;
                        }
                    }
                }
            }

        }
        void makeDirt()
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                Dirt dirt = new Dirt(ref cleanMeter);
                sponge.addDirt(dirt);
                AddChild(dirt);
                timer = 1000;
            }
        }

        public void removeDirtConsequence(Dirt dirt)
        {
            cleanMeter -= dirt.cleanImpact;
        }

        void goBack()
        {
            if (MyGame.CheckMouseInRectClick(downArrow))
            {
                isActive = false;
                level.isInScene = false;
                visible = false;
                if (HasChild(shop))
                {
                    RemoveChild(shop);
                }
               // makeTutorialDissapear();
            }
        }

        bool spongeOnScreen = false;
        void displaySponge()
        {
            if (spongeOnScreen == false)
            {
                spongeClean=cleanDirtWithSponge.Play();
                AddChild(sponge);
                spongeOnScreen = true;
            }
        }
        void RemoveSponge()
        {
            if (spongeOnScreen == true)
            {
                spongeClean.Stop();
                RemoveChild(sponge);
                spongeOnScreen = false;
            }


        }
        void moveFoodCan()
        {
            foodCan.x = Input.mouseX;
            foodCan.y = Input.mouseY;
        }
        void displayFoodCan()
        {
            if (isFoodDisplayed == false)
            {
                AddChild(foodCan);
                isFoodDisplayed = true;
            }
        }
        void RemoveFoodCan()
        {
            if (isFoodDisplayed == true)
            {
                RemoveChild(foodCan);
                isFoodDisplayed = false;
            }


        }
        bool isShopDisplayed = false;
        bool isFoodDisplayed = false;
        void displayShop()
        {
            AddChild(shop);

            if (isShopDisplayed == false)
            {
                openShopSoundChannel = openShop.Play();
                shop.visible = true;
                isShopDisplayed = true;
            }

        }
        void RemoveShop()
        {
            if (isShopDisplayed == true)
            {
                RemoveChild(shop);
                openShopSoundChannel.Stop();
                shop.visible = false;
                isShopDisplayed = false;
            }
        }
    }
}
