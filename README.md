### Batch File Renamer
<i>A simple program to rename a directory of files according to a style the user selects.</i>

<details>
    <summary>Overview</summary>
    <ul><br>
        A recent migration from Windows to Linux inspired a change in preference towards file naming conventions, and a program that could quickly update the filenames of an entire directory of files seemed like a good project to refine C# competency outside of game development. The aim of this project is thus to gain practical experience working with files in .NET, as well as improve techniques for designing program infrastructure.
        <br><br>
		This program is intended to provide the user with the ability to rename a given directory of files according to one of three styles: all words lowercased, all words uppercased, or first letter of each word uppercased. The user can optionally choose the way spacing between words is handled, choosing from white space, dash, or underscore.
        <br><br>
        Note: project is currently at an intermediate stage in development. Future revisions will see successive implementation of features and possible changes to infrastructure.
    </ul><br>
</details>

<details>
    <summary>Development</summary>
    <ul><br>
        This project originally started with an MVC structure to provide a baseline architecture to work from and keep logic and data separate. However, as the project grew, a request system was introduced, which altered the program flow and necessitated a reevaluation of the overall project structure.
        <br><br>
        As the existence of model, view, and controller classes became more of a forced compliance to an architecture rather than a structure to guide development, the classes were removed or transitioned to designations that seemed more practical.
    </ul><br>
</details>

<details>
    <summary>Core Goals</summary>
    <ul><br>
        · Demonstrate general competency with C# in a .NET console environment
        <br>
        · Demonstrate knowledge of practices for successful integration with version control and docker
        <br>
        · Demonstrate abilities regarding refactoring and iteration
        <br>
        · Generally improve techniques regarding decoupling and project structuring
        <br>
    </ul><br>
</details>

<details open>
	<summary>How to Use the Project</summary>
	<ul><br>
		<b>1.</b> Download and open in desired code editor as usual
		<br>
		<b>2.</b> Run Program.cs
		<br><br>
		<i>Created in VSCode 1.88 on Linux using .NET (C# Dev Kit)</i>
	</ul>
</details>
