// vite.config.js
// vite.config.js
import { defineConfig } from 'vite';
import { sveltekit } from '@sveltejs/kit/vite';

export default defineConfig({
  plugins: [sveltekit()],
  server: {
    host: '0.0.0.0',
    strictPort: true,
    port: process.env.PORT || 5173,
    hmr: {
      protocol: 'wss',
      host: 'front-svelte.onrender.com',
      clientPort: 443
    },
    allowedHosts: ['front-svelte.onrender.com']
  }
});
