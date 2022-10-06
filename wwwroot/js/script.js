const dropdowns = document.querySelectorAll('.dropdown'); 

dropdowns.forEach(dropdown => {
    const select = dropdown.querySelector('.select'); 
    const caret = dropdown.querySelector('.caret'); 
    const ddMenu = dropdown.querySelector('.dd-menu'); 
    const options = dropdown.querySelectorAll('.dd-menu li'); 
    const selected = dropdown.querySelector('.selected'); 

    select.addEventListener('click', () => {
        select.classList.toggle('select-clicked');
        caret.classList.toggle('caret-rotate');
        ddMenu.classList.toggle('dd-menu-open');
    });

    options.forEach(option => {
        option.addEventListener('click', () => {
            selected.innerText = option.innerText;
            select.classList.remove('select-clicked');
            caret.classList.remove('caret-rotate');
            ddMenu.classList.remove('dd-menu-open');
            options.forEach(option => {
                option.classList.remove('active');
            });
            option.classList.add('active');
        });
    });
});