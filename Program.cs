using FnafCamerasAttempt;
using Raylib_cs;
using static Raylib_cs.Raylib;

List<Color> colorsForRooms = new List<Color>()
{
    Color.Red, Color.Blue,Color.Green, Color.Orange,Color.Yellow,Color.Black,Color.White,Color.Magenta,Color.Brown
};
List<Room> rooms = new List<Room>();

for (int i = 0;  i < colorsForRooms.Count; i++)
{
    rooms.Add(new Room(i, "something", colorsForRooms[i]));
}


int windowWidth = 800;
int windowHeight = 450;
InitWindow(windowWidth, windowHeight, "Cameras");

int currentCamera = 0;

while(!WindowShouldClose())
{
    if (IsMouseButtonPressed(MouseButton.Left))
    {
        foreach (Room room in rooms)
        {
            if (room.Onclick(GetMouseX(),GetMouseY()) != null)
            {
                currentCamera = room.number;
            }
        }
    }
    BeginDrawing();
    rooms[currentCamera].DrawRoom(windowWidth,windowHeight);
    for (int i = 0; i < rooms.Count;i++)
    {
        rooms[i].DrawCamera();
    }
    EndDrawing();
}

CloseWindow();