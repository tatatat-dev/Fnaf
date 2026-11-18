
using System.Numerics;
using FnafCamerasAttempt;
using Raylib_cs;
using static Raylib_cs.Raylib;

List<(string name,int posX,int posY, Color color)> coordinatesAndImagesForRooms = new List<(string name, int posX, int posY, Color color)>()
{
    ("something0",1200,450, Color.Red),
    ("something1",1160,520, Color.Blue),
    ("something2", 1020, 550, Color.Green),
    ("something3", 1450, 550, Color.Orange),
    ("something4", 1130, 610, Color.Yellow),
    ("something5", 1445, 700, Color.Black),
    ("something6", 1080, 720, Color.White),
    ("something7", 1180, 750, Color.Magenta),
    ("something8", 1180, 800, Color.Brown),
    ("something9", 1330, 750, Color.Pink),
    ("something10", 1330, 800, Color.DarkGray)

};
List<Room> rooms = new List<Room>();

for (int i = 0;  i < coordinatesAndImagesForRooms.Count; i++)
{
    rooms.Add(new Room(i, coordinatesAndImagesForRooms[i].name, coordinatesAndImagesForRooms[i].posX, coordinatesAndImagesForRooms[i].posY, coordinatesAndImagesForRooms[i].color));
}


int windowWidth = 1600;
int windowHeight = 900;
InitWindow(windowWidth, windowHeight, "Cameras");

SetTargetFPS(60);

int currentCamera = 1;

while(!WindowShouldClose())
{
    if (IsMouseButtonPressed(MouseButton.Left))
    {
        foreach (Room room in rooms)
        {
            if (room.OnClick(GetMouseX(),GetMouseY())) currentCamera = room.number;
        }
    }
    BeginDrawing();
    rooms[currentCamera].DrawRoom(windowWidth,windowHeight);
    for (int i = 0; i < rooms.Count;i++)
    {
        rooms[i].DrawCamera(currentCamera);
    }
    EndDrawing();
}

CloseWindow();

