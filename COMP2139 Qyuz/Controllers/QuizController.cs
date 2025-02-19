using COMP2139_Qyuz.Models;
using Microsoft.AspNetCore.Mvc;


namespace COMP2139_Qyuz.Controllers;

public class QuizController : Controller
{
    private static List<QuizQuestion> _questions = new List<QuizQuestion>
        {
            new QuizQuestion { QuestionText = "What does the 'protocol' in a URL specify?", 
            Options = new List<string>{ "The type of network connection", "The security level of the website", "The method used to access the resource", "The location of the server" }, 
            CorrectAnswer = "The method used to access the resource" },
            
            new QuizQuestion { QuestionText = "Which part of 'https://www.modulemedia.com/ourwork/index.html' represents the path?", 
                Options = new List<string>{ "https", "www.modulemedia.com", "/ourwork/", "index.html" }, 
                CorrectAnswer = "/ourwork/" },


            new QuizQuestion { QuestionText = "Which part of 'https://www.modulemedia.com/ourwork/index.html' represents the filename?", 
                Options = new List<string>{ "https", "www.modulemedia.com", "/ourwork/", "index.html" }, 
                CorrectAnswer = "index.html" },

            new QuizQuestion { QuestionText = "Which of the following is an example of a 'protocol' in a URL?", 
            Options = new List<string>{ "www.example.com", "https", "/ourwork/", "index.html" }, 
            CorrectAnswer = "https" },

            new QuizQuestion { QuestionText = "Which part of 'https://www.modulemedia.com/ourwork/index.html' is the domain name?", 
            Options = new List<string>{ "https", "www.modulemedia.com", "/ourwork/", "index.html" }, 
            CorrectAnswer = "www.modulemedia.com" },
            
            new QuizQuestion { QuestionText = "Which protocol is used for communication between web browsers and web servers?", 
                Options = new List<string>{ "HTTP", "FTP", "SMTP", "DNS" }, 
                CorrectAnswer = "HTTP" },

            new QuizQuestion { QuestionText = "Which protocol is a secure version of HTTP?", 
                Options = new List<string>{ "TCP", "HTTPS", "FTP", "UDP" }, 
                CorrectAnswer = "HTTPS" },

            new QuizQuestion { QuestionText = "Which protocol is responsible for enabling communication between two computers over a network?", 
                Options = new List<string>{ "HTTP", "SMTP", "TCP/IP", "FTP" }, 
                CorrectAnswer = "TCP/IP" },
            
            new QuizQuestion { QuestionText = "Which step comes first in processing a dynamic web page?", 
                Options = new List<string>{ "Rendering the page in the browser", "Processing server-side logic", "Receiving an HTTP request", "Executing JavaScript on the client" }, 
                CorrectAnswer = "Receiving an HTTP request" },

            new QuizQuestion { QuestionText = "What is the last step in processing a dynamic web page?", 
                Options = new List<string>{ "Rendering the page in the browser", "Processing database queries", "Receiving an HTTP request", "Executing middleware functions" }, 
                CorrectAnswer = "Rendering the page in the browser" },
            new QuizQuestion { QuestionText = "What comes next after the web browser sends an HTTP request?", 
            Options = new List<string>{ "Database processes the request", "Application Server sends a response", "Web Server (Kestrel) receives the request", "Web browser executes JavaScript" }, 
            CorrectAnswer = "Web Server (Kestrel) receives the request" },

            new QuizQuestion { QuestionText = "What comes next after the Web Server (Kestrel) receives the HTTP request?", 
            Options = new List<string>{ "Application Server (ASP.NET Core) processes the request", "Web browser renders the response", "Database Server (SQL Server) executes a query", "The page is displayed to the user" }, 
            CorrectAnswer = "Application Server (ASP.NET Core) processes the request" },

            new QuizQuestion { QuestionText = "What comes next after the Application Server (ASP.NET Core) processes the request?", 
            Options = new List<string>{ "Web Browser sends another request", "Database Server (SQL Server) retrieves data", "Web Server sends the response", "HTML and CSS are rendered" }, 
            CorrectAnswer = "Database Server (SQL Server) retrieves data" },

            new QuizQuestion { QuestionText = "What comes next after the Database Server (SQL Server) retrieves data?", 
            Options = new List<string>{ "Application Server (ASP.NET Core) processes the data and prepares a response", "Web Browser executes JavaScript", "HTML, CSS, and JavaScript are displayed", "Web Server directly responds to the request" }, 
            CorrectAnswer = "Application Server (ASP.NET Core) processes the data and prepares a response" },

            new QuizQuestion { QuestionText = "What comes next after the Application Server (ASP.NET Core) processes the data and prepares a response?", 
            Options = new List<string>{ "Database sends another query", "Web Server (Kestrel) sends an HTTP response", "Web Browser sends a follow-up request", "User logs in to the system" }, 
            CorrectAnswer = "Web Server (Kestrel) sends an HTTP response" },

            new QuizQuestion { QuestionText = "What comes next after the Web Server (Kestrel) sends an HTTP response?", 
            Options = new List<string>{ "Web Browser renders the response (HTML, CSS, JavaScript)", "Application Server requests more data", "Database Server validates the response", "Web Server receives another request" }, 
            CorrectAnswer = "Web Browser renders the response (HTML, CSS, JavaScript)" },

            new QuizQuestion { QuestionText = "What is the final step in processing a dynamic web page?", 
            Options = new List<string>{ "Web Browser displays the processed page to the user", "Database Server sends another query", "Web Server prepares a new request", "Application Server requests more data" }, 
            CorrectAnswer = "Web Browser displays the processed page to the user" },

            
            new QuizQuestion { QuestionText = "What is ASP.NET used for?", 
                Options = new List<string>{ "Creating web applications and services", "Managing databases", "Operating system development", "Machine learning algorithms" }, 
                CorrectAnswer = "Creating web applications and services" },

            new QuizQuestion { QuestionText = "What are the benefits of transitioning from classic ASP to ASP.NET?", 
                Options = new List<string>{ "Improved performance, increased security, and a more consistent programming model", "More complex syntax and reduced compatibility", "Limited scalability and restricted cloud usage", "Only available on Windows" }, 
                CorrectAnswer = "Improved performance, increased security, and a more consistent programming model" },

            new QuizQuestion { QuestionText = "What is a key characteristic of ASP.NET Core compared to ASP.NET?", 
                Options = new List<string>{ "It is a complete rewrite designed for modern web applications", "It is only supported on Windows", "It lacks security improvements", "It cannot handle cloud applications" }, 
                CorrectAnswer = "It is a complete rewrite designed for modern web applications" },

            new QuizQuestion { QuestionText = "What are the key advantages of ASP.NET Core?", 
                Options = new List<string>{ "Cross-platform capabilities, performance improvements, and cloud optimization", "Only works with Windows", "More restrictive than previous versions", "Does not support modern development" }, 
                CorrectAnswer = "Cross-platform capabilities, performance improvements, and cloud optimization" },
            
            new QuizQuestion { QuestionText = "What is .NET Framework primarily used for?", 
                Options = new List<string>{ "Cross-platform development", "Only web development", "Software development on Windows", "Cloud-based applications only" }, 
                CorrectAnswer = "Software development on Windows" },

            new QuizQuestion { QuestionText = "What is a key characteristic of .NET Core?", 
                Options = new List<string>{ "Windows-only framework", "Cross-platform, open-source version of .NET", "Designed for mobile development only", "Only supports desktop applications" }, 
                CorrectAnswer = "Cross-platform, open-source version of .NET" },

            new QuizQuestion { QuestionText = "How does .NET Core improve performance?", 
                Options = new List<string>{ "By using only necessary packages", "By running only on Windows", "By requiring more system resources", "By using legacy technologies" }, 
                CorrectAnswer = "By using only necessary packages" },

            new QuizQuestion { QuestionText = "Is .NET Core open-source?", 
                Options = new List<string>{ "Yes", "No" }, 
                CorrectAnswer = "Yes" },

            new QuizQuestion { QuestionText = "Is .NET Framework open-source?", 
                Options = new List<string>{ "Yes", "No" }, 
                CorrectAnswer = "No" },

            new QuizQuestion { QuestionText = "Which .NET version supports cross-platform development?", 
                Options = new List<string>{ ".NET Core", ".NET Framework" }, 
                CorrectAnswer = ".NET Core" },

            new QuizQuestion { QuestionText = "Which .NET version is limited to Windows only?", 
                Options = new List<string>{ ".NET Core", ".NET Framework" }, 
                CorrectAnswer = ".NET Framework" },

            new QuizQuestion { QuestionText = "Which .NET version offers better performance optimization?", 
                Options = new List<string>{ ".NET Core", ".NET Framework" }, 
                CorrectAnswer = ".NET Core" },

            new QuizQuestion { QuestionText = "How is deployment handled in .NET Core?", 
                Options = new List<string>{ "Modular deployment", "Via Internet Information Server only" }, 
                CorrectAnswer = "Modular deployment" },

            new QuizQuestion { QuestionText = "How is deployment handled in .NET Framework?", 
                Options = new List<string>{ "Modular deployment", "Via Internet Information Server only" }, 
                CorrectAnswer = "Via Internet Information Server only" },

            new QuizQuestion { QuestionText = "Which .NET version uses portable class libraries?", 
                Options = new List<string>{ ".NET Core", ".NET Framework" }, 
                CorrectAnswer = ".NET Core" },

            new QuizQuestion { QuestionText = "Which .NET version has built-in class libraries?", 
                Options = new List<string>{ ".NET Core", ".NET Framework" }, 
                CorrectAnswer = ".NET Framework" },

            new QuizQuestion { QuestionText = "What is the primary purpose of Razor Pages in ASP.NET Core?", 
                Options = new List<string>{ "For building APIs", "For handling background tasks", "For page-focused scenarios", "For database management" }, 
                CorrectAnswer = "For page-focused scenarios" },

            new QuizQuestion { QuestionText = "Which file extension is used for Razor Pages in ASP.NET Core?", 
                Options = new List<string>{ ".html", ".cshtml", ".razor", ".aspx" }, 
                CorrectAnswer = ".cshtml" },

            new QuizQuestion { QuestionText = "What is the corresponding file for each Razor Page (.cshtml) file?", 
                Options = new List<string>{ ".html.cs", ".cs", ".cshtml.cs", ".razor.cs" }, 
                CorrectAnswer = ".cshtml.cs" },

            new QuizQuestion { QuestionText = "What does the .cshtml.cs file contain?", 
                Options = new List<string>{ "PageModel", "CSS styles", "JavaScript logic", "Database queries" }, 
                CorrectAnswer = "PageModel" },

            new QuizQuestion { QuestionText = "What is gRPC used for in ASP.NET Core?", 
                Options = new List<string>{ "Building interactive web pages", "Developing lightweight microservices and APIs", "Handling SQL queries", "Processing static files" }, 
                CorrectAnswer = "Developing lightweight microservices and APIs" },

            new QuizQuestion { QuestionText = "What type of framework is gRPC?", 
                Options = new List<string>{ "A database framework", "A remote procedure call (RPC) framework", "A frontend UI framework", "A cloud storage framework" }, 
                CorrectAnswer = "A remote procedure call (RPC) framework" },

            new QuizQuestion { QuestionText = "Is gRPC a high-performance and cross-platform framework?", 
                Options = new List<string>{ "Yes", "No" }, 
                CorrectAnswer = "Yes" },

            new QuizQuestion { QuestionText = "What is one of the primary advantages of gRPC in ASP.NET Core?", 
                Options = new List<string>{ "It replaces MVC", "It improves API communication performance", "It only works with Windows applications", "It is used for UI development" }, 
                CorrectAnswer = "It improves API communication performance" },
            new QuizQuestion { QuestionText = "What does MVC stand for?", 
                Options = new List<string>{ "Model-View-Command", "Module-Variable-Control", "Model-View-Controller", "Main-Variable-Class" }, 
                CorrectAnswer = "Model-View-Controller" },

            new QuizQuestion { QuestionText = "Which component of MVC is responsible for handling user requests?", 
                Options = new List<string>{ "Model", "View", "Controller", "Database" }, 
                CorrectAnswer = "Controller" },

            new QuizQuestion { QuestionText = "Which component of MVC contains the application's business logic and data access code?", 
                Options = new List<string>{ "Model", "View", "Controller", "Database" }, 
                CorrectAnswer = "Model" },

            new QuizQuestion { QuestionText = "Which MVC component is responsible for rendering the user interface?", 
                Options = new List<string>{ "Model", "View", "Controller", "Database" }, 
                CorrectAnswer = "View" },

            new QuizQuestion { QuestionText = "Which component in MVC interacts directly with the database?", 
                Options = new List<string>{ "Model", "View", "Controller", "Web Browser" }, 
                CorrectAnswer = "Model" },

            new QuizQuestion { QuestionText = "What does the Controller do in the MVC pattern?", 
                Options = new List<string>{ "Handles database queries", "Processes user requests and updates the model", "Renders the HTML page", "Stores user sessions" }, 
                CorrectAnswer = "Processes user requests and updates the model" },
            new QuizQuestion { QuestionText = "What does MVC stand for?", 
                Options = new List<string>{ "Model-View-Command", "Module-Variable-Control", "Model-View-Controller", "Main-Variable-Class" }, 
                CorrectAnswer = "Model-View-Controller" },

            new QuizQuestion { QuestionText = "Which component of MVC is responsible for handling user requests?", 
                Options = new List<string>{ "Model", "View", "Controller", "Database" }, 
                CorrectAnswer = "Controller" },

            new QuizQuestion { QuestionText = "Which component of MVC contains the application's business logic and data access code?", 
                Options = new List<string>{ "Model", "View", "Controller", "Database" }, 
                CorrectAnswer = "Model" },

            new QuizQuestion { QuestionText = "Which MVC component is responsible for rendering the user interface?", 
                Options = new List<string>{ "Model", "View", "Controller", "Database" }, 
                CorrectAnswer = "View" },

            new QuizQuestion { QuestionText = "Which component in MVC interacts directly with the database?", 
                Options = new List<string>{ "Model", "View", "Controller", "Web Browser" }, 
                CorrectAnswer = "Model" },

            new QuizQuestion { QuestionText = "What does the Controller do in the MVC pattern?", 
                Options = new List<string>{ "Handles database queries", "Processes user requests and updates the model", "Renders the HTML page", "Stores user sessions" }, 
                CorrectAnswer = "Processes user requests and updates the model" },
            new QuizQuestion { QuestionText = "What is Middleware in ASP.NET Core?", 
                Options = new List<string>{ "A security framework", "Software that handles requests and responses in an application pipeline", "A database management tool", "A front-end framework for UI development" }, 
                CorrectAnswer = "Software that handles requests and responses in an application pipeline" },

            new QuizQuestion { QuestionText = "In ASP.NET Core, where is middleware used?", 
                Options = new List<string>{ "In the database engine", "In the front-end JavaScript framework", "In the application pipeline", "In cloud storage services" }, 
                CorrectAnswer = "In the application pipeline" },

            new QuizQuestion { QuestionText = "What does middleware primarily handle?", 
                Options = new List<string>{ "Only HTTP requests", "Only HTTP responses", "Both HTTP requests and responses", "Database transactions" }, 
                CorrectAnswer = "Both HTTP requests and responses" },

            new QuizQuestion { QuestionText = "What can each middleware component do in the request pipeline?", 
                Options = new List<string>{ "Only pass the request to the next middleware", "Perform operations on HTTP requests and optionally modify the response", "Only modify responses", "Store data in the database" }, 
                CorrectAnswer = "Perform operations on HTTP requests and optionally modify the response" },

            new QuizQuestion { QuestionText = "What happens when a middleware component short-circuits the pipeline?", 
                Options = new List<string>{ "The request is passed to all middleware components", "The response is delayed", "The pipeline stops processing and immediately returns a response", "The request is sent back to the client for modification" }, 
                CorrectAnswer = "The pipeline stops processing and immediately returns a response" },

            new QuizQuestion { QuestionText = "What does it mean to 'pass the request on' in middleware?", 
                Options = new List<string>{ "The request is forwarded to the next middleware component", "The request is stopped and sent back to the client", "The response is immediately generated", "The request is modified and stored in the database" }, 
                CorrectAnswer = "The request is forwarded to the next middleware component" },

            new QuizQuestion { QuestionText = "What is the purpose of the Razor View Engine in ASP.NET Core MVC?", 
                Options = new List<string>{ "For managing database connections", "For handling HTTP requests", "For dynamic HTML rendering", "For writing JavaScript code" }, 
                CorrectAnswer = "For dynamic HTML rendering" },

            new QuizQuestion { QuestionText = "Which of the following is a key flexibility feature in ASP.NET Core MVC?", 
                Options = new List<string>{ "Only MVC projects are supported", "APIs and MVC can be mixed in the same project", "Only REST APIs can be created", "MVC must be separate from APIs" }, 
                CorrectAnswer = "APIs and MVC can be mixed in the same project" },

            new QuizQuestion { QuestionText = "What is the benefit of mixing APIs and MVC in the same project?", 
                Options = new List<string>{ "It allows building flexible web applications", "It enforces strict project separation", "It improves database performance", "It eliminates the need for JavaScript" }, 
                CorrectAnswer = "It allows building flexible web applications" },

            new QuizQuestion { QuestionText = "What is the primary purpose of routing in ASP.NET Core?", 
                Options = new List<string>{ "To store user sessions", "To map an HTTP request to a controller action", "To manage database connections", "To render HTML templates" }, 
                CorrectAnswer = "To map an HTTP request to a controller action" },

            new QuizQuestion { QuestionText = "What component determines which controller action to call based on an HTTP request?", 
                Options = new List<string>{ "Model", "Router", "View", "Database Server" }, 
                CorrectAnswer = "Router" },
            new QuizQuestion { QuestionText = "When an HTTP request is made to '/posts', what happens first in the routing process?", 
                Options = new List<string>{ "The controller processes the request", "The request is directly sent to the view", "The router determines which action to call on the controller", "The model retrieves data from the database" }, 
                CorrectAnswer = "The router determines which action to call on the controller" },

            new QuizQuestion { QuestionText = "After the router determines the correct controller, which file processes the request?", 
                Options = new List<string>{ "Post.cs", "Post.cshtml", "PostsController.cs", "Database Server" }, 
                CorrectAnswer = "PostsController.cs" },

            new QuizQuestion { QuestionText = "Which component processes the business logic after the controller receives a request?", 
                Options = new List<string>{ "Router", "Model", "View", "Web Server" }, 
                CorrectAnswer = "Model" },

            new QuizQuestion { QuestionText = "After processing the request, where does the model send the data?", 
                Options = new List<string>{ "Directly back to the router", "To the controller", "To the view for rendering", "To the web server" }, 
                CorrectAnswer = "To the controller" },

            new QuizQuestion { QuestionText = "What is the final step in the ASP.NET Core routing process?", 
                Options = new List<string>{ "The model saves data to the database", "The controller sends data to the view for rendering", "The router calls another controller", "The web browser makes another request" }, 
                CorrectAnswer = "The controller sends data to the view for rendering" },

            new QuizQuestion { QuestionText = "Which file in the MVC structure is responsible for rendering the data?", 
                Options = new List<string>{ "PostsController.cs", "Post.cs", "Post.cshtml", "Router" }, 
                CorrectAnswer = "Post.cshtml" },

            new QuizQuestion { QuestionText = "Which file in the MVC structure contains the business logic and interacts with the database?", 
                Options = new List<string>{ "Post.cs", "Post.cshtml", "Router", "PostsController.cs" }, 
                CorrectAnswer = "Post.cs" },

            new QuizQuestion { QuestionText = "What is conventional routing in ASP.NET Core?", 
                Options = new List<string>{ "A way to define routes globally using predefined patterns", "A method to generate routes dynamically at runtime", "A database query routing mechanism", "A security feature for authentication" }, 
                CorrectAnswer = "A way to define routes globally using predefined patterns" },

            new QuizQuestion { QuestionText = "Where are conventional routes typically defined in an ASP.NET Core application?", 
                Options = new List<string>{ "In the Model class", "In the Startup.cs file", "In the database configuration", "In the HTML files" }, 
                CorrectAnswer = "In the Startup.cs file" },

            new QuizQuestion { QuestionText = "Which method is commonly used in Startup.cs to define conventional routes?", 
                Options = new List<string>{ "Configure", "UseRouting", "UseEndpoints", "All of the above" }, 
                CorrectAnswer = "All of the above" },

            new QuizQuestion { QuestionText = "How does conventional routing match incoming URLs?", 
                Options = new List<string>{ "By checking for exact string matches", "By using predefined patterns defined in Startup.cs", "By dynamically generating routes for each request", "By looking up routes in the database" }, 
                CorrectAnswer = "By using predefined patterns defined in Startup.cs" },

            new QuizQuestion { QuestionText = "What is attribute-based routing in ASP.NET Core?", 
                Options = new List<string>{ "A routing method that defines routes in the database", "A way to define routes using attributes on controllers and actions", "A method that does not require defining any routes", "A security feature for APIs" }, 
                CorrectAnswer = "A way to define routes using attributes on controllers and actions" },

            new QuizQuestion { QuestionText = "How is attribute-based routing applied in ASP.NET Core?", 
                Options = new List<string>{ "By defining routes in the Model class", "By decorating controllers and actions with route attributes", "By configuring the route in Startup.cs", "By using JavaScript functions" }, 
                CorrectAnswer = "By decorating controllers and actions with route attributes" },

            new QuizQuestion { QuestionText = "What is one advantage of attribute-based routing?", 
                Options = new List<string>{ "It allows more control over URIs", "It automatically creates API documentation", "It eliminates the need for controllers", "It replaces MVC with WebForms" }, 
                CorrectAnswer = "It allows more control over URIs" },

            new QuizQuestion { QuestionText = "Where can route attributes be applied in ASP.NET Core?", 
                Options = new List<string>{ "Only on controllers", "Only on actions", "On both controllers and actions", "Only in Startup.cs" }, 
                CorrectAnswer = "On both controllers and actions" },

            new QuizQuestion { QuestionText = "Which of the following is an example of an attribute-based route?", 
                Options = new List<string>{ "[Route(\"api/products\")]", "[HttpGet]", "[Authorize]", "[Middleware]" }, 
                CorrectAnswer = "[Route(\"api/products\")]" },

            
            new QuizQuestion { QuestionText = "What is Dependency Injection (DI)?", 
                Options = new List<string>{ "A security mechanism", "A design pattern that provides dependent objects to a class", "A database query optimization technique", "A UI rendering method" }, 
                CorrectAnswer = "A design pattern that provides dependent objects to a class" },

            new QuizQuestion { QuestionText = "What is Inversion of Control (IoC) in the context of Dependency Injection?", 
                Options = new List<string>{ "A process of reversing database transactions", "A way to shift control of dependencies from a class to the framework", "A method to reduce application performance", "A technique used for front-end styling" }, 
                CorrectAnswer = "A way to shift control of dependencies from a class to the framework" },

            new QuizQuestion { QuestionText = "Which of the following best describes Constructor Injection?", 
                Options = new List<string>{ "Injecting dependencies via a class’s constructor", "Using reflection to inject dependencies at runtime", "Injecting dependencies only through configuration files", "A method that does not use constructors" }, 
                CorrectAnswer = "Injecting dependencies via a class’s constructor" },

            new QuizQuestion { QuestionText = "What role does Dependency Injection play in ASP.NET Core?", 
                Options = new List<string>{ "It eliminates the need for services", "It allows the framework to manage object dependencies automatically", "It prevents controllers from handling user requests", "It only applies to front-end development" }, 
                CorrectAnswer = "It allows the framework to manage object dependencies automatically" },

            new QuizQuestion { QuestionText = "Which service is injected into the HomeController in the given example?", 
                Options = new List<string>{ "ILogger", "IServiceProvider", "IDatabaseConnection", "IHttpContextAccessor" }, 
                CorrectAnswer = "ILogger" },

            new QuizQuestion { QuestionText = "How is ILogger injected into the HomeController?", 
                Options = new List<string>{ "By manually instantiating it in the constructor", "By passing it as a parameter through the constructor", "By defining it in a separate configuration file", "By using JavaScript" }, 
                CorrectAnswer = "By passing it as a parameter through the constructor" },

            new QuizQuestion { QuestionText = "Who provides the ILogger instance in ASP.NET Core?", 
                Options = new List<string>{ "The developer manually", "ASP.NET Core framework", "A hardcoded dependency in the controller", "The web browser" }, 
                CorrectAnswer = "ASP.NET Core framework" },

            new QuizQuestion { QuestionText = "What is one major advantage of using Dependency Injection?", 
                Options = new List<string>{ "It tightly couples components together", "It makes code more maintainable and testable", "It slows down application performance", "It eliminates the need for controllers" }, 
                CorrectAnswer = "It makes code more maintainable and testable" },

            new QuizQuestion { QuestionText = "Which of the following is NOT an advantage of Dependency Injection?", 
                Options = new List<string>{ "Loose coupling between components", "Improved testability", "Automatic management of dependencies", "Forces all dependencies to be created manually" }, 
                CorrectAnswer = "Forces all dependencies to be created manually" },

            new QuizQuestion { QuestionText = "What is the main advantage of loose coupling in Dependency Injection?", 
                Options = new List<string>{ "It reduces system flexibility", "It allows classes to create their own dependencies", "It makes the system more adaptable to changes", "It tightly binds classes together" }, 
                CorrectAnswer = "It makes the system more adaptable to changes" },

            new QuizQuestion { QuestionText = "How does Dependency Injection reduce tight coupling?", 
                Options = new List<string>{ "By allowing classes to create their own dependencies", "By letting the framework manage dependencies", "By hardcoding service instances inside classes", "By preventing services from communicating with each other" }, 
                CorrectAnswer = "By letting the framework manage dependencies" },

            new QuizQuestion { QuestionText = "How does Dependency Injection improve testability?", 
                Options = new List<string>{ "By allowing real services to be replaced with mock objects", "By preventing the use of external services", "By enforcing hardcoded dependencies", "By making it harder to isolate components" }, 
                CorrectAnswer = "By allowing real services to be replaced with mock objects" },

            new QuizQuestion { QuestionText = "What is the benefit of using mock objects in testing?", 
                Options = new List<string>{ "They make tests slower", "They simulate real services for isolated testing", "They replace all services in production", "They eliminate the need for controllers" }, 
                CorrectAnswer = "They simulate real services for isolated testing" },

            new QuizQuestion { QuestionText = "How does Dependency Injection enhance maintainability?", 
                Options = new List<string>{ "By tightly coupling classes and dependencies", "By allowing classes and dependencies to evolve independently", "By enforcing manual dependency management", "By reducing flexibility in software design" }, 
                CorrectAnswer = "By allowing classes and dependencies to evolve independently" },

            new QuizQuestion { QuestionText = "What is a key advantage of decoupling classes from their dependencies?", 
                Options = new List<string>{ "It makes the system harder to modify", "It improves scalability and maintainability", "It increases complexity in the code", "It eliminates the need for Dependency Injection" }, 
                CorrectAnswer = "It improves scalability and maintainability" },


        };
        private static List<QuizQuestion> _questions2 = new List<QuizQuestion>
        {
            new QuizQuestion { QuestionText = "What is the primary role of the Model in ASP.NET MVC?", 
                Options = new List<string>{ "Rendering the user interface", "Handling user requests", "Representing domain data and business logic", "Routing HTTP requests" }, 
                CorrectAnswer = "Representing domain data and business logic" },

            new QuizQuestion { QuestionText = "Which of the following is NOT a responsibility of the Model?", 
                Options = new List<string>{ "Business Logic", "Persistence mechanisms", "User Interface rendering", "Representation of domain data" }, 
                CorrectAnswer = "User Interface rendering" },
            new QuizQuestion { QuestionText = "What is the primary responsibility of the View in MVC?", 
                Options = new List<string>{ "Managing database transactions", "Handling business logic", "Rendering the user interface and representing the Model", "Processing user authentication" }, 
                CorrectAnswer = "Rendering the user interface and representing the Model" },

            new QuizQuestion { QuestionText = "Which component of MVC is responsible for displaying data to the user?", 
                Options = new List<string>{ "Model", "View", "Controller", "Database" }, 
                CorrectAnswer = "View" },
            new QuizQuestion { QuestionText = "What is the primary responsibility of the Controller in MVC?", 
                Options = new List<string>{ "Rendering HTML pages", "Handling user requests and binding data between Model and View", "Executing SQL queries", "Defining application security policies" }, 
                CorrectAnswer = "Handling user requests and binding data between Model and View" },

            new QuizQuestion { QuestionText = "Which MVC component acts as an intermediary between Model and View?", 
                Options = new List<string>{ "Model", "Controller", "View", "Router" }, 
                CorrectAnswer = "Controller" },

            new QuizQuestion { QuestionText = "Why is the Controller referred to as the 'Application's Brain' in MVC?", 
                Options = new List<string>{ "Because it directly processes all database queries", "Because it handles user requests, binds data, and returns views", "Because it stores all user data", "Because it only manages front-end components" }, 
                CorrectAnswer = "Because it handles user requests, binds data, and returns views" },

            new QuizQuestion { QuestionText = "Which component in MVC is responsible for business logic and persistence mechanisms?", 
                Options = new List<string>{ "Model", "View", "Controller", "Router" }, 
                CorrectAnswer = "Model" },

            new QuizQuestion { QuestionText = "Which component in MVC is responsible for presenting data to the user?", 
                Options = new List<string>{ "Model", "View", "Controller", "Database" }, 
                CorrectAnswer = "View" },

            new QuizQuestion { QuestionText = "Which component in MVC processes user requests and determines how data should be presented?", 
                Options = new List<string>{ "Model", "View", "Controller", "Middleware" }, 
                CorrectAnswer = "Controller" },

            new QuizQuestion { QuestionText = "What is the first step in the MVC process?", 
                Options = new List<string>{ "The View delivers content", "The Model retrieves data", "The Controller receives a request from the user", "The Controller sends data to the View" }, 
                CorrectAnswer = "The Controller receives a request from the user" },

            new QuizQuestion { QuestionText = "After the Controller receives a request, what is the next step?", 
                Options = new List<string>{ "The Controller contacts the Model", "The View processes the request", "The Model directly interacts with the user", "The request is sent back to the user" }, 
                CorrectAnswer = "The Controller contacts the Model" },

            new QuizQuestion { QuestionText = "What happens after the Controller contacts the Model?", 
                Options = new List<string>{ "The Model retrieves and returns data", "The View processes the data", "The user gets an immediate response", "The Controller sends data to the View" }, 
                CorrectAnswer = "The Model retrieves and returns data" },

            new QuizQuestion { QuestionText = "Once the Model returns data, what does the Controller do next?", 
                Options = new List<string>{ "It sends data to the View for presentation", "It stores data in the database", "It directly displays the data to the user", "It reprocesses the data again" }, 
                CorrectAnswer = "It sends data to the View for presentation" },

            new QuizQuestion { QuestionText = "What is the final step in the MVC process?", 
                Options = new List<string>{ "The Controller contacts the Model again", "The View delivers the content to the user", "The user sends another request", "The database returns more data" }, 
                CorrectAnswer = "The View delivers the content to the user" },

            new QuizQuestion { QuestionText = "Which component in MVC is responsible for receiving user requests?", 
                Options = new List<string>{ "Model", "View", "Controller", "Database" }, 
                CorrectAnswer = "Controller" },

            new QuizQuestion { QuestionText = "Which component in MVC retrieves data from the database?", 
                Options = new List<string>{ "Controller", "View", "Model", "User Interface" }, 
                CorrectAnswer = "Model" },

            new QuizQuestion { QuestionText = "Which component in MVC is responsible for displaying data to the user?", 
                Options = new List<string>{ "Controller", "View", "Model", "Database" }, 
                CorrectAnswer = "View" },

            new QuizQuestion { QuestionText = "Which component acts as an intermediary between the Model and View?", 
                Options = new List<string>{ "Controller", "Router", "Middleware", "Database" }, 
                CorrectAnswer = "Controller" },

            new QuizQuestion { QuestionText = "What role does the database play in the MVC architecture?", 
                Options = new List<string>{ "Handles user requests", "Stores and retrieves data for the Model", "Renders the user interface", "Manages API responses" }, 
                CorrectAnswer = "Stores and retrieves data for the Model" },

            new QuizQuestion { QuestionText = "Which of the following is an advantage of MVC?", 
                Options = new List<string>{ 
                    "Tightly coupled components", 
                    "Clarity of design", 
                    "Direct database access from the view", 
                    "Limited scalability" }, 
                CorrectAnswer = "Clarity of design" },

            new QuizQuestion { QuestionText = "Which of the following is an advantage of MVC?", 
                Options = new List<string>{ 
                    "Code duplication across components", 
                    "Efficient modularity", 
                    "Views are restricted to one format", 
                    "Controllers must handle all data processing" }, 
                CorrectAnswer = "Efficient modularity" },

            new QuizQuestion { QuestionText = "Which of the following is an advantage of MVC?", 
                Options = new List<string>{ 
                    "Multiple views", 
                    "A single fixed UI", 
                    "Data and UI are merged into one component", 
                    "Direct manipulation of the database from the view" }, 
                CorrectAnswer = "Multiple views" },

            new QuizQuestion { QuestionText = "Which of the following is an advantage of MVC?", 
                Options = new List<string>{ 
                    "Ease of growth", 
                    "Rigid and unscalable architecture", 
                    "Every update requires full system changes", 
                    "Limited reusability" }, 
                CorrectAnswer = "Ease of growth" },

            new QuizQuestion { QuestionText = "Which of the following is an advantage of MVC?", 
                Options = new List<string>{ 
                    "Powerful user interfaces", 
                    "Views have no control over data presentation", 
                    "UI is separate from application logic", 
                    "Controllers cannot communicate with models" }, 
                CorrectAnswer = "Powerful user interfaces" },

            
            new QuizQuestion { QuestionText = "What do data models in MVC represent?", 
                Options = new List<string>{ "The structure of the data and business logic", "Only the database schema", "User interface elements", "Static web pages" }, 
                CorrectAnswer = "The structure of the data and business logic" },
            new QuizQuestion { QuestionText = "What does domain modeling focus on?", 
                Options = new List<string>{ "Representing real-world entities and relationships", "Designing UI components", "Managing HTTP requests", "Storing JavaScript logic" }, 
                CorrectAnswer = "Representing real-world entities and relationships" },

            new QuizQuestion { QuestionText = "What is captured in a domain model?", 
                Options = new List<string>{ "Essential aspects of the application's domain", "Only front-end layouts", "API endpoints", "HTML structure" }, 
                CorrectAnswer = "Essential aspects of the application's domain" },

            new QuizQuestion { QuestionText = "What is Entity Framework Core (EF Core)?", 
                Options = new List<string>{ "A database management system", "An object-relational mapper (ORM)", "A front-end UI framework", "A JavaScript library" }, 
                CorrectAnswer = "An object-relational mapper (ORM)" },

            new QuizQuestion { QuestionText = "What does an object-relational mapper (ORM) allow developers to do?", 
                Options = new List<string>{ "Work with a database using .NET objects", "Design user interfaces", "Process HTTP requests", "Manage server configurations" }, 
                CorrectAnswer = "Work with a database using .NET objects" },

            new QuizQuestion { QuestionText = "What does EF Core create a bridge between?", 
                Options = new List<string>{ "Model classes and database tables", "JavaScript and CSS files", "User inputs and controllers", "Networking protocols and APIs" }, 
                CorrectAnswer = "Model classes and database tables" },

            new QuizQuestion { QuestionText = "What does EF Core allow developers to do with data?", 
                Options = new List<string>{ "Query and save data using strongly typed objects", "Write SQL manually for every query", "Only retrieve data without saving", "Only save data without querying" }, 
                CorrectAnswer = "Query and save data using strongly typed objects" },

            new QuizQuestion { QuestionText = "What are data annotations in EF Core?", 
                Options = new List<string>{ 
                    "Functions for performing complex queries", 
                    "Attributes applied to model properties to define the database schema", 
                    "A method to configure routes in MVC", 
                    "A way to define JavaScript validation rules" }, 
                CorrectAnswer = "Attributes applied to model properties to define the database schema" },

            new QuizQuestion { QuestionText = "Which of the following is an example of a data annotation in EF Core?", 
                Options = new List<string>{ 
                    "[Route]", "[HttpGet]", "[Key]", "[RenderBody]" }, 
                CorrectAnswer = "[Key]" },

            new QuizQuestion { QuestionText = "What is the purpose of the [Required] annotation in EF Core?", 
                Options = new List<string>{ 
                    "Specifies a primary key for a column", 
                    "Ensures a property cannot have a null value", 
                    "Maps a property to a different table", 
                    "Allows automatic data generation" }, 
                CorrectAnswer = "Ensures a property cannot have a null value" },

            new QuizQuestion { QuestionText = "What is Fluent API used for in EF Core?", 
                Options = new List<string>{ 
                    "Defining front-end styles", 
                    "Further configuring models using code-based syntax", 
                    "Handling HTTP requests", 
                    "Creating database views" }, 
                CorrectAnswer = "Further configuring models using code-based syntax" },

            new QuizQuestion { QuestionText = "Which method is commonly used for Fluent API configuration in EF Core?", 
                Options = new List<string>{ 
                    "OnConfiguring", "OnModelCreating", "ConfigureRoutes", "SetDatabaseSchema" }, 
                CorrectAnswer = "OnModelCreating" },

            
            new QuizQuestion { QuestionText = "What does CRUD stand for in EF Core?", 
                Options = new List<string>{ 
                    "Create, Read, Update, Delete", 
                    "Compile, Run, Upload, Deploy", 
                    "Cache, Retrieve, Use, Discard", 
                    "Convert, Reorder, Undo, Debug" }, 
                CorrectAnswer = "Create, Read, Update, Delete" },

            new QuizQuestion { QuestionText = "What does the 'Create' operation do in EF Core?", 
                Options = new List<string>{ 
                    "Adds new records to the database", 
                    "Retrieves existing records", 
                    "Deletes records from the database", 
                    "Modifies existing records" }, 
                CorrectAnswer = "Adds new records to the database" },

            new QuizQuestion { QuestionText = "What is the purpose of the 'Read' operation in CRUD?", 
                Options = new List<string>{ 
                    "Retrieving records from the database", 
                    "Updating database records", 
                    "Deleting records permanently", 
                    "Inserting new records" }, 
                CorrectAnswer = "Retrieving records from the database" },

            new QuizQuestion { QuestionText = "What does the 'Update' operation in CRUD do?", 
                Options = new List<string>{ 
                    "Modifies existing records in the database", 
                    "Retrieves data from the database", 
                    "Deletes unwanted records", 
                    "Creates new tables" }, 
                CorrectAnswer = "Modifies existing records in the database" },

            new QuizQuestion { QuestionText = "Which CRUD operation removes records from the database?", 
                Options = new List<string>{ 
                    "Create", "Read", "Update", "Delete" }, 
                CorrectAnswer = "Delete" },

            new QuizQuestion { QuestionText = "What is the main purpose of Views in MVC?", 
                Options = new List<string>{ 
                    "Handling business logic", 
                    "Displaying application data to the user", 
                    "Managing database operations", 
                    "Processing HTTP requests" }, 
                CorrectAnswer = "Displaying application data to the user" },

            new QuizQuestion { QuestionText = "Which layer in MVC acts as the visual representation of the application's data?", 
                Options = new List<string>{ 
                    "Model", "View", "Controller", "Database" }, 
                CorrectAnswer = "View" },

            new QuizQuestion { QuestionText = "How are Views in MVC related to business logic?", 
                Options = new List<string>{ 
                    "They are responsible for handling business logic", 
                    "They are separate from business logic and only focus on presentation", 
                    "They manage user authentication and session data", 
                    "They process and validate database queries" }, 
                CorrectAnswer = "They are separate from business logic and only focus on presentation" },

            new QuizQuestion { QuestionText = "Who provides the data that Views present to the user?", 
                Options = new List<string>{ 
                    "The Model", "The Controller", "The View itself", "The Database Server" }, 
                CorrectAnswer = "The Controller" },

            new QuizQuestion { QuestionText = "What is Razor in MVC?", 
                Options = new List<string>{ 
                    "A JavaScript framework", 
                    "A markup syntax that lets you embed C# code into web pages", 
                    "A database management tool", 
                    "A CSS preprocessor" }, 
                CorrectAnswer = "A markup syntax that lets you embed C# code into web pages" },

            new QuizQuestion { QuestionText = "What does Razor bridge the gap between?", 
                Options = new List<string>{ 
                    "JavaScript and CSS", 
                    "HTML and C#", 
                    "Database and Views", 
                    "Backend and SQL queries" }, 
                CorrectAnswer = "HTML and C#" },

            new QuizQuestion { QuestionText = "What is a key feature of Razor syntax?", 
                Options = new List<string>{ 
                    "It dynamically generates HTML content on the server before sending it to the browser", 
                    "It only works with JavaScript frameworks", 
                    "It is used for designing front-end UI", 
                    "It processes SQL queries directly" }, 
                CorrectAnswer = "It dynamically generates HTML content on the server before sending it to the browser" },

            new QuizQuestion { QuestionText = "Where does Razor generate HTML content?", 
                Options = new List<string>{ 
                    "On the client-side", 
                    "On the server before sending it to the browser", 
                    "Inside the database", 
                    "Directly inside JavaScript files" }, 
                CorrectAnswer = "On the server before sending it to the browser" },

            new QuizQuestion { QuestionText = "What is a key feature of Razor syntax?", 
                Options = new List<string>{ 
                    "It dynamically generates HTML content on the server before sending it to the browser", 
                    "It only works with JavaScript frameworks", 
                    "It is used for designing front-end UI", 
                    "It processes SQL queries directly" }, 
                CorrectAnswer = "It dynamically generates HTML content on the server before sending it to the browser" },

            new QuizQuestion { QuestionText = "Where does Razor generate HTML content?", 
                Options = new List<string>{ 
                    "On the client-side", 
                    "On the server before sending it to the browser", 
                    "Inside the database", 
                    "Directly inside JavaScript files" }, 
                CorrectAnswer = "On the server before sending it to the browser" },

            new QuizQuestion { QuestionText = "What does the @model directive do in Razor?", 
                Options = new List<string>{ 
                    "Specifies the type of object the view expects from the controller", 
                    "Defines a database connection", 
                    "Handles JavaScript functions", 
                    "Manages API calls" }, 
                CorrectAnswer = "Specifies the type of object the view expects from the controller" },

            new QuizQuestion { QuestionText = "In Razor, what does the @model directive define?", 
                Options = new List<string>{ 
                    "The type of data sent to the view from the controller", 
                    "The layout structure of the page", 
                    "A JavaScript function", 
                    "A CSS style" }, 
                CorrectAnswer = "The type of data sent to the view from the controller" },

            new QuizQuestion { QuestionText = "What does the foreach loop do in Razor?", 
                Options = new List<string>{ 
                    "Iterates over the IEnumerable<Product> model passed from the controller", 
                    "Executes database queries", 
                    "Handles user authentication", 
                    "Sends API requests to external services" }, 
                CorrectAnswer = "Iterates over the IEnumerable<Product> model passed from the controller" },

            new QuizQuestion { QuestionText = "How are code blocks defined in Razor syntax?", 
                Options = new List<string>{ 
                    "Using <script> tags", 
                    "Encapsulated with @{ ... }", 
                    "By writing plain C# code inside HTML", 
                    "By using JavaScript functions" }, 
                CorrectAnswer = "Encapsulated with @{ ... }" },

            new QuizQuestion { QuestionText = "Which looping construct is commonly used in Razor views to iterate over collections?", 
                Options = new List<string>{ 
                    "for loop", 
                    "while loop", 
                    "foreach loop", 
                    "do-while loop" }, 
                CorrectAnswer = "foreach loop" },

            new QuizQuestion { QuestionText = "What is the purpose of using a foreach loop in Razor views?", 
                Options = new List<string>{ 
                    "To execute JavaScript code", 
                    "To iterate over collections and display data", 
                    "To handle HTTP requests", 
                    "To define controller methods" }, 
                CorrectAnswer = "To iterate over collections and display data" },

            new QuizQuestion { QuestionText = "How is conditional rendering achieved in Razor views?", 
                Options = new List<string>{ 
                    "Using JavaScript functions", 
                    "Including if-else statements in Razor syntax", 
                    "Only displaying hardcoded values", 
                    "Using external API calls" }, 
                CorrectAnswer = "Including if-else statements in Razor syntax" },

            new QuizQuestion { QuestionText = "In Razor syntax, what does the following expression do? @product.IsAvailable ? 'Yes' : 'No'", 
                Options = new List<string>{ 
                    "Executes a database query", 
                    "Applies conditional rendering to display 'Yes' if true and 'No' if false", 
                    "Defines a CSS class", 
                    "Handles user authentication" }, 
                CorrectAnswer = "Applies conditional rendering to display 'Yes' if true and 'No' if false" },

            new QuizQuestion { QuestionText = "What will be displayed if product.IsAvailable is false?", 
                Options = new List<string>{ 
                    "'Yes'", 
                    "'No'", 
                    "The original value of product.IsAvailable", 
                    "An empty string" }, 
                CorrectAnswer = "'No'" },

            new QuizQuestion { QuestionText = "What is the primary role of controllers in MVC?", 
                Options = new List<string>{ 
                    "Managing database queries", 
                    "Taking user input, working with models, and selecting views to render a response", 
                    "Handling front-end styling", 
                    "Executing JavaScript functions" }, 
                CorrectAnswer = "Taking user input, working with models, and selecting views to render a response" },

            new QuizQuestion { QuestionText = "How do controllers handle HTTP requests in MVC?", 
                Options = new List<string>{ 
                    "Each action in a controller corresponds to a different HTTP request type", 
                    "Controllers only handle GET requests", 
                    "Controllers only render views without processing data", 
                    "Controllers directly update the database without models" }, 
                CorrectAnswer = "Each action in a controller corresponds to a different HTTP request type" },

            new QuizQuestion { QuestionText = "Which component in MVC is responsible for handling user input?", 
                Options = new List<string>{ 
                    "Model", "View", "Controller", "Database" }, 
                CorrectAnswer = "Controller" },

            new QuizQuestion { QuestionText = "What happens after a controller processes a request?", 
                Options = new List<string>{ 
                    "It selects a view to render a response", 
                    "It sends data directly to the database", 
                    "It bypasses the model and directly updates the UI", 
                    "It executes client-side scripts" }, 
                CorrectAnswer = "It selects a view to render a response" },

            new QuizQuestion { QuestionText = "From which base class do controllers in ASP.NET Core inherit?", 
                Options = new List<string>{ 
                    "ControllerBase", 
                    "ModelBase", 
                    "ViewBase", 
                    "RouteHandler" }, 
                CorrectAnswer = "ControllerBase" },

            new QuizQuestion { QuestionText = "What does inheriting from the Controller base class provide?", 
                Options = new List<string>{ 
                    "Methods for handling database queries", 
                    "Methods for responding to HTTP requests", 
                    "A built-in front-end framework", 
                    "Direct access to JavaScript execution" }, 
                CorrectAnswer = "Methods for responding to HTTP requests" },

            
            new QuizQuestion { QuestionText = "What are actions within a controller in ASP.NET Core?", 
                Options = new List<string>{ 
                    "Endpoints to which HTTP requests are routed", 
                    "CSS styling elements", 
                    "Methods for defining database schemas", 
                    "JavaScript event handlers" }, 
                CorrectAnswer = "Endpoints to which HTTP requests are routed" },

            new QuizQuestion { QuestionText = "How do controllers handle HTTP requests in ASP.NET Core?", 
                Options = new List<string>{ 
                    "By executing SQL queries directly", 
                    "By defining actions that act as endpoints for HTTP requests", 
                    "By processing only GET requests", 
                    "By managing UI rendering exclusively" }, 
                CorrectAnswer = "By defining actions that act as endpoints for HTTP requests" },


            new QuizQuestion { QuestionText = "From which base class do controllers in ASP.NET Core inherit?", 
                Options = new List<string>{ 
                    "ControllerBase", 
                    "ModelBase", 
                    "ViewBase", 
                    "RouteHandler" }, 
                CorrectAnswer = "ControllerBase" },

            new QuizQuestion { QuestionText = "What does inheriting from the Controller base class provide?", 
                Options = new List<string>{ 
                    "Methods for handling database queries", 
                    "Methods for responding to HTTP requests", 
                    "A built-in front-end framework", 
                    "Direct access to JavaScript execution" }, 
                CorrectAnswer = "Methods for responding to HTTP requests" },

            new QuizQuestion { QuestionText = "What are actions within a controller in ASP.NET Core?", 
                Options = new List<string>{ 
                    "Endpoints to which HTTP requests are routed", 
                    "CSS styling elements", 
                    "Methods for defining database schemas", 
                    "JavaScript event handlers" }, 
                CorrectAnswer = "Endpoints to which HTTP requests are routed" },

            new QuizQuestion { QuestionText = "How do controllers handle HTTP requests in ASP.NET Core?", 
                Options = new List<string>{ 
                    "By executing SQL queries directly", 
                    "By defining actions that act as endpoints for HTTP requests", 
                    "By processing only GET requests", 
                    "By managing UI rendering exclusively" }, 
                CorrectAnswer = "By defining actions that act as endpoints for HTTP requests" },

            new QuizQuestion { QuestionText = "What does the Index action do in an ASP.NET Core controller?", 
                Options = new List<string>{ 
                    "Retrieves all products using the IProductRepository service and passes them to the Index view", 
                    "Retrieves a single product by ID", 
                    "Deletes a product from the database", 
                    "Handles user authentication" }, 
                CorrectAnswer = "Retrieves all products using the IProductRepository service and passes them to the Index view" },

            new QuizQuestion { QuestionText = "What does the Details action do in an ASP.NET Core controller?", 
                Options = new List<string>{ 
                    "Retrieves a single product by ID and passes it to the Details view", 
                    "Retrieves all products and displays them in a list", 
                    "Deletes a product from the database", 
                    "Handles form submission from the user" }, 
                CorrectAnswer = "Retrieves a single product by ID and passes it to the Details view" },

            new QuizQuestion { QuestionText = "What happens if the requested product does not exist in the Details action?", 
                Options = new List<string>{ 
                    "It returns a NotFound result", 
                    "It redirects to the Index view", 
                    "It displays an empty product page", 
                    "It creates a new product automatically" }, 
                CorrectAnswer = "It returns a NotFound result" },

            new QuizQuestion { QuestionText = "What is the primary function of action methods in MVC controllers?", 
                Options = new List<string>{ 
                    "Handling user input, interacting with models, and selecting views", 
                    "Storing data directly in the database", 
                    "Managing front-end design and animations", 
                    "Executing JavaScript functions in the browser" }, 
                CorrectAnswer = "Handling user input, interacting with models, and selecting views" },

            new QuizQuestion { QuestionText = "How are action methods mapped to HTTP requests?", 
                Options = new List<string>{ 
                    "Using predefined class variables", 
                    "By mapping them to different HTTP request types such as GET and POST", 
                    "By defining JavaScript event listeners", 
                    "By executing SQL queries automatically" }, 
                CorrectAnswer = "By mapping them to different HTTP request types such as GET and POST" },

            new QuizQuestion { QuestionText = "Which HTTP request type is typically used for retrieving data?", 
                Options = new List<string>{ 
                    "POST", "DELETE", "GET", "PUT" }, 
                CorrectAnswer = "GET" },

            new QuizQuestion { QuestionText = "Which HTTP request type is typically used for submitting data?", 
                Options = new List<string>{ 
                    "POST", "GET", "DELETE", "PATCH" }, 
                CorrectAnswer = "POST" },

            new QuizQuestion { QuestionText = "What is attribute routing in MVC?", 
                Options = new List<string>{ 
                    "A way to define database schema", 
                    "Decorating action methods with attributes to specify HTTP request types", 
                    "A method for rendering front-end UI", 
                    "A technique for writing JavaScript functions in controllers" }, 
                CorrectAnswer = "Decorating action methods with attributes to specify HTTP request types" },

            new QuizQuestion { QuestionText = "Which of the following is NOT a valid HTTP method attribute in MVC?", 
                Options = new List<string>{ 
                    "[HttpGet]", "[HttpPost]", "[HttpRender]", "[HttpDelete]" }, 
                CorrectAnswer = "[HttpRender]" },

            new QuizQuestion { QuestionText = "How can action methods receive parameters?", 
                Options = new List<string>{ 
                    "By using route data or query strings", 
                    "By defining them in CSS files", 
                    "By creating hardcoded values in JavaScript", 
                    "By embedding them in HTML attributes" }, 
                CorrectAnswer = "By using route data or query strings" },

            new QuizQuestion { QuestionText = "What is the purpose of the Index method marked with [HttpGet]?", 
                Options = new List<string>{ 
                    "To submit form data", 
                    "To display a feedback form to the user", 
                    "To delete an existing record", 
                    "To modify a user’s data" }, 
                CorrectAnswer = "To display a feedback form to the user" },

            new QuizQuestion { QuestionText = "What does the SubmitFeedback method marked with [HttpPost] do?", 
                Options = new List<string>{ 
                    "Displays a feedback form", 
                    "Handles form submission, processes feedback, and returns validation messages", 
                    "Retrieves data from the database", 
                    "Deletes user feedback" }, 
                CorrectAnswer = "Handles form submission, processes feedback, and returns validation messages" },

            new QuizQuestion { QuestionText = "Which action result is used to render a specified view?", 
                Options = new List<string>{ 
                    "RedirectToActionResult", 
                    "JsonResult", 
                    "ViewResult", 
                    "ContentResult" }, 
                CorrectAnswer = "ViewResult" },

            new QuizQuestion { QuestionText = "What does RedirectToActionResult do in MVC?", 
                Options = new List<string>{ 
                    "Returns JSON data", 
                    "Renders a view", 
                    "Redirects to another action or controller", 
                    "Deletes an HTTP request" }, 
                CorrectAnswer = "Redirects to another action or controller" },

            new QuizQuestion { QuestionText = "What is the purpose of JsonResult in MVC?", 
                Options = new List<string>{ 
                    "Returns a JSON representation of an object", 
                    "Redirects users to another view", 
                    "Loads JavaScript functions", 
                    "Processes SQL queries" }, 
                CorrectAnswer = "Returns a JSON representation of an object" },

            

        };

