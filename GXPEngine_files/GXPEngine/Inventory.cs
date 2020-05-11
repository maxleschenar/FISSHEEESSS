﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    public class Inventory:GameObject
    {
        public const int Food = 1;
        public const int Sponge = 2;
        public const int Shop = 3;
        Item food;
        Item sponge;
        Item shop;
        Sprite emptySpace1;
        Sprite emptySpace2;
        Sprite emptySpace3;
        List<Item> listOfItemsInInventory;
        public int id=0;
        //Sprite emptySpace4;
        public Inventory()
        {
            listOfItemsInInventory = new List<Item>();
            food = new Item("fish_food.png",Food);
            sponge = new Item("sponge.png",Sponge);
            shop = new Item("shop.png",Shop);
            emptySpace1 = new Sprite("checkers.png");
            emptySpace2 = new Sprite("checkers.png");
            emptySpace3 = new Sprite("checkers.png");

            emptySpace1.x = game.width - 100;
            emptySpace2.x = game.width - 100;
            emptySpace3.x = game.width - 100;
            emptySpace1.y = 150;
            emptySpace2.y = 300;
            emptySpace3.y = 450;
            //emptySpace1.width /= 5;
            //emptySpace1.height /= 5;
           // emptySpace2.width /= 5;
            //emptySpace2.height /= 5;
           // emptySpace3.width /= 5;
           // emptySpace3.height /= 5;

            AddChild(emptySpace1);
            AddChild(emptySpace2);
            AddChild(emptySpace3);

            food.x = emptySpace1.x;
            food.y = emptySpace1.y;
            food.width /= 6;
            food.height /= 6;
           // AddChild(food);

            sponge.x = emptySpace2.x;
            sponge.y = emptySpace2.y;
            sponge.width -= sponge.width/3;
            sponge.height -= sponge.height /3;
           // AddChild(sponge);

            shop.x = emptySpace3.x;
            shop.y = emptySpace3.y;
            shop.width /= 6;
            shop.height /= 6;
            //AddChild(shop);
            listOfItemsInInventory.Add(food);
            listOfItemsInInventory.Add(sponge);
            listOfItemsInInventory.Add(shop);
            //emptySpace4 = new Sprite("checkers.png");
            AddChild(food);
            AddChild(sponge);
            AddChild(shop);
        }
        void Update()
        {
            checkIfItemIsPressed();
            checkID();
        }
        void checkIfItemIsPressed()
        {
            foreach(Item item in listOfItemsInInventory)
            {
                if (MyGame.CheckMouseInRectClick(item))
                {
                    if (item.selected == false)
                    {
                        foreach (Item thing in listOfItemsInInventory)
                        {
                            if (thing != item)
                            {
                                thing.selected = false;
                            }
                            else thing.selected = true;
                        }
                        id = item.id;
                    }
                    else
                    {
                        item.selected = false;
                        id = 0;
                    }
                    
                }
            }
        }
        public bool checkIfItemIsOverlapped()
        {
            foreach (Item item in listOfItemsInInventory)
            {
                if (MyGame.CheckMouseInRect(item))
                {
                    return true;
                }
            }
            return false;
        }

        void checkID()
        {
            switch (id)
            {
                case Food:
                    //RemoveChild(food);
                    food.visible = false;
                    sponge.visible = true;
                    //shop.visible = true;
                    //AddChild(sponge);
                    //AddChild(shop);
                    break;
                case Sponge:
                    //RemoveChild(sponge);
                    //AddChild(food);
                    //AddChild(shop);
                    food.visible = true;
                    sponge.visible = false;
                   // shop.visible = true;
                    break;
                case Shop:
                    ////RemoveChild(shop);
                    //AddChild(sponge);
                    //AddChild(food);
                    food.visible = true;
                    sponge.visible = true;
                    //shop.visible = true;
                    break;
                case 0:
                    //AddChild(food);
                    //AddChild(sponge);
                    //AddChild(shop);
                    food.visible = true;
                    sponge.visible = true;
                    //shop.visible = true;
                    break;
            }
        }
    }
}
