
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace FnafCamerasAttempt
{
    public class Room
    {
        public int number;
        public string name;
        public Color color;

        private static int buttonSide = 30;
        private static int distance = 45;
        private static int textSize = 10;

   
        public Room(int newNumber, string newName, Color newColor)
        {
            number = newNumber;
            name = newName;
            color = newColor;
        }
        public void DrawCamera()
        {
            int buttonYPos = distance;
            int buttonXPos = number * distance + distance;
            DrawRectangle(buttonXPos, buttonYPos, buttonSide, buttonSide, Color.Gray);
            DrawText($"CAM{number}", buttonXPos, buttonYPos, textSize, Color.White);
        }

        public int? Onclick(int mouseX, int mouseY)
        {
            int buttonYPos = distance;
            int buttonXPos = number * distance + distance;
            if (mouseX>=buttonXPos && mouseX <=buttonXPos+buttonSide && mouseY>=buttonYPos && mouseY <= buttonYPos+buttonSide) return number;
            return null;
        }
        public void DrawRoom(int width, int height)
        {
            DrawRectangle(0, 0, width, height, color);
        }
    }
}
