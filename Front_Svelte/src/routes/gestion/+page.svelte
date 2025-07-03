<script>
  import { goto } from '$app/navigation';
  function cerrarSesion() {
    sessionStorage.clear();
    goto('/');
  }
</script>

<nav class="navbar navbar-expand-lg navbar-dark bg-dark">
  <div class="container-fluid">
    <a class="navbar-brand" href="/gestion">Panel de Gestión</a>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse justify-content-end" id="navbarNav">
      <ul class="navbar-nav">
        <li class="nav-item">
          <a class="nav-link" href="#" on:click={cerrarSesion}>Cerrar sesión</a>
        </li>
      </ul>
    </div>
  </div>
</nav>

<h1 class="mb-4 text-center">Panel de Administración</h1>

<div class="row g-4">
  <div class="col-md-4">
    <div class="card h-100 shadow-sm p-4 text-center">
      <h4>Usuarios</h4>
      <p>Gestiona los usuarios registrados.</p>
      <a href="/gestion-usuarios" class="btn btn-outline-primary">Ver Usuarios</a>
    </div>
  </div>
  <div class="col-md-4">
    <div class="card h-100 shadow-sm p-4 text-center">
      <h4>Clientes</h4>
      <p>Gestiona los clientes registrados.</p>
      <a href="/gestion-clientes" class="btn btn-outline-primary">Ver Clientes</a>
    </div>
  </div>
  <div class="col-md-4">
    <div class="card h-100 shadow-sm p-4 text-center">
      <h4>Productos</h4>
      <p>Agrega, edita o elimina productos.</p>
      <a href="/gestion-producto" class="btn btn-outline-primary">Gestionar Productos</a>
    </div>
  </div>
  <div class="col-md-4">
    <div class="card h-100 shadow-sm p-4 text-center">
      <h4>Facturas</h4>
      <p>Consulta y administra pedidos.</p>
      <a href="/gestion-facturas" class="btn btn-outline-primary">Ver Órdenes</a>
    </div>
  </div>
  <div class="col-md-4">
    <div class="card h-100 shadow-sm p-4 text-center">
      <h4>Estadísticas</h4>
      <p>Consulta métricas importantes.</p>
      <a href="/estadisticas" class="btn btn-outline-primary">Ver Estadísticas</a>
    </div>
  </div>
</div>

<div class="row text-center mt-5">
  <div class="col-12">
    <p class="text-muted">Bienvenido al panel de administración. Aquí puedes controlar los datos de tu sistema.</p>
  </div>
</div>

<footer class="bg-dark text-white text-center py-3 mt-5">
  <p class="mb-0">&copy; 2025 AdminDB. Todos los derechos reservados.</p>
</footer>

<style>
    /* Fondo body */
body {
    background: linear-gradient(to right, #a0d8ef, #3ac1d4);
    color: #1a1a1a;
}

/* Navbar */
.navbar {
    background-color: #17a2b8 !important; /* turquesa un poco más oscuro */
}

.navbar-brand, .nav-link {
    color: #ffffff !important;
}

    .nav-link:hover {
        color: #c7f0f7 !important;
    }


</style>