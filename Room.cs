
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace FnafCamerasAttempt
{
    public class Room
    {
        public int number;
        public string name;
        public Color color;

        const int buttonSideX = 70;
        const int buttonSideY = 40;
        private Rectangle buttonRec;
        const int textSize = 25;

        private int buttonYPos;
        private int buttonXPos;

        public Room(int newNumber, string newName, int buttonX, int buttonY, Color newColor)
        {
            number = newNumber;
            name = newName;

            buttonXPos = buttonX;
            buttonYPos = buttonY;

            color = newColor;


            buttonRec = new Rectangle(buttonXPos,buttonYPos,buttonSideX,buttonSideY);
        }
        public void DrawCamera(int currentRoom)
        {
            Color colorForActiveCamera = Color.Gray;
            if (currentRoom == number) 
            { 
                colorForActiveCamera = Color.LightGray;
                DrawText($"{name}", 1200, 20, 50, Color.White);
            }
            DrawRectangle(buttonXPos, buttonYPos, buttonSideX, buttonSideY, colorForActiveCamera);
            DrawText($"CAM{number}", buttonXPos, buttonYPos, textSize, Color.White);
        }

        public bool OnClick(int mouseX, int mouseY)
        {
            Vector2 mousePos = new Vector2(mouseX, mouseY);
            
            if (CheckCollisionPointRec(mousePos,buttonRec)) return true;
            return false;
        }
        public void DrawRoom(int width, int height)
        {
            DrawRectangle(0, 0, width, height, color);
        }
    }
}
