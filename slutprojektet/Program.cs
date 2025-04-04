using System.Numerics;
using Raylib_cs;

/* 

    Rymdskepp (spelaren) som kan röras med piltangenterna
    Fiender som kommer fram från toppen av skärmen
    System där man kan skjuta fienderna med mellanslag

*/

// Skärmdimensioner
const int screenWidth = 800;
const int screenHeight = 1000;

Raylib.InitWindow(screenWidth, screenHeight, "Space Invaders");
Raylib.SetTargetFPS(60);

// Rymdskepp dimensioner
Vector2 playerPosition = new Vector2(screenWidth / 2, screenHeight - 100);
float playerSpeed = 5.0f;

// Spelets loop
while (Raylib.WindowShouldClose() == false)
{

    // Rörelsekontroller
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

    // Ritar mappen
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.Black);

    // Ritar rymdskeppet
    Raylib.DrawTriangle(
        new Vector2(playerPosition.X, playerPosition.Y - 20),
        new Vector2(playerPosition.X - 20, playerPosition.Y + 20),
        new Vector2(playerPosition.X + 20, playerPosition.Y + 20),
        Color.Green
    );

    Raylib.EndDrawing();
}