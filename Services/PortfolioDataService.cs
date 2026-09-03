using MahmoudDev.Models;
using System.Net;
using System.Net.Mail;

namespace MahmoudDev.Services
{
    public class PortfolioDataService : IPortfolioDataService
    {
        private readonly PortfolioViewModel _portfolio;

        public PortfolioDataService()
        {
            _portfolio = InitializePortfolio();
        }

        public PortfolioViewModel GetPortfolioData() => _portfolio;

        public List<Project> GetProjects(string? category = null)
        {
            if (string.IsNullOrWhiteSpace(category) || category.Equals("all", StringComparison.OrdinalIgnoreCase))
                return _portfolio.Projects;

            return _portfolio.Projects
                .Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public Project? GetProjectById(string id)
        {
            return _portfolio.Projects.FirstOrDefault(p => p.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        public CaseStudy? GetCaseStudy(string id)
        {
            return _portfolio.Projects
                .Where(p => p.CaseStudy != null && p.CaseStudy.Id.Equals(id, StringComparison.OrdinalIgnoreCase))
                .Select(p => p.CaseStudy)
                .FirstOrDefault();
        }

        public List<SkillGroup> GetSkills() => _portfolio.SkillGroups;
        public List<ExperienceItem> GetExperiences() => _portfolio.Experiences;
        public List<JourneyStage> GetJourneyStages() => _portfolio.JourneyStages;
        public List<ServiceItem> GetServices() => _portfolio.Services;

        private PortfolioViewModel InitializePortfolio()
        {
            return new PortfolioViewModel
            {
                BrandName = "Mahmoud.Dev",
                DeveloperName = "Mahmoud Abd-Elbakey",
                Role = "Full Stack .NET Developer",
                Tagline = "I don't just build your idea — I help make it better.",
                SubTagline = "I turn ideas into attractive, effective, and useful digital experiences through modern .NET, solid system architecture, and thoughtful user-centered problem solving.",

                SkillGroups = new List<SkillGroup>
                {
                    new SkillGroup
                    {
                        Category = "Programming",
                        Title = "Core Programming",
                        Description = "Strong foundational logic, object-oriented design, algorithmic efficiency, and memory-conscious development.",
                        IconName = "code",
                        Skills = new List<SkillItem>
                        {
                            new SkillItem { Name = "C#", Category = "Programming", Context = "Primary language for scalable enterprise backends, asynchronous programming, modern C# 12/13 idioms, and clean code.", IsPrimary = true },
                            new SkillItem { Name = "C++", Category = "Programming", Context = "Low-level system foundations, memory management understanding, data structures, and algorithmic rigor.", IsPrimary = false },
                            new SkillItem { Name = "Python", Category = "Programming", Context = "Automation scripts, quick prototyping, data parsing, and auxiliary tooling.", IsPrimary = false }
                        }
                    },
                    new SkillGroup
                    {
                        Category = ".NET",
                        Title = ".NET Ecosystem",
                        Description = "Full stack application runtime, enterprise web APIs, high-throughput microservices, and database ORM design.",
                        IconName = "layers",
                        Skills = new List<SkillItem>
                        {
                            new SkillItem { Name = ".NET", Category = ".NET", Context = "Cross-platform runtime, dependency injection, configuration, logging, and performance profiling.", IsPrimary = true },
                            new SkillItem { Name = "ASP.NET Core", Category = ".NET", Context = "Robust middleware pipelines, high-performance web hosts, security, authentication, and filter pipelines.", IsPrimary = true },
                            new SkillItem { Name = "Web API", Category = ".NET", Context = "RESTful architectural design, standard response contracts, rate limiting, and versioning.", IsPrimary = true },
                            new SkillItem { Name = "MVC", Category = ".NET", Context = "Model-View-Controller pattern, Razor view rendering, view components, model validation, and CSRF protection.", IsPrimary = true },
                            new SkillItem { Name = "Entity Framework Core", Category = ".NET", Context = "Code-First/DB-First migrations, eager/lazy/explicit loading, query optimization, split queries, and change tracking.", IsPrimary = true },
                            new SkillItem { Name = "LINQ", Category = ".NET", Context = "Expressive data querying, deferred execution, complex projections, and in-memory aggregation.", IsPrimary = true }
                        }
                    },
                    new SkillGroup
                    {
                        Category = "Database",
                        Title = "Database & Persistence",
                        Description = "Relational modeling, indexing strategies, procedural data logic, and high-concurrency consistency.",
                        IconName = "database",
                        Skills = new List<SkillItem>
                        {
                            new SkillItem { Name = "SQL Server", Category = "Database", Context = "Production relational database administration, execution plan analysis, clustering, and backup integrity.", IsPrimary = true },
                            new SkillItem { Name = "SQL", Category = "Database", Context = "Complex multi-table joins, subqueries, Common Table Expressions (CTEs), and window functions.", IsPrimary = true },
                            new SkillItem { Name = "Database Design", Category = "Database", Context = "Normalization (1NF to 3NF), foreign key integrity constraints, entity-relationship modeling.", IsPrimary = true },
                            new SkillItem { Name = "Stored Procedures", Category = "Database", Context = "Compiled server-side routines for secure, high-speed bulk transactions and strict business logic encapsulation.", IsPrimary = true },
                            new SkillItem { Name = "Views", Category = "Database", Context = "Indexed and partitioned views simplifying reporting abstractions and shielding sensitive tables.", IsPrimary = false },
                            new SkillItem { Name = "Functions", Category = "Database", Context = "Scalar and table-valued user functions (TVFs) for reusable data transformations.", IsPrimary = false },
                            new SkillItem { Name = "Triggers", Category = "Database", Context = "Data audit trails, automated timestamping, and referential validation safeguards.", IsPrimary = false }
                        }
                    },
                    new SkillGroup
                    {
                        Category = "Frontend",
                        Title = "Frontend & Interface",
                        Description = "Modern, responsive, user-centered client experiences with seamless backend connectivity.",
                        IconName = "layout",
                        Skills = new List<SkillItem>
                        {
                            new SkillItem { Name = "HTML5", Category = "Frontend", Context = "Semantic structure, accessibility standards (WCAG), SEO best practices, and fast DOM hierarchy.", IsPrimary = true },
                            new SkillItem { Name = "CSS3", Category = "Frontend", Context = "Modern Flexbox, CSS Grid, custom properties, responsive breakpoints, smooth animations, and zero clutter.", IsPrimary = true },
                            new SkillItem { Name = "JavaScript", Category = "Frontend", Context = "Vanilla ES6+, asynchronous Fetch API, DOM manipulation, state handling, micro-interactions, and modular architecture.", IsPrimary = true }
                        }
                    },
                    new SkillGroup
                    {
                        Category = "Tools",
                        Title = "Tooling & DevOps",
                        Description = "Version control, containerization, IDE mastery, and interactive API documentation.",
                        IconName = "cpu",
                        Skills = new List<SkillItem>
                        {
                            new SkillItem { Name = "Git", Category = "Tools", Context = "Branching strategies, interactive rebase, merge conflict resolution, and atomic commits.", IsPrimary = true },
                            new SkillItem { Name = "GitHub", Category = "Tools", Context = "Pull request workflows, code review standards, issue tracking, and GitHub Actions CI/CD.", IsPrimary = true },
                            new SkillItem { Name = "Docker", Category = "Tools", Context = "Multi-stage Dockerfile container builds for ASP.NET Core apps and SQL Server containerized testing.", IsPrimary = true },
                            new SkillItem { Name = "Visual Studio", Category = "Tools", Context = "Deep diagnostic tools, memory profilers, integrated test runners, and Roslyn analyzers.", IsPrimary = true },
                            new SkillItem { Name = "VS Code", Category = "Tools", Context = "Lightweight cross-platform development, Omnisharp, C# Dev Kit, and rapid scripting.", IsPrimary = false },
                            new SkillItem { Name = "Swagger / OpenAPI", Category = "Tools", Context = "Live interactive API documentation, schema generation, token authentication testing, and client contract sharing.", IsPrimary = true }
                        }
                    }
                },

                Projects = new List<Project>
                {
                    new Project
                    {
                        Id = "logicore",
                        Title = "LogiCore Express",
                        Category = "Enterprise Web App",
                        Subtitle = "Intelligent Fleet Dispatch & Warehouse Logistics Engine",
                        Description = "A mission-critical enterprise dispatching system transforming manual freight logging into an automated, real-time allocation and tracking hub.",
                        ClientOrDomain = "Logistics & Supply Chain",
                        ValueProposition = "Transformed a slow 14-second reporting spreadsheet into an instant 200ms real-time dashboard while automating driver route allocation.",
                        Technologies = new List<string> { "C#", "ASP.NET Core", "Entity Framework Core", "SQL Server", "Stored Procedures", "JavaScript", "Docker" },
                        MainFeatures = new List<string>
                        {
                            "Real-time trip dispatcher with dynamic capacity load calculation",
                            "Optimized SQL Server stored procedures cutting reporting queries by 85%",
                            "Driver compliance and audit trail via SQL triggers",
                            "Role-based security for Dispatchers, Fleet Managers, and Drivers"
                        },
                        HasCaseStudy = true,
                        CaseStudy = new CaseStudy
                        {
                            Id = "logicore-cs",
                            ProjectTitle = "LogiCore Express",
                            Tagline = "From Manual Spreadsheets to Real-Time Fleet Intelligence",
                            TheProblem = "The client was suffering from dispatch bottlenecks: manual phone calls between warehouse managers and drivers, duplicate manifests, and financial reports that took up to 14 seconds to query, frequently locking database tables during peak morning hours.",
                            TheOriginalIdea = "The client initially asked for a simple web form to record driver sign-outs and replace printed paper trip slips.",
                            MyApproach = "I saw that simply moving the paper form into a web browser wouldn't solve their real problem — dispatch delays and capacity mismatches. I suggested adding an intelligent allocation pipeline that automatically calculates available vehicle volume, validates driver rest periods, and executes high-speed batch reporting via optimized SQL Server stored procedures instead of raw unindexed LINQ queries.",
                            TheSolution = "Engineered an end-to-end ASP.NET Core application with a clean three-tier architecture. Implemented EF Core for rapid transaction processing alongside custom SQL Server Stored Procedures and non-clustered composite indexes for heavy analytical summaries.",
                            KeyFeatures = new List<string>
                            {
                                "Dynamic fleet capacity calculator with real-time payload alerts",
                                "Automated dispatcher conflict prevention (prevents overlapping assignments)",
                                "Comprehensive audit logging powered by database triggers",
                                "Responsive tablet-ready driver checkpoint interface"
                            },
                            Technologies = new List<string> { "ASP.NET Core Web API", "C#", "Entity Framework Core", "SQL Server", "Stored Procedures & Views", "Vanilla JS", "Docker" },
                            ChallengesAndSolutions = new List<string>
                            {
                                "Challenge: Reporting queries locked the orders table during high morning dispatch volume. -> Solution: Implemented SQL Server snapshot isolation and built an indexed summary view, reducing lock contention to 0%.",
                                "Challenge: Frequent network drops at remote warehouse terminals. -> Solution: Created client-side optimistic UI updates with automatic retry queues over Fetch API."
                            },
                            ResultsAndImpact = new List<string>
                            {
                                "85% reduction in reporting query latency (from 14.2s to 210ms)",
                                "Eliminated 100% of double-booking and route conflict incidents",
                                "Saved the dispatch team over 40 hours of manual coordination every week",
                                "Successfully handling over 8,500 daily route checkpoints with zero downtime"
                            },
                            Metrics = new Dictionary<string, string>
                            {
                                { "Query Latency", "-85%" },
                                { "Booking Conflicts", "0" },
                                { "Weekly Hours Saved", "40+ hrs" },
                                { "Uptime", "99.98%" }
                            },
                            VisualMockup = "/images/project-logicore.svg",
                            LiveDemoUrl = "https://github.com/mahmoud-dev/logicore-express",
                            GithubUrl = "https://github.com/mahmoud-dev/logicore-express"
                        }
                    },
                    new Project
                    {
                        Id = "mediconnect",
                        Title = "MediConnect Health",
                        Category = "Healthcare System",
                        Subtitle = "Multi-Clinic Patient Scheduling & Teleconsultation Portal",
                        Description = "A HIPAA-aligned digital appointment and consultation workflow connecting specialized clinics with patients and attending physicians.",
                        ClientOrDomain = "Healthcare & Clinic Networks",
                        ValueProposition = "Reduced patient no-show rates by 62% through automated smart reminders and eliminated double-booking via optimistic concurrency.",
                        Technologies = new List<string> { "C#", "ASP.NET Core MVC", "Web API", "SQL Server", "Entity Framework Core", "LINQ", "JavaScript" },
                        MainFeatures = new List<string>
                        {
                            "Optimistic concurrency control preventing concurrent booking conflicts",
                            "Multi-doctor shift scheduling with dynamic buffer slots",
                            "Interactive patient portal with instant confirmation and prep instructions",
                            "Doctor consultation notes with secure document upload"
                        },
                        HasCaseStudy = true,
                        CaseStudy = new CaseStudy
                        {
                            Id = "mediconnect-cs",
                            ProjectTitle = "MediConnect Health",
                            Tagline = "Eliminating Healthcare Scheduling Conflicts and No-Shows",
                            TheProblem = "A network of private healthcare clinics experienced high patient no-show rates (over 28%) and frequent double-booking errors caused by simultaneous reception calls and walk-in updates.",
                            TheOriginalIdea = "The client asked for a static calendar interface where receptionists could manually select time slots.",
                            MyApproach = "I investigated the underlying reasons for missed appointments and booking collisions. I recommended adding automated SMS/Email trigger reminders, an optimistic concurrency token on the appointment entity in EF Core, and a self-service patient reschedule link that dynamically frees cancelled slots for waitlisted patients.",
                            TheSolution = "Delivered an ASP.NET Core MVC and Web API solution with ASP.NET Core Identity for secure role-based permissions (Patients, Doctors, Administrators), backed by SQL Server transactional integrity and custom table-valued functions for doctor availability calculation.",
                            KeyFeatures = new List<string>
                            {
                                "EF Core RowVersion concurrency check guaranteeing zero double-bookings",
                                "Self-service patient confirmation and reschedule portal",
                                "Custom SQL Server availability calculation function evaluating clinic holidays and doctor shifts",
                                "Audit-ready patient record access logs"
                            },
                            Technologies = new List<string> { "ASP.NET Core", "C#", "SQL Server", "Entity Framework Core", "LINQ", "CSS3 / Vanilla JS", "Swagger" },
                            ChallengesAndSolutions = new List<string>
                            {
                                "Challenge: High concurrency during 8:00 AM slot release times led to race conditions. -> Solution: Applied EF Core concurrency tokens with clear user-friendly conflict resolution prompts.",
                                "Challenge: Protecting sensitive health data. -> Solution: Implemented field-level data protection and strict parameterization across all SQL endpoints."
                            },
                            ResultsAndImpact = new List<string>
                            {
                                "62% reduction in missed appointments (no-show rate dropped from 28% to 10.6%)",
                                "Zero double-booking incidents across 18,000+ completed appointments",
                                "Reception call duration decreased by 45%, freeing staff for patient care",
                                "Client expanded the system to 4 additional branch clinics within 6 months"
                            },
                            Metrics = new Dictionary<string, string>
                            {
                                { "No-Show Drop", "-62%" },
                                { "Double Bookings", "Zero" },
                                { "Call Time Saved", "45%" },
                                { "Appointments Handled", "18,000+" }
                            },
                            VisualMockup = "/images/project-mediconnect.svg",
                            LiveDemoUrl = "https://github.com/mahmoud-dev/mediconnect-health",
                            GithubUrl = "https://github.com/mahmoud-dev/mediconnect-health"
                        }
                    },
                    new Project
                    {
                        Id = "commercecraft",
                        Title = "CommerceCraft Engine",
                        Category = "E-Commerce",
                        Subtitle = "High-Throughput Modular E-Commerce & Inventory Core",
                        Description = "A custom commerce platform designed for flash sales, inventory reconciliation, and friction-free multi-step checkout.",
                        ClientOrDomain = "Retail & Digital Commerce",
                        ValueProposition = "Boosted checkout throughput by 3.2x while guaranteeing 100% inventory accuracy under heavy flash-sale concurrency.",
                        Technologies = new List<string> { "C#", "ASP.NET Core Web API", "Entity Framework Core", "SQL Server", "Database Design", "HTML5/CSS3", "JavaScript" },
                        MainFeatures = new List<string>
                        {
                            "Idempotent order checkout pipeline with payment webhook integration",
                            "Strict transactional inventory decrement with SQL Server isolation",
                            "Category hierarchy management with recursive SQL CTE queries",
                            "Interactive product filtering and responsive cart interface"
                        },
                        HasCaseStudy = true,
                        CaseStudy = new CaseStudy
                        {
                            Id = "commercecraft-cs",
                            ProjectTitle = "CommerceCraft Engine",
                            Tagline = "Resilient Inventory Architecture for High-Demand Flash Sales",
                            TheProblem = "A boutique retail brand frequently suffered from stock discrepancies: popular items were oversold during seasonal campaigns, causing angry customer cancellations, payment chargebacks, and manual inventory adjustments.",
                            TheOriginalIdea = "Build a standard online product catalog with a third-party checkout button.",
                            MyApproach = "I explained that off-the-shelf basic carts fail during concurrent bursts because they decouple payment confirmation from stock reservation. I designed an atomic checkout pipeline where cart reservations hold stock for 10 minutes using database-level locking, releasing it automatically if the user abandons checkout.",
                            TheSolution = "Engineered a decoupled ASP.NET Core REST API paired with a high-performance JavaScript frontend. Handled payment reconciliation via resilient webhooks with retry policies and exponential backoff.",
                            KeyFeatures = new List<string>
                            {
                                "Atomic inventory reservation using stored procedures and SERIALIZABLE transactions",
                                "Recursive SQL CTEs for nested product taxonomy and fast faceted search",
                                "Idempotent payment webhook receiver preventing duplicate order creation",
                                "Interactive shopping cart drawer with instant promo code validation"
                            },
                            Technologies = new List<string> { ".NET 10", "C#", "ASP.NET Core Web API", "SQL Server", "EF Core", "Swagger", "Vanilla JS" },
                            ChallengesAndSolutions = new List<string>
                            {
                                "Challenge: High cart abandonment left reserved stock locked. -> Solution: Built a background timed worker service that scans expired reservation leases and restores available quantity in real time.",
                                "Challenge: Complex multi-attribute pricing rules (size, color, bulk discounts). -> Solution: Designed a flexible rule-engine pattern in C# with unit-tested price evaluation."
                            },
                            ResultsAndImpact = new List<string>
                            {
                                "Over-selling reduced to exactly zero items during Black Friday peak campaign",
                                "Checkout processing speed improved by 3.2x compared to the legacy platform",
                                "Cart completion conversion increased by 24% due to clear reservation timers",
                                "Processed over $320,000 in transaction volume in the first quarter"
                            },
                            Metrics = new Dictionary<string, string>
                            {
                                { "Overselling Rate", "0.00%" },
                                { "Speed Boost", "3.2x" },
                                { "Conversion Lift", "+24%" },
                                { "Processed Volume", "$320k+" }
                            },
                            VisualMockup = "/images/project-commercecraft.svg",
                            LiveDemoUrl = "https://github.com/mahmoud-dev/commercecraft-engine",
                            GithubUrl = "https://github.com/mahmoud-dev/commercecraft-engine"
                        }
                    },
                    new Project
                    {
                        Id = "taskpulse",
                        Title = "TaskPulse Collaboration Hub",
                        Category = "Productivity SaaS",
                        Subtitle = "Agile Project Tracking & Team Velocity Dashboard",
                        Description = "A streamlined work tracking system with interactive Kanban workflows, sprint velocity metrics, and granular project roles.",
                        ClientOrDomain = "Software & Agency Teams",
                        ValueProposition = "Replaced fragmented communication channels with a unified project board and automated milestone notifications.",
                        Technologies = new List<string> { "C#", "ASP.NET Core", "SQL Server", "Entity Framework Core", "JavaScript", "CSS Grid" },
                        MainFeatures = new List<string>
                        {
                            "Drag-and-drop Kanban workflow with smooth client-side DOM transitions",
                            "Team velocity calculations derived from SQL Server aggregate views",
                            "Audit log of every task modification, label change, and comment",
                            "Exportable sprint milestone reports"
                        },
                        HasCaseStudy = true,
                        CaseStudy = new CaseStudy
                        {
                            Id = "taskpulse-cs",
                            ProjectTitle = "TaskPulse Collaboration Hub",
                            Tagline = "Agile Velocity & Real-Time Team Alignment",
                            TheProblem = "Engineering teams suffered from disjointed task updates across emails and chat apps, causing missed sprint deliverables and opaque individual workloads.",
                            TheOriginalIdea = "The client asked for a basic HTML checklist where members could mark tickets as done.",
                            MyApproach = "I recommended upgrading to an interactive Kanban board with drag-and-drop state transitions, indexed SQL Server views calculating real-time sprint burndown velocity, and role-based access for Product Owners, Tech Leads, and Developers.",
                            TheSolution = "Developed an ASP.NET Core solution integrating efficient SQL Server CTEs for parent-child epic hierarchies, lightweight vanilla JS for drag-and-drop events, and secure audit history logging for every card change.",
                            KeyFeatures = new List<string>
                            {
                                "Interactive Kanban board with client-side optimistic UI updates",
                                "SQL Server CTE queries calculating hierarchical sprint burndown velocity",
                                "Role-based permissions (Product Owner, Developer, Stakeholder)",
                                "Granular change audit logging via database triggers"
                            },
                            Technologies = new List<string> { "ASP.NET Core", "C#", "SQL Server", "EF Core", "Vanilla JS", "CSS Grid" },
                            ChallengesAndSolutions = new List<string>
                            {
                                "Challenge: High-frequency task position reordering in large sprints caused database thrashing. -> Solution: Implemented floating-point fractional index ranking, eliminating full table re-indexing on card moves.",
                                "Challenge: Real-time status updates without heavy WebSocket overhead. -> Solution: Engineered lightweight polling with HTTP 304 Not Modified cache validation."
                            },
                            ResultsAndImpact = new List<string>
                            {
                                "40% reduction in missed sprint milestone deliverables",
                                "Under 120ms execution time for complex velocity and burndown reports",
                                "Zero lost task updates across 10,000+ card transitions",
                                "Adopted by 3 active engineering squads within the organization"
                            },
                            Metrics = new Dictionary<string, string>
                            {
                                { "Missed Deadlines", "-40%" },
                                { "Report Latency", "120ms" },
                                { "Active Squads", "3 Teams" },
                                { "Card Moves Handled", "10k+" }
                            },
                            VisualMockup = "/images/project-taskpulse.svg",
                            LiveDemoUrl = "https://github.com/mahmoud-dev/taskpulse-hub",
                            GithubUrl = "https://github.com/mahmoud-dev/taskpulse-hub"
                        }
                    }
                },

                Experiences = new List<ExperienceItem>
                {
                    new ExperienceItem
                    {
                        Role = "Full Stack .NET Developer",
                        Organization = "Freelance & Solutions Consultant",
                        Period = "2024 — Present",
                        Location = "Remote",
                        Summary = "Partnering directly with business founders and project stakeholders to design, architect, and deliver custom .NET web solutions, enterprise tools, and modernized database systems.",
                        Responsibilities = new List<string>
                        {
                            "Conduct client discovery sessions to uncover root business problems and refine raw concepts into structured software specifications.",
                            "Architect and build full stack web applications using ASP.NET Core, EF Core, SQL Server, and responsive modern frontend interfaces.",
                            "Design and implement secure RESTful Web APIs documented with Swagger for web and mobile client integration.",
                            "Optimize slow legacy databases by diagnosing query plans, creating indexes, and rewriting queries into high-speed stored procedures."
                        },
                        Contributions = new List<string>
                        {
                            "Delivered 6+ custom digital solutions spanning logistics, healthcare scheduling, and e-commerce with 100% on-time milestone delivery.",
                            "Proactively proposed UI/UX workflow improvements on every client project, yielding average satisfaction scores of 4.9/5.0."
                        },
                        Results = new List<string>
                        {
                            "Achieved an average 60%+ query performance improvement across client database environments.",
                            "Helped clients automate over 100 collective weekly operational hours."
                        },
                        Technologies = new List<string> { "C#", "ASP.NET Core", "Web API", "SQL Server", "EF Core", "JavaScript", "Git", "Docker" }
                    },
                    new ExperienceItem
                    {
                        Role = "Junior .NET Software Developer",
                        Organization = "TechCore Digital Solutions",
                        Period = "2023 — 2024",
                        Location = "Cairo, Egypt",
                        Summary = "Developed backend services, maintained enterprise MVC applications, and collaborated in cross-functional agile sprints.",
                        Responsibilities = new List<string>
                        {
                            "Implemented RESTful endpoints in ASP.NET Core Web API with clean request validation and standardized error handling.",
                            "Wrote unit and integration tests using xUnit, ensuring high reliability across business logic modules.",
                            "Maintained database schemas, wrote migrations in EF Core, and crafted parameterized SQL queries to prevent SQL injection.",
                            "Collaborated with frontend developers and UI designers to integrate modern JavaScript interfaces with backend endpoints."
                        },
                        Contributions = new List<string>
                        {
                            "Refactored legacy data access layers into repository and unit-of-work patterns, reducing code duplication by 30%.",
                            "Contributed to CI/CD pipeline automation on GitHub Actions for automated testing and staging deployments."
                        },
                        Results = new List<string>
                        {
                            "Resolved 80+ backlog issues and feature tickets with a near-zero regression rate.",
                            "Received commendation for proactive communication and code clarity during peer reviews."
                        },
                        Technologies = new List<string> { "C#", "ASP.NET Core MVC", "Entity Framework Core", "SQL Server", "LINQ", "HTML5", "CSS3", "Git" }
                    }
                },

                EducationItems = new List<EducationItem>
                {
                    new EducationItem
                    {
                        Degree = "Bachelor of Science in Computer Science / Information Systems",
                        Institution = "Faculty of Computers and Artificial Intelligence",
                        Period = "2020 — 2024",
                        Focus = "Software Engineering, Database Management Systems, Algorithms & Data Structures",
                        Description = "Graduated with a solid theoretical and practical foundation in computer systems, object-oriented software engineering, relational database design, and network protocols.",
                        KeyMilestones = new List<string>
                        {
                            "Graduation Project: Excellence award for an automated cloud-connected management portal built with .NET and SQL Server",
                            "Consistently top tier in Database Systems, Operating Systems, and Advanced C# courses",
                            "Led university study groups on Data Structures, Problem Solving, and Competitive Programming"
                        },
                        RelevantTopics = new List<string> { "Object-Oriented Programming (OOP)", "Database Architecture & Normalization", "Software Engineering Lifecycle (SDLC)", "Data Structures & Algorithms", "Computer Networks & Security" }
                    },
                    new EducationItem
                    {
                        Degree = "Specialized .NET Full Stack Professional Track",
                        Institution = "Information Technology Institute (ITI) / Professional Certification",
                        Period = "2023 — 2024",
                        Focus = "Enterprise ASP.NET Core, EF Core, Microservices Architecture, Advanced SQL Server",
                        Description = "Intensive professional training focusing on production-grade software delivery, enterprise architectural patterns, API security, and real-world project development under senior mentors.",
                        KeyMilestones = new List<string>
                        {
                            "Completed 500+ hours of hands-on software development and live architectural code reviews",
                            "Delivered a comprehensive end-to-end e-commerce and logistics capstone project",
                            "Mastered performance profiling, database index tuning, and containerization with Docker"
                        },
                        RelevantTopics = new List<string> { "ASP.NET Core Web API", "Entity Framework Core Internals", "SQL Server Query Optimization", "Clean Architecture & SOLID Principles", "Docker Containerization" }
                    }
                },

                JourneyStages = new List<JourneyStage>
                {
                    new JourneyStage
                    {
                        Step = 1,
                        StageTitle = "Curiosity & The Algorithmic Spark",
                        Subtitle = "Student & Logic Explorer",
                        Timeframe = "2020 — 2021",
                        Story = "My journey began with a curiosity about how digital systems turn abstract lines of code into real-world utility. Writing C++ and Python, I spent countless hours dissecting algorithms, understanding memory layouts, and discovering the joy of solving intricate logic puzzles.",
                        Milestones = new List<string>
                        {
                            "Mastered data structures (arrays, linked lists, trees, graphs, hash tables)",
                            "Solved 250+ algorithmic challenges on competitive programming platforms",
                            "Built terminal-based utilities and discovered a passion for clean architecture"
                        },
                        KeyLearnings = new List<string> { "C++ fundamentals", "Algorithmic thinking", "Time & space complexity", "Debugging discipline" },
                        ImpactSummary = "Built the foundational mindset: code is not just syntax; it is structured problem solving."
                    },
                    new JourneyStage
                    {
                        Step = 2,
                        StageTitle = "The .NET Awakening & Core Mastery",
                        Subtitle = "Deep Dive into Enterprise C# & Databases",
                        Timeframe = "2021 — 2022",
                        Story = "Transitioning to C# felt like discovering a superpower. The elegance of C#, the robustness of the .NET runtime, and the sheer power of SQL Server relational modeling clicked together. I spent this phase building console and desktop tools, mastering OOP, and understanding how data lives in databases.",
                        Milestones = new List<string>
                        {
                            "Deep dive into C# OOP, generics, LINQ, and delegates",
                            "Mastered relational database design, 3NF normalization, and complex SQL joins",
                            "Built first full database-connected inventory and student management systems"
                        },
                        KeyLearnings = new List<string> { "C#", "OOP & SOLID", "SQL Server", "Relational Modeling", "LINQ" },
                        ImpactSummary = "Realized that great software begins with solid data architecture and clean class contracts."
                    },
                    new JourneyStage
                    {
                        Step = 3,
                        StageTitle = "Building Beyond Specs: The Web Era",
                        Subtitle = "ASP.NET Core, APIs & Frontend Integration",
                        Timeframe = "2022 — 2023",
                        Story = "I stepped into web application development with ASP.NET Core MVC and Web API. Rather than building cookie-cutter tutorials, I pushed myself to build real products with authentication, file handling, database migrations, and responsive JavaScript interfaces that actual users could test.",
                        Milestones = new List<string>
                        {
                            "Built full-stack applications integrating ASP.NET Core with vanilla JS and modern CSS",
                            "Implemented secure JWT authentication, role management, and session state",
                            "Discovered that software succeeds or fails based on user experience, not just backend code"
                        },
                        KeyLearnings = new List<string> { "ASP.NET Core MVC", "Web API", "EF Core", "HTML/CSS/JS", "RESTful Design" },
                        ImpactSummary = "Shifted from building isolated components to creating cohesive, end-to-end digital experiences."
                    },
                    new JourneyStage
                    {
                        Step = 4,
                        StageTitle = "Real-World Commercial Experience",
                        Subtitle = "Production Deployments & Collaborative Engineering",
                        Timeframe = "2023 — 2024",
                        Story = "Stepping into professional software environments challenged me to handle real-world complexities: concurrent users, edge cases, legacy code refactoring, database performance tuning, and cross-team communication. I learned how to turn ambiguous requirements into dependable software releases.",
                        Milestones = new List<string>
                        {
                            "Delivered production features for commercial web applications under agile sprints",
                            "Optimized database execution plans, reducing production query bottlenecks by up to 85%",
                            "Contributed to CI/CD pipelines, Docker container setups, and Swagger API documentation"
                        },
                        KeyLearnings = new List<string> { "Production Debugging", "SQL Query Optimization", "Docker", "Git/GitHub Workflows", "Team Collaboration" },
                        ImpactSummary = "Understood that clean code is code that teammates can read, maintain, and trust in production."
                    },
                    new JourneyStage
                    {
                        Step = 5,
                        StageTitle = "The Idea Partner Mindset",
                        Subtitle = "Turning Raw Concepts into Better Digital Solutions",
                        Timeframe = "2024 — Present",
                        Story = "This is where my core brand was born. I realized that the biggest gap in software development isn't typing code — it's truly understanding what a client needs and helping them make their idea better. Today, I combine deep technical .NET mastery with business empathy, proactive suggestions, and end-to-end ownership.",
                        Milestones = new List<string>
                        {
                            "Founded Mahmoud.Dev as an independent brand for high-quality .NET development",
                            "Consulted for business founders, improving user flows, database models, and conversion rates",
                            "Delivered standout solutions including LogiCore Express, MediConnect, and CommerceCraft"
                        },
                        KeyLearnings = new List<string> { "Product Strategy", "System Architecture", "Client Communication", "UX Flow Design", "Continuous Delivery" },
                        ImpactSummary = "Operating not just as a developer who writes code, but as a strategic technical partner who elevates client ideas."
                    },
                    new JourneyStage
                    {
                        Step = 6,
                        StageTitle = "Continuous Evolution & Future Horizons",
                        Subtitle = "Modern .NET 10, Cloud Architecture & Global Impact",
                        Timeframe = "Looking Forward",
                        Story = "Technology never stands still, and neither do I. I continuously sharpen my skills with modern .NET 10 features, cloud-native deployments, asynchronous distributed architectures, and refined micro-interactions. My goal is to become an industry-recognized software architect who builds digital products that touch millions of lives.",
                        Milestones = new List<string>
                        {
                            "Exploring cloud-native microservices and serverless integration on Azure",
                            "Contributing to open-source developer tooling and technical writing",
                            "Committed to lifelong mastery, technical excellence, and humble curiosity"
                        },
                        KeyLearnings = new List<string> { ".NET 10 Innovation", "Cloud Architectures", "High-Availability Systems", "Design Leadership" },
                        ImpactSummary = "Remaining perpetually curious, committed to quality, and eager to take on increasingly ambitious challenges."
                    }
                },

                WhyMeReasons = new List<WhyWorkWithMeItem>
                {
                    new WhyWorkWithMeItem
                    {
                        Pillar = "Deep Understanding",
                        Headline = "I uncover the real problem behind the request",
                        ClientPerspective = "Many developers jump straight into coding the moment they get a prompt, delivering something that matches words literally but fails the actual business goal.",
                        MahmoudApproach = "I take the time to listen, ask the right questions, understand your users, and analyze your operational workflows before writing a single line of code.",
                        BusinessImpact = "You get software that actually solves your operational bottleneck rather than another digital tool that creates headaches.",
                        IconSvg = "compass"
                    },
                    new WhyWorkWithMeItem
                    {
                        Pillar = "Idea Elevation",
                        Headline = "I take your concept and suggest ways to make it better",
                        ClientPerspective = "You have a vision, but you might not know the technical possibilities, automation tricks, or UX patterns that can make it shine.",
                        MahmoudApproach = "I don't passively follow a checklist. I proactively brainstorm features, identify edge cases, and propose smart enhancements that make the final product more attractive and effective.",
                        BusinessImpact = "Your product launches with a competitive edge and superior user delight that you might not have originally planned for.",
                        IconSvg = "sparkles"
                    },
                    new WhyWorkWithMeItem
                    {
                        Pillar = "Root-Cause Problem Solving",
                        Headline = "I fix the bottleneck, not just the surface symptoms",
                        ClientPerspective = "Quick duct-tape fixes cause recurring bugs, database slowdowns, and costly refactors months down the line.",
                        MahmoudApproach = "Whether analyzing a slow SQL query, resolving concurrency race conditions, or simplifying an awkward multi-step form, I engineer solutions that endure.",
                        BusinessImpact = "Your application runs smoothly under heavy loads with minimal ongoing maintenance costs.",
                        IconSvg = "target"
                    },
                    new WhyWorkWithMeItem
                    {
                        Pillar = "User Experience Mindset",
                        Headline = "I believe enterprise software should feel enjoyable to use",
                        ClientPerspective = "Many backend developers disregard the visual interface, resulting in clunky, confusing, and frustrating software.",
                        MahmoudApproach = "I pay meticulous attention to visual hierarchy, responsive layouts, clear error messages, and micro-interactions so every click feels natural and effortless.",
                        BusinessImpact = "Higher user adoption, lower training overhead for your staff, and glowing feedback from your clients.",
                        IconSvg = "heart"
                    },
                    new WhyWorkWithMeItem
                    {
                        Pillar = "Technical Integrity",
                        Headline = "Clean architecture, structured databases & reliable .NET code",
                        ClientPerspective = "Messy code bases become impossible to upgrade or hand over to other developers in the future.",
                        MahmoudApproach = "I build upon clean architecture, SOLID principles, well-documented REST APIs (Swagger), strict database constraints, and meaningful commit histories.",
                        BusinessImpact = "A reliable digital asset that is easily extensible as your business grows.",
                        IconSvg = "shield-check"
                    },
                    new WhyWorkWithMeItem
                    {
                        Pillar = "Transparent Partnership",
                        Headline = "Proactive communication with zero mystery or guesswork",
                        ClientPerspective = "Clients often fear disappearing developers who go dark for weeks with no updates.",
                        MahmoudApproach = "I maintain consistent, clear communication throughout the project: regular milestone demos, transparent progress tracking, and honest feedback.",
                        BusinessImpact = "Complete peace of mind knowing your project is in dedicated, reliable hands every single step of the way.",
                        IconSvg = "messages-square"
                    }
                },

                Services = new List<ServiceItem>
                {
                    new ServiceItem
                    {
                        Title = "Full Stack Web Development",
                        CategoryTag = "End-to-End Solutions",
                        ClientBenefit = "Get a cohesive, high-performing web application built from the database up to the user interface, eliminating communication gaps between separate frontend and backend teams.",
                        Description = "Complete digital solutions engineered with modern ASP.NET Core on the backend and responsive, elegant HTML5/CSS3/JavaScript on the client.",
                        Deliverables = new List<string> { "Full architectural blueprint", "Responsive frontend UI", "Secure ASP.NET Core backend", "Database integration & deployment" },
                        TechStack = new List<string> { "C#", "ASP.NET Core", "SQL Server", "EF Core", "JavaScript", "HTML5/CSS3" },
                        IconSvg = "globe"
                    },
                    new ServiceItem
                    {
                        Title = "Business Websites",
                        CategoryTag = "Brand Presence",
                        ClientBenefit = "Turn casual website visitors into paying clients with an elegant, fast-loading, and credible digital showcase that reflects the prestige of your company.",
                        Description = "Custom-tailored business websites designed to highlight your services, showcase your team, build customer trust, and drive lead inquiries.",
                        Deliverables = new List<string> { "Custom visual layout", "Mobile & tablet optimization", "SEO-ready semantic markup", "Lead capture forms & analytics" },
                        TechStack = new List<string> { "ASP.NET Core MVC", "Responsive CSS Grid", "Vanilla JS", "Contact Endpoints" },
                        IconSvg = "briefcase"
                    },
                    new ServiceItem
                    {
                        Title = "Custom Web Applications",
                        CategoryTag = "Business Automation",
                        ClientBenefit = "Automate tedious daily operations, replace disjointed spreadsheets, and empower your team with tailored internal portals designed specifically for your workflows.",
                        Description = "Bespoke SaaS tools, inventory trackers, customer management portals, and scheduling systems built to fit your exact business rules.",
                        Deliverables = new List<string> { "Role-based user permissions", "Automated workflow calculations", "Data export & audit logs", "Real-time status tracking" },
                        TechStack = new List<string> { "C#", "ASP.NET Core", "SQL Server", "Stored Procedures", "JavaScript" },
                        IconSvg = "layers"
                    },
                    new ServiceItem
                    {
                        Title = "Backend Development",
                        CategoryTag = "Core Infrastructure",
                        ClientBenefit = "Ensure your digital product operates on a rock-solid, secure, and lightning-fast backend that never crumbles under high traffic.",
                        Description = "Robust server-side logic, secure authentication pipelines, business rule processing, background task workers, and third-party integrations.",
                        Deliverables = new List<string> { "Clean modular architecture", "Security & authentication (Identity/JWT)", "Error logging & health checks", "Scalable data layer" },
                        TechStack = new List<string> { "C#", ".NET 10", "ASP.NET Core", "Dependency Injection", "Docker" },
                        IconSvg = "server"
                    },
                    new ServiceItem
                    {
                        Title = "REST APIs",
                        CategoryTag = "Connectivity & Integration",
                        ClientBenefit = "Connect mobile apps, web frontends, payment gateways, and third-party partners effortlessly with secure, standardized, and self-documenting APIs.",
                        Description = "Design and implementation of RESTful APIs following industry standards, HTTP status semantics, payload validation, and interactive Swagger documentation.",
                        Deliverables = new List<string> { "RESTful API endpoints", "Interactive Swagger/OpenAPI docs", "Token authentication & rate limiting", "Client SDK or contract models" },
                        TechStack = new List<string> { "ASP.NET Core Web API", "C#", "Swagger", "JSON", "JWT" },
                        IconSvg = "network"
                    },
                    new ServiceItem
                    {
                        Title = "Database Development & Optimization",
                        CategoryTag = "Data Engineering",
                        ClientBenefit = "Protect your company's most valuable asset — your data — while slashing query response times and preventing costly data corruption.",
                        Description = "Relational database schema design, index optimization, complex stored procedures, database views, and automated data audit triggers.",
                        Deliverables = new List<string> { "Normalized relational schema", "Optimized stored procedures & views", "Index strategy & execution tuning", "Audit trail triggers" },
                        TechStack = new List<string> { "SQL Server", "T-SQL", "Stored Procedures", "Views", "Triggers", "EF Core" },
                        IconSvg = "database"
                    },
                    new ServiceItem
                    {
                        Title = "Website Improvement & Modernization",
                        CategoryTag = "Performance & Refresh",
                        ClientBenefit = "Breathe new life into sluggish, outdated, or hard-to-use applications without throwing away your existing investment.",
                        Description = "Auditing existing systems to improve user experience, increase page load speeds, resolve stubborn bugs, and upgrade old frameworks to modern .NET.",
                        Deliverables = new List<string> { "Comprehensive performance audit", "UI/UX responsiveness overhaul", "Code refactoring & security patch", "Query speed optimization" },
                        TechStack = new List<string> { ".NET Migration", "CSS3 Modernization", "SQL Profiling", "Security Auditing" },
                        IconSvg = "wrench"
                    }
                },

                Achievements = new List<AchievementItem>
                {
                    new AchievementItem
                    {
                        Title = "Excellence in Capstone System Architecture",
                        Category = "Academic & Engineering",
                        IssuerOrEvent = "Faculty of Computers and Artificial Intelligence",
                        Year = "2024",
                        Description = "Awarded top engineering distinction for designing and building an automated cloud-connected management system with .NET and SQL Server.",
                        Highlight = "Ranked Top 5% among graduation cohorts"
                    },
                    new AchievementItem
                    {
                        Title = "Professional .NET Full Stack Certification",
                        Category = "Professional Certification",
                        IssuerOrEvent = "Information Technology Institute (ITI)",
                        Year = "2024",
                        Description = "Completed over 500 intensive development hours in enterprise ASP.NET Core, EF Core, SQL Server tuning, and containerization.",
                        Highlight = "Certified Full Stack .NET Specialist"
                    },
                    new AchievementItem
                    {
                        Title = "Competitive Programming Distinction",
                        Category = "Problem Solving",
                        IssuerOrEvent = "Algorithmic Problem Solving Contests",
                        Year = "2022 — 2023",
                        Description = "Solved over 250 complex algorithmic challenges spanning graphs, dynamic programming, and data structures under strict time and memory limits.",
                        Highlight = "250+ Algorithmic Challenges Solved"
                    },
                    new AchievementItem
                    {
                        Title = "Database Performance Optimization Milestone",
                        Category = "Commercial Impact",
                        IssuerOrEvent = "Commercial Client Projects",
                        Year = "2024",
                        Description = "Successfully refactored a critical enterprise logistics database, cutting heavy report query execution time from 14.2 seconds down to 210 milliseconds.",
                        Highlight = "85% Query Latency Reduction"
                    }
                },

                Testimonials = new List<TestimonialItem>
                {
                    new TestimonialItem
                    {
                        ClientName = "Tarek Al-Mansoor",
                        RoleAndCompany = "Operations Director, Gulf Logistics Group",
                        ProjectContext = "LogiCore Express Logistics System",
                        Feedback = "Working with Mahmoud was a breath of fresh air. We originally came to him with a very basic idea for a driver form. Mahmoud listened, asked penetrating questions about how our warehouse operates, and came back with a solution that literally automated our dispatching and cut our report generation from 15 seconds to instant. He truly improves your idea before he builds it.",
                        Rating = 5,
                        Initials = "TA"
                    },
                    new TestimonialItem
                    {
                        ClientName = "Dr. Sarah El-Khatib",
                        RoleAndCompany = "Managing Director, Delta Medical Centers",
                        ProjectContext = "MediConnect Healthcare Portal",
                        Feedback = "Mahmoud delivered exactly what he promised, and then some. The booking system he built solved our persistent double-booking headache completely. The interface is clean, calm, and our patients love how simple it is. He is always responsive, clear, and proactive. I wholeheartedly recommend Mahmoud to anyone needing a trustworthy .NET developer.",
                        Rating = 5,
                        Initials = "SK"
                    },
                    new TestimonialItem
                    {
                        ClientName = "Omar Farouk",
                        RoleAndCompany = "Founder & CEO, Horizon Commerce",
                        ProjectContext = "CommerceCraft Custom E-Commerce Engine",
                        Feedback = "Most developers just build what you write on the ticket, even if it has flaws. Mahmoud stopped us from making a major mistake with our inventory management during flash sales and architected a solution that held zero stock discrepancies during our biggest sale of the year. He is a genuine problem solver and technical partner.",
                        Rating = 5,
                        Initials = "OF"
                    }
                }
            };
        }
    }

    public class ContactService : IContactService
    {
        private readonly List<ContactRequest> _inquiries = new();
        private readonly ILogger<ContactService> _logger;
        private readonly IConfiguration _configuration;

        public ContactService(ILogger<ContactService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<(bool Success, string Message)> SubmitInquiryAsync(ContactRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                return (false, "Please provide your name.");

            if (string.IsNullOrWhiteSpace(request.Email) || !request.Email.Contains('@'))
                return (false, "Please provide a valid email address so Mahmoud can reach back to you.");

            if (string.IsNullOrWhiteSpace(request.Description))
                return (false, "Please share a brief description of your project or idea.");

            lock (_inquiries)
            {
                _inquiries.Add(request);
            }

            _logger.LogInformation("New project inquiry received from {Name} ({Email}) for project type: {Type}",
                request.Name, request.Email, request.ProjectType);

            // Send Email Notification in background so the client receives an instant response
            _ = Task.Run(async () =>
            {
                try
                {
                    await TrySendEmailAsync(request);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Background email delivery error for {Email}", request.Email);
                }
            });

            return (true, "Thank you, " + request.Name + "! Your message has been received. Mahmoud will review your project details and get back to you within 24 hours.");
        }

        private async Task TrySendEmailAsync(ContactRequest request)
        {
            try
            {
                var senderEmail = _configuration["SmtpSettings:SenderEmail"] 
                               ?? _configuration["SmtpSettings__SenderEmail"] 
                               ?? _configuration["SMTP_SENDER_EMAIL"] 
                               ?? "mahmoudabdelbakey1@gmail.com";

                var senderPassword = _configuration["SmtpSettings:SenderPassword"] 
                                  ?? _configuration["SmtpSettings__SenderPassword"] 
                                  ?? _configuration["SMTP_SENDER_PASSWORD"];

                var receiverEmail = _configuration["SmtpSettings:ReceiverEmail"] 
                                 ?? _configuration["SmtpSettings__ReceiverEmail"] 
                                 ?? _configuration["SMTP_RECEIVER_EMAIL"] 
                                 ?? "mahmoudabdelbakey1@gmail.com";

                var server = _configuration["SmtpSettings:Server"] 
                          ?? _configuration["SmtpSettings__Server"];

                var port = 587;
                if (int.TryParse(_configuration["SmtpSettings:Port"] ?? _configuration["SmtpSettings__Port"], out var p))
                {
                    port = p;
                }

                senderEmail = senderEmail.Trim();
                senderPassword = senderPassword.Trim().Replace(" ", "");
                receiverEmail = receiverEmail.Trim();

                using var mail = new MailMessage();
                mail.From = new MailAddress(senderEmail, $"Portfolio Lead — {request.Name}");
                mail.To.Add(receiverEmail);
                mail.ReplyToList.Add(new MailAddress(request.Email, request.Name));
                mail.Subject = $"💼 [Mahmoud.Dev] New Project Inquiry from {request.Name} ({request.ProjectType})";
                
                // Professional HTML Email Template
                string htmlBody = $@"
<!DOCTYPE html>
<html lang='en'>
<head>
  <meta charset='UTF-8'>
  <style>
    body {{ font-family: 'Segoe UI', -apple-system, BlinkMacSystemFont, Roboto, sans-serif; background-color: #f4f6f8; margin: 0; padding: 24px; color: #1e293b; }}
    .container {{ max-width: 600px; background: #ffffff; margin: 0 auto; border-radius: 12px; overflow: hidden; box-shadow: 0 4px 20px rgba(0,0,0,0.06); border: 1px solid #e2e8f0; }}
    .header {{ background: linear-gradient(135deg, #0F766E 0%, #115E59 100%); padding: 32px 28px; text-align: left; color: #ffffff; }}
    .header h1 {{ margin: 0; font-size: 22px; font-weight: 700; letter-spacing: -0.02em; }}
    .header p {{ margin: 6px 0 0 0; font-size: 14px; opacity: 0.9; }}
    .content {{ padding: 28px; }}
    .badge {{ display: inline-block; background: #E6FFFA; color: #0F766E; font-size: 12px; font-weight: 700; padding: 4px 10px; border-radius: 9999px; margin-bottom: 20px; }}
    .info-table {{ width: 100%; border-collapse: collapse; margin-bottom: 24px; }}
    .info-table td {{ padding: 10px 0; border-bottom: 1px solid #edf2f7; font-size: 14px; vertical-align: top; }}
    .info-table td.label {{ width: 130px; font-weight: 600; color: #64748b; }}
    .info-table td.value {{ color: #0f172a; font-weight: 500; }}
    .message-box {{ background: #f8fafc; border-left: 4px solid #0F766E; padding: 18px; border-radius: 6px; font-size: 14px; line-height: 1.6; color: #334155; white-space: pre-wrap; }}
    .action-btn {{ display: inline-block; background: #0F766E; color: #ffffff !important; font-weight: 600; text-decoration: none; padding: 12px 24px; border-radius: 8px; font-size: 14px; margin-top: 24px; }}
    .footer {{ background: #f8fafc; padding: 20px 28px; font-size: 12px; color: #94a3b8; text-align: center; border-top: 1px solid #edf2f7; }}
  </style>
</head>
<body>
  <div class='container'>
    <div class='header'>
      <h1>📬 New Project Inquiry</h1>
      <p>Received directly from your portfolio: <strong>Mahmoud.Dev</strong></p>
    </div>
    <div class='content'>
      <span class='badge'>Instant Notification</span>
      <table class='info-table'>
        <tr>
          <td class='label'>Client Name:</td>
          <td class='value'><strong>{WebUtility.HtmlEncode(request.Name)}</strong></td>
        </tr>
        <tr>
          <td class='label'>Client Email:</td>
          <td class='value'><a href='mailto:{WebUtility.HtmlEncode(request.Email)}' style='color: #0F766E; font-weight: 600;'>{WebUtility.HtmlEncode(request.Email)}</a></td>
        </tr>
        <tr>
          <td class='label'>Project Type:</td>
          <td class='value'>{WebUtility.HtmlEncode(request.ProjectType)}</td>
        </tr>
        <tr>
          <td class='label'>Budget Range:</td>
          <td class='value'>{(string.IsNullOrWhiteSpace(request.Budget) ? "Flexible / Not specified" : WebUtility.HtmlEncode(request.Budget))}</td>
        </tr>
        <tr>
          <td class='label'>Submission Time:</td>
          <td class='value'>{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} UTC</td>
        </tr>
      </table>

      <div style='font-weight: 700; font-size: 14px; color: #0f172a; margin-bottom: 8px;'>Project Description & Requirements:</div>
      <div class='message-box'>{WebUtility.HtmlEncode(request.Description)}</div>

      <div style='text-align: center;'>
        <a href='mailto:{WebUtility.HtmlEncode(request.Email)}?subject=Re:%20Inquiry%20from%20Mahmoud.Dev' class='action-btn'>
          Reply to {WebUtility.HtmlEncode(request.Name)} →
        </a>
      </div>
    </div>
    <div class='footer'>
      Mahmoud Abd-Elbakey • Full Stack .NET Developer • <a href='https://mahmoud.dev' style='color: #94a3b8;'>Mahmoud.Dev</a>
    </div>
  </div>
</body>
</html>";

                mail.Body = htmlBody;
                mail.IsBodyHtml = true;

                using var smtp = new SmtpClient(server, port)
                {
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(senderEmail, senderPassword),
                    Timeout = 15000
                };

                _logger.LogInformation("Attempting SMTP dispatch via {Server}:{Port} using sender {Sender} to {Receiver}...", server, port, senderEmail, receiverEmail);
                await smtp.SendMailAsync(mail);
                _logger.LogInformation("SUCCESS: Professional HTML notification email successfully sent to {ReceiverEmail}", receiverEmail);
            }
            catch (SmtpException smtpEx)
            {
                _logger.LogError(smtpEx, "SMTP Error sending notification email to {Receiver}. StatusCode={Code}, Message={Message}", request.Email, smtpEx.StatusCode, smtpEx.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send notification email for inquiry from {Email}. Error: {Message}", request.Email, ex.Message);
            }
        }

        public List<ContactRequest> GetAllInquiries()
        {
            lock (_inquiries)
            {
                return new List<ContactRequest>(_inquiries);
            }
        }
    }
}
