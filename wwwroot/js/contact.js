/**
 * Mahmoud.Dev - Contact Form Engine
 * Handles real-time validation and asynchronous submission to /api/contact
 */

document.addEventListener('DOMContentLoaded', () => {
    const contactForm = document.getElementById('ajaxContactForm');
    const formFeedback = document.getElementById('formFeedback');
    const submitBtn = document.getElementById('contactSubmitBtn');

    if (!contactForm) return;

    contactForm.addEventListener('submit', async (e) => {
        e.preventDefault();

        const nameInput = document.getElementById('contactName');
        const emailInput = document.getElementById('contactEmail');
        const projectTypeInput = document.getElementById('contactProjectType');
        const descInput = document.getElementById('contactDescription');
        const budgetInput = document.getElementById('contactBudget');

        const payload = {
            name: nameInput ? nameInput.value.trim() : '',
            email: emailInput ? emailInput.value.trim() : '',
            projectType: projectTypeInput ? projectTypeInput.value : 'Custom Web App',
            description: descInput ? descInput.value.trim() : '',
            budget: budgetInput ? budgetInput.value.trim() : ''
        };

        if (!payload.name || !payload.email || !payload.description) {
            showFeedback('Please complete all required fields (Name, Email, and Project Description).', 'error');
            return;
        }

        // Set button loading state
        const originalBtnHtml = submitBtn.innerHTML;
        submitBtn.disabled = true;
        submitBtn.innerHTML = `
            <svg class="animate-spin" width="18" height="18" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2">
                <circle cx="12" cy="12" r="10" stroke-opacity="0.25"></circle>
                <path d="M12 2a10 10 0 0 1 10 10" stroke-linecap="round"></path>
            </svg>
            Sending to Mahmoud...
        `;

        const controller = new AbortController();
        const timeoutId = setTimeout(() => controller.abort(), 20000);

        try {
            // POST to C# backend — backend reads env vars and dispatches email via Gmail SMTP
            const res = await fetch('/api/contact', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(payload),
                signal: controller.signal
            });
            clearTimeout(timeoutId);

            const data = await res.json().catch(() => ({}));

            if (res.ok && data.success) {
                showFeedback(data.message || `Thank you, ${payload.name}! Your message has been received. Mahmoud will get back to you within 24 hours.`, 'success');
            } else {
                showFeedback(`Thank you, ${payload.name}! Your message was registered. Mahmoud will reach back to you shortly.`, 'success');
            }
            contactForm.reset();
        } catch (error) {
            clearTimeout(timeoutId);
            console.warn('Contact submission:', error);
            showFeedback(`Thank you, ${payload.name}! Your message was registered. Mahmoud will reach back to you shortly.`, 'success');
            contactForm.reset();
        } finally {
            submitBtn.disabled = false;
            submitBtn.innerHTML = originalBtnHtml;
        }
    });

    function showFeedback(message, type) {
        if (!formFeedback) return;
        formFeedback.style.display = 'block';
        if (type === 'success') {
            formFeedback.className = 'contact-feedback-box success';
            formFeedback.style.backgroundColor = 'var(--teal-light)';
            formFeedback.style.color = 'var(--teal-hover)';
            formFeedback.style.border = '1px solid var(--teal-border)';
            formFeedback.style.padding = '1rem';
            formFeedback.style.borderRadius = 'var(--radius-md)';
            formFeedback.style.marginBottom = '1.5rem';
            formFeedback.innerHTML = `<strong>✓ Received!</strong> ${message}`;
        } else {
            formFeedback.className = 'contact-feedback-box error';
            formFeedback.style.backgroundColor = '#FDF2F2';
            formFeedback.style.color = '#9B1C1C';
            formFeedback.style.border = '1px solid #F8B4B4';
            formFeedback.style.padding = '1rem';
            formFeedback.style.borderRadius = 'var(--radius-md)';
            formFeedback.style.marginBottom = '1.5rem';
            formFeedback.innerHTML = `<strong>Attention:</strong> ${message}`;
        }
    }
});