        private static List<QuizQuestion> _questions3 = new List<QuizQuestion>
        {
            new QuizQuestion { QuestionText = "What is the role of Models in the MVC architecture?", 
                Options = new List<string>{ 
                    "To define the user interface", 
                    "To represent data and business logic", 
                    "To manage routing configuration", 
                    "To control how data is displayed" }, 
                CorrectAnswer = "To represent data and business logic" },

            new QuizQuestion { QuestionText = "What do models manage in an MVC application?", 
                Options = new List<string>{ 
                    "Only the visual layout", 
                    "Only database queries", 
                    "Rules, data, and logic of the application", 
                    "Controller actions" }, 
                CorrectAnswer = "Rules, data, and logic of the application" },

            new QuizQuestion { QuestionText = "How do models interact with other MVC components?", 
                Options = new List<string>{ 
                    "They define the UI directly", 
                    "They store and provide data independently of Views and Controllers", 
                    "They only work with Controllers", 
                    "They are responsible for rendering HTML content" }, 
                CorrectAnswer = "They store and provide data independently of Views and Controllers" },

            new QuizQuestion { QuestionText = "Which MVC component is responsible for data and business logic?", 
                Options = new List<string>{ 
                    "Controller", "View", "Model", "Router" }, 
                CorrectAnswer = "Model" },

            new QuizQuestion { QuestionText = "Which component in MVC pulls data from the Model via getters?", 
                Options = new List<string>{ 
                    "View", "Controller", "Middleware", "Router" }, 
                CorrectAnswer = "Controller" },

            new QuizQuestion { QuestionText = "What action does the View perform in MVC?", 
                Options = new List<string>{ 
                    "Represents the current model state", 
                    "Stores data in the database", 
                    "Processes business logic", 
                    "Handles server-side authentication" }, 
                CorrectAnswer = "Represents the current model state" },

            new QuizQuestion { QuestionText = "How does the Controller interact with the Model?", 
                Options = new List<string>{ 
                    "It modifies and retrieves data from the Model", 
                    "It directly updates the user interface", 
                    "It replaces the View component", 
                    "It only handles user authentication" }, 
                CorrectAnswer = "It modifies and retrieves data from the Model" },

            new QuizQuestion { QuestionText = "How do models in MVC interact with databases?", 
                Options = new List<string>{ 
                    "Using Object-Relational Mapping (ORM) tools like Entity Framework", 
                    "Directly modifying database tables in the View", 
                    "By writing raw SQL queries inside the Controller", 
                    "Through JavaScript scripts" }, 
                CorrectAnswer = "Using Object-Relational Mapping (ORM) tools like Entity Framework" },

            new QuizQuestion { QuestionText = "What is responsible for data management in an MVC application?", 
                Options = new List<string>{ 
                    "Model", "View", "Controller", "Middleware" }, 
                CorrectAnswer = "Model" },
          
            new QuizQuestion { QuestionText = "What does CRUD stand for in database interactions?", 
                Options = new List<string>{ 
                    "Create, Read, Update, Delete", 
                    "Convert, Render, Upload, Download", 
                    "Compile, Run, Update, Debug", 
                    "Cache, Retrieve, Undo, Deploy" }, 
                CorrectAnswer = "Create, Read, Update, Delete" },

            new QuizQuestion { QuestionText = "Which component in MVC typically handles CRUD operations?", 
                Options = new List<string>{ 
                    "Model", "View", "Controller", "Middleware" }, 
                CorrectAnswer = "Model" },

            new QuizQuestion { QuestionText = "In the example, what would a model representing an 'Engineer' manage?", 
                Options = new List<string>{ 
                    "UI rendering for engineers", 
                    "Engineer data with methods to retrieve, add, update, or delete records", 
                    "Controller actions only", 
                    "Styling elements for engineer-related views" }, 
                CorrectAnswer = "Engineer data with methods to retrieve, add, update, or delete records" },

            new QuizQuestion { ImageUrl = "/Images/Screenshot 2025-02-18 200958.png", QuestionText = "Which framework is shown in the image as interacting with the database?", 
                Options = new List<string>{ 
                    "Entity Framework Core", 
                    "React.js", 
                    "Django ORM", 
                    "MongoDB" }, 
                CorrectAnswer = "Entity Framework Core"},

            new QuizQuestion { QuestionText = "What is EF Core?", 
                Options = new List<string>{ 
                    "A front-end framework for UI design", 
                    "A lightweight, extensible, open-source, and cross-platform version of Entity Framework", 
                    "A JavaScript library for handling HTTP requests", 
                    "A database management system (DBMS)" }, 
                CorrectAnswer = "A lightweight, extensible, open-source, and cross-platform version of Entity Framework" },

            new QuizQuestion { QuestionText = "What is the function of EF Core?", 
                Options = new List<string>{ 
                    "It serves as an Object-Relational Mapper (ORM) that enables .NET developers to work with a database using .NET objects", 
                    "It is a framework for styling web applications", 
                    "It is used for managing server requests", 
                    "It is a tool for front-end development" }, 
                CorrectAnswer = "It serves as an Object-Relational Mapper (ORM) that enables .NET developers to work with a database using .NET objects" },

            new QuizQuestion { QuestionText = "What does EF Core eliminate the need for?", 
                Options = new List<string>{ 
                    "Writing complex SQL queries manually", 
                    "Using .NET objects", 
                    "Handling HTTP requests", 
                    "Defining CSS styles" }, 
                CorrectAnswer = "Writing complex SQL queries manually" },

            new QuizQuestion { QuestionText = "What does EF Core use to query databases?", 
                Options = new List<string>{ 
                    "LINQ (Language Integrated Query)", 
                    "JavaScript", 
                    "XML", 
                    "CSS" }, 
                CorrectAnswer = "LINQ (Language Integrated Query)" },

            new QuizQuestion { QuestionText = "What feature in EF Core automatically tracks changes made to entity instances?", 
                Options = new List<string>{ 
                    "Change Tracking", 
                    "Migrations", 
                    "LINQ Queries", 
                    "Routing" }, 
                CorrectAnswer = "Change Tracking" },

            new QuizQuestion { QuestionText = "What is the purpose of migrations in EF Core?", 
                Options = new List<string>{ 
                    "To incrementally update the database schema while preserving existing data", 
                    "To delete the database schema", 
                    "To optimize front-end UI components", 
                    "To generate automated documentation" }, 
                CorrectAnswer = "To incrementally update the database schema while preserving existing data" },

            new QuizQuestion { QuestionText = "What does EF Core provide by default but allows customization using Data Annotations or Fluent API?", 
                Options = new List<string>{ 
                    "Conventions and Configurations", 
                    "Routing and Middleware", 
                    "Frontend Components", 
                    "HTTP Request Handling" }, 
                CorrectAnswer = "Conventions and Configurations" },
            new QuizQuestion { QuestionText = "What are conventions in EF Core?", 
                Options = new List<string>{ 
                    "Built-in rules EF Core applies by default, such as pluralizing table names and primary key recognition", 
                    "Manually defined configurations for database structure", 
                    "Custom validation rules for front-end forms", 
                    "A way to manage user authentication" }, 
                CorrectAnswer = "Built-in rules EF Core applies by default, such as pluralizing table names and primary key recognition" },

            new QuizQuestion { QuestionText = "Which of the following is an example of an EF Core convention?", 
                Options = new List<string>{ 
                    "Pluralizing table names", 
                    "Hardcoding database table names", 
                    "Defining explicit column mappings for all tables", 
                    "Manually specifying all primary keys" }, 
                CorrectAnswer = "Pluralizing table names" },

            new QuizQuestion { QuestionText = "How can default EF Core conventions be overridden?", 
                Options = new List<string>{ 
                    "Using Fluent API or Data Annotations", 
                    "By modifying the HTML structure", 
                    "By executing JavaScript functions", 
                    "By writing CSS styles" }, 
                CorrectAnswer = "Using Fluent API or Data Annotations" },

            new QuizQuestion { QuestionText = "What is the purpose of configurations in EF Core?", 
                Options = new List<string>{ 
                    "To override default conventions with a predefined database structure", 
                    "To generate database queries dynamically", 
                    "To format data on the front-end", 
                    "To handle HTTP requests" }, 
                CorrectAnswer = "To override default conventions with a predefined database structure" },

            new QuizQuestion { QuestionText = "What is the role of the DbContext class in Entity Framework Core?", 
                Options = new List<string>{ 
                    "It represents a session with the database, allowing for querying and saving data", 
                    "It defines the front-end UI structure", 
                    "It is used to manage CSS styles", 
                    "It processes JavaScript events" }, 
                CorrectAnswer = "It represents a session with the database, allowing for querying and saving data" },

            new QuizQuestion { QuestionText = "What does the DbContext class help manage?", 
                Options = new List<string>{ 
                    "The database connection and configurations for Entity Framework", 
                    "Front-end page rendering", 
                    "User authentication", 
                    "API routing" }, 
                CorrectAnswer = "The database connection and configurations for Entity Framework" },

            new QuizQuestion { QuestionText = "What allows relationships between model classes to be defined in Entity Framework Core?", 
                Options = new List<string>{ 
                    "Navigation properties and collections", 
                    "JavaScript functions", 
                    "CSS classes", 
                    "HTML elements" }, 
                CorrectAnswer = "Navigation properties and collections" },

            new QuizQuestion { QuestionText = "Why might a relationship between models work without being explicitly defined in DbContext?", 
                Options = new List<string>{ 
                    "Because EF Core infers relationships based on its conventions", 
                    "Because EF Core does not require relationships", 
                    "Because relationships must always be hardcoded", 
                    "Because models do not interact with databases" }, 
                CorrectAnswer = "Because EF Core infers relationships based on its conventions" },


            new QuizQuestion { QuestionText = "What is the purpose of inheriting from DbContext in EF Core?", 
                Options = new List<string>{ 
                    "To provide database connection management and entity tracking", 
                    "To create UI elements", 
                    "To handle HTTP requests", 
                    "To define middleware components" }, 
                CorrectAnswer = "To provide database connection management and entity tracking" },

            new QuizQuestion { QuestionText = "What does DbSet<Student> represent in EF Core?", 
                Options = new List<string>{ 
                    "A table in the database representing Students", 
                    "A method for rendering HTML", 
                    "A controller action", 
                    "A JavaScript object" }, 
                CorrectAnswer = "A table in the database representing Students" },

            new QuizQuestion { QuestionText = "How does EF Core represent database tables in DbContext?", 
                Options = new List<string>{ 
                    "Using DbSet properties", 
                    "Using HTML elements", 
                    "Through JavaScript functions", 
                    "By manually writing SQL queries" }, 
                CorrectAnswer = "Using DbSet properties" },

            

            new QuizQuestion { QuestionText = "Which method in DbContext is used to configure the database connection?", 
                Options = new List<string>{ 
                    "OnConfiguring", 
                    "ConfigureServices", 
                    "InitializeDatabase", 
                    "SetupConnection" }, 
                CorrectAnswer = "OnConfiguring" },

            new QuizQuestion { QuestionText = "What is the purpose of the OnConfiguring method in DbContext?", 
                Options = new List<string>{ 
                    "To define the database connection string", 
                    "To modify front-end styles", 
                    "To execute JavaScript scripts", 
                    "To handle API routing" }, 
                CorrectAnswer = "To define the database connection string" },

            new QuizQuestion { QuestionText = "How does DbContext enable querying in EF Core?", 
                Options = new List<string>{ 
                    "By using LINQ queries against the database with DbSet properties", 
                    "By manually writing raw SQL queries", 
                    "By directly modifying HTML elements", 
                    "By handling front-end interactions" }, 
                CorrectAnswer = "By using LINQ queries against the database with DbSet properties" },

            new QuizQuestion { QuestionText = "Which CRUD operations does DbContext facilitate?", 
                Options = new List<string>{ 
                    "Create, Read, Update, Delete", 
                    "Compile, Run, Update, Debug", 
                    "Cache, Retrieve, Undo, Deploy", 
                    "Convert, Render, Upload, Download" }, 
                CorrectAnswer = "Create, Read, Update, Delete" },

            new QuizQuestion { QuestionText = "Which component in EF Core helps manage CRUD operations?", 
                Options = new List<string>{ 
                    "DbContext", "Controller", "Middleware", "View" }, 
                CorrectAnswer = "DbContext" },

            new QuizQuestion { QuestionText = "What is the purpose of Change Tracking in DbContext?", 
                Options = new List<string>{ 
                    "To automatically keep track of changes made to entities", 
                    "To manually update database entries", 
                    "To modify front-end UI components", 
                    "To manage server configurations" }, 
                CorrectAnswer = "To automatically keep track of changes made to entities" },

            new QuizQuestion { QuestionText = "How does DbContext help with database migrations?", 
                Options = new List<string>{ 
                    "It enables schema updates based on model changes", 
                    "It modifies the HTML layout of the application", 
                    "It executes JavaScript functions", 
                    "It compiles CSS styles" }, 
                CorrectAnswer = "It enables schema updates based on model changes" },

            new QuizQuestion { QuestionText = "What feature in EF Core allows schema updates without data loss?", 
                Options = new List<string>{ 
                    "Migrations", "Change Tracking", "Query Optimization", "View Rendering" }, 
                CorrectAnswer = "Migrations" },

            new QuizQuestion { QuestionText = "What are data annotations used for in EF Core?", 
                Options = new List<string>{ 
                    "Defining validation rules and database schema configurations", 
                    "Styling the front-end UI", 
                    "Managing API requests", 
                    "Handling HTTP routing" }, 
                CorrectAnswer = "Defining validation rules and database schema configurations" },

            new QuizQuestion { QuestionText = "Where are data annotations placed in EF Core?", 
                Options = new List<string>{ 
                    "On model properties", 
                    "Inside the database", 
                    "In the View files", 
                    "Inside JavaScript functions" }, 
                CorrectAnswer = "On model properties" },

            new QuizQuestion { QuestionText = "What does the [Required] annotation enforce?", 
                Options = new List<string>{ 
                    "Ensures the property cannot be null", 
                    "Limits the length of a string", 
                    "Specifies the data type", 
                    "Sets a numeric range" }, 
                CorrectAnswer = "Ensures the property cannot be null" },

            new QuizQuestion { QuestionText = "Which annotation is used to define a minimum and maximum numeric range?", 
                Options = new List<string>{ 
                    "[Range]", 
                    "[StringLength]", 
                    "[Required]", 
                    "[DataType]" }, 
                CorrectAnswer = "[Range]" },

            new QuizQuestion { QuestionText = "Which annotation is used to limit the length of a string?", 
                Options = new List<string>{ 
                    "[StringLength]", 
                    "[Required]", 
                    "[Range]", 
                    "[DataType]" }, 
                CorrectAnswer = "[StringLength]" },

            new QuizQuestion { QuestionText = "Which annotation is used to specify a particular data format?", 
                Options = new List<string>{ 
                    "[DataType]", 
                    "[Required]", 
                    "[StringLength]", 
                    "[Range]" }, 
                CorrectAnswer = "[DataType]" },

            new QuizQuestion { QuestionText = "What is the purpose of migrations in Entity Framework Core?", 
                Options = new List<string>{ 
                    "To incrementally update the database schema while preserving existing data", 
                    "To delete and recreate the database whenever changes are made", 
                    "To handle user authentication", 
                    "To manage API routing" }, 
                CorrectAnswer = "To incrementally update the database schema while preserving existing data" },

            new QuizQuestion { QuestionText = "How do migrations help developers in EF Core?", 
                Options = new List<string>{ 
                    "They allow the database schema to evolve over time without recreating the database or losing data", 
                    "They force developers to manually rewrite SQL scripts", 
                    "They are only used for front-end design", 
                    "They replace the need for data validation" }, 
                CorrectAnswer = "They allow the database schema to evolve over time without recreating the database or losing data" },

            new QuizQuestion { QuestionText = "Which feature in EF Core helps manage schema changes while preserving existing data?", 
                Options = new List<string>{ 
                    "Migrations", 
                    "Change Tracking", 
                    "Data Annotations", 
                    "Routing Middleware" }, 
                CorrectAnswer = "Migrations" },

            new QuizQuestion { QuestionText = "What problem do migrations solve in database management?", 
                Options = new List<string>{ 
                    "They prevent loss of data while modifying the database schema", 
                    "They improve website performance", 
                    "They enhance API response times", 
                    "They handle JavaScript execution" }, 
                CorrectAnswer = "They prevent loss of data while modifying the database schema" },

            
        };

