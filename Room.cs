
using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace FnafCamerasAttempt
{
    public class Room
    {
        public string cameraNumber;
        public int cameraID;
        public string name;
        const int textPoseXForName = 1300;
        const int textPoseYForName = 20;
        const int textSizeForName = 50;
        

        public Color color;

        const int buttonSideX = 70;
        const int buttonSideY = 40;
        private Rectangle buttonRec;
        private Rectangle buttonEdgeRec;
        const int cameraEdge = 3;
        const int textSizeCamera = 17;
        const int textIndentCamera = 3;

        public Room(string newCameraNumber,int newCameraID, string newName, int buttonX, int buttonY, Color newColor)
        {
            cameraNumber = newCameraNumber;
            cameraID = newCameraID;
            name = newName;

            color = newColor;


            buttonRec = new Rectangle(buttonX,buttonY,buttonSideX,buttonSideY);
            buttonEdgeRec = new Rectangle(buttonX - cameraEdge, buttonY - cameraEdge, buttonSideX + cameraEdge * 2, buttonSideY + cameraEdge * 2);
        }
        public void DrawCamera(int currentRoom)
        {
            Color colorForActiveCamera = Color.DarkGray;
            if (currentRoom == cameraID) 
            { 
                colorForActiveCamera = Color.Gray;
            }
            DrawRectangleRec(buttonEdgeRec, Color.White);
            DrawRectangleRec(buttonRec, colorForActiveCamera);
            DrawText("CAM", (int)buttonRec.X+textIndentCamera, (int)buttonRec.Y + textIndentCamera, textSizeCamera, Color.White);
            DrawText($"{cameraNumber}", (int)buttonRec.X + textIndentCamera, (int)buttonRec.Y+ textSizeCamera + textIndentCamera, textSizeCamera, Color.White);
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
            DrawText($"{name}", textPoseXForName, textPoseYForName, textSizeForName, Color.White);
        }
    }
}
