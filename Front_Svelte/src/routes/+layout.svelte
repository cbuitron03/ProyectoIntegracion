<script>
  import { onMount } from 'svelte';
  import { page } from '$app/stores'; // para reactivo al path, si quieres

  // Variables para usuario y carrito
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
    // Leer datos del usuario desde sessionStorage
    const usuarioJSON = sessionStorage.getItem("usuarioActual");
    if (usuarioJSON) {
      const usuarioObj = JSON.parse(usuarioJSON);
      usuarioNombre = usuarioObj.US_NOMBRE || usuarioObj.US_USUARIO || usuarioObj.US_CEDULA || "Usuario";
      mostrarCerrarSesion = true;
      mostrarNavLogin = false;
    } else {
      usuarioNombre = '';
      mostrarCerrarSesion = false;
      mostrarNavLogin = true;
    }

    actualizarContadorCarrito();
  });

  function cerrarSesion() {
    sessionStorage.clear();
    location.href = "/Login/InicioSesion"; // O la ruta que uses en SvelteKit
  }
</script>

<style>
  /* Aquí agrega o importa tus estilos */
  nav.navbar {
    background-color: #e91e63;
    color: white;
    padding: 1rem;
  }
  nav.navbar a.nav-link {
    color: white;
    text-decoration: none;
    margin-right: 1rem;
  }
  nav.navbar a.nav-link:hover {
    text-decoration: underline;
  }
  .cart-badge {
    background: #c2185b;
    color: white;
    border-radius: 50%;
    padding: 0.2rem 0.6rem;
    font-size: 0.8rem;
    vertical-align: top;
    margin-left: 0.2rem;
  }
  footer {
    margin-top: 2rem;
    text-align: center;
    color: #666;
  }
</style>

<nav class="navbar">
  <div class="container" style="display: flex; align-items: center; justify-content: space-between;">
    <a href="/" class="navbar-brand" style="font-weight: bold; font-size: 1.5rem; color: white;">Ternura Infinita</a>
    
    <div class="navbar-collapse" style="display: flex; align-items: center;">
      <ul class="navbar-nav" style="display: flex; list-style: none; padding: 0; margin: 0;">
        <li class="nav-item"><a href="/" class="nav-link">Inicio</a></li>
        <li class="nav-item"><a href="/about" class="nav-link">Sobre Nosotros</a></li>
        <li class="nav-item"><a href="/productos" class="nav-link">Productos</a></li>
        {#if mostrarNavLogin}
          <li class="nav-item" id="navLogin"><a href="/login/iniciosesion" class="nav-link">Iniciar Sesión</a></li>
        {/if}
      </ul>

      <ul class="navbar-nav" style="display: flex; list-style: none; padding: 0; margin: 0; margin-left: 2rem; align-items: center;">
        {#if usuarioNombre}
          <li class="nav-item nav-user" style="color: white; margin-right: 1rem;">👤 {usuarioNombre}</li>
        {/if}
        {#if mostrarCerrarSesion}
          <li class="nav-item">
            <a href="#" on:click|preventDefault={cerrarSesion} class="nav-link logout" style="color: white;">Cerrar sesión</a>
          </li>
        {/if}
        <li class="nav-item">
          <a href="/carrito1" class="nav-link cart-icon" title="Ver carrito" style="color: white; position: relative;">
            🛒
            {#if cantidadCarrito > 0}
              <span class="cart-badge">{cantidadCarrito}</span>
            {/if}
          </a>
        </li>
      </ul>
    </div>
  </div>
</nav>

<div class="container body-content" style="margin-top: 1rem;">
  <slot />
  <hr />
  <footer>
    <p>© {new Date().getFullYear()} - Ternura Infinita. Todos los derechos reservados.</p>
  </footer>
</div>