        private static List<QuizQuestion> _questions4 = new List<QuizQuestion>
        {
            new QuizQuestion { QuestionText = "What is the role of Controllers in the MVC framework?", 
                Options = new List<string>{ 
                    "They act as intermediaries between the Model and the View, handling user requests, processing them, and returning a response", 
                    "They store and retrieve data directly from the database", 
                    "They manage front-end design and layout", 
                    "They only handle API requests" }, 
                CorrectAnswer = "They act as intermediaries between the Model and the View, handling user requests, processing them, and returning a response" },

            new QuizQuestion { QuestionText = "What do Controllers determine in an MVC application?", 
                Options = new List<string>{ 
                    "How to respond to user input and which View should be rendered", 
                    "The structure of the database schema", 
                    "The way HTML elements are styled", 
                    "The way JavaScript executes client-side interactions" }, 
                CorrectAnswer = "How to respond to user input and which View should be rendered" },

            new QuizQuestion { QuestionText = "Which component in MVC is responsible for handling user requests?", 
                Options = new List<string>{ 
                    "Controller", "Model", "View", "Middleware" }, 
                CorrectAnswer = "Controller" },

            new QuizQuestion { QuestionText = "What does the Controller pull data from?", 
                Options = new List<string>{ 
                    "Model", "View", "Database directly", "JavaScript files" }, 
                CorrectAnswer = "Model" },

            new QuizQuestion { QuestionText = "What action does the Controller take after processing user input?", 
                Options = new List<string>{ 
                    "It determines which View to render", 
                    "It directly modifies the database", 
                    "It handles UI animations", 
                    "It executes background server tasks" }, 
                CorrectAnswer = "It determines which View to render" },

            new QuizQuestion { QuestionText = "What is the role of controllers in handling client requests?", 
                Options = new List<string>{ 
                    "They receive HTTP requests and decide the course of action", 
                    "They directly modify the database schema", 
                    "They manage front-end styling", 
                    "They execute JavaScript code" }, 
                CorrectAnswer = "They receive HTTP requests and decide the course of action" },

            new QuizQuestion { QuestionText = "How does a controller typically handle different types of requests?", 
                Options = new List<string>{ 
                    "Each action method corresponds to a specific request", 
                    "Controllers handle all requests using a single method", 
                    "Controllers only process GET requests", 
                    "Controllers execute JavaScript functions on the front-end" }, 
                CorrectAnswer = "Each action method corresponds to a specific request" },

            new QuizQuestion { QuestionText = "How do controllers work with ASP.NET Core's ROUTING engine?", 
                Options = new List<string>{ 
                    "They direct requests to the appropriate action methods", 
                    "They generate database queries", 
                    "They render front-end HTML elements", 
                    "They manage user authentication" }, 
                CorrectAnswer = "They direct requests to the appropriate action methods" },

            new QuizQuestion { QuestionText = "What does the Index() action method in HomeController do?", 
                Options = new List<string>{ 
                    "It renders the Index view", 
                    "It fetches model data and returns JSON", 
                    "It deletes a record from the database", 
                    "It modifies front-end UI components" }, 
                CorrectAnswer = "It renders the Index view" },

            new QuizQuestion { QuestionText = "What is the purpose of the About(int id) method in HomeController?", 
                Options = new List<string>{ 
                    "It responds to requests for an About page, potentially with an identifier", 
                    "It processes API authentication", 
                    "It handles form submissions", 
                    "It generates a new controller" }, 
                CorrectAnswer = "It responds to requests for an About page, potentially with an identifier" },

            new QuizQuestion { QuestionText = "What is the role of controllers in MVC?", 
                Options = new List<string>{ 
                    "They serve as the glue between Models and Views, using data from Models to render Views or update Models based on user input", 
                    "They are responsible for storing data in the database", 
                    "They handle only UI design", 
                    "They execute JavaScript functions on the front-end" }, 
                CorrectAnswer = "They serve as the glue between Models and Views, using data from Models to render Views or update Models based on user input" },

            new QuizQuestion { QuestionText = "Which component in MVC is responsible for rendering data to the user?", 
                Options = new List<string>{ 
                    "View", "Model", "Controller", "Database" }, 
                CorrectAnswer = "View" },

            new QuizQuestion { QuestionText = "What is the typical flow of data in an MVC application?", 
                Options = new List<string>{ 
                    "User input -> Controller -> Model -> Database -> Model -> Controller -> View", 
                    "Controller -> User input -> Model -> View", 
                    "Model -> View -> Controller", 
                    "View -> Model -> Controller" }, 
                CorrectAnswer = "User input -> Controller -> Model -> Database -> Model -> Controller -> View" },

            new QuizQuestion { QuestionText = "Which component in MVC is responsible for handling user input and deciding how to process it?", 
                Options = new List<string>{ 
                    "Controller", "Model", "View", "Database" }, 
                CorrectAnswer = "Controller" },

            new QuizQuestion { QuestionText = "What action does the Controller take after receiving user input?", 
                Options = new List<string>{ 
                    "It retrieves or updates data in the Model and selects the appropriate View for rendering", 
                    "It directly modifies the database", 
                    "It bypasses the Model and directly updates the View", 
                    "It only stores user input without processing" }, 
                CorrectAnswer = "It retrieves or updates data in the Model and selects the appropriate View for rendering" },

            new QuizQuestion { QuestionText = "What is the role of action methods in MVC controllers?", 
                Options = new List<string>{ 
                    "They handle requests and return responses", 
                    "They store database records", 
                    "They execute JavaScript functions", 
                    "They define CSS styles for front-end design" }, 
                CorrectAnswer = "They handle requests and return responses" },

            new QuizQuestion { QuestionText = "Each action method in MVC typically corresponds to what?", 
                Options = new List<string>{ 
                    "A specific operation or endpoint", 
                    "A front-end UI element", 
                    "A static HTML file", 
                    "A database table" }, 
                CorrectAnswer = "A specific operation or endpoint" },

            new QuizQuestion { QuestionText = "What is the primary function of action methods in MVC?", 
                Options = new List<string>{ 
                    "Handling user interactions within the MVC pattern", 
                    "Storing CSS styles for HTML rendering", 
                    "Executing SQL queries directly", 
                    "Managing cloud storage configurations" }, 
                CorrectAnswer = "Handling user interactions within the MVC pattern" },

            new QuizQuestion { QuestionText = "What is the first step when a request is received in an MVC application?", 
                Options = new List<string>{ 
                    "The request is received and matched to the appropriate controller action via routing", 
                    "The database is directly modified", 
                    "The HTML content is generated first", 
                    "The JavaScript function is executed before anything else" }, 
                CorrectAnswer = "The request is received and matched to the appropriate controller action via routing" },

            new QuizQuestion { QuestionText = "What happens before an action method executes in MVC?", 
                Options = new List<string>{ 
                    "Model binding and validation occur", 
                    "The View is rendered immediately", 
                    "The database updates itself automatically", 
                    "JavaScript functions run before any processing" }, 
                CorrectAnswer = "Model binding and validation occur" },

            new QuizQuestion { QuestionText = "Which MVC component executes after the action method completes?", 
                Options = new List<string>{ 
                    "ViewResult Execution", 
                    "Middleware Processing", 
                    "Database Connection", 
                    "Routing Module" }, 
                CorrectAnswer = "ViewResult Execution" },

            new QuizQuestion { QuestionText = "What do action methods return in MVC?", 
                Options = new List<string>{ 
                    "Action results, depending on the nature of the request and desired output", 
                    "Always an HTML page", 
                    "Only JSON data", 
                    "A static text response" }, 
                CorrectAnswer = "Action results, depending on the nature of the request and desired output" },

            new QuizQuestion { QuestionText = "What is the purpose of IActionResult in MVC?", 
                Options = new List<string>{ 
                    "It allows an action method to return different types of results", 
                    "It forces all methods to return JSON", 
                    "It is used only for handling HTTP requests", 
                    "It is responsible for database connections" }, 
                CorrectAnswer = "It allows an action method to return different types of results" },

            new QuizQuestion { QuestionText = "What does ViewResult return?", 
                Options = new List<string>{ 
                    "An HTML view", 
                    "A JSON response", 
                    "A file response", 
                    "A database query result" }, 
                CorrectAnswer = "An HTML view" },

            new QuizQuestion { QuestionText = "Which action result is used to return JSON data?", 
                Options = new List<string>{ 
                    "JsonResult", 
                    "ViewResult", 
                    "RedirectResult", 
                    "FileResult" }, 
                CorrectAnswer = "JsonResult" },

            new QuizQuestion { QuestionText = "Which action result is used for redirection to a different action or route?", 
                Options = new List<string>{ 
                    "RedirectResult", 
                    "JsonResult", 
                    "ViewResult", 
                    "FileResult" }, 
                CorrectAnswer = "RedirectResult" },

            new QuizQuestion { QuestionText = "Which action result is used to read/write files as a response?", 
                Options = new List<string>{ 
                    "FileResult", 
                    "JsonResult", 
                    "ViewResult", 
                    "RedirectResult" }, 
                CorrectAnswer = "FileResult" },

            new QuizQuestion { QuestionText = "Which HTTP verbs are commonly used in action methods?", 
                Options = new List<string>{ 
                    "GET, POST, PUT, DELETE", 
                    "CONNECT, TRACE, PATCH, OPTIONS", 
                    "HEAD, UPDATE, SYNC, EXECUTE", 
                    "IMPORT, EXPORT, REFRESH, ROLLBACK" }, 
                CorrectAnswer = "GET, POST, PUT, DELETE" },

            new QuizQuestion { QuestionText = "What does the GET verb typically do in an action method?", 
                Options = new List<string>{ 
                    "Retrieves and displays data", 
                    "Creates a new resource", 
                    "Updates existing data", 
                    "Deletes a resource" }, 
                CorrectAnswer = "Retrieves and displays data" },

            new QuizQuestion { QuestionText = "Which HTTP verb is used to create a new resource?", 
                Options = new List<string>{ 
                    "POST", 
                    "GET", 
                    "PUT", 
                    "DELETE" }, 
                CorrectAnswer = "POST" },

            new QuizQuestion { QuestionText = "How do action methods specify which HTTP verb they handle?", 
                Options = new List<string>{ 
                    "By using attribute routing, such as [HttpGet] or [HttpPost]", 
                    "By writing SQL queries in the method", 
                    "By defining a JavaScript function", 
                    "By setting a ViewBag property" }, 
                CorrectAnswer = "By using attribute routing, such as [HttpGet] or [HttpPost]" },

            new QuizQuestion { QuestionText = "What does the [HttpGet] attribute indicate in an action method?", 
                Options = new List<string>{ 
                    "That the method responds to GET requests", 
                    "That the method handles file uploads", 
                    "That the method modifies database records", 
                    "That the method deletes a resource" }, 
                CorrectAnswer = "That the method responds to GET requests" },

            new QuizQuestion { QuestionText = "What type of request does [HttpPost] handle?", 
                Options = new List<string>{ 
                    "POST requests, typically for creating new resources", 
                    "Retrieving existing resources", 
                    "Deleting resources from a database", 
                    "Updating data without affecting the database" }, 
                CorrectAnswer = "POST requests, typically for creating new resources" },

            new QuizQuestion { QuestionText = "How do action methods specify which HTTP verb they handle?", 
                Options = new List<string>{ 
                    "By using attribute routing with [HttpGet], [HttpPost], [HttpPut], or [HttpDelete]", 
                    "By defining the verb inside a JavaScript function", 
                    "By writing SQL queries inside the controller", 
                    "By modifying front-end HTML elements" }, 
                CorrectAnswer = "By using attribute routing with [HttpGet], [HttpPost], [HttpPut], or [HttpDelete]" },
         
            new QuizQuestion { QuestionText = "What is the purpose of the GET HTTP verb?", 
                Options = new List<string>{ 
                    "To retrieve data or a resource", 
                    "To create a new resource", 
                    "To update an existing resource", 
                    "To delete a resource" }, 
                CorrectAnswer = "To retrieve data or a resource" },

            new QuizQuestion { QuestionText = "Which HTTP verb is used to create a new resource?", 
                Options = new List<string>{ 
                    "POST", 
                    "GET", 
                    "PUT", 
                    "DELETE" }, 
                CorrectAnswer = "POST" },

            new QuizQuestion { QuestionText = "How does a PUT request differ from a POST request?", 
                Options = new List<string>{ 
                    "PUT is idempotent, meaning calling it multiple times produces the same result", 
                    "PUT creates a new resource while POST updates an existing one", 
                    "PUT is only used for retrieving data", 
                    "PUT does not interact with the server" }, 
                CorrectAnswer = "PUT is idempotent, meaning calling it multiple times produces the same result" },

            new QuizQuestion { QuestionText = "Which HTTP verb is used to delete a resource from the server?", 
                Options = new List<string>{ 
                    "DELETE", 
                    "POST", 
                    "PATCH", 
                    "GET" }, 
                CorrectAnswer = "DELETE" },

            new QuizQuestion { QuestionText = "What is the main difference between PUT and PATCH requests?", 
                Options = new List<string>{ 
                    "PATCH applies partial modifications, while PUT replaces the entire resource", 
                    "PATCH creates new resources, while PUT deletes them", 
                    "PATCH does not update resources", 
                    "PUT and PATCH function exactly the same" }, 
                CorrectAnswer = "PATCH applies partial modifications, while PUT replaces the entire resource" },

            new QuizQuestion { QuestionText = "Where are routes defined in an ASP.NET Core application?", 
                Options = new List<string>{ 
                    "In the Program.cs file", 
                    "In the database", 
                    "In the HTML files", 
                    "In JavaScript functions" }, 
                CorrectAnswer = "In the Program.cs file" },

            new QuizQuestion { QuestionText = "What routing method is used to define standard route patterns in ASP.NET Core?", 
                Options = new List<string>{ 
                    "MapControllerRoute", 
                    "UseDefaultFiles", 
                    "ConfigureRouting", 
                    "RouteMiddleware" }, 
                CorrectAnswer = "MapControllerRoute" },

            new QuizQuestion { QuestionText = "What does the default route pattern '{controller=Home}/{action=Index}/{id?}' mean?", 
                Options = new List<string>{ 
                    "Requests will be mapped to the Home controller’s Index action by default", 
                    "All requests are blocked by default", 
                    "It defines an API-only routing strategy", 
                    "It forces all routes to use query strings" }, 
                CorrectAnswer = "Requests will be mapped to the Home controller’s Index action by default" },

            new QuizQuestion { QuestionText = "What is the purpose of defining multiple routes in ASP.NET Core?", 
                Options = new List<string>{ 
                    "To allow different routing patterns for various parts of the application", 
                    "To restrict all user access to the application", 
                    "To make database queries faster", 
                    "To improve JavaScript execution" }, 
                CorrectAnswer = "To allow different routing patterns for various parts of the application" },

            new QuizQuestion { QuestionText = "Which type of applications benefit from multiple route definitions?", 
                Options = new List<string>{ 
                    "Applications with API endpoints, admin panels, or separate areas", 
                    "Static HTML websites", 
                    "Single-page applications with no backend", 
                    "Mobile apps using only local storage" }, 
                CorrectAnswer = "Applications with API endpoints, admin panels, or separate areas" },

            new QuizQuestion { QuestionText = "What does the route pattern 'api/{controller}/{id?}' define?", 
                Options = new List<string>{ 
                    "A routing pattern for API endpoints", 
                    "A routing pattern for admin panels", 
                    "A custom middleware function", 
                    "A JavaScript function execution order" }, 
                CorrectAnswer = "A routing pattern for API endpoints" },

            new QuizQuestion { QuestionText = "Which route pattern is commonly used for admin panels?", 
                Options = new List<string>{ 
                    "'admin/{controller=Admin}/{action=Index}/{id?}'", 
                    "'api/{controller}/{id?}'", 
                    "'{controller=Home}/{action=Index}/{id?}'", 
                    "'{controller}/{view}/{script.js}'" }, 
                CorrectAnswer = "'admin/{controller=Admin}/{action=Index}/{id?}'" },

            new QuizQuestion { QuestionText = "What is the purpose of route attributes in ASP.NET Core controllers?", 
                Options = new List<string>{ 
                    "To define how HTTP requests are mapped to action methods", 
                    "To execute JavaScript functions", 
                    "To modify CSS styles dynamically", 
                    "To store session data in cookies" }, 
                CorrectAnswer = "To define how HTTP requests are mapped to action methods" },

            new QuizQuestion { QuestionText = "Which attribute is used to specify a GET request in ASP.NET Core controllers?", 
                Options = new List<string>{ 
                    "[HttpGet]", 
                    "[HttpPost]", 
                    "[HttpPut]", 
                    "[HttpDelete]" }, 
                CorrectAnswer = "[HttpGet]" },

            new QuizQuestion { QuestionText = "Which attribute is used to specify a POST request in ASP.NET Core controllers?", 
                Options = new List<string>{ 
                    "[HttpPost]", 
                    "[HttpGet]", 
                    "[HttpDelete]", 
                    "[HttpPatch]" }, 
                CorrectAnswer = "[HttpPost]" },

            
            new QuizQuestion { QuestionText = "What is the purpose of the '[HttpGet(\"{id}\")]' route attribute?", 
                Options = new List<string>{ 
                    "It maps GET requests to '/api/products/{id}' to retrieve a specific product", 
                    "It handles POST requests for creating a new product", 
                    "It maps DELETE requests for removing a product", 
                    "It processes form submissions from the front end" }, 
                CorrectAnswer = "It maps GET requests to '/api/products/{id}' to retrieve a specific product" },

            new QuizQuestion { QuestionText = "How does the '[HttpGet(\"category/{categoryId}\")]' route attribute work?", 
                Options = new List<string>{ 
                    "It maps GET requests to '/api/products/category/{categoryId}' for retrieving products by category", 
                    "It maps POST requests for creating a new product", 
                    "It handles DELETE requests for removing a product", 
                    "It updates an existing product in the database" }, 
                CorrectAnswer = "It maps GET requests to '/api/products/category/{categoryId}' for retrieving products by category" },

            new QuizQuestion { QuestionText = "What does '[HttpPost]' typically do in an ASP.NET Core controller?", 
                Options = new List<string>{ 
                    "Handles POST requests to create a new resource", 
                    "Handles GET requests to retrieve data", 
                    "Handles DELETE requests to remove data", 
                    "Handles PATCH requests to modify part of a resource" }, 
                CorrectAnswer = "Handles POST requests to create a new resource" },

            new QuizQuestion { QuestionText = "What is the purpose of route constraints in ASP.NET Core?", 
                Options = new List<string>{ 
                    "To restrict which URLs match a route pattern based on data type or specific values", 
                    "To modify database records dynamically", 
                    "To execute JavaScript functions in the browser", 
                    "To encrypt URL parameters for security" }, 
                CorrectAnswer = "To restrict which URLs match a route pattern based on data type or specific values" },

            new QuizQuestion { QuestionText = "Which of the following URL paths will match the route pattern 'products/{id:int}'?", 
                Options = new List<string>{ 
                    "/products/5", 
                    "/products/abc", 
                    "/products/item123", 
                    "/products/view" }, 
                CorrectAnswer = "/products/5" },

            new QuizQuestion { QuestionText = "What happens if a user tries to access '/products/abc' when the route pattern is 'products/{id:int}'?", 
                Options = new List<string>{ 
                    "The request will not match the route because 'abc' is not an integer", 
                    "The request will be redirected to another controller", 
                    "The request will be processed normally", 
                    "The request will be cached for faster response" }, 
                CorrectAnswer = "The request will not match the route because 'abc' is not an integer" },

            new QuizQuestion { QuestionText = "What is the purpose of custom route templates in ASP.NET Core?", 
                Options = new List<string>{ 
                    "To define routes that don’t follow conventional patterns, allowing flexibility in URL structures", 
                    "To store user session data", 
                    "To generate SQL queries automatically", 
                    "To replace the need for controllers in an application" }, 
                CorrectAnswer = "To define routes that don’t follow conventional patterns, allowing flexibility in URL structures" },

            new QuizQuestion { QuestionText = "Which of the following route patterns allows retrieving products by name and ID?", 
                Options = new List<string>{ 
                    "'products/{productName}-{id}'", 
                    "'products/{id:int}'", 
                    "'products/view/{category}'", 
                    "'products/{name}/details'" }, 
                CorrectAnswer = "'products/{productName}-{id}'" },

            new QuizQuestion { QuestionText = "What is the purpose of naming routes in ASP.NET Core?", 
                Options = new List<string>{ 
                    "To provide unique identifiers for routes, allowing easier URL generation in the application", 
                    "To improve website SEO", 
                    "To enhance JavaScript performance", 
                    "To prevent users from modifying URLs" }, 
                CorrectAnswer = "To provide unique identifiers for routes, allowing easier URL generation in the application" },

            

            new QuizQuestion { QuestionText = "What is the purpose of route grouping in ASP.NET Core?", 
                Options = new List<string>{ 
                    "To organize routes into groups, often used in areas or for specific functionalities", 
                    "To improve SQL query performance", 
                    "To allow dynamic JavaScript execution", 
                    "To store API responses in session storage" }, 
                CorrectAnswer = "To organize routes into groups, often used in areas or for specific functionalities" },

            new QuizQuestion { QuestionText = "Why does the order of route definitions matter in ASP.NET Core?", 
                Options = new List<string>{ 
                    "Routes are evaluated in the order they are defined, so more specific routes should be placed before general ones", 
                    "Routes are randomly evaluated, and order has no effect", 
                    "Routes with numeric constraints always get priority", 
                    "Routes are ignored unless they contain query parameters" }, 
                CorrectAnswer = "Routes are evaluated in the order they are defined, so more specific routes should be placed before general ones" },

            new QuizQuestion { QuestionText = "What happens if a general route is placed before a more specific route?", 
                Options = new List<string>{ 
                    "The general route will be matched first, and the specific route may never be reached", 
                    "The specific route will always override the general route", 
                    "All routes will be ignored", 
                    "The application will throw a routing error" }, 
                CorrectAnswer = "The general route will be matched first, and the specific route may never be reached" },

            new QuizQuestion { QuestionText = "What is attribute routing in ASP.NET Core MVC?", 
                Options = new List<string>{ 
                    "A way to define routes directly on controllers and actions using attributes", 
                    "A method for dynamically generating routes from a database", 
                    "A built-in middleware for handling authentication", 
                    "A JavaScript function that controls API requests" }, 
                CorrectAnswer = "A way to define routes directly on controllers and actions using attributes" },

            new QuizQuestion { QuestionText = "Where are routes defined when using attribute routing?", 
                Options = new List<string>{ 
                    "Directly on controllers and actions", 
                    "In the database schema", 
                    "Inside CSS stylesheets", 
                    "Within JavaScript files" }, 
                CorrectAnswer = "Directly on controllers and actions" },

            new QuizQuestion { QuestionText = "What is controller-level routing in ASP.NET Core MVC?", 
                Options = new List<string>{ 
                    "Applying a route prefix to a controller to define a common path for all actions within the controller", 
                    "Defining individual routes for each action separately", 
                    "Dynamically generating URLs based on user input", 
                    "Using JavaScript to modify API endpoints at runtime" }, 
                CorrectAnswer = "Applying a route prefix to a controller to define a common path for all actions within the controller" },

            new QuizQuestion { QuestionText = "What is action-level routing?", 
                Options = new List<string>{ 
                    "Defining routes for specific actions to create custom and descriptive URLs", 
                    "Applying a route prefix to the entire controller", 
                    "Using external scripts to control routing", 
                    "Only allowing GET requests in controllers" }, 
                CorrectAnswer = "Defining routes for specific actions to create custom and descriptive URLs" },

            new QuizQuestion { QuestionText = "What does the route attribute '[Route(\"api/[Controller]\")]' do?", 
                Options = new List<string>{ 
                    "Sets a base route for all actions within the controller", 
                    "Forces all requests to use HTTP GET", 
                    "Defines a custom middleware for routing", 
                    "Enables authentication for all API endpoints" }, 
                CorrectAnswer = "Sets a base route for all actions within the controller" },

            new QuizQuestion { QuestionText = "How is an action method mapped to a specific route in attribute routing?", 
                Options = new List<string>{ 
                    "By using attributes such as [HttpGet(\"{id}\")] or [HttpPost]", 
                    "By defining all routes in the Program.cs file", 
                    "By creating a separate routing table", 
                    "By using only JavaScript-based routing" }, 
                CorrectAnswer = "By using attributes such as [HttpGet(\"{id}\")] or [HttpPost]" },

            new QuizQuestion { QuestionText = "In ASP.NET Core MVC, how is data passed to views?", 
                Options = new List<string>{ 
                    "From controllers to views using various methods", 
                    "Directly from the database to the view", 
                    "Only through JavaScript functions", 
                    "By modifying the HTML files manually" }, 
                CorrectAnswer = "From controllers to views using various methods" },

            new QuizQuestion { QuestionText = "Which of the following methods can be used to pass data to views in ASP.NET Core MVC?", 
                Options = new List<string>{ 
                    "ViewBag, ViewData, and TempData", 
                    "SessionStorage, LocalStorage, and Cookies", 
                    "JavaScript functions, Ajax calls, and API requests", 
                    "CSS variables, HTML attributes, and JavaScript events" }, 
                CorrectAnswer = "ViewBag, ViewData, and TempData" },

            new QuizQuestion { QuestionText = "Why is it important to understand the different methods for passing data to views?", 
                Options = new List<string>{ 
                    "To ensure effective data handling and rendering in views", 
                    "To modify the database directly from the view", 
                    "To enable JavaScript execution within controllers", 
                    "To prevent CSS conflicts in the application" }, 
                CorrectAnswer = "To ensure effective data handling and rendering in views" },

            new QuizQuestion { QuestionText = "What is ViewBag in ASP.NET Core MVC?", 
                Options = new List<string>{ 
                    "A dynamic object that allows passing data from the controller to the view", 
                    "A method for storing user session data", 
                    "A function for handling API requests", 
                    "A built-in SQL query execution tool" }, 
                CorrectAnswer = "A dynamic object that allows passing data from the controller to the view" },

            new QuizQuestion { QuestionText = "How does ViewBag define properties?", 
                Options = new List<string>{ 
                    "It uses dynamic properties, meaning they are defined at runtime", 
                    "It requires a strict predefined structure", 
                    "It only accepts integer values", 
                    "It cannot store multiple properties" }, 
                CorrectAnswer = "It uses dynamic properties, meaning they are defined at runtime" },

            new QuizQuestion { QuestionText = "Which scenario is ViewBag most suitable for?", 
                Options = new List<string>{ 
                    "Passing small amounts of data that do not require complex logic or structure", 
                    "Storing large datasets for database transactions", 
                    "Managing authentication and authorization", 
                    "Handling HTTP requests and responses" }, 
                CorrectAnswer = "Passing small amounts of data that do not require complex logic or structure" },

            new QuizQuestion { QuestionText = "How is data stored in ViewBag accessed in a Razor view?", 
                Options = new List<string>{ 
                    "@ViewBag.PropertyName", 
                    "ViewBag[\"PropertyName\"]", 
                    "ViewBag.Get(\"PropertyName\")", 
                    "@Model.PropertyName" }, 
                CorrectAnswer = "@ViewBag.PropertyName" },

            new QuizQuestion { QuestionText = "Which of the following is a correct way to assign a value to ViewBag in a controller?", 
                Options = new List<string>{ 
                    "ViewBag.Message = \"Hello, World!\";", 
                    "ViewBag[\"Message\"] = \"Hello, World!\";", 
                    "ViewBag.Set(\"Message\", \"Hello, World!\");", 
                    "ViewBag.Add(\"Message\", \"Hello, World!\");" }, 
                CorrectAnswer = "ViewBag.Message = \"Hello, World!\";" },

            new QuizQuestion { QuestionText = "What is ViewData in ASP.NET Core MVC?", 
                Options = new List<string>{ 
                    "A dictionary of objects that are accessed using string keys", 
                    "A built-in SQL query execution tool", 
                    "A method for handling HTTP requests", 
                    "A class for managing API endpoints" }, 
                CorrectAnswer = "A dictionary of objects that are accessed using string keys" },

            new QuizQuestion { QuestionText = "How is ViewData different from ViewBag?", 
                Options = new List<string>{ 
                    "ViewData uses string keys, while ViewBag uses dynamic properties", 
                    "ViewData stores objects permanently, while ViewBag only stores strings", 
                    "ViewData is used only for large datasets", 
                    "ViewData requires JavaScript to access values" }, 
                CorrectAnswer = "ViewData uses string keys, while ViewBag uses dynamic properties" },

            new QuizQuestion { QuestionText = "What is ViewData based on?", 
                Options = new List<string>{ 
                    "ViewDataDictionary class", 
                    "Dictionary<string, object> class", 
                    "SessionStorage API", 
                    "ASP.NET Core Middleware" }, 
                CorrectAnswer = "ViewDataDictionary class" },

            new QuizQuestion { QuestionText = "How is data stored in ViewData accessed in a Razor view?", 
                Options = new List<string>{ 
                    "ViewData[\"PropertyName\"]", 
                    "@ViewBag.PropertyName", 
                    "ViewData.Get(\"PropertyName\")", 
                    "@Model.PropertyName" }, 
                CorrectAnswer = "ViewData[\"PropertyName\"]" },

            new QuizQuestion { QuestionText = "Which of the following is a correct way to assign a value to ViewData in a controller?", 
                Options = new List<string>{ 
                    "ViewData[\"Message\"] = \"Hello, World!\";", 
                    "ViewData.Message = \"Hello, World!\";", 
                    "ViewData.Add(\"Message\", \"Hello, World!\");", 
                    "ViewData.Set(\"Message\", \"Hello, World!\");" }, 
                CorrectAnswer = "ViewData[\"Message\"] = \"Hello, World!\";" },

            new QuizQuestion { QuestionText = "What is TempData used for in ASP.NET Core MVC?", 
                Options = new List<string>{ 
                    "Passing data from one request to another", 
                    "Storing session-based user authentication tokens", 
                    "Fetching data from a remote API", 
                    "Modifying the database schema dynamically" }, 
                CorrectAnswer = "Passing data from one request to another" },

            new QuizQuestion { QuestionText = "In which scenario is TempData commonly used?", 
                Options = new List<string>{ 
                    "Redirects, as it persists data for the duration of an HTTP request", 
                    "Long-term session storage", 
                    "Storing user preferences across multiple visits", 
                    "Client-side caching of data" }, 
                CorrectAnswer = "Redirects, as it persists data for the duration of an HTTP request" },

            new QuizQuestion { QuestionText = "How long does data stored in TempData persist?", 
                Options = new List<string>{ 
                    "Until the next HTTP request", 
                    "Permanently, unless manually deleted", 
                    "Only within the same action method", 
                    "For the entire duration of the application" }, 
                CorrectAnswer = "Until the next HTTP request" },

            new QuizQuestion { QuestionText = "How is TempData accessed in a Razor view?", 
                Options = new List<string>{ 
                    "@TempData[\"Message\"]", 
                    "TempData.Get(\"Message\")", 
                    "@ViewBag.Message", 
                    "ViewData[\"Message\"]" }, 
                CorrectAnswer = "@TempData[\"Message\"]" },

            new QuizQuestion { QuestionText = "Which of the following is a correct way to assign a value to TempData in a controller?", 
                Options = new List<string>{ 
                    "TempData[\"Message\"] = \"Success!\";", 
                    "TempData.Message = \"Success!\";", 
                    "TempData.Set(\"Message\", \"Success!\");", 
                    "TempData.Add(\"Message\", \"Success!\");" }, 
                CorrectAnswer = "TempData[\"Message\"] = \"Success!\";" },

          
            
        };

