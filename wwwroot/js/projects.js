/**
 * Mahmoud.Dev - Projects & Case Studies Engine
 * Handles project filtering and interactive case study deep dives
 */

document.addEventListener('DOMContentLoaded', () => {
    initProjectFiltering();
    initCaseStudyModal();
});

function initProjectFiltering() {
    const filterButtons = document.querySelectorAll('.project-filter-btn');
    const projectCards = document.querySelectorAll('.project-card');

    if (!filterButtons.length) return;

    // Ensure all project cards are immediately and fully visible on initial load
    projectCards.forEach(card => {
        card.style.display = 'flex';
        card.style.opacity = '1';
        card.style.transform = 'translateY(0)';
        card.style.transition = 'opacity 0.3s ease, transform 0.3s ease';
    });

    filterButtons.forEach(btn => {
        btn.addEventListener('click', () => {
            const filter = btn.getAttribute('data-filter');

            filterButtons.forEach(b => b.classList.remove('active'));
            btn.classList.add('active');

            projectCards.forEach(card => {
                const category = card.getAttribute('data-category');
                if (filter === 'all' || category === filter) {
                    card.style.display = 'flex';
                    setTimeout(() => {
                        card.style.opacity = '1';
                        card.style.transform = 'translateY(0)';
                    }, 50);
                } else {
                    card.style.opacity = '0';
                    card.style.transform = 'translateY(15px)';
                    setTimeout(() => {
                        card.style.display = 'none';
                    }, 250);
                }
            });
        });
    });
}

function initCaseStudyModal() {
    const modal = document.getElementById('caseStudyModal');
    const closeBtn = document.getElementById('closeModalBtn');
    const viewButtons = document.querySelectorAll('.view-casestudy-btn');

    if (!modal) return;

    viewButtons.forEach(btn => {
        btn.addEventListener('click', async (e) => {
            e.preventDefault();
            const caseStudyId = btn.getAttribute('data-id');
            await loadCaseStudy(caseStudyId);
        });
    });

    if (closeBtn) {
        closeBtn.addEventListener('click', closeModal);
    }

    modal.addEventListener('click', (e) => {
        if (e.target === modal) {
            closeModal();
        }
    });

    document.addEventListener('keydown', (e) => {
        if (e.key === 'Escape' && modal.classList.contains('show')) {
            closeModal();
        }
    });

    function closeModal() {
        modal.classList.remove('show');
        document.body.style.overflow = '';
    }

    async function loadCaseStudy(id) {
        try {
            const response = await fetch(`/api/portfolio/casestudy/${id}`);
            if (!response.ok) throw new Error('Case study not found');
            const data = await response.json();
            renderCaseStudyContent(data);
            modal.classList.add('show');
            document.body.style.overflow = 'hidden';
        } catch (err) {
            console.error('Failed to load case study:', err);
        }
    }

    function renderCaseStudyContent(data) {
        const titleEl = document.getElementById('modalProjectTitle');
        const tagEl = document.getElementById('modalProjectTagline');
        const problemEl = document.getElementById('modalProblem');
        const originalIdeaEl = document.getElementById('modalOriginalIdea');
        const approachEl = document.getElementById('modalApproach');
        const solutionEl = document.getElementById('modalSolution');
        const metricsContainer = document.getElementById('modalMetricsContainer');
        const featuresContainer = document.getElementById('modalFeaturesContainer');
        const challengesContainer = document.getElementById('modalChallengesContainer');
        const resultsContainer = document.getElementById('modalResultsContainer');
        const techContainer = document.getElementById('modalTechContainer');

        if (titleEl) titleEl.textContent = data.projectTitle;
        if (tagEl) tagEl.textContent = data.tagline;
        if (problemEl) problemEl.textContent = data.theProblem;
        if (originalIdeaEl) originalIdeaEl.textContent = data.theOriginalIdea;
        if (approachEl) approachEl.textContent = data.myApproach;
        if (solutionEl) solutionEl.textContent = data.theSolution;

        // Metrics
        if (metricsContainer && data.metrics) {
            metricsContainer.innerHTML = Object.entries(data.metrics).map(([key, val]) => `
                <div class="metric-pill">
                    <div class="metric-pill-value">${val}</div>
                    <div class="metric-pill-label">${key}</div>
                </div>
            `).join('');
        }

        // Features
        if (featuresContainer && data.keyFeatures) {
            featuresContainer.innerHTML = data.keyFeatures.map(f => `
                <li style="margin-bottom: 0.5rem; display: flex; align-items: flex-start; gap: 0.5rem;">
                    <span style="color: var(--teal-primary); font-weight: bold;">✓</span>
                    <span>${f}</span>
                </li>
            `).join('');
        }

        // Challenges & Solutions
        if (challengesContainer && data.challengesAndSolutions) {
            challengesContainer.innerHTML = data.challengesAndSolutions.map(c => `
                <div style="background-color: var(--bg-secondary); padding: 1rem; border-radius: var(--radius-md); margin-bottom: 0.75rem; border-left: 3px solid var(--teal-primary);">
                    <div style="font-size: 0.9rem; line-height: 1.5;">${c}</div>
                </div>
            `).join('');
        }

        // Results & Impact
        if (resultsContainer && data.resultsAndImpact) {
            resultsContainer.innerHTML = data.resultsAndImpact.map(r => `
                <li style="margin-bottom: 0.5rem; display: flex; align-items: flex-start; gap: 0.5rem;">
                    <span style="color: var(--teal-primary); font-weight: bold;">→</span>
                    <span>${r}</span>
                </li>
            `).join('');
        }

        // Tech stack
        if (techContainer && data.technologies) {
            techContainer.innerHTML = data.technologies.map(t => `
                <span class="badge badge-teal">${t}</span>
            `).join('');
        }

        // Visual Mockup Showcase
        const mockupWrapper = document.getElementById('modalMockupWrapper');
        const mockupImg = document.getElementById('modalVisualMockup');
        if (mockupWrapper && mockupImg) {
            if (data.visualMockup) {
                mockupImg.src = data.visualMockup;
                mockupWrapper.style.display = 'block';
            } else {
                mockupWrapper.style.display = 'none';
            }
        }

        // Action Buttons
        const githubBtn = document.getElementById('modalGithubBtn');
        const dedicatedBtn = document.getElementById('modalDedicatedBtn');
        if (githubBtn) {
            githubBtn.href = data.githubUrl || '#';
        }
        if (dedicatedBtn) {
            dedicatedBtn.href = `/case-study/${data.id}`;
        }
    }
}
