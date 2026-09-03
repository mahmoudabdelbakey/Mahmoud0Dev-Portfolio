/**
 * Mahmoud.Dev - Skills Matrix Interaction
 */

document.addEventListener('DOMContentLoaded', () => {
    const tabs = document.querySelectorAll('.skill-tab-btn');
    const categories = document.querySelectorAll('.skill-category-block');

    if (!tabs.length) return;

    tabs.forEach(tab => {
        tab.addEventListener('click', () => {
            const selectedCategory = tab.getAttribute('data-category');

            tabs.forEach(t => t.classList.remove('active'));
            tab.classList.add('active');

            categories.forEach(block => {
                const cat = block.getAttribute('data-category');
                if (selectedCategory === 'all' || cat === selectedCategory) {
                    block.style.display = 'block';
                } else {
                    block.style.display = 'none';
                }
            });
        });
    });
});