        private static List<QuizQuestion> _questions5 = new List<QuizQuestion>
        {

            new QuizQuestion { QuestionText = "What is the primary purpose of the Razor engine in ASP.NET Core MVC?", 
                Options = new List<string>{ 
                    "To embed server-based code into webpages", 
                    "To handle database queries", 
                    "To create and manage HTTP requests", 
                    "To perform unit testing for applications" }, 
                CorrectAnswer = "To embed server-based code into webpages" },

            new QuizQuestion { QuestionText = "Which programming language does Razor seamlessly integrate with?", 
                Options = new List<string>{ 
                    "C#", 
                    "JavaScript", 
                    "Python", 
                    "PHP" }, 
                CorrectAnswer = "C#" },

            new QuizQuestion { QuestionText = "What is a key feature of Razor?", 
                Options = new List<string>{ 
                    "Fluid integration of server code with HTML", 
                    "Execution of SQL queries directly from views", 
                    "Managing application security", 
                    "Performing client-side rendering only" }, 
                CorrectAnswer = "Fluid integration of server code with HTML" },

            new QuizQuestion { QuestionText = "What is the purpose of the @model directive in Razor?", 
                Options = new List<string>{ 
                    "To specify the model type the view expects", 
                    "To define a controller action", 
                    "To format HTML content", 
                    "To execute JavaScript functions" }, 
                CorrectAnswer = "To specify the model type the view expects" },

            new QuizQuestion { QuestionText = "Which syntax is used in Razor to define code blocks?", 
                Options = new List<string>{ 
                    "@{ ... }", 
                    "<script> ... </script>", 
                    "[[ ... ]]", 
                    "<csharp> ... </csharp>" }, 
                CorrectAnswer = "@{ ... }" },

            new QuizQuestion { QuestionText = "What symbol is used in Razor expressions to render server-side values into HTML?", 
                Options = new List<string>{ 
                    "@", 
                    "$", 
                    "%", 
                    "#" }, 
                CorrectAnswer = "@" },

            new QuizQuestion { QuestionText = "What symbol is used in Razor to embed C# code within HTML?", 
                Options = new List<string>{ 
                    "@", 
                    "$", 
                    "#", 
                    "%" }, 
                CorrectAnswer = "@" },

            new QuizQuestion { QuestionText = "What feature in Razor allows dynamic content rendering by mixing C# with HTML?", 
                Options = new List<string>{ 
                    "Mixing C# and HTML", 
                    "View Components", 
                    "JavaScript Integration", 
                    "Razor Pages" }, 
                CorrectAnswer = "Mixing C# and HTML" },

            new QuizQuestion { QuestionText = "What does Razor Data Binding allow?", 
                Options = new List<string>{ 
                    "Binding model properties directly in the HTML", 
                    "Executing SQL queries", 
                    "Sending HTTP requests", 
                    "Handling client-side events" }, 
                CorrectAnswer = "Binding model properties directly in the HTML" },

            new QuizQuestion { QuestionText = "What is the purpose of ASP.NET MVC model binding?", 
                Options = new List<string>{ 
                    "Mapping HTTP request data with a model", 
                    "Encrypting user credentials", 
                    "Rendering JavaScript functions", 
                    "Performing server-side caching" }, 
                CorrectAnswer = "Mapping HTTP request data with a model" },

            new QuizQuestion { QuestionText = "What are partial views in ASP.NET Core MVC?", 
                Options = new List<string>{ 
                    "Mini-views rendered within other views", 
                    "Full-page views that replace entire pages", 
                    "Database query components", 
                    "Client-side JavaScript modules" }, 
                CorrectAnswer = "Mini-views rendered within other views" },

            new QuizQuestion { QuestionText = "What is a primary use case of partial views?", 
                Options = new List<string>{ 
                    "For reusable content like headers, footers, or navigation menus", 
                    "To store database records", 
                    "To manage session states", 
                    "To create API endpoints" }, 
                CorrectAnswer = "For reusable content like headers, footers, or navigation menus" },

            new QuizQuestion { QuestionText = "How do partial views contribute to maintainability?", 
                Options = new List<string>{ 
                    "They help break down complex views into manageable components", 
                    "They increase database performance", 
                    "They improve JavaScript execution speed", 
                    "They enable direct API communication" }, 
                CorrectAnswer = "They help break down complex views into manageable components" },

            new QuizQuestion { QuestionText = "What is an advantage of using partial views?", 
                Options = new List<string>{ 
                    "Encourages reusability of views across different parts of the application", 
                    "Enhances API security", 
                    "Optimizes SQL queries", 
                    "Reduces the need for client-side JavaScript" }, 
                CorrectAnswer = "Encourages reusability of views across different parts of the application" },

            new QuizQuestion { QuestionText = "Where are partial views typically stored in an ASP.NET Core MVC project?", 
                Options = new List<string>{ 
                    "In the Views folder, often within a Shared directory", 
                    "In the Controllers folder", 
                    "In the API Endpoints folder", 
                    "In the Models directory" }, 
                CorrectAnswer = "In the Views folder, often within a Shared directory" },

            new QuizQuestion { QuestionText = "How can partial views be rendered in a parent view?", 
                Options = new List<string>{ 
                    "Using the Html.Partial or Html.RenderPartial methods", 
                    "By including them in the Controllers directory", 
                    "By linking them via JavaScript", 
                    "By creating a new Razor Page" }, 
                CorrectAnswer = "Using the Html.Partial or Html.RenderPartial methods" },

            new QuizQuestion { QuestionText = "What is a key characteristic of a partial view?", 
                Options = new List<string>{ 
                    "It does not have a layout", 
                    "It is a standalone webpage", 
                    "It can only be used once per project", 
                    "It requires a database connection" }, 
                CorrectAnswer = "It does not have a layout" },

            new QuizQuestion { QuestionText = "What is the purpose of the _ProductCard.cshtml partial view in the provided example?", 
                Options = new List<string>{ 
                    "To display a product's information within a parent view", 
                    "To handle user authentication", 
                    "To generate API responses", 
                    "To manage database migrations" }, 
                CorrectAnswer = "To display a product's information within a parent view" },

            new QuizQuestion { QuestionText = "Which methods can be used to pass data to partial views?", 
                Options = new List<string>{ 
                    "ViewData, ViewBag, and Model", 
                    "Session Variables and Cookies", 
                    "Only ViewBag", 
                    "Only ViewData" }, 
                CorrectAnswer = "ViewData, ViewBag, and Model" },

            new QuizQuestion { QuestionText = "Which method passes data to a partial view using a dictionary format?", 
                Options = new List<string>{ 
                    "ViewData", 
                    "ViewBag", 
                    "TempData", 
                    "Direct Model Binding" }, 
                CorrectAnswer = "ViewData" },

            new QuizQuestion { QuestionText = "Which method is used in the code snippet to pass data to the _ProductDetails partial view using ViewBag?", 
                Options = new List<string>{ 
                    "ViewBag.Product = product;", 
                    "ViewData[\"Product\"] = product;", 
                    "TempData[\"Product\"] = product;", 
                    "Session[\"Product\"] = product;" }, 
                CorrectAnswer = "ViewBag.Product = product;" },

            new QuizQuestion { QuestionText = "What is the primary advantage of passing data to a partial view using a model?", 
                Options = new List<string>{ 
                    "It ensures strong typing and better code maintainability", 
                    "It allows for temporary data storage", 
                    "It automatically saves data to the database", 
                    "It prevents XSS attacks" }, 
                CorrectAnswer = "It ensures strong typing and better code maintainability" },

            new QuizQuestion { QuestionText = "How do View Components differ from Partial Views in ASP.NET Core MVC?", 
                Options = new List<string>{ 
                    "View Components include their own logic, while Partial Views do not", 
                    "Partial Views have their own logic, while View Components do not", 
                    "Both View Components and Partial Views have identical functionality", 
                    "View Components can only be used inside Razor Pages" }, 
                CorrectAnswer = "View Components include their own logic, while Partial Views do not" },

            new QuizQuestion { QuestionText = "What is a common use case for View Components?", 
                Options = new List<string>{ 
                    "Creating reusable components like shopping carts, login panels, or navigation bars", 
                    "Handling user authentication", 
                    "Managing database transactions", 
                    "Processing API requests" }, 
                CorrectAnswer = "Creating reusable components like shopping carts, login panels, or navigation bars" },

            new QuizQuestion { QuestionText = "Which method is typically used inside a View Component to return a result?", 
                Options = new List<string>{ 
                    "InvokeAsync", 
                    "RenderPartial", 
                    "ExecuteAction", 
                    "RenderComponent" }, 
                CorrectAnswer = "InvokeAsync" },
            new QuizQuestion { QuestionText = "What does the InvokeAsync method return in a View Component?", 
                Options = new List<string>{ 
                    "Task<IViewComponentResult>", 
                    "ViewResult", 
                    "JsonResult", 
                    "PartialViewResult" }, 
                CorrectAnswer = "Task<IViewComponentResult>" },

            new QuizQuestion { QuestionText = "How can a View Component be invoked from a Razor View?", 
                Options = new List<string>{ 
                    "@await Component.InvokeAsync(\"ComponentName\")", 
                    "@Html.RenderComponent(\"ComponentName\")", 
                    "@ViewComponent(\"ComponentName\")", 
                    "@RenderViewComponent(\"ComponentName\")" }, 
                CorrectAnswer = "@await Component.InvokeAsync(\"ComponentName\")" },

            new QuizQuestion { QuestionText = "What class must a View Component inherit from in ASP.NET Core?", 
                Options = new List<string>{ 
                    "ViewComponent", 
                    "Controller", 
                    "PartialView", 
                    "ComponentBase" }, 
                CorrectAnswer = "ViewComponent" },

            new QuizQuestion { QuestionText = "How is a View Component class created?", 
                Options = new List<string>{ 
                    "By inheriting from ViewComponent", 
                    "By using the @ViewComponent directive", 
                    "By extending the Controller class", 
                    "By calling the Component.Register() method" }, 
                CorrectAnswer = "By inheriting from ViewComponent" },
            
            new QuizQuestion { 
                QuestionText = "What is a key difference between View Components and Partial Views?", 
                Options = new List<string>{ 
                    "View Components contain logic, while Partial Views do not", 
                    "Partial Views contain logic, while View Components do not", 
                    "Both View Components and Partial Views contain logic", 
                    "Neither View Components nor Partial Views contain logic" 
                }, 
                CorrectAnswer = "View Components contain logic, while Partial Views do not" 
            },
            
            new QuizQuestion { 
            QuestionText = "How do View Components differ from Partial Views in terms of logic?", 
            Options = new List<string>{ 
                "View Components contain processing logic, while Partial Views are purely for rendering", 
                "Partial Views contain processing logic, while View Components are purely for rendering", 
                "Both View Components and Partial Views contain processing logic", 
                "Neither View Components nor Partial Views contain processing logic" 
            }, 
            CorrectAnswer = "View Components contain processing logic, while Partial Views are purely for rendering" 
            },

            new QuizQuestion { 
                QuestionText = "What makes View Components more independent than Partial Views?", 
                Options = new List<string>{ 
                    "They are self-contained and can include their own data access logic", 
                    "They require additional dependencies to function", 
                    "They are more lightweight than Partial Views", 
                    "They rely entirely on controller actions for data" 
                }, 
                CorrectAnswer = "They are self-contained and can include their own data access logic" 
            },

            new QuizQuestion { 
                QuestionText = "In what scenario is a Partial View more suitable than a View Component?", 
                Options = new List<string>{ 
                    "When rendering simple UI elements without complex logic", 
                    "When data processing is needed within the view", 
                    "When handling complex business logic", 
                    "When a component needs to access a database independently" 
                }, 
                CorrectAnswer = "When rendering simple UI elements without complex logic" 
            },

            new QuizQuestion { 
                QuestionText = "Which feature is unique to View Components compared to Partial Views?", 
                Options = new List<string>{ 
                    "They can contain logic and access data independently", 
                    "They can only be used inside Razor pages", 
                    "They are strictly for UI rendering", 
                    "They cannot be reused in multiple views" 
                }, 
                CorrectAnswer = "They can contain logic and access data independently" 
            },

            new QuizQuestion { 
                QuestionText = "What is a key advantage of using Partial Views?", 
                Options = new List<string>{ 
                    "They simplify UI by breaking down views into reusable components", 
                    "They allow independent data access like View Components", 
                    "They require complex logic to function", 
                    "They can only be used with Web APIs" 
                }, 
                CorrectAnswer = "They simplify UI by breaking down views into reusable components" 
            },
            
            new QuizQuestion { 
                QuestionText = "What is the primary purpose of Layouts in ASP.NET Core MVC?", 
                Options = new List<string>{ 
                    "To define a common site template for consistent UI across multiple pages", 
                    "To store database connection strings", 
                    "To handle user authentication", 
                    "To define API endpoints" 
                }, 
                CorrectAnswer = "To define a common site template for consistent UI across multiple pages" 
            },

            new QuizQuestion { 
                QuestionText = "What type of files are Layouts in ASP.NET Core MVC?", 
                Options = new List<string>{ 
                    "Razor files", 
                    "JavaScript files", 
                    "CSS files", 
                    "JSON configuration files" 
                }, 
                CorrectAnswer = "Razor files" 
            },

            new QuizQuestion { 
                QuestionText = "Which UI elements can be included in a Layout file?", 
                Options = new List<string>{ 
                    "Headers, footers, navigation menus", 
                    "Database tables", 
                    "Controller actions", 
                    "C# classes" 
                }, 
                CorrectAnswer = "Headers, footers, navigation menus" 
            },

            new QuizQuestion { 
                QuestionText = "What is the main benefit of using a single layout file?", 
                Options = new List<string>{ 
                    "Promoting code reuse and reducing redundancy", 
                    "Enforcing authentication across all views", 
                    "Automatically handling data migrations", 
                    "Storing API responses for future use" 
                }, 
                CorrectAnswer = "Promoting code reuse and reducing redundancy" 
            },

            new QuizQuestion { 
                QuestionText = "What is the purpose of the RenderBody method in a Layout file?", 
                Options = new List<string>{ 
                    "To act as a placeholder where the content of a view is rendered", 
                    "To define a global CSS style", 
                    "To execute SQL queries", 
                    "To store session data" 
                }, 
                CorrectAnswer = "To act as a placeholder where the content of a view is rendered" 
            },

            new QuizQuestion { 
                QuestionText = "What is the purpose of defining sections in a layout?", 
                Options = new List<string>{ 
                    "To allow views to inject content into specific parts of the layout", 
                    "To define database relationships", 
                    "To create reusable controller actions", 
                    "To manage authentication settings" 
                }, 
                CorrectAnswer = "To allow views to inject content into specific parts of the layout" 
            },

            new QuizQuestion { 
                QuestionText = "What are sections in layouts mainly used for?", 
                Options = new List<string>{ 
                    "Adding page-specific scripts or styles", 
                    "Defining API endpoints", 
                    "Handling user authentication", 
                    "Creating database migrations" 
                }, 
                CorrectAnswer = "Adding page-specific scripts or styles" 
            },

            new QuizQuestion { 
            QuestionText = "What is the role of model binding in ASP.NET Core MVC?", 
            Options = new List<string>{ 
                "To bind HTTP requests to the corresponding Controller’s Action method and model", 
                "To authenticate users before accessing a controller", 
                "To validate user inputs in the View layer", 
                "To optimize database queries for performance" 
            }, 
            CorrectAnswer = "To bind HTTP requests to the corresponding Controller’s Action method and model" 
            },

            new QuizQuestion { 
                QuestionText = "What happens when a user performs an HTTP request with form data in an MVC application?", 
                Options = new List<string>{ 
                    "The request is redirected to the corresponding Controller Action method and its model", 
                    "The request is directly stored in the database", 
                    "The request is processed by JavaScript before reaching the controller", 
                    "The request is ignored if no matching view is found" 
                }, 
                CorrectAnswer = "The request is redirected to the corresponding Controller Action method and its model" 
            },

            new QuizQuestion { 
                QuestionText = "How does the model binder function in an MVC application?", 
                Options = new List<string>{ 
                    "It maps incoming HTTP requests to the corresponding action method and model", 
                    "It encrypts sensitive user data", 
                    "It renders HTML views dynamically", 
                    "It connects the controller directly to the database" 
                }, 
                CorrectAnswer = "It maps incoming HTTP requests to the corresponding action method and model" 
            },

            new QuizQuestion { 
                QuestionText = "Which component acts as an agent between the View, Controller, and Model?", 
                Options = new List<string>{ 
                    "Model Binder", 
                    "ViewData", 
                    "Middleware", 
                    "Entity Framework" 
                }, 
                CorrectAnswer = "Model Binder" 
            },

            new QuizQuestion { 
                QuestionText = "What happens when an HTTP request transfers to the controller?", 
                Options = new List<string>{ 
                    "The model binder binds the request to the corresponding action method", 
                    "The request is stored in the model without processing", 
                    "The view directly modifies the controller's state", 
                    "The model automatically sends a response to the user" 
                }, 
                CorrectAnswer = "The model binder binds the request to the corresponding action method" 
            },

            new QuizQuestion { 
            QuestionText = "What is the purpose of data binding in Razor views?", 
            Options = new List<string>{ 
                "To connect data from models to HTML elements", 
                "To generate database queries dynamically", 
                "To encrypt user inputs before submission", 
                "To prevent users from modifying form data" 
            }, 
            CorrectAnswer = "To connect data from models to HTML elements" 
            },

            new QuizQuestion { 
                QuestionText = "Which of the following is an example of one-way data binding in Razor?", 
                Options = new List<string>{ 
                    "@Model.PropertyName", 
                    "@Html.RenderPartial()", 
                    "@ViewBag.Message", 
                    "@TempData[\"Key\"]" 
                }, 
                CorrectAnswer = "@Model.PropertyName" 
            },

            new QuizQuestion { 
                QuestionText = "What distinguishes two-way data binding from one-way data binding in Razor views?", 
                Options = new List<string>{ 
                    "Two-way data binding allows data to be submitted back to the server", 
                    "One-way data binding is used only for form inputs", 
                    "Two-way data binding can only display data without modifications", 
                    "One-way data binding requires AJAX to function" 
                }, 
                CorrectAnswer = "Two-way data binding allows data to be submitted back to the server" 
            },

            new QuizQuestion { 
                QuestionText = "Which form elements are typically used for two-way data binding in Razor views?", 
                Options = new List<string>{ 
                    "input, select, and textarea", 
                    "div, span, and p", 
                    "table, thead, and tbody", 
                    "section, aside, and article" 
                }, 
                CorrectAnswer = "input, select, and textarea" 
            },

            new QuizQuestion { 
                QuestionText = "Which statement about one-way data binding is correct?", 
                Options = new List<string>{ 
                    "It displays data from a model to a view", 
                    "It enables real-time data synchronization with the server", 
                    "It requires JavaScript for data rendering", 
                    "It can only be used with database-generated data" 
                }, 
                CorrectAnswer = "It displays data from a model to a view" 
            },
            
            new QuizQuestion { 
            QuestionText = "What is model binding in ASP.NET Core MVC?", 
            Options = new List<string>{ 
                "The automatic mapping of data from HTTP requests to action method parameters", 
                "A process of encrypting form data before submission", 
                "A way to manually extract user input in controllers", 
                "A technique for caching data in the database" 
            }, 
            CorrectAnswer = "The automatic mapping of data from HTTP requests to action method parameters" 
            },

            new QuizQuestion { 
                QuestionText = "What does validation ensure in ASP.NET Core MVC?", 
                Options = new List<string>{ 
                    "That data submitted through forms meets certain criteria", 
                    "That all forms are processed asynchronously", 
                    "That controllers do not accept null values", 
                    "That only administrators can submit forms" 
                }, 
                CorrectAnswer = "That data submitted through forms meets certain criteria" 
            },

            new QuizQuestion { 
                QuestionText = "Which of the following is commonly used to define validation rules in ASP.NET Core?", 
                Options = new List<string>{ 
                    "Data annotations", 
                    "SQL queries", 
                    "JavaScript functions", 
                    "Controller attributes" 
                }, 
                CorrectAnswer = "Data annotations" 
            },

            new QuizQuestion { 
                QuestionText = "What role does model binding play in handling form data?", 
                Options = new List<string>{ 
                    "It maps form data from HTTP requests to action method parameters", 
                    "It prevents users from submitting data through forms", 
                    "It automatically encrypts all HTTP request data", 
                    "It forces users to enter only numeric values in forms" 
                }, 
                CorrectAnswer = "It maps form data from HTTP requests to action method parameters" 
            },

            new QuizQuestion { 
                QuestionText = "Which HTTP request data does model binding work with?", 
                Options = new List<string>{ 
                    "Form fields, query strings, route values, and headers", 
                    "Only form fields", 
                    "Only query strings", 
                    "Only JSON payloads" 
                }, 
                CorrectAnswer = "Form fields, query strings, route values, and headers" 
            },
            
            new QuizQuestion { 
            QuestionText = "What is the role of JavaScript in Razor views?", 
            Options = new List<string>{ 
                "To integrate JavaScript for dynamic client-side behaviors", 
                "To replace C# code in Razor views", 
                "To execute SQL queries directly in the browser", 
                "To disable all client-side interactions" 
            }, 
            CorrectAnswer = "To integrate JavaScript for dynamic client-side behaviors" 
            },

            new QuizQuestion { 
                QuestionText = "How can AJAX be used in Razor views?", 
                Options = new List<string>{ 
                    "To make asynchronous requests to the server without reloading the entire page", 
                    "To replace HTML content with C# code", 
                    "To prevent users from submitting forms", 
                    "To refresh the entire webpage on each request" 
                }, 
                CorrectAnswer = "To make asynchronous requests to the server without reloading the entire page" 
            },

            new QuizQuestion { 
                QuestionText = "Which of the following best describes AJAX in Razor views?", 
                Options = new List<string>{ 
                    "It allows sending and receiving data without refreshing the page", 
                    "It only works with Web Forms applications", 
                    "It disables JavaScript functionality in views", 
                    "It forces the user to reload the page after every action" 
                }, 
                CorrectAnswer = "It allows sending and receiving data without refreshing the page" 
            },

            new QuizQuestion { 
                QuestionText = "What benefit does AJAX provide in Razor views?", 
                Options = new List<string>{ 
                    "It improves user experience by allowing seamless interactions with the server", 
                    "It prevents all server requests", 
                    "It forces all pages to use static content only", 
                    "It removes the need for JavaScript in Razor views" 
                }, 
                CorrectAnswer = "It improves user experience by allowing seamless interactions with the server" 
            },

            new QuizQuestion { 
                QuestionText = "What happens when AJAX is used in Razor views?", 
                Options = new List<string>{ 
                    "The server processes the request asynchronously without reloading the page", 
                    "The entire webpage is refreshed on every request", 
                    "The request is blocked by default", 
                    "JavaScript is disabled on the client-side" 
                }, 
                CorrectAnswer = "The server processes the request asynchronously without reloading the page" 
            },


        };

