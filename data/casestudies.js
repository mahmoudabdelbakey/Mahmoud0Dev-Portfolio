/**
 * Mahmoud.Dev - Static Case Study Data
 * Used by projects.js to load case studies without a backend API.
 * Mirrors the C# PortfolioDataService CaseStudy objects exactly.
 */

const CASE_STUDIES = {
  "logicore-cs": {
    id: "logicore-cs",
    projectTitle: "LogiCore Express",
    tagline: "From Manual Spreadsheets to Real-Time Fleet Intelligence",
    theProblem: "The client was suffering from dispatch bottlenecks: manual phone calls between warehouse managers and drivers, duplicate manifests, and financial reports that took up to 14 seconds to query, frequently locking database tables during peak morning hours.",
    theOriginalIdea: "The client initially asked for a simple web form to record driver sign-outs and replace printed paper trip slips.",
    myApproach: "I saw that simply moving the paper form into a web browser would not solve their real problem. I suggested adding an intelligent allocation pipeline that automatically calculates available vehicle volume, validates driver rest periods, and executes high-speed batch reporting via optimized SQL Server stored procedures instead of raw unindexed LINQ queries.",
    theSolution: "Engineered an end-to-end ASP.NET Core application with a clean three-tier architecture. Implemented EF Core for rapid transaction processing alongside custom SQL Server Stored Procedures and non-clustered composite indexes for heavy analytical summaries.",
    keyFeatures: [
      "Dynamic fleet capacity calculator with real-time payload alerts",
      "Automated dispatcher conflict prevention (prevents overlapping assignments)",
      "Comprehensive audit logging powered by database triggers",
      "Responsive tablet-ready driver checkpoint interface"
    ],
    technologies: ["ASP.NET Core Web API", "C#", "Entity Framework Core", "SQL Server", "Stored Procedures & Views", "Vanilla JS", "Docker"],
    challengesAndSolutions: [
      "Challenge: Reporting queries locked the orders table during high morning dispatch volume. -> Solution: Implemented SQL Server snapshot isolation and built an indexed summary view, reducing lock contention to 0%.",
      "Challenge: Frequent network drops at remote warehouse terminals. -> Solution: Created client-side optimistic UI updates with automatic retry queues over Fetch API."
    ],
    resultsAndImpact: [
      "85% reduction in reporting query latency (from 14.2s to 210ms)",
      "Eliminated 100% of double-booking and route conflict incidents",
      "Saved the dispatch team over 40 hours of manual coordination every week",
      "Successfully handling over 8,500 daily route checkpoints with zero downtime"
    ],
    metrics: { "Query Latency": "-85%", "Booking Conflicts": "0", "Weekly Hours Saved": "40+ hrs", "Uptime": "99.98%" },
    visualMockup: "./images/project-logicore.svg",
    githubUrl: "https://github.com/mahmoud-dev/logicore-express"
  },

  "mediconnect-cs": {
    id: "mediconnect-cs",
    projectTitle: "MediConnect Health",
    tagline: "Eliminating Healthcare Scheduling Conflicts and No-Shows",
    theProblem: "A network of private healthcare clinics experienced high patient no-show rates (over 28%) and frequent double-booking errors caused by simultaneous reception calls and walk-in updates.",
    theOriginalIdea: "The client asked for a static calendar interface where receptionists could manually select time slots.",
    myApproach: "I investigated the underlying reasons for missed appointments and booking collisions. I recommended adding automated email reminders, an optimistic concurrency token on the appointment entity in EF Core, and a self-service patient reschedule link that dynamically frees cancelled slots for waitlisted patients.",
    theSolution: "Delivered an ASP.NET Core MVC and Web API solution with ASP.NET Core Identity for secure role-based permissions (Patients, Doctors, Administrators), backed by SQL Server transactional integrity and custom table-valued functions for doctor availability calculation.",
    keyFeatures: [
      "EF Core RowVersion concurrency check guaranteeing zero double-bookings",
      "Self-service patient confirmation and reschedule portal",
      "Custom SQL Server availability calculation function evaluating clinic holidays and doctor shifts",
      "Audit-ready patient record access logs"
    ],
    technologies: ["ASP.NET Core", "C#", "SQL Server", "Entity Framework Core", "LINQ", "CSS3 / Vanilla JS", "Swagger"],
    challengesAndSolutions: [
      "Challenge: High concurrency during 8:00 AM slot release times led to race conditions. -> Solution: Applied EF Core concurrency tokens with clear user-friendly conflict resolution prompts.",
      "Challenge: Protecting sensitive health data. -> Solution: Implemented field-level data protection and strict parameterization across all SQL endpoints."
    ],
    resultsAndImpact: [
      "62% reduction in missed appointments (no-show rate dropped from 28% to 10.6%)",
      "Zero double-booking incidents across 18,000+ completed appointments",
      "Reception call duration decreased by 45%, freeing staff for patient care",
      "Client expanded the system to 4 additional branch clinics within 6 months"
    ],
    metrics: { "No-Show Drop": "-62%", "Double Bookings": "Zero", "Call Time Saved": "45%", "Appointments Handled": "18,000+" },
    visualMockup: "./images/project-mediconnect.svg",
    githubUrl: "https://github.com/mahmoud-dev/mediconnect-health"
  },

  "commercecraft-cs": {
    id: "commercecraft-cs",
    projectTitle: "CommerceCraft Engine",
    tagline: "Resilient Inventory Architecture for High-Demand Flash Sales",
    theProblem: "A boutique retail brand frequently suffered from stock discrepancies: popular items were oversold during seasonal campaigns, causing angry customer cancellations, payment chargebacks, and manual inventory adjustments.",
    theOriginalIdea: "Build a standard online product catalog with a third-party checkout button.",
    myApproach: "I explained that off-the-shelf basic carts fail during concurrent bursts because they decouple payment confirmation from stock reservation. I designed an atomic checkout pipeline where cart reservations hold stock for 10 minutes using database-level locking, releasing it automatically if the user abandons checkout.",
    theSolution: "Engineered a decoupled ASP.NET Core REST API paired with a high-performance JavaScript frontend. Handled payment reconciliation via resilient webhooks with retry policies and exponential backoff.",
    keyFeatures: [
      "Atomic inventory reservation using stored procedures and SERIALIZABLE transactions",
      "Recursive SQL CTEs for nested product taxonomy and fast faceted search",
      "Idempotent payment webhook receiver preventing duplicate order creation",
      "Interactive shopping cart drawer with instant promo code validation"
    ],
    technologies: [".NET 10", "C#", "ASP.NET Core Web API", "SQL Server", "EF Core", "Swagger", "Vanilla JS"],
    challengesAndSolutions: [
      "Challenge: High cart abandonment left reserved stock locked. -> Solution: Built a background timed worker service that scans expired reservation leases and restores available quantity in real time.",
      "Challenge: Complex multi-attribute pricing rules (size, color, bulk discounts). -> Solution: Designed a flexible rule-engine pattern in C# with unit-tested price evaluation."
    ],
    resultsAndImpact: [
      "Over-selling reduced to exactly zero items during Black Friday peak campaign",
      "Checkout processing speed improved by 3.2x compared to the legacy platform",
      "Cart completion conversion increased by 24% due to clear reservation timers",
      "Processed over $320,000 in transaction volume in the first quarter"
    ],
    metrics: { "Overselling Rate": "0.00%", "Speed Boost": "3.2x", "Conversion Lift": "+24%", "Processed Volume": "$320k+" },
    visualMockup: "./images/project-commercecraft.svg",
    githubUrl: "https://github.com/mahmoud-dev/commercecraft-engine"
  },

  "taskpulse-cs": {
    id: "taskpulse-cs",
    projectTitle: "TaskPulse Collaboration Hub",
    tagline: "Agile Velocity & Real-Time Team Alignment",
    theProblem: "Engineering teams suffered from disjointed task updates across emails and chat apps, causing missed sprint deliverables and opaque individual workloads.",
    theOriginalIdea: "The client asked for a basic HTML checklist where members could mark tickets as done.",
    myApproach: "I recommended upgrading to an interactive Kanban board with drag-and-drop state transitions, indexed SQL Server views calculating real-time sprint burndown velocity, and role-based access for Product Owners, Tech Leads, and Developers.",
    theSolution: "Developed an ASP.NET Core solution integrating efficient SQL Server CTEs for parent-child epic hierarchies, lightweight vanilla JS for drag-and-drop events, and secure audit history logging for every card change.",
    keyFeatures: [
      "Interactive Kanban board with client-side optimistic UI updates",
      "SQL Server CTE queries calculating hierarchical sprint burndown velocity",
      "Role-based permissions (Product Owner, Developer, Stakeholder)",
      "Granular change audit logging via database triggers"
    ],
    technologies: ["ASP.NET Core", "C#", "SQL Server", "EF Core", "Vanilla JS", "CSS Grid"],
    challengesAndSolutions: [
      "Challenge: High-frequency task position reordering in large sprints caused database thrashing. -> Solution: Implemented floating-point fractional index ranking, eliminating full table re-indexing on card moves.",
      "Challenge: Real-time status updates without heavy WebSocket overhead. -> Solution: Engineered lightweight polling with HTTP 304 Not Modified cache validation."
    ],
    resultsAndImpact: [
      "40% reduction in missed sprint milestone deliverables",
      "Under 120ms execution time for complex velocity and burndown reports",
      "Zero lost task updates across 10,000+ card transitions",
      "Adopted by 3 active engineering squads within the organization"
    ],
    metrics: { "Missed Deadlines": "-40%", "Report Latency": "120ms", "Active Squads": "3 Teams", "Card Moves Handled": "10k+" },
    visualMockup: "./images/project-taskpulse.svg",
    githubUrl: "https://github.com/mahmoud-dev/taskpulse-hub"
  }
};

function getCaseStudyById(id) {
  return CASE_STUDIES[id] || null;
}

