/**
 * Mahmoud.Dev - Core Interactive Engine
 * Handles navigation, smooth scrolling, scroll-spy, theme management, and micro-interactions.
 */

document.addEventListener('DOMContentLoaded', () => {
    initNavigation();
    initTheme();
    initScrollAnimations();
    initBackToTop();
    initResumeModal();
});

function initNavigation() {
    const navbar = document.querySelector('.navbar');
    const navToggle = document.querySelector('.nav-toggle-mobile');
    const navLinks = document.querySelector('.nav-links');
    const links = document.querySelectorAll('.nav-link');

    // Sticky nav effect on scroll
    window.addEventListener('scroll', () => {
        if (window.scrollY > 40) {
            navbar.classList.add('scrolled');
        } else {
            navbar.classList.remove('scrolled');
        }
        updateActiveNav();
    });

    // Mobile menu toggle
    if (navToggle && navLinks) {
        navToggle.addEventListener('click', () => {
            navLinks.classList.toggle('show');
            const isExpanded = navLinks.classList.contains('show');
            navToggle.setAttribute('aria-expanded', isExpanded);
        });

        // Close mobile menu on link click
        links.forEach(link => {
            link.addEventListener('click', () => {
                if (window.innerWidth <= 1040) {
                    navLinks.classList.remove('show');
                }
            });
        });
    }

    // Scroll spy
    function updateActiveNav() {
        const sections = document.querySelectorAll('section[id]');
        const scrollPosition = window.scrollY + 160;

        sections.forEach(section => {
            const sectionTop = section.offsetTop;
            const sectionHeight = section.offsetHeight;
            const sectionId = section.getAttribute('id');

            if (scrollPosition >= sectionTop && scrollPosition < sectionTop + sectionHeight) {
                links.forEach(link => {
                    link.classList.remove('active');
                    if (link.getAttribute('href') === `#${sectionId}`) {
                        link.classList.add('active');
                    }
                });
            }
        });
    }
}

function initTheme() {
    const themeBtn = document.getElementById('themeToggleBtn');
    const currentTheme = localStorage.getItem('mahmoud_theme') || 'light';

    if (currentTheme === 'dark') {
        document.documentElement.setAttribute('data-theme', 'dark');
        updateThemeIcon(true);
    }

    if (themeBtn) {
        themeBtn.addEventListener('click', () => {
            const isDark = document.documentElement.getAttribute('data-theme') === 'dark';
            const newTheme = isDark ? 'light' : 'dark';
            document.documentElement.setAttribute('data-theme', newTheme);
            localStorage.setItem('mahmoud_theme', newTheme);
            updateThemeIcon(!isDark);
        });
    }

    function updateThemeIcon(isDark) {
        if (!themeBtn) return;
        themeBtn.innerHTML = isDark ? `
            <svg width="18" height="18" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                <circle cx="12" cy="12" r="5"></circle>
                <line x1="12" y1="1" x2="12" y2="3"></line>
                <line x1="12" y1="21" x2="12" y2="23"></line>
                <line x1="4.22" y1="4.22" x2="5.64" y2="5.64"></line>
                <line x1="18.36" y1="18.36" x2="19.78" y2="19.78"></line>
                <line x1="1" y1="12" x2="3" y2="12"></line>
                <line x1="21" y1="12" x2="23" y2="12"></line>
                <line x1="4.22" y1="19.78" x2="5.64" y2="18.36"></line>
                <line x1="18.36" y1="5.64" x2="19.78" y2="4.22"></line>
            </svg>
        ` : `
            <svg width="18" height="18" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                <path d="M21 12.79A9 9 0 1 1 11.21 3 7 7 0 0 0 21 12.79z"></path>
            </svg>
        `;
    }
}

function initScrollAnimations() {
    // Ensure all cards, timeline items, journey steps, services, and project cards are 100% visible
    const allContentElements = document.querySelectorAll('.card, .timeline-item, .journey-step-card, .whyme-card, .service-card, .project-card, .direct-link-card');
    allContentElements.forEach(el => {
        el.style.opacity = '1';
        el.style.transform = 'none';
    });
}

function initBackToTop() {
    const backToTopBtn = document.getElementById('backToTopBtn');
    if (backToTopBtn) {
        backToTopBtn.addEventListener('click', (e) => {
            e.preventDefault();
            window.scrollTo({
                top: 0,
                behavior: 'smooth'
            });
        });
    }
}

function initResumeModal() {
    const resumeBtn = document.getElementById('openResumeBtn');
    const resumeModal = document.getElementById('resumeModal');
    const closeResumeBtn = document.getElementById('closeResumeBtn');

    if (!resumeModal) return;

    if (resumeBtn) {
        resumeBtn.addEventListener('click', (e) => {
            e.preventDefault();
            resumeModal.classList.add('show');
            document.body.style.overflow = 'hidden';
        });
    }

    if (closeResumeBtn) {
        closeResumeBtn.addEventListener('click', () => {
            resumeModal.classList.remove('show');
            document.body.style.overflow = '';
        });
    }

    resumeModal.addEventListener('click', (e) => {
        if (e.target === resumeModal) {
            resumeModal.classList.remove('show');
            document.body.style.overflow = '';
        }
    });

    document.addEventListener('keydown', (e) => {
        if (e.key === 'Escape' && resumeModal.classList.contains('show')) {
            resumeModal.classList.remove('show');
            document.body.style.overflow = '';
        }
    });
}
