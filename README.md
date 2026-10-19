# Jewandre Practice

Hands-on practice material for the **Industry Practices Bootcamp: Blazor, C# & SQL**.
Each module gets its own folder, added one at a time as the course progresses.

| Folder | Module | What's in it |
| --- | --- | --- |
| `module-1-design-principles/` | 1 – Jargon & core concepts | A small Blazor app full of design-principle problems to find |

## One-time setup on your computer

1. **Install the tools**
   - [.NET SDK](https://dotnet.microsoft.com/download) (8.0 or newer). Check with `dotnet --version`.
   - [VS Code](https://code.visualstudio.com/) and the **C# Dev Kit** extension
     (VS Code will offer it when you open this folder).
   - [Git](https://git-scm.com/downloads). Check with `git --version`.

2. **Get your local copy** (in a terminal, in the folder where you keep projects):

   ```
   git clone https://github.com/JewandreJuliano/Jewandre-practice.git
   cd Jewandre-practice
   code .
   ```

3. **Run an app** from the VS Code terminal (`` Ctrl+` ``):

   ```
   cd module-1-design-principles/SalesApp
   dotnet run
   ```

## Local copy vs GitHub

Your clone is completely separate from GitHub. Edit, break and experiment freely:
nothing leaves your machine until you `git push`.

- Get new modules when they're added: `git pull`
- See what you've changed: `git status`
- Throw away all your local changes to a file: `git restore <file>`
