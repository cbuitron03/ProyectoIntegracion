<script>
  import { onMount } from 'svelte';
  import { goto } from '$app/navigation';

  let nombre = '';
  let descripcion = '';
  let precio = '';
  let stock = '';
  let estado = '';
  let imagenes = [''];
  let errores = {};
  let guardando = false;

  function agregarImagen() {
    imagenes = [...imagenes, ''];
  }

  function eliminarImagen(index) {
    imagenes = imagenes.filter((_, i) => i !== index);
  }

  function validarFormulario() {
    errores = {};
    if (nombre.trim().length < 3) errores.nombre = true;
    if (descripcion.trim().length < 5) errores.descripcion = true;
    if (isNaN(precio) || Number(precio) <= 0) errores.precio = true;
    if (isNaN(stock) || Number(stock) < 0) errores.stock = true;
    if (!estado) errores.estado = true;

    imagenes.forEach((url, i) => {
      if (url.trim() && !/^https?:\/\/.+/.test(url)) errores[`img_${i}`] = true;
    });

    return Object.keys(errores).length === 0;
  }

  async function guardarProducto() {
    if (!validarFormulario()) {
      alert('Por favor corrija los campos marcados.');
      return;
    }

    guardando = true;

    const urlProducto = `https://backendternurainfinita.runasp.net/api/Productos?PRD_NOMBRE=${encodeURIComponent(nombre)}&PRD_DESCRIPCION=${encodeURIComponent(descripcion)}&PRD_PRECIO=${encodeURIComponent(precio)}&PRD_STOCK=${encodeURIComponent(stock)}&PRD_ESTADO=${encodeURIComponent(estado)}`;

    try {
      const res = await fetch(urlProducto, { method: 'POST' });
      const prdCod = await res.text();

      if (!prdCod || isNaN(prdCod)) throw new Error('Código de producto inválido.');

      const promesas = imagenes
        .map((url) => url.trim())
        .filter((url) => url)
        .map((url) =>
          fetch(`https://backendternurainfinita.runasp.net/api/Imagen?PRD_COD=${prdCod}&IMG_URL=${encodeURIComponent(url)}&IMG_TIPO=Principal`, {
            method: 'POST'
          })
        );

      await Promise.all(promesas);

      alert(promesas.length ? 'Producto e imágenes creados correctamente.' : 'Producto creado sin imágenes.');
      goto('/gestion-producto');
    } catch (e) {
      alert('Error al crear el producto: ' + e.message);
    } finally {
      guardando = false;
    }
  }
</script>

<style>
  .invalid { border-color: red; }
</style>

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

<h2 class="mb-4 text-center">Crear Producto</h2>

<div class="container d-flex justify-content-center">
  <form class="w-100" style="max-width: 700px;" on:submit|preventDefault={guardarProducto}>
    <div class="mb-3">
      <label class="form-label">Nombre</label>
      <input class="form-control form-control-sm {errores.nombre ? 'invalid' : ''}" bind:value={nombre} required>
    </div>

    <div class="mb-3">
      <label class="form-label">Descripción</label>
      <textarea class="form-control form-control-sm {errores.descripcion ? 'invalid' : ''}" rows="3" bind:value={descripcion} required></textarea>
    </div>

    <div class="mb-3">
      <label class="form-label">Precio</label>
      <input type="number" step="0.01" min="0.01" class="form-control form-control-sm {errores.precio ? 'invalid' : ''}" bind:value={precio} required>
    </div>

    <div class="mb-3">
      <label class="form-label">Stock</label>
      <input type="number" min="0" class="form-control form-control-sm {errores.stock ? 'invalid' : ''}" bind:value={stock} required>
    </div>

    <div class="mb-3">
      <label class="form-label">Estado</label>
      <select class="form-select form-select-sm {errores.estado ? 'invalid' : ''}" bind:value={estado} required>
        <option value="">-- Seleccione estado --</option>
        <option value="Activo">Activo</option>
        <option value="Inactivo">Inactivo</option>
      </select>
    </div>

    <hr />
    <h5>Imágenes</h5>
    {#each imagenes as img, i}
      <div class="mb-2 d-flex align-items-center">
        <input
          type="url"
          class="form-control form-control-sm {errores[`img_${i}`] ? 'invalid' : ''}"
          placeholder="URL de imagen"
          bind:value={imagenes[i]}
        />
        <button type="button" class="btn btn-danger btn-sm ms-2" on:click={() => eliminarImagen(i)}>Eliminar</button>
      </div>
    {/each}
    <button type="button" class="btn btn-sm btn-outline-primary mb-3" on:click={agregarImagen}>Agregar Imagen</button>

    <div class="d-flex justify-content-between">
      <button type="submit" class="btn btn-success btn-sm" disabled={guardando}>{guardando ? 'Guardando...' : 'Guardar'}</button>
      <button type="button" class="btn btn-secondary btn-sm" on:click={() => goto('/gestion-producto')}>Cancelar</button>
    </div>
  </form>
</div>

<footer class="bg-dark text-white text-center py-3 mt-5">
  <p class="mb-0">&copy; 2025 AdminDB. Todos los derechos reservados.</p>
</footer>
