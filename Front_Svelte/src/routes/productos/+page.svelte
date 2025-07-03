<script>
  import { onMount } from 'svelte';
  import { writable } from 'svelte/store';

  const productos = writable([]);
  const apiUrl = 'https://backendternurainfinita.runasp.net/api/integracion/productos';

  function escapeHtml(text) {
    return text.replace(/&/g, '&amp;')
               .replace(/</g, '&lt;')
               .replace(/>/g, '&gt;')
               .replace(/"/g, '&quot;')
               .replace(/'/g, '&#39;');
  }

  function escapeJs(text) {
    return text.replace(/\\/g, '\\\\')
               .replace(/'/g, "\\'")
               .replace(/\"/g, '\\"');
  }

  function addToCart(id, nombre, precio, stock) {
    const qtyInput = document.getElementById(`qty-${id}`);
    const cantidad = parseInt(qtyInput?.value || '1');

    if (cantidad > stock) {
      alert(`Solo hay ${stock} unidades disponibles.`);
      return;
    }

    const imagen = document.querySelector(`#carousel-${id} .carousel-img.active`)?.src ||
                   document.querySelector(`#carousel-${id} .carousel-img`)?.src ||
                   '/images/default-placeholder.png';

    let carrito = JSON.parse(sessionStorage.getItem("carrito")) || [];
    const index = carrito.findIndex(p => p.id === id);

    if (index !== -1) {
      const nuevaCantidad = carrito[index].cantidad + cantidad;
      if (nuevaCantidad > stock) {
        alert(`Ya tienes ${carrito[index].cantidad} en el carrito. Solo puedes agregar ${stock - carrito[index].cantidad} más.`);
        return;
      }
      carrito[index].cantidad = nuevaCantidad;
    } else {
      carrito.push({ id, nombre, precio: parseFloat(precio), cantidad, imagen });
    }

    sessionStorage.setItem("carrito", JSON.stringify(carrito));
    qtyInput.value = 1;
  }

  function cambiarImagen(id, direccion) {
    const imagenes = document.querySelectorAll(`#carousel-${id} .carousel-img`);
    let actual = Array.from(imagenes).findIndex(img => img.classList.contains('active'));

    if (actual === -1) return;
    imagenes[actual].classList.remove('active');
    imagenes[actual].style.display = 'none';

    const siguiente = (actual + direccion + imagenes.length) % imagenes.length;
    imagenes[siguiente].classList.add('active');
    imagenes[siguiente].style.display = 'block';
  }

  onMount(async () => {
    try {
      const res = await fetch(apiUrl);
      const data = await res.json();
      productos.set(data);
    } catch (err) {
      alert("Error al obtener los productos.");
    }
  });
</script>


<h2 class="titulo-productos">Nuestros Productos</h2>
<div class="productos-container">
  {#each $productos as producto (producto.idProducto)}
    <div class="producto-card">
      <div class="producto-nombre">{producto.prodNombre}</div>

      <!-- Carrusel de imágenes simple -->
      <div id="carousel-{producto.idProducto}" class="carousel slide">
        {#if producto.prodImg?.length > 0}
          {#each producto.prodImg as img, i (img)}
            <img
              src={img}
              class="carousel-img {i === 0 ? 'active' : ''}"
              alt="Imagen de {producto.prodDescripcion}"
            />
          {/each}
          <div class="carousel-controls">
            <button on:click={() => cambiarImagen(producto.idProducto, -1)}>&lt;</button>
            <button on:click={() => cambiarImagen(producto.idProducto, 1)}>&gt;</button>
          </div>
        {:else}
          <img src="/images/default-placeholder.png" class="carousel-img active" />
        {/if}
      </div>

      <div class="producto-descripcion">{producto.prodDescripcion}</div>
      <p class="precio">${producto.prodPrecio.toFixed(2)}</p>
      <p style="color: {producto.prodStock > 0 ? '#28a745' : '#dc3545'}; font-weight: bold;">
        {producto.prodStock > 0 ? `Stock disponible: ${producto.prodStock}` : 'Agotado'}
      </p>

      <div class="cart-controls">
        <div class="qty-group">
          <label for={"qty-" + producto.idProducto}>Cantidad:</label>
          <input
            type="number"
            id={"qty-" + producto.idProducto}
            min="1"
            max={producto.prodStock}
            value="1"
            class="qty-input"
            disabled={producto.prodStock <= 0}
          />
        </div>
        <button
          class="btn btn-outline-pink"
          on:click={() => addToCart(producto.idProducto, escapeJs(producto.prodNombre), producto.prodPrecio, producto.prodStock)}
          disabled={producto.prodStock <= 0}
        >
          🧸 Agregar al carrito
        </button>
      </div>
    </div>
  {/each}
</div>