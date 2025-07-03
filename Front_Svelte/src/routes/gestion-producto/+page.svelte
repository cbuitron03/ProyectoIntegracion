<script>
  import { onMount } from 'svelte';
  import { goto } from '$app/navigation';
  import 'bootstrap-icons/font/bootstrap-icons.css';

  let productos = [];
  let filtro = '';
  let cargando = false;
  let error = false;

  onMount(() => {
    cargarProductos();
  });

  function cargarProductos() {
    cargando = true;
    error = false;
    fetch('https://backendternurainfinita.runasp.net/api/integracion/productos')
      .then(res => res.json())
      .then(data => {
        productos = data;
        cargando = false;
      })
      .catch(() => {
        error = true;
        cargando = false;
      });
  }

  function crearProducto() {
    goto('/crear-producto');
  }

  function verDetalles(id) {
    goto(`/detalle-producto/${id}`);
  }

  function editarProducto(id) {
    goto(`/editar-producto/${id}`);
  }

  function desactivarProducto(id) {
    if (confirm(`¿Está seguro de desactivar el producto con código ${id}?`)) {
      fetch(`https://backendternurainfinita.runasp.net/api/Productos/${id}`, {
        method: 'DELETE'
      })
        .then(() => {
          alert('Producto desactivado correctamente.');
          cargarProductos();
        })
        .catch(() => alert('Error al desactivar el producto.'));
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
  <h2 class="mb-4">Productos</h2>

  <div class="d-flex justify-content-between mb-3">
    <button class="btn btn-primary" on:click={crearProducto}>
      <i class="bi bi-plus-circle"></i> Crear Nuevo
    </button>

    <input type="text" bind:value={filtro} class="form-control w-25" placeholder="Buscar producto...">
  </div>

  {#if cargando}
    <div class="text-center my-4">
      <div class="spinner-border text-primary" role="status"></div>
    </div>
  {:else if error}
    <div class="alert alert-danger" role="alert">
      Error al obtener los productos. Intente más tarde.
    </div>
  {:else}
    <table class="table table-striped table-hover align-middle">
      <thead class="table-dark">
        <tr>
          <th>Código</th>
          <th>Nombre</th>
          <th>Precio</th>
          <th>Stock</th>
          <th>Categoría</th>
          <th>Acciones</th>
        </tr>
      </thead>
      <tbody>
        {#each productos.filter(p => p.prodNombre.toLowerCase().includes(filtro.toLowerCase())) as producto}
          <tr>
            <td>{producto.idProducto}</td>
            <td>{producto.prodNombre}</td>
            <td>${parseFloat(producto.prodPrecio).toFixed(2)}</td>
            <td>{producto.prodStock}</td>
            <td>{producto.prodCategoria}</td>
            <td>
                <button
                class="btn btn-info btn-sm me-1"
                title="Detalles"
                aria-label="Ver detalles del producto"
                on:click={() => verDetalles(producto.idProducto)}
                >
                <i class="bi bi-eye"></i>
                </button>

                <button
                class="btn btn-warning btn-sm me-1"
                title="Editar"
                aria-label="Editar producto"
                on:click={() => editarProducto(producto.idProducto)}
                >
                <i class="bi bi-pencil"></i>
                </button>

                <button
                class="btn btn-danger btn-sm"
                title="Desactivar"
                aria-label="Desactivar producto"
                on:click={() => desactivarProducto(producto.idProducto)}
                >
                <i class="bi bi-x-circle"></i>
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