        private static List<QuizQuestion> _questions6 = new List<QuizQuestion>
        {
            new QuizQuestion { 
            QuestionText = "What does Form Handling typically involve?", 
            Options = new List<string>{ 
                "Using HTML <form> tag, model binding, and submitting data to a server", 
                "Using JavaScript functions to handle user input", 
                "Only validating user input on the client-side", 
                "Sending data directly to the database without validation" 
            }, 
            CorrectAnswer = "Using HTML <form> tag, model binding, and submitting data to a server" 
            },

            new QuizQuestion { 
                QuestionText = "What does Model Binding do in ASP.NET Core MVC?", 
                Options = new List<string>{ 
                    "Automatically maps form data to model properties in a controller action", 
                    "Manually assigns form data to variables in JavaScript", 
                    "Stores form data in session storage", 
                    "Encrypts form data before submission" 
                }, 
                CorrectAnswer = "Automatically maps form data to model properties in a controller action" 
            },

            new QuizQuestion { 
                QuestionText = "Where is form data automatically mapped in Model Binding?", 
                Options = new List<string>{ 
                    "To model properties in a controller action", 
                    "To CSS styles", 
                    "To the local file system", 
                    "To a JavaScript object" 
                }, 
                CorrectAnswer = "To model properties in a controller action" 
            },

            new QuizQuestion { 
                QuestionText = "Which HTML element is commonly used for form handling in ASP.NET Core MVC?", 
                Options = new List<string>{ 
                    "<form>", 
                    "<div>", 
                    "<section>", 
                    "<table>" 
                }, 
                CorrectAnswer = "<form>" 
            },

            new QuizQuestion { 
                QuestionText = "What is the role of Model Binding in form handling?", 
                Options = new List<string>{ 
                    "It automatically maps form data to model properties", 
                    "It encrypts all form data before submission", 
                    "It allows form data to be stored only in cookies", 
                    "It ensures forms can only be submitted once per session" 
                }, 
                CorrectAnswer = "It automatically maps form data to model properties" 
            },
            new QuizQuestion { 
                QuestionText = "What types of inputs might advanced forms include?", 
                Options = new List<string>{ 
                    "Text, number, select, radio buttons, checkboxes", 
                    "Only text inputs", 
                    "Only radio buttons and checkboxes", 
                    "Only number inputs" 
                }, 
                CorrectAnswer = "Text, number, select, radio buttons, checkboxes" 
            },

            new QuizQuestion { 
                QuestionText = "What is Input Validation in ASP.NET Core MVC?", 
                Options = new List<string>{ 
                    "Using data annotations in models to validate form inputs", 
                    "Manually checking inputs using JavaScript", 
                    "Only validating form data after submission", 
                    "Ignoring form validation" 
                }, 
                CorrectAnswer = "Using data annotations in models to validate form inputs" 
            },

            new QuizQuestion { 
                QuestionText = "Which method is commonly used for input validation in models?", 
                Options = new List<string>{ 
                    "Data annotations", 
                    "Inline CSS", 
                    "Console logs", 
                    "HTML comments" 
                }, 
                CorrectAnswer = "Data annotations" 
            },

            new QuizQuestion { 
                QuestionText = "Which of these is NOT a type of input used in complex forms?", 
                Options = new List<string>{ 
                    "Audio input", 
                    "Text input", 
                    "Radio buttons", 
                    "Checkboxes" 
                }, 
                CorrectAnswer = "Audio input" 
            },

            new QuizQuestion { 
                QuestionText = "How does ASP.NET Core MVC handle input validation?", 
                Options = new List<string>{ 
                    "Using data annotations in models", 
                    "Only through JavaScript validation", 
                    "By storing data in cookies", 
                    "By converting all inputs to plain text" 
                }, 
                CorrectAnswer = "Using data annotations in models" 
            },
            new QuizQuestion { 
                QuestionText = "Which HTTP methods can be used for form submission?", 
                Options = new List<string>{ 
                    "GET and POST", 
                    "PUT and DELETE", 
                    "HEAD and OPTIONS", 
                    "TRACE and CONNECT" 
                }, 
                CorrectAnswer = "GET and POST" 
            },

            new QuizQuestion { 
                QuestionText = "What is the main purpose of the GET method in form submission?", 
                Options = new List<string>{ 
                    "Requesting data from a specified resource", 
                    "Submitting data to be processed", 
                    "Deleting data from the server", 
                    "Updating data in a database" 
                }, 
                CorrectAnswer = "Requesting data from a specified resource" 
            },

            new QuizQuestion { 
                QuestionText = "What is the main purpose of the POST method in form submission?", 
                Options = new List<string>{ 
                    "Submitting data to be processed", 
                    "Requesting data from a specified resource", 
                    "Fetching a cached version of a webpage", 
                    "Updating the browser’s local storage" 
                }, 
                CorrectAnswer = "Submitting data to be processed" 
            },

            new QuizQuestion { 
                QuestionText = "Which HTTP method should be used when sending sensitive data in a form?", 
                Options = new List<string>{ 
                    "POST", 
                    "GET", 
                    "HEAD", 
                    "OPTIONS" 
                }, 
                CorrectAnswer = "POST" 
            },

            new QuizQuestion { 
                QuestionText = "What is a key difference between GET and POST methods?", 
                Options = new List<string>{ 
                    "GET requests data, while POST submits data to be processed", 
                    "GET is encrypted, while POST is not", 
                    "POST is faster than GET", 
                    "GET supports larger payloads than POST" 
                }, 
                CorrectAnswer = "GET requests data, while POST submits data to be processed" 
            },
            new QuizQuestion { 
            QuestionText = "What is the purpose of Model Binding in ASP.NET Core MVC?", 
            Options = new List<string>{ 
                "To manually extract and convert data from requests", 
                "To automate the mapping of user input to model properties in a controller", 
                "To store user input in session variables", 
                "To replace traditional database queries with API calls" 
            }, 
            CorrectAnswer = "To automate the mapping of user input to model properties in a controller" 
            },

            new QuizQuestion { 
                QuestionText = "Which of the following best describes Model Binding?", 
                Options = new List<string>{ 
                    "A process that maps user input to model properties in a controller", 
                    "A feature used to store session state in ASP.NET Core", 
                    "A technique for handling database migrations", 
                    "A method for styling Razor views" 
                }, 
                CorrectAnswer = "A process that maps user input to model properties in a controller" 
            },

            new QuizQuestion { 
                QuestionText = "What does Model Binding help to simplify?", 
                Options = new List<string>{ 
                    "Manually extracting and converting data from requests", 
                    "Manually writing SQL queries for data retrieval", 
                    "Designing custom layouts for views", 
                    "Binding JavaScript functions to HTML elements" 
                }, 
                CorrectAnswer = "Manually extracting and converting data from requests" 
            },

            new QuizQuestion { 
                QuestionText = "Which key feature does Model Binding provide?", 
                Options = new List<string>{ 
                    "Automates the creation of model instances from incoming requests", 
                    "Manages database transactions automatically", 
                    "Improves Razor syntax performance", 
                    "Enforces strict client-side validation only" 
                }, 
                CorrectAnswer = "Automates the creation of model instances from incoming requests" 
            },

            new QuizQuestion { 
                QuestionText = "What additional benefits does Model Binding offer?", 
                Options = new List<string>{ 
                    "Validation and type conversion", 
                    "Automatic UI generation", 
                    "Session state persistence", 
                    "CSS and JavaScript rendering improvements" 
                }, 
                CorrectAnswer = "Validation and type conversion" 
            },
            new QuizQuestion { 
            QuestionText = "What does the MVC framework automatically map to action method parameters during the binding process?", 
            Options = new List<string>{ 
                "Only database records", 
                "Only session data", 
                "Incoming form data, query parameters, and route data", 
                "Only JSON responses from APIs" 
            }, 
            CorrectAnswer = "Incoming form data, query parameters, and route data" 
            },

            new QuizQuestion { 
                QuestionText = "Which of the following is a source of data for model binding?", 
                Options = new List<string>{ 
                    "Only XML files", 
                    "Only HTTP cookies", 
                    "Form fields, route data, and query strings", 
                    "Only user authentication tokens" 
                }, 
                CorrectAnswer = "Form fields, route data, and query strings" 
            },

            new QuizQuestion { 
                QuestionText = "What is the purpose of the model binding process in MVC?", 
                Options = new List<string>{ 
                    "To automatically map incoming request data to action method parameters", 
                    "To manually extract and process query parameters in controllers", 
                    "To generate front-end HTML elements", 
                    "To store API responses in session variables" 
                }, 
                CorrectAnswer = "To automatically map incoming request data to action method parameters" 
            },

            new QuizQuestion { 
                QuestionText = "Which of the following best describes model binding in MVC?", 
                Options = new List<string>{ 
                    "A process that maps HTTP request data to controller action parameters", 
                    "A technique for rendering dynamic Razor views", 
                    "A method for configuring dependency injection", 
                    "A feature for automatically generating JavaScript code" 
                }, 
                CorrectAnswer = "A process that maps HTTP request data to controller action parameters" 
            },

            new QuizQuestion { 
                QuestionText = "Which of the following is NOT a valid data source for model binding?", 
                Options = new List<string>{ 
                    "Query strings", 
                    "Form fields", 
                    "Route data", 
                    "JavaScript files" 
                }, 
                CorrectAnswer = "JavaScript files" 
            },
            new QuizQuestion { 
                QuestionText = "Which of the following are binding attributes in ASP.NET Core MVC?", 
                Options = new List<string>{ 
                    "[FromBody], [FromForm], [FromQuery], [FromRoute]", 
                    "[FromSession], [FromCache], [FromCookie], [FromHeader]", 
                    "[FromService], [FromComponent], [FromEvent], [FromXml]", 
                    "[FromDatabase], [FromJson], [FromMiddleware], [FromScript]" 
                }, 
                CorrectAnswer = "[FromBody], [FromForm], [FromQuery], [FromRoute]" 
            },

            new QuizQuestion { 
                QuestionText = "What does Form-to-Model Mapping ensure?", 
                Options = new List<string>{ 
                    "That form field names match the property names of the model", 
                    "That data is automatically stored in the database", 
                    "That all form data is encrypted before binding", 
                    "That form fields can have any name and still bind correctly" 
                }, 
                CorrectAnswer = "That form field names match the property names of the model" 
            },
            new QuizQuestion { 
            QuestionText = "Where is client-side validation performed?", 
            Options = new List<string>{ 
                "In the user's browser", 
                "On the server", 
                "In the database", 
                "In the controller"
            }, 
            CorrectAnswer = "In the user's browser" 
            },

            new QuizQuestion { 
                QuestionText = "What is the purpose of client-side validation?", 
                Options = new List<string>{ 
                    "To provide immediate feedback on input validation", 
                    "To validate data only after submission", 
                    "To store data in the database", 
                    "To replace server-side validation"
                }, 
                CorrectAnswer = "To provide immediate feedback on input validation" 
            },

            new QuizQuestion { 
                QuestionText = "Which of the following is a benefit of client-side validation?", 
                Options = new List<string>{ 
                    "Enhances user experience by providing immediate feedback", 
                    "Eliminates the need for server-side validation", 
                    "Prevents all invalid inputs", 
                    "Automatically fixes errors in user input"
                }, 
                CorrectAnswer = "Enhances user experience by providing immediate feedback" 
            },

            new QuizQuestion { 
                QuestionText = "How does ASP.NET Core MVC support client-side validation?", 
                Options = new List<string>{ 
                    "Using data annotations in models which can be automatically translated into JavaScript for validation", 
                    "By requiring manual JavaScript coding for validation", 
                    "By disabling server-side validation", 
                    "By validating input only after form submission"
                }, 
                CorrectAnswer = "Using data annotations in models which can be automatically translated into JavaScript for validation" 
            },

            new QuizQuestion { 
                QuestionText = "How does client-side validation impact server load?", 
                Options = new List<string>{ 
                    "It reduces server load as invalid forms are not submitted", 
                    "It increases server load by performing additional checks", 
                    "It has no impact on server load", 
                    "It slows down database queries"
                }, 
                CorrectAnswer = "It reduces server load as invalid forms are not submitted" 
            },


            new QuizQuestion { 
                QuestionText = "What library does ASP.NET Core MVC integrate with for client-side validation?", 
                Options = new List<string>{ 
                    "jQuery Validation library", 
                    "Bootstrap Validation library", 
                    "Angular Validation library", 
                    "React Validation library" 
                }, 
                CorrectAnswer = "jQuery Validation library" 
            },

            new QuizQuestion { 
                QuestionText = "What must be included in the project to enable jQuery validation?", 
                Options = new List<string>{ 
                    "jQuery and jQuery Validation libraries", 
                    "Only jQuery library", 
                    "Only jQuery Validation library", 
                    "No additional libraries are needed" 
                }, 
                CorrectAnswer = "jQuery and jQuery Validation libraries" 
            },

            new QuizQuestion { 
                QuestionText = "What does ASP.NET Core MVC automatically convert data annotation validation rules into?", 
                Options = new List<string>{ 
                    "HTML5 data attributes", 
                    "CSS classes", 
                    "JavaScript functions", 
                    "SQL constraints" 
                }, 
                CorrectAnswer = "HTML5 data attributes" 
            },

            new QuizQuestion { 
                QuestionText = "What can developers write if needed for client-side validation?", 
                Options = new List<string>{ 
                    "Custom JavaScript validation logic", 
                    "Additional C# models", 
                    "Extra HTML attributes", 
                    "New database constraints" 
                }, 
                CorrectAnswer = "Custom JavaScript validation logic" 
            },

            
            new QuizQuestion { 
            QuestionText = "Which annotation ensures that a property cannot be null or empty?", 
            Options = new List<string>{ 
                "[Required]", 
                "[EmailAddress]", 
                "[Url]", 
                "[Compare(\"OtherProperty\")]"
            }, 
            CorrectAnswer = "[Required]" 
            },

            new QuizQuestion { 
                QuestionText = "Which annotation sets a numeric range constraint for a property's value?", 
                Options = new List<string>{ 
                    "[Range(min, max)]", 
                    "[StringLength(max, MinimumLength = min)]", 
                    "[RegularExpression(pattern)]", 
                    "[DataType(DataType)]"
                }, 
                CorrectAnswer = "[Range(min, max)]" 
            },

            new QuizQuestion { 
                QuestionText = "Which annotation validates that a property value is a valid email address?", 
                Options = new List<string>{ 
                    "[EmailAddress]", 
                    "[Phone]", 
                    "[Url]", 
                    "[CreditCard]"
                }, 
                CorrectAnswer = "[EmailAddress]" 
            },

            new QuizQuestion { 
                QuestionText = "Which annotation is used to check if a property value matches another specified property?", 
                Options = new List<string>{ 
                    "[Compare(\"OtherProperty\")]", 
                    "[MinLength(length)]", 
                    "[RegularExpression(pattern)]", 
                    "[DataType(DataType)]"
                }, 
                CorrectAnswer = "[Compare(\"OtherProperty\")]" 
            },

            new QuizQuestion { 
                QuestionText = "Which annotation ensures a property value matches a regex pattern?", 
                Options = new List<string>{ 
                    "[RegularExpression(pattern)]", 
                    "[Url]", 
                    "[Phone]", 
                    "[StringLength(max, MinimumLength = min)]"
                }, 
                CorrectAnswer = "[RegularExpression(pattern)]" 
            },

            new QuizQuestion { 
                QuestionText = "Which annotation validates that a property value is a valid credit card number?", 
                Options = new List<string>{ 
                    "[CreditCard]", 
                    "[Url]", 
                    "[Phone]", 
                    "[MaxLength(length)]"
                }, 
                CorrectAnswer = "[CreditCard]" 
            },

            new QuizQuestion { 
                QuestionText = "Which annotation specifies the data type but does not enforce validation?", 
                Options = new List<string>{ 
                    "[DataType(DataType)]", 
                    "[EmailAddress]", 
                    "[Phone]", 
                    "[Compare(\"OtherProperty\")]"
                }, 
                CorrectAnswer = "[DataType(DataType)]" 
            },
            new QuizQuestion { 
                QuestionText = "What is the primary purpose of server-side validation?", 
                Options = new List<string>{ 
                    "To verify user input on the server after submission", 
                    "To improve client-side performance", 
                    "To replace client-side validation completely", 
                    "To store user input without verification"
                }, 
                CorrectAnswer = "To verify user input on the server after submission" 
            },

            new QuizQuestion { 
                QuestionText = "Why is server-side validation important even if client-side validation is present?", 
                Options = new List<string>{ 
                    "Client-side validation can be bypassed or not implemented", 
                    "It eliminates the need for secure database storage", 
                    "It speeds up rendering on the browser", 
                    "It ensures only valid URLs are processed"
                }, 
                CorrectAnswer = "Client-side validation can be bypassed or not implemented" 
            },

            new QuizQuestion { 
                QuestionText = "Which of the following is a key benefit of server-side validation?", 
                Options = new List<string>{ 
                    "Protects against malicious data input and security threats", 
                    "Eliminates the need for encryption", 
                    "Improves CSS styling of forms", 
                    "Automatically formats user input into JSON"
                }, 
                CorrectAnswer = "Protects against malicious data input and security threats" 
            },

            new QuizQuestion { 
                QuestionText = "How does server-side validation ensure data integrity?", 
                Options = new List<string>{ 
                    "By validating data before processing or storing it", 
                    "By allowing users to directly modify database records", 
                    "By relying on JavaScript validation only", 
                    "By automatically encrypting form submissions"
                }, 
                CorrectAnswer = "By validating data before processing or storing it" 
            },
            new QuizQuestion { 
                QuestionText = "What is the purpose of data annotations in ASP.NET Core MVC?", 
                Options = new List<string>{ 
                    "To define validation rules directly in model classes", 
                    "To apply styles to HTML elements", 
                    "To create database tables dynamically", 
                    "To handle HTTP requests in controllers" 
                }, 
                CorrectAnswer = "To define validation rules directly in model classes" 
            },
            new QuizQuestion { 
                QuestionText = "Which of the following are common data annotations used in ASP.NET Core MVC?", 
                Options = new List<string>{ 
                    "[Required]", 
                    "[StringLength]", 
                    "[Range]", 
                    "[EmailAddress]" 
                }, 
                CorrectAnswer = "[Required], [StringLength], [Range], [EmailAddress]" 
            },

            new QuizQuestion { 
    QuestionText = "What is ModelState in ASP.NET Core MVC?", 
    Options = new List<string>{ 
        "A property of a controller that represents a collection of name and value pairs submitted to the server during a POST request, including the validation state of each field.", 
        "A built-in feature that stores authentication tokens for user sessions.", 
        "A method used to send data from a controller to a view.", 
        "A database migration tool used for schema updates in Entity Framework Core." 
    }, 
    CorrectAnswer = "A property of a controller that represents a collection of name and value pairs submitted to the server during a POST request, including the validation state of each field." 
},

new QuizQuestion { 
    QuestionText = "What is the primary purpose of ModelState in ASP.NET Core MVC?", 
    Options = new List<string>{ 
        "It is primarily used for validating form submissions against model data.", 
        "It is used to generate database tables from models.", 
        "It is responsible for defining routing patterns in controllers.", 
        "It provides a caching mechanism for storing frequently accessed data." 
    }, 
    CorrectAnswer = "It is primarily used for validating form submissions against model data." 
},

new QuizQuestion { 
    QuestionText = "What does ModelState contain?", 
    Options = new List<string>{ 
        "Both the data submitted in the form and the validation results for that data.", 
        "Only the submitted form data without validation results.", 
        "Only the validation errors without any form data.", 
        "Predefined error messages for form submissions." 
    }, 
    CorrectAnswer = "Both the data submitted in the form and the validation results for that data." 
},

new QuizQuestion { 
    QuestionText = "Which of the following is a key point about ModelState in ASP.NET Core MVC?", 
    Options = new List<string>{ 
        "ModelState is automatically populated by ASP.NET Core MVC during the model binding process.", 
        "ModelState must be manually created and populated for each form submission.", 
        "ModelState only works for GET requests and is ignored for POST requests.", 
        "ModelState is used exclusively for handling database queries." 
    }, 
    CorrectAnswer = "ModelState is automatically populated by ASP.NET Core MVC during the model binding process." 
},
new QuizQuestion { 
    QuestionText = "What can ModelState be used for when displaying errors?", 
    Options = new List<string>{ 
        "Checking for validation errors and displaying appropriate error messages in the view.", 
        "Managing user sessions and authentication tokens.", 
        "Handling database migrations and schema updates.", 
        "Caching form input data for future requests." 
    }, 
    CorrectAnswer = "Checking for validation errors and displaying appropriate error messages in the view." 
},

new QuizQuestion { 
    QuestionText = "What is the role of ModelState in providing user feedback?", 
    Options = new List<string>{ 
        "It provides immediate and relevant feedback to users about their input, enhancing user experience.", 
        "It sends email notifications to users when a form submission fails.", 
        "It encrypts form data before sending it to the server.", 
        "It allows users to bypass required field validation in forms." 
    }, 
    CorrectAnswer = "It provides immediate and relevant feedback to users about their input, enhancing user experience." 
},

new QuizQuestion { 
    QuestionText = "What does ModelState.IsValid check in the controller action?", 
    Options = new List<string>{ 
        "Whether the input passes the validation rules.", 
        "Whether the user has administrative privileges.", 
        "If the user is authenticated before submitting the form.", 
        "If the form data has been successfully stored in the database." 
    }, 
    CorrectAnswer = "Whether the input passes the validation rules." 
},

new QuizQuestion { 
    QuestionText = "Which Razor tag helper is used to display validation messages next to input fields?", 
    Options = new List<string>{ 
        "asp-validation-for", 
        "asp-error-display", 
        "asp-message-box", 
        "asp-validation-message" 
    }, 
    CorrectAnswer = "asp-validation-for" 
},


            




        };
        
