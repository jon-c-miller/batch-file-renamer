### Batch File Renamer
<i>A simple program to rename a directory of files according to a style the user selects.</i>

<details>
    <summary>Overview</summary>
    <ul><br>
        A recent migration from Windows to Linux inspired a change in preference towards file naming conventions, and a program that could quickly update the filenames of an entire directory of files seemed like a good project to refine C# competency outside of game development. The aim of this project is thus to gain practical experience working with files in .NET, as well as improve techniques for designing program infrastructure.
        <br><br>
		This program is intended to provide the user with the ability to rename a given directory of files according to one of three styles: all words lowercased, all words uppercased, or first letter of each word uppercased. The user can optionally choose the way spacing between words is handled, choosing from white space, dash, or underscore.
        <br><br>
        Currently, the program operates in the directory of the executable, necessitating physically moving the executable to the directory desired to be updated. File updating is handled in one of two ways: making a copy of the files or moving them, respectively using File.Copy() or File.Move(). In either case, the program will utilize a directory named 'updated files' in the same directory as the executable. This directory is automatically created if it does not exist. Files with matching filename paths already in the updated files directory will be skipped.
        <br><br>
        Upon obtaining responses to a succession of prompts designed to customize the output, a final summary of requested operations is displayed to the user before they commit to the changes. Cancellation and escaping back to the main menu can be done right after selecting an option from the menu, and right before committing final changes.
        <br><br>
        A list of changes to the filenames will be printed to the console during execution of the requested tasks, followed by a final completion notification and prompt to return to the main menu. While tasks are executed in the directory of the program's executable, those same tasks are not performed on the actual executable file itself.
    </ul><br>
</details>

<details>
    <summary>Development</summary>
    <ul><br>
        This project originally started with an MVC structure to provide a baseline architecture to work from and keep logic and data separate. However, as the project grew, a request system was introduced, which altered the program flow and necessitated a reevaluation of the overall project structure.
        <br><br>
        As the existence of model, view, and controller classes became more of a forced compliance to an architecture rather than a structure to guide development, the classes were removed or transitioned to designations that seemed more practical.
        <br><br>
        Thus the project evolved around use of a simplified synchronous pipeline, which takes incoming requests as a request id enum along with generic data, wraps them in a Request class instance, adds that instance to a list, then passes the id and data back to a handler class one at a time. 
        <br><br>
        Early on, a key design decision was to have all print statements kept in a single database collection and accessible via keyword enum. This added abstraction helped to keep program elements organized and easier to read without having lots of console statements crowding the logic flow.
        <br><br>
        A rudimentary state machine to assist in basic flow control was later added, but later review of the project's practical needs revealed that a state machine wasn't really necessary, considering that there were only two basic states: waiting on user input and the near instantanous processing of final execution. The state machine structure was therefore removed and replaced with a boolean to work with the process method, allowing console input/parsing when true.
        <br><br>
        At a certain point, the main program loop was greatly simplified by moving all lower level logic into either the request processing class or the request handler class, resulting in a while loop that called a Process() method in each class as long as a Continue boolean was true in the handler class. This allowed the program's higher level nature to be easily observed and understood, and all but eliminated yet another potential place for unintended runtime errors.
        <br><br>
        In general, it could be said that the infrastructure developed alongside this project was at times overkill considering the simple nature of its tasks, but there was never a point where the architecture itself became an obstacle that could not quickly be overcome by simplifying, using a different approach, or remolding it to the immediate needs of the system.
        <br><br>
        Overall, the design path of this project offered fresh, exciting, and interesting challenges, as well as a chance to build a system from the ground up while experimenting with various architecture outside of the framework of a game engine.
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
        · Experiment with and improve techniques regarding decoupling and project structuring
        <br>
    </ul><br>
</details>

<details open>
    <summary>How to Use the Project</summary>
    <ul>
        <br><b>Method 1 (run in code editor)</b><br>
        <ul>
            · Download project and run in desired code editor as usual (Program.cs)
            <br><i>Choose 'Y' in response to 'Keep original files (copy instead of move)?' to avoid app.csproj and Program.cs being moved</i>
        </ul>
    </ul>
    <ul>
        <b>Method 2 (run after building from source)</b><br>
        <ul>
            · Open the project in desired code editor and build the release: <code>dotnet publish -c Release</code>
            <br>· Locate the single file executable in app/bin/Release/publish
            <br>· Copy or move the executable to a directory with files to be renamed
            <br>· Run the executable via terminal
        </ul>
    </ul>
    <ul>
        <b>Method 3 (run with Docker)</b><br>
        <ul>
			· Build the docker image: <code>docker build -t batch-file-renamer .</code>
			<br>· Run the image: <code>docker run --rm -it batch-file-renamer</code>
			<br>
			<br><b>-t</b> tags the resulting image as 'batch-file-renamer'
			<br><b>--rm</b> removes the image container when done
			<br><b>-it</b> shows console output
			<br>
		</ul>
        <br><i>Created in VSCode 1.88 on Linux using .Net (C# Dev Kit)</i>
    </ul>
</details>
