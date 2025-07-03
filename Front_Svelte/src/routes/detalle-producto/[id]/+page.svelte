<script>
  import { onMount } from 'svelte';
  import { page } from '$app/stores';
  import { goto } from '$app/navigation';
  import { get } from 'svelte/store';
  import 'bootstrap-icons/font/bootstrap-icons.css';

  let producto = null;
  let id = get(page).params.id; // asume ruta: /detalle-producto/[id]

  onMount(() => {
    fetch(`https://backendternurainfinita.runasp.net/api/integracion/productos/${id}`)
      .then(res => res.json())
      .then(data => producto = data)
      .catch(() => alert("Error al cargar los detalles del producto."));
  });
</script>

<style>
  #detalleProducto {
    max-width: 900px;
    margin: 0 auto 40px;
    border-radius: 12px;
    box-shadow: 0 6px 18px rgba(0, 0, 0, 0.1);
    background: #fff;
    padding: 30px;
  }

  #infoProducto p {
    font-size: 1.05rem;
    margin-bottom: 0.6rem;
  }

  #infoProducto strong {
    color: #333;
  }

  #galeriaImagenes .card {
    border: none;
    border-radius: 12px;
    overflow: hidden;
    transition: transform 0.3s ease;
    cursor: pointer;
  }

  #galeriaImagenes .card:hover {
    transform: scale(1.05);
    box-shadow: 0 8px 20px rgba(0, 123, 255, 0.3);
    z-index: 5;
  }

  #galeriaImagenes img {
    border-radius: 12px;
    object-fit: cover;
    height: 180px;
    width: 100%;
  }

  .btn-volver {
    display: block;
    max-width: 150px;
    margin: 0 auto;
  }
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

<h2 class="mb-4 text-center text-primary fw-bold">
  <i class="bi bi-box-seam me-2"></i> Detalles del Producto
</h2>

{#if producto}
  <div id="detalleProducto" class="bg-white">
    <div class="row">
      <div class="col-lg-5 mb-4" id="infoProducto">
        <h3 class="text-primary fw-bold">{producto.prodNombre || 'Sin nombre'}</h3>
        <p><strong>Categoría:</strong> {producto.prodCategoria || 'N/A'}</p>
        <p><strong>Descripción:</strong> {producto.prodDescripcion || 'N/A'}</p>
        <p><strong>Precio:</strong> <span class="text-success fw-semibold fs-5">${parseFloat(producto.prodPrecio).toFixed(2)}</span></p>
        <p><strong>Stock:</strong> {producto.prodStock || 0} unidades</p>
        <p><strong>Proveedor:</strong> {producto.prodProveedor || 'N/A'}</p>
      </div>

      <div class="col-lg-7">
        <h5 class="mb-3 text-center text-secondary">Galería de Imágenes</h5>
        <div class="row" id="galeriaImagenes">
          {#if producto.prodImg && producto.prodImg.length > 0}
            {#each producto.prodImg as url}
              <div class="col-6 col-md-4 mb-3">
                <div class="card shadow-sm">
                  <img src={url} alt="Imagen del producto" loading="lazy" />
                </div>
              </div>
            {/each}
          {:else}
            <p class="text-muted text-center">No hay imágenes disponibles.</p>
          {/if}
        </div>
      </div>
    </div>

    <button class="btn btn-outline-primary btn-volver mt-4" on:click={() => goto('/gestion-producto')}>
      <i class="bi bi-arrow-left-circle me-2"></i> Volver
    </button>
  </div>
{/if}

<footer class="bg-dark text-white text-center py-3 mt-5">
  <p class="mb-0">&copy; 2025 AdminDB. Todos los derechos reservados.</p>
</footer>

