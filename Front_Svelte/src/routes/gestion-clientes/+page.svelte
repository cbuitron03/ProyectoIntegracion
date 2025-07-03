<script>
  import { onMount } from 'svelte';
  import { goto } from '$app/navigation';
  import 'bootstrap-icons/font/bootstrap-icons.css';

  let clientes = [];
  let filtro = '';
  let cargando = false;
  let error = false;

  onMount(() => {
    cargarClientes();
  });

  function cargarClientes() {
    cargando = true;
    error = false;

    fetch('https://backendternurainfinita.runasp.net/api/Clientes')
      .then((res) => res.json())
      .then((data) => {
        clientes = data || [];
        cargando = false;
      })
      .catch(() => {
        error = true;
        cargando = false;
      });
  }

  function crearCliente() {
    goto('/crear-cliente');
  }

  function verDetalles(cedula) {
    goto(`/detalle-cliente/${cedula}`);
  }

  function editarCliente(cedula) {
    goto(`/editar-cliente/${cedula}`);
  }

  function eliminarCliente(cedula) {
    if (confirm(`¿Estás seguro de desactivar al cliente con cédula ${cedula}?`)) {
      fetch(`https://backendternurainfinita.runasp.net/api/Clientes?cedula=${encodeURIComponent(cedula)}`, {
        method: 'DELETE'
      })
        .then(() => {
          alert('Cliente desactivado correctamente.');
          cargarClientes();
        })
        .catch((err) => {
          alert('Error al desactivar el cliente.');
        });
    }
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
  <h2 class="mb-4">Clientes</h2>

  <div class="d-flex justify-content-between mb-3">
    <button class="btn btn-primary" on:click={crearCliente}>
      <i class="bi bi-plus-circle"></i> Crear Nuevo
    </button>

    <input type="text" bind:value={filtro} class="form-control w-25" placeholder="Buscar cliente..." />
  </div>

  {#if cargando}
    <div class="text-center my-4">
      <div class="spinner-border text-primary" role="status"></div>
    </div>
  {:else if error}
    <div class="alert alert-danger" role="alert">
      Error al obtener los clientes. Intente más tarde.
    </div>
  {:else}
    <table class="table table-striped table-hover align-middle">
      <thead class="table-dark">
        <tr>
          <th>Cédula</th>
          <th>Nombre</th>
          <th>Teléfono</th>
          <th>Correo</th>
          <th>Dirección</th>
          <th>Estado</th>
          <th>Acciones</th>
        </tr>
      </thead>
      <tbody>
        {#each clientes.filter(c =>
          (c.CLI_CEDULA + c.CLI_NOMBRE + c.CLI_TELEFONO + c.CLI_CORREO + c.CLI_DIRECCION)
            .toLowerCase()
            .includes(filtro.toLowerCase())
        ) as cliente}
          <tr>
            <td>{cliente.CLI_CEDULA}</td>
            <td>{cliente.CLI_NOMBRE}</td>
            <td>{cliente.CLI_TELEFONO}</td>
            <td>{cliente.CLI_CORREO}</td>
            <td>{cliente.CLI_DIRECCION}</td>
            <td>{cliente.CLI_ESTADO ?? 'N/A'}</td>
            <td>
              <button
                class="btn btn-info btn-sm me-1"
                title="Detalles"
                on:click={() => verDetalles(cliente.CLI_CEDULA)}
              >
                <i class="bi bi-eye"></i>
              </button>
              <button
                class="btn btn-warning btn-sm me-1"
                title="Editar"
                on:click={() => editarCliente(cliente.CLI_CEDULA)}
              >
                <i class="bi bi-pencil"></i>
              </button>
              <button
                class="btn btn-danger btn-sm"
                title="Eliminar"
                on:click={() => eliminarCliente(cliente.CLI_CEDULA)}
              >
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
