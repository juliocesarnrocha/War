﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace War
{
    class Button
    {
        private Vector2 buttonPos;
        private Texture2D buttonTexture;
        private String imgFile;
        private BoundingBox box;
        private int currentFrame;
       
        public Button(int x, int y)
        {
            
            buttonPos = new Vector2(x, y);
            currentFrame = 0;

            
           

        }
        public Boolean isInRange(int x, int y)
        {
            return true;
        }
        public Vector2 getButtonPosition()
        {
            return buttonPos;
        }
        public Texture2D getButtonTexture()
        {
            return buttonTexture;
        }
        public String getImgFile()
        {
            return imgFile;
        }
        public void setButtonPosition(Vector2 v)
        {
            buttonPos = v;
        }
        public void setButtonTexture(Texture2D t)
        {
            buttonTexture = t;
        }
        public void getImgFile(String s)
        {
            imgFile = s;
        }
        public Boolean isCollided(float x, float y)
        {
            if (x > buttonPos.X && x < buttonPos.X + buttonTexture.Width && y > buttonPos.Y && y < buttonPos.Y + buttonTexture.Height)
                return true;
            else
                return false;
        }
        public void changeCurrentFrame(float x, float y)
        {
            if (x > buttonPos.X && x < buttonPos.X + buttonTexture.Width/2 && y > buttonPos.Y && y < buttonPos.Y + buttonTexture.Height)
                currentFrame = 1;
            else
                currentFrame = 0;
        }
        public Rectangle getCurrentFrame()
        {
            return new Rectangle(currentFrame *200, 0, 200, 100);
        }
        
          


    }
}
