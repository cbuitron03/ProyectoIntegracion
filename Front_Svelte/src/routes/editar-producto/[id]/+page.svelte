<script>
  import { onMount } from 'svelte';
  import { page } from '$app/stores';
  import { goto } from '$app/navigation';

  let id = '';
  let producto = {
    prodNombre: '',
    prodDescripcion: '',
    prodPrecio: 0,
    prodStock: 0,
    prodEstado: 'Activo',
    prodImg: []
  };
  let imagenesEliminadas = [];
  let nuevaImagen = '';

  onMount(() => {
    id = $page.params.id;
    cargarProducto();
  });

  function cargarProducto() {
    fetch(`https://backendternurainfinita.runasp.net/api/integracion/productos/${id}`)
      .then(res => res.json())
      .then(data => {
        producto = data;
      })
      .catch(() => alert('Error al cargar el producto.'));
  }

  function agregarImagen() {
    producto.prodImg.push('');
  }

  function eliminarImagen(index) {
    const url = producto.prodImg[index];
    if (confirm("¿Estás seguro de eliminar esta imagen?")) {
      imagenesEliminadas.push(url);
      producto.prodImg.splice(index, 1);
    }
  }

  function guardarCambios() {
    const urlPUT = `https://backendternurainfinita.runasp.net/api/Productos` +
      `?PRD_COD=${id}` +
      `&PRD_NOMBRE=${encodeURIComponent(producto.prodNombre)}` +
      `&PRD_DESCRIPCION=${encodeURIComponent(producto.prodDescripcion)}` +
      `&PRD_PRECIO=${producto.prodPrecio}` +
      `&PRD_STOCK=${producto.prodStock}` +
      `&PRD_ESTADO=${encodeURIComponent(producto.prodEstado)}`;

    fetch(urlPUT, { method: 'PUT' })
      .then(() => actualizarImagenes())
      .catch(() => alert("Error al actualizar el producto."));
  }

  function actualizarImagenes() {
    const promesas = [];

    producto.prodImg.forEach(url => {
      const urlImg = `https://backendternurainfinita.runasp.net/api/Imagen` +
        `?PRD_COD=${id}` +
        `&IMG_URL=${encodeURIComponent(url)}` +
        `&IMG_TIPO=Principal`;

      promesas.push(fetch(urlImg, { method: 'POST' }));
    });

    imagenesEliminadas.forEach(url => {
      promesas.push(
        fetch(`https://backendternurainfinita.runasp.net/api/Imagen?IMG_URL=${encodeURIComponent(url)}`, { method: 'DELETE' })
      );
    });

    Promise.all(promesas)
      .then(() => {
        alert("Producto e imágenes actualizadas correctamente.");
        goto('/productos');
      })
      .catch(() => alert("Error al actualizar, crear o eliminar imágenes."));
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

<div class="container mt-4" style="max-width: 700px;">
  <h2 class="mb-4 text-center">Editar Producto</h2>
  <form on:submit|preventDefault={guardarCambios}>
    <div class="mb-3">
      <label for="prdNombre" class="form-label">Nombre</label>
      <input id="prdNombre" class="form-control" bind:value={producto.prodNombre} required />
    </div>

    <div class="mb-3">
      <label for="prdDescripcion" class="form-label">Descripción</label>
      <textarea id="prdDescripcion" class="form-control" rows="3" bind:value={producto.prodDescripcion} required></textarea>
    </div>

    <div class="mb-3">
      <label for="prdPrecio" class="form-label">Precio</label>
      <input type="number" id="prdPrecio" class="form-control" min="0" step="0.01" bind:value={producto.prodPrecio} required />
    </div>

    <div class="mb-3">
      <label for="prdStock" class="form-label">Stock</label>
      <input type="number" id="prdStock" class="form-control" min="0" bind:value={producto.prodStock} required />
    </div>

    <div class="mb-3">
      <label for="prdEstado" class="form-label">Estado</label>
      <select id="prdEstado" class="form-select" bind:value={producto.prodEstado} required>
        <option value="Activo">Activo</option>
        <option value="Inactivo">Inactivo</option>
      </select>
    </div>

    <hr />
    <h5>Imágenes</h5>
    {#each producto.prodImg as img, i}
      <div class="mb-2 d-flex align-items-center">
        <input type="url" class="form-control" placeholder="URL de imagen" bind:value={producto.prodImg[i]} required />
        <button type="button" class="btn btn-danger btn-sm ms-2" on:click={() => eliminarImagen(i)}>Eliminar</button>
      </div>
    {/each}
    <button type="button" class="btn btn-sm btn-outline-primary mb-3" on:click={agregarImagen}>Agregar Imagen</button>

    <div class="d-flex justify-content-between">
      <button type="submit" class="btn btn-primary">Guardar Cambios</button>
      <a href="/productos" class="btn btn-secondary">Cancelar</a>
    </div>
  </form>
</div>

<footer class="bg-dark text-white text-center py-3 mt-5">
  <p class="mb-0">&copy; 2025 AdminDB. Todos los derechos reservados.</p>
</footer>
