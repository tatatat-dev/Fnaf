
using System.Numerics;
using FnafCamerasAttempt;
using Raylib_cs;
using static Raylib_cs.Raylib;

List<(string cameraNumber, string name,int posX,int posY, Color color)> coordinatesAndImagesForRooms = new List<(string cameraNumber, string name, int posX, int posY, Color color)>()
{
    ("1A","something0",1200,450, Color.Red),
    ("1B","something1",1160,520, Color.Blue),
    ("5","something2", 1020, 550, Color.Green),
    ("7","something3", 1450, 550, Color.Orange),
    ("1C","something4", 1130, 610, Color.Yellow),
    ("67","something5", 1445, 700, Color.Black),
    ("3","something6", 1080, 720, Color.White),
    ("2A","something7", 1180, 750, Color.Magenta),
    ("2B","something8", 1180, 800, Color.Brown),
    ("4A","something9", 1330, 750, Color.Pink),
    ("4B","something10", 1330, 800, Color.DarkGray)

};
List<Room> rooms = new List<Room>();

for (int i = 0;  i < coordinatesAndImagesForRooms.Count; i++)
{
    rooms.Add(new Room(coordinatesAndImagesForRooms[i].cameraNumber,i, coordinatesAndImagesForRooms[i].name, coordinatesAndImagesForRooms[i].posX, coordinatesAndImagesForRooms[i].posY, coordinatesAndImagesForRooms[i].color));
}


int windowWidth = 1600;
int windowHeight = 900;
InitWindow(windowWidth, windowHeight, "Cameras");

SetTargetFPS(60);

bool isCamerasActive = false;
int currentCamera = 0;

Rectangle switchCamerasRec = new Rectangle(500,800,650,75);
Color switchCamerasColor = new Color(128,128,128,70);
bool canSwitch = true;

Vector2 cursorPos = new Vector2(0, 0);
Vector2 pastCursorPos = new Vector2(0, 0);


while(!WindowShouldClose())
{
    cursorPos = new Vector2(GetMouseX(), GetMouseY());
    if (IsMouseButtonPressed(MouseButton.Left))
    {
        foreach (Room room in rooms)
        {
            if (room.OnClick(GetMouseX(),GetMouseY())) currentCamera = room.cameraID;
        }
    }

    if (CheckCollisionPointRec(cursorPos, switchCamerasRec))
    {
        if (canSwitch && pastCursorPos.Y < cursorPos.Y)
        {
            isCamerasActive = !isCamerasActive;
        }
        canSwitch = false;
    }
    else canSwitch = true;

    pastCursorPos = new Vector2(cursorPos.X, cursorPos.Y);
        BeginDrawing();
    if (isCamerasActive)
    {
        rooms[currentCamera].DrawRoom(windowWidth, windowHeight);
        for (int i = 0; i < rooms.Count; i++)
        {
            rooms[i].DrawCamera(currentCamera);
        }
    }
    else
    {
        DrawRectangle(0, 0, windowWidth, windowHeight, Color.Black);
    }
    DrawRectangleRec(switchCamerasRec, switchCamerasColor);
        EndDrawing();
}

CloseWindow();

