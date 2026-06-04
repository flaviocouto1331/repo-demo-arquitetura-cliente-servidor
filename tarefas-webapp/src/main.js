import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.bundle.min.js';
import './style.css';

import { NavbarComponent } from './components/navbar-component.js';
import { PegarRota, PegarEventosRotas } from './router.js';

document.addEventListener('DOMContentLoaded', async () => {

    const navbar = document.querySelector('#navbarSupportedContent');
    const app = document.querySelector('#app');

    navbar.innerHTML = NavbarComponent();

    PegarEventosRotas(app);

    await PegarRota(app);

});