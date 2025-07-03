<script>
  import { onMount } from 'svelte';
  import { page } from '$app/stores';
  import "../app.css";

  let usuarioNombre = '';
  let mostrarCerrarSesion = false;
  let mostrarNavLogin = true;
  let cantidadCarrito = 0;

  function actualizarContadorCarrito() {
    const carrito = JSON.parse(sessionStorage.getItem("carrito")) || [];
    const cantidadTotal = carrito.reduce((acc, item) => acc + (parseInt(item.cantidad) || 0), 0);
    cantidadCarrito = cantidadTotal;
  }

  onMount(() => {
    const usuarioJSON = sessionStorage.getItem("usuarioActual");
    if (usuarioJSON) {
      const usuarioObj = JSON.parse(usuarioJSON);
      usuarioNombre = usuarioObj.US_NOMBRE || usuarioObj.US_USUARIO || usuarioObj.US_CEDULA || "Usuario";
      mostrarCerrarSesion = true;
      mostrarNavLogin = false;
    }

    actualizarContadorCarrito();
  });

  function cerrarSesion() {
    sessionStorage.clear();
    location.href = "/inicio-sesion";
  }
</script>

<nav class="navbar">
  <div class="container">
    <h1 class="logo">Ternura Infinita</h1>
    <ul class="nav-links">
      <li><a href="/home" class="nav-link">Inicio</a></li>
      <li><a href="/sobre-nosotros" class="nav-link">Sobre Nosotros</a></li>
      <li><a href="/productos" class="nav-link">Productos</a></li>
      {#if mostrarNavLogin}
        <li><a href="/inicio-sesion" class="nav-link">Iniciar Sesión</a></li>
      {/if}
      {#if mostrarCerrarSesion}
        <li class="nav-usuario">👤 {usuarioNombre}</li>
        <li><button class="cerrar-btn" on:click={cerrarSesion}>Cerrar Sesión</button></li>
      {/if}
      <li class="carrito">
        <a href="/carrito" class="nav-link">🛒 {cantidadCarrito}</a>
      </li>
    </ul>
  </div>
</nav>

<main class="contenido-principal">
  <slot />
</main>

<footer class="footer">
  © 2025 - Ternura Infinita. Todos los derechos reservados.
</footer>

<style>
  :global(body) {
    margin: 0;
    font-family: 'Segoe UI', sans-serif;
    background-color: #fde0e6;
    color: #333;
  }

  .navbar {
    background-color: #e91e63;
    color: white;
    padding: 1rem 0;
  }

  .container {
    max-width: 1200px;
    margin: 0 auto;
    padding: 0 1rem;
    display: flex;
    flex-wrap: wrap;
    align-items: center;
    justify-content: space-between;
  }

  .logo {
    font-size: 1.5rem;
    margin: 0;
  }

  .nav-links {
    list-style: none;
    display: flex;
    flex-wrap: wrap;
    gap: 1rem;
    padding: 0;
    margin: 0;
    align-items: center;
  }

  .nav-link {
    color: white;
    text-decoration: none;
    font-weight: bold;
  }

  .nav-link:hover {
    text-decoration: underline;
  }

  .cerrar-btn {
    background-color: transparent;
    border: 1px solid white;
    color: white;
    padding: 4px 10px;
    border-radius: 8px;
    cursor: pointer;
  }

  .cerrar-btn:hover {
    background-color: white;
    color: #e91e63;
  }

  .contenido-principal {
    max-width: 1200px;
    margin: 2rem auto;
    padding: 1rem;
    background-color: #fff;
    border-radius: 12px;
    box-shadow: 0 2px 10px rgba(0,0,0,0.05);
  }

  .footer {
    text-align: center;
    font-size: 0.9rem;
    padding: 2rem 0;
    color: #555;
  }

  .carrito {
    font-size: 1.2rem;
    color: white;
  }

  .nav-usuario {
    color: white;
    font-weight: bold;
  }
</style>
