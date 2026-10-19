# Module 1 – Design principles: spot the problems

`SalesApp` is a small Blazor Server app that **works** but was written in a hurry.
It is a miniature version of what you meet in a large production app.

Your job in this module is to **find and name** the problems, not fix them.
(Fixing them is what Modules 2–4 are for.)

## Run it

From the repo root, in the VS Code terminal:

```
cd module-1-design-principles/SalesApp
dotnet run
```

Open http://localhost:5080. Watch the terminal too: the fake database and email
sender print what they're doing there. Stop the app with `Ctrl+C`.

## Things to try in the browser

1. **Sales report:** run it for each region. Look at the terminal output.
2. **Region summary:** load it, then click **Clean up cancelled orders**.
3. **Region summary:** tick **Show archived (2025) sales**, then click **Clean up cancelled orders** again.
   What happens, and why?

## The exercise

Read these files:

- `Components/Pages/SalesReport.razor`
- `Components/Pages/RegionSummary.razor`
- `Data/LegacySalesDb.cs`
- `Services/EmailSender.cs`
- `Services/ReportEngine.cs`

For **each** principle below, find at least one place the code breaks it.
Write down the file, the line(s), and one sentence on *why* it's a problem.

| Principle | Where (file + lines) | Why it's a problem |
| --- | --- | --- |
| S – Single Responsibility | | |
| O – Open/Closed | | |
| L – Liskov Substitution | | |
| I – Interface Segregation | | |
| D – Dependency Inversion | | |
| DRY | | |
| YAGNI | | |
| Separation of concerns | | |

**Bonus:** list any other code smells you notice. There are several that belong
to Module 2 (C# best practices). See if you can spot them early.

## Hand it in

Create a file `module-1-design-principles/ANSWERS.md` with your table,
commit it, and push it (or just paste it into the chat). I'll review it.

Hint for the Git part:

```
git add module-1-design-principles/ANSWERS.md
git commit -m "Add Module 1 answers"
git push
```
