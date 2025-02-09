![logo](https://raw.githubusercontent.com/danilwhale/Raylib-cs.BleedingEdge/main/Assets/Logo-96.png)

### Raylib-cs.BleedingEdge
C# bindings for raylib, a simple and easy-to-use library to learn videogames programming (www.raylib.com)

[![NuGet Downloads](https://img.shields.io/nuget/dt/Raylib-cs.BleedingEdge?style=flat-square&logo=nuget)](https://www.nuget.org/packages/Raylib-cs.BleedingEdge)
[![GitHub License](https://img.shields.io/github/license/danilwhale/Raylib-cs.BleedingEdge?style=flat-square)](https://github.com/danilwhale/Raylib-cs.BleedingEdge/blob/main/LICENSE)
[![Discord](https://img.shields.io/discord/426912293134270465?style=flat-square&logo=discord&logoColor=white)](https://discord.gg/raylib)
[![GitHub Repo stars](https://img.shields.io/github/stars/danilwhale/Raylib-cs.BleedingEdge?style=flat-square)](https://github.com/danilwhale/Raylib-cs.BleedingEdge/stargazers)
[![GitHub commit activity](https://img.shields.io/github/commit-activity/w/danilwhale/Raylib-cs.BleedingEdge?style=flat-square)](https://github.com/danilwhale/Raylib-cs.BleedingEdge/commits/main/)
[![GitHub Actions Workflow Status](https://img.shields.io/github/actions/workflow/status/danilwhale/Raylib-cs.BleedingEdge/build.yml?style=flat-square&logo=githubactions&logoColor=white)](https://github.com/danilwhale/Raylib-cs.BleedingEdge/actions)

---

Raylib-cs.BleedingEdge targets .NET 8+ and uses [the master branch of raylib repo](https://github.com/raysan5/raylib/tree/master)

> there are still no examples, you can rely on [Raylib-cs](https://github.com/chrisdill/raylib-cs) examples
> as this binding has mostly same function signatures (see [code differences](#code-differences))

basic example
---

```csharp
using Raylib_cs.BleedingEdge;
using static Raylib_cs.BleedingEdge.Raylib;

const int screenWidth = 800;
const int screenHeight = 540;

InitWindow(screenWidth, screenHeight, "raylib [core] example - basic window");

while (!WindowShouldClose())
{
    BeginDrawing();
    ClearBackground(Color.RayWhite);
    
    DrawText("Congrats! You created your first window!", 190, 200, 20, Color.LightGray);
    
    EndDrawing();
}

CloseWindow();
```

differences from [Raylib-cs](https://github.com/ChrisDill/Raylib-cs)
---

### main differences
| [Raylib-cs](https://github.com/chrisdill/raylib-cs) | Raylib-cs.BleedingEdge  |
|-----------------------------------------------------|-------------------------|
| .NET 6.0+                                           | .NET 8.0+               |
| Released 07-2018                                    | Released 08-2024        |
| raylib 5.0                                          | raylib 5.5-dev (master) |

### code differences
Raylib-cs.BleedingEdge is a little more low-level than Raylib-cs, for example: 
Raylib-cs has `GetDroppedFiles`, which basically does `LoadDroppedFiles`, copies data from resulting `FilePathList` 
to `string[]` and does `UnloadDroppedFiles`. Raylib-cs.BleedingEdge doesn't have `GetDroppedFiles`, 
instead of this you must do `LoadDroppedFiles` and `UnloadDroppedFiles` yourself, like in normal raylib.

###### `*` means *any*, e.g. `*Span<T>` can be `Span<T>` or `ReadOnlySpan<T>`
| [Raylib-cs](https://github.com/chrisdill/raylib-cs) | Raylib-cs.BleedingEdge                                   |
|-----------------------------------------------------|----------------------------------------------------------|
| `using Raylib-cs`                                   | `using Raylib-cs.BleedingEdge`                           |
| `Texture2D`                                         | `Texture`                                                |
| `RenderTexture2D`                                   | `RenderTexture`                                          |
| `T[]` for functions with pointers                   | `Span<T>` for functions with pointers                    |
| `int` argument for the length of array              | -, use `Span<T>.Slice` if necessary                      |
| `Function_()` as `string` variant                   | `FunctionString()` as `string` variant                   |
| `Utf8Buffer`                                        | `Utf8Handle`                                             |
| `New<T>(uint)`                                      | `MemAlloc<T>(uint)`                                      |
| `Get*` (`GetDroppedFiles`)                          | -, use `Load*`, `Unload*` (`Load/UnloadDroppedFiles`)    |
