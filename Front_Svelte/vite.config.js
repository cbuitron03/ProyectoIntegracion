// vite.config.js
import { defineConfig } from 'vite';
import { sveltekit } from '@sveltejs/kit/vite';

export default defineConfig({
  plugins: [sveltekit()],
  server: {
    host: true, // permite conexiones externas
    allowedHosts: ['https://front-svelte.onrender.com'] // ← añade tu dominio aquí
  }
});