        public IActionResult Index()
        {
            ViewBag.Quiz1 = _questions.Select(q => new QuizQuestion
            {
                QuestionText = q.QuestionText,
                Options = q.Options.OrderBy(o => Guid.NewGuid()).ToList(), // Shuffle choices
                CorrectAnswer = q.CorrectAnswer
            }).OrderBy(q => Guid.NewGuid()).ToList(); // Shuffle questions

            ViewBag.Quiz2 = _questions2.Select(q => new QuizQuestion
            {
                QuestionText = q.QuestionText,
                Options = q.Options.OrderBy(o => Guid.NewGuid()).ToList(), // Shuffle choices
                CorrectAnswer = q.CorrectAnswer
            }).OrderBy(q => Guid.NewGuid()).ToList(); // Shuffle questions
            
            

            return View();
        }

        public IActionResult Quiz3()
        {
            ViewBag.Quiz3 = _questions3.Select(q => new QuizQuestion
            {
                QuestionText = q.QuestionText,
                Options = q.Options.OrderBy(o => Guid.NewGuid()).ToList(), // Shuffle choices
                CorrectAnswer = q.CorrectAnswer
            }).OrderBy(q => Guid.NewGuid()).ToList(); // Shuffle questions
            
            ViewBag.Quiz4 = _questions4.Select(q => new QuizQuestion
            {
                QuestionText = q.QuestionText,
                Options = q.Options.OrderBy(o => Guid.NewGuid()).ToList(), // Shuffle choices
                CorrectAnswer = q.CorrectAnswer
            }).OrderBy(q => Guid.NewGuid()).ToList(); // Shuffle questions

            return View();
        }
        public IActionResult Quiz5()
        {
            ViewBag.Quiz5 = _questions5.Select(q => new QuizQuestion
            {
                QuestionText = q.QuestionText,
                Options = q.Options.OrderBy(o => Guid.NewGuid()).ToList(), // Shuffle choices
                CorrectAnswer = q.CorrectAnswer
            }).OrderBy(q => Guid.NewGuid()).ToList(); // Shuffle questions
            ViewBag.Quiz6 = _questions6.Select(q => new QuizQuestion
            {
                QuestionText = q.QuestionText,
                Options = q.Options.OrderBy(o => Guid.NewGuid()).ToList(), // Shuffle choices
                CorrectAnswer = q.CorrectAnswer
            }).OrderBy(q => Guid.NewGuid()).ToList(); // Shuffle questions

            return View();
        }
}