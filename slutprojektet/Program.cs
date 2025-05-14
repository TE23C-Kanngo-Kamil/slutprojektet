using System.Numerics;
using Raylib_cs;

/* 

    Mål:
    - Rymdskepp (spelaren) som kan röras med piltangenterna
    - Fiender som finns vid toppen av skärmen
    - System där man kan skjuta fienderna med mellanslag
    - Lägga till stjärnor runt om i backgrunden

*/

// Skärmdimensioner
const int screenWidth = 800;
const int screenHeight = 1000;

// Starta spelets fönster
Raylib.InitWindow(screenWidth, screenHeight, "Space Invaders");
Raylib.SetTargetFPS(60);

// Spelarens startposition och hastighet
Vector2 playerPosition = new Vector2(screenWidth / 2, screenHeight - 100);
float playerSpeed = 5.0f;

while (Raylib.WindowShouldClose() == false)
{
    // --- Hantera spelarens rörelse ---

    // Om en piltangent hålls nere:
    // Flytta spelaren i den riktningen
    // Begränsa så att spelaren inte går utanför skärmen

    if (Raylib.IsKeyDown(KeyboardKey.Left) && playerPosition.X > 0)
    {
        playerPosition.X -= playerSpeed;
    }
    if (Raylib.IsKeyDown(KeyboardKey.Right) && playerPosition.X < screenWidth - 50)
    {
        playerPosition.X += playerSpeed;
    }
    if (Raylib.IsKeyDown(KeyboardKey.Up) && playerPosition.Y > 0)
    {
        playerPosition.Y -= playerSpeed;
    }
    if (Raylib.IsKeyDown(KeyboardKey.Down) && playerPosition.Y < screenHeight - 50)
    {
        playerPosition.Y += playerSpeed;
    }

    // --- Rita spelet ---
    // Börja rita skärmen
    // Rensa bakgrunden (svart)
    // Rita spelarens skepp
    // Rita fiender vid toppen
    // Avsluta ritningen

    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.Black);

    // Rita spelarens skepp
    // Rita olika rektanglar för att skapa en skeppform

    // Basen
    Raylib.DrawRectangle((int)playerPosition.X - 10, (int)playerPosition.Y + 10, 20, 10, Color.Orange);
    Raylib.DrawRectangle((int)playerPosition.X - 6, (int)playerPosition.Y + 20, 12, 8, Color.Red);

    // Huvudkropp
    Raylib.DrawRectangle((int)playerPosition.X - 5, (int)playerPosition.Y - 10, 10, 20, Color.LightGray);

    // Vingar
    Raylib.DrawRectangle((int)playerPosition.X - 15, (int)playerPosition.Y, 10, 15, Color.Gray);
    Raylib.DrawRectangle((int)playerPosition.X + 5, (int)playerPosition.Y, 10, 15, Color.Gray);

    // Cockpit
    Raylib.DrawRectangle((int)playerPosition.X - 3, (int)playerPosition.Y - 14, 6, 6, Color.SkyBlue);

    // Rita aliens
    // Definiera ett pixelmönster för en alien
    // Rita 4 stycken aliens på rad med detta mönster

    int alienSize = 6;  // Storlek på varje "pixel"
    int startY = 100;
    int[] alienXPositions = { 100, 250, 400, 550 }; // Positionerna för varje alien

    // Pixelmönstret för en alien (1 = grön pixel, 0 = tom)
    int[,] alienPixels = new int[,]
    {
    {0,0,1,0,0,0,0,1,0,0},
    {0,0,0,1,0,0,1,0,0,0},
    {0,0,1,1,1,1,1,1,0,0},
    {0,1,1,0,1,1,0,1,1,0},
    {1,1,1,1,1,1,1,1,1,1},
    {1,0,1,1,1,1,1,1,0,1},
    {1,0,1,0,0,0,0,1,0,1},
    {0,0,0,1,0,0,1,0,0,0}
    };

    foreach (int baseX in alienXPositions)
    {
        for (int y = 0; y < alienPixels.GetLength(0); y++)
        {
            for (int x = 0; x < alienPixels.GetLength(1); x++)
            {
                if (alienPixels[y, x] == 1)
                {
                    Raylib.DrawRectangle(
                        baseX + x * alienSize,
                        startY + y * alienSize,
                        alienSize,
                        alienSize,
                        Color.Green
                    );
                }
            }
        }
    }

    Raylib.EndDrawing();
}