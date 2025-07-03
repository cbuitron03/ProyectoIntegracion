<script>
  import { onMount } from 'svelte';
  import { goto } from '$app/navigation';
  import 'bootstrap-icons/font/bootstrap-icons.css';

  let usuarios = [];
  let filtro = '';
  let cargando = false;
  let error = false;

  onMount(() => {
    cargarUsuarios();
  });

  function cargarUsuarios() {
    cargando = true;
    error = false;

    fetch('https://backendternurainfinita.runasp.net/api/Usuarios')
      .then((res) => res.json())
      .then((data) => {
        usuarios = data || [];
        cargando = false;
      })
      .catch(() => {
        error = true;
        cargando = false;
      });
  }

  function crearUsuario() {
    goto('/crear-usuario');
  }

  function editarUsuario(usuario) {
    goto(`/editar-usuario/${usuario}`);
  }

  function eliminarUsuario(usuario) {
    if (confirm(`¿Estás seguro de desactivar al usuario ${usuario}?`)) {
      fetch(`https://backendternurainfinita.runasp.net/api/Usuarios?usuario=${encodeURIComponent(usuario)}`, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ activo: false })
      })
        .then(() => {
          alert('Usuario desactivado correctamente.');
          cargarUsuarios();
        })
        .catch(() => {
          alert('Error al desactivar el usuario.');
        });
    }
  }

  function togglePassword(id) {
    const input = document.getElementById(`pass-${id}`);
    if (input?.type === 'password') input.type = 'text';
    else input.type = 'password';
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
          <a class="nav-link" href="/home">Cerrar sesión</a>
        </li>
      </ul>
    </div>
  </div>
</nav>

<div class="container mt-4">
  <h2 class="mb-4">Usuarios</h2>

  <div class="d-flex justify-content-between mb-3">
    <button class="btn btn-primary" on:click={crearUsuario}>
      <i class="bi bi-plus-circle"></i> Crear Nuevo
    </button>

    <input type="text" bind:value={filtro} class="form-control w-25" placeholder="Buscar usuario..." />
  </div>

  {#if cargando}
    <div class="text-center my-4">
      <div class="spinner-border text-primary" role="status"></div>
    </div>
  {:else if error}
    <div class="alert alert-danger" role="alert">
      Error al obtener los usuarios. Intente más tarde.
    </div>
  {:else}
    <table class="table table-striped table-hover align-middle">
      <thead class="table-dark">
        <tr>
          <th>Código</th>
          <th>Usuario</th>
          <th>Contraseña</th>
          <th>Rol</th>
          <th>Estado</th>
          <th>Acciones</th>
        </tr>
      </thead>
      <tbody>
        {#each usuarios.filter(u =>
          (u.US_USUARIO + u.US_ROL + u.US_ESTADO)
            .toLowerCase()
            .includes(filtro.toLowerCase())
        ) as usuario}
          <tr>
            <td>{usuario.US_COD}</td>
            <td>{usuario.US_USUARIO}</td>
            <td>
              <input
                type="password"
                class="form-control form-control-sm d-inline-block"
                value={usuario.US_PASS}
                readonly
                style="width:130px;"
                id={"pass-" + usuario.US_COD}
              />
              <button class="btn btn-outline-secondary btn-sm ms-1" on:click={() => togglePassword(usuario.US_COD)}>
                <i class="bi bi-eye"></i>
              </button>
            </td>
            <td>{usuario.US_ROL}</td>
            <td>{usuario.US_ESTADO ?? 'N/A'}</td>
            <td>
              <button class="btn btn-warning btn-sm me-1" title="Editar" on:click={() => editarUsuario(usuario.US_USUARIO)}>
                <i class="bi bi-pencil"></i>
              </button>
              <button class="btn btn-danger btn-sm" title="Eliminar" on:click={() => eliminarUsuario(usuario.US_USUARIO)}>
                <i class="bi bi-trash"></i>
              </button>
            </td>
          </tr>
        {/each}
      </tbody>
    </table>
  {/if}
</div>

<footer class="bg-dark text-white text-center py-3 mt-5">
  <p class="mb-0">&copy; 2025 AdminDB. Todos los derechos reservados.</p>
</footer>

<style>
  .navbar {
    margin-bottom: 1rem;
  }
</style>
