<script>
  import { onMount } from 'svelte';
  import { goto } from '$app/navigation';

  let carrito = [];
  let subtotal = 0;
  let iva = 0;
  let total = 0;

  let mostrarResumen = false;
  let mostrarModal = false;

  onMount(() => {
    renderCarrito();
    const params = new URLSearchParams(window.location.search);
    if (params.get("requiereCompra") === "true") {
      const pendiente = JSON.parse(sessionStorage.getItem("carritoPendiente"));
      if (pendiente) {
        sessionStorage.setItem("carrito", JSON.stringify(pendiente));
        sessionStorage.removeItem("carritoPendiente");
        renderCarrito();
      }
    }
  });

  function renderCarrito() {
    carrito = JSON.parse(sessionStorage.getItem("carrito")) || [];
    subtotal = carrito.reduce((acc, item) => acc + (item.precio * item.cantidad), 0);
    iva = subtotal * 0.15;
    total = subtotal + iva;
    mostrarResumen = carrito.length > 0;
  }

  function quitarProducto(index) {
    carrito.splice(index, 1);
    sessionStorage.setItem("carrito", JSON.stringify(carrito));
    renderCarrito();
  }

  function verificarCompra() {
    const usuario = JSON.parse(sessionStorage.getItem("usuarioActual"));
    if (usuario && usuario.US_USUARIO) {
      finalizarCompra(usuario.US_USUARIO);
    } else {
      sessionStorage.setItem("carritoPendiente", JSON.stringify(carrito));
      goto('/inicio-sesion?requiereCompra=true');
    }
  }

  async function finalizarCompra(cedulaCliente) {
    const productos = carrito.map(item => ({
      idProducto: item.id,
      cantidad: item.cantidad
    }));

    const datosCompra = {
      carrito: { productos },
      direccion: "Calle Falsa 123, Ciudad",
      metodoPago: "Tarjeta de Crédito",
      cliente: {
        cliCedula: cedulaCliente
      }
    };

    try {
      const respuesta = await fetch("https://backendternurainfinita.runasp.net/api/integracion/compra", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(datosCompra)
      });

      if (!respuesta.ok) throw new Error("Error al crear la compra");

      const facturaId = await respuesta.json();
      sessionStorage.setItem("facturaGenerada", facturaId);
      sessionStorage.setItem("clienteCedula", cedulaCliente);
      mostrarModal = true;
    } catch (error) {
      alert("Error al realizar la compra: " + error.message);
    }
  }

  async function confirmarBanco() {
    const facCod = sessionStorage.getItem("facturaGenerada");
    const cedula = sessionStorage.getItem("clienteCedula");

    try {
      const response = await fetch(`https://backendternurainfinita.runasp.net/api/banco/transaccion?cliCedula=${cedula}&facCod=${facCod}`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({})
      });

      const resultado = await response.json();

      if (resultado === true) {
        alert("✅ Transacción completada con éxito.");
        sessionStorage.removeItem("carrito");
        renderCarrito();
      } else {
        alert("❌ Transacción fallida. Contacte con su banco.");
      }
    } catch (err) {
      alert("Error al realizar la transacción: " + err.message);
    }

    mostrarModal = false;
  }
</script>

<h2 class="text-center mb-4">🛍️ Tu Carrito</h2>

{#if carrito.length === 0}
  <div class="text-center text-muted py-5">
    🛒 Tu carrito está vacío 😿<br />
    <a href="/productos" class="btn btn-outline-primary mt-3">Ver Productos</a>
  </div>
{:else}
  <div class="table-responsive">
    <table class="table table-bordered text-center align-middle">
      <thead class="table-danger">
        <tr>
          <th>Producto</th>
          <th>Imagen</th>
          <th>Precio Unitario</th>
          <th>Cantidad</th>
          <th>Subtotal</th>
          <th>Quitar</th>
        </tr>
      </thead>
      <tbody>
        {#each carrito as item, index}
          <tr>
            <td>{item.nombre}</td>
            <td><img src={item.imagen} width="60" class="img-thumbnail" /></td>
            <td>${item.precio.toFixed(2)}</td>
            <td>{item.cantidad}</td>
            <td>${(item.precio * item.cantidad).toFixed(2)}</td>
            <td><button class="btn btn-sm btn-outline-danger" on:click={() => quitarProducto(index)}>Quitar</button></td>
          </tr>
        {/each}
      </tbody>
    </table>
  </div>
{/if}

{#if mostrarResumen}
  <div class="text-end mt-4 me-2">
    <h5>Subtotal: ${subtotal.toFixed(2)}</h5>
    <h5>IVA (15%): ${iva.toFixed(2)}</h5>
    <h4><strong>Total: ${total.toFixed(2)}</strong></h4>
    <small class="text-muted">(Impuestos incluidos)</small>

    <div class="mt-3">
      <button class="btn btn-success btn-lg" on:click={verificarCompra}>
        ✅ Finalizar compra
      </button>
    </div>
  </div>
{/if}

{#if mostrarModal}
  <div class="modal-backdrop">
    <div class="modal-content-box">
      <h5>¿Tienes cuenta bancaria?</h5>
      <p>Para continuar con la compra, necesitamos saber si tienes cuenta en el banco.</p>
      <div class="modal-actions">
        <button class="btn btn-primary" on:click={confirmarBanco}>Sí</button>
        <button class="btn btn-secondary" on:click={() => mostrarModal = false}>No</button>
      </div>
    </div>
  </div>
{/if}
