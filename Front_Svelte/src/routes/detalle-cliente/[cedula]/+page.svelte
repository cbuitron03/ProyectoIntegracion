<script>
  import { onMount } from 'svelte';
  import { page } from '$app/stores';
  import { get } from 'svelte/store';

  let cedula = '';
  let cliente = null;
  let usuario = null;
  let facturas = [];
  let errores = {
    cliente: null,
    usuario: null,
    facturas: null
  };

  onMount(async () => {
    cedula = get(page).url.searchParams.get('cedula');
    if (!cedula) return;

    try {
      const resCliente = await fetch(`https://backendternurainfinita.runasp.net/api/Clientes?cedula=${encodeURIComponent(cedula)}`);
      cliente = await resCliente.json();
    } catch (e) {
      errores.cliente = 'Error al cargar el cliente';
    }

    try {
      const resUsuario = await fetch(`https://backendternurainfinita.runasp.net/api/Usuarios?usuario=${encodeURIComponent(cedula)}`);
      usuario = await resUsuario.json();
    } catch (e) {
      errores.usuario = 'Error al cargar el usuario';
    }

    try {
      const resFacturas = await fetch(`https://backendternurainfinita.runasp.net/api/Facturas?cedula=${encodeURIComponent(cedula)}`);
      facturas = await resFacturas.json();
    } catch (e) {
      errores.facturas = 'Error al cargar las facturas';
    }
  });

  async function cargarDetallesFactura(factura) {
    if (factura.detallesCargados) return;
    try {
      const res = await fetch(`https://backendternurainfinita.runasp.net/api/DetalleFactura/${factura.FAC_COD}`);
      factura.detalles = await res.json();

      for (const detalle of factura.detalles) {
        try {
          const resProd = await fetch(`https://backendternurainfinita.runasp.net/api/Productos/${detalle.PRD_COD}`);
          const producto = await resProd.json();
          detalle.PRD_NOMBRE = producto.PRD_NOMBRE;
        } catch (e) {
          detalle.PRD_NOMBRE = `Producto ${detalle.PRD_COD}`;
        }
      }
      factura.detallesCargados = true;
    } catch (e) {
      factura.detalles = [];
    }
  }
</script>

<nav class="navbar navbar-expand-lg navbar-dark bg-dark">
  <div class="container-fluid">
    <a class="navbar-brand" href="/gestion">Panel de Gestión</a>
    <div class="collapse navbar-collapse justify-content-end">
      <ul class="navbar-nav">
        <li class="nav-item">
          <a class="nav-link" href="/home">Cerrar sesión</a>
        </li>
      </ul>
    </div>
  </div>
</nav>

<div class="container mt-4">
  <h2 class="mb-4 text-center">Detalle del Cliente</h2>

  <div class="card mb-4">
    <div class="card-header bg-primary text-white">Información del Cliente</div>
    <div class="card-body">
      {#if errores.cliente}
        <div class="text-danger">{errores.cliente}</div>
      {:else if !cliente}
        <div>Cargando...</div>
      {:else}
        <p><strong>Cédula:</strong> {cliente.CLI_CEDULA}</p>
        <p><strong>Nombre:</strong> {cliente.CLI_NOMBRE}</p>
        <p><strong>Teléfono:</strong> {cliente.CLI_TELEFONO}</p>
        <p><strong>Correo:</strong> {cliente.CLI_CORREO}</p>
        <p><strong>Dirección:</strong> {cliente.CLI_DIRECCION}</p>
        <p><strong>Estado:</strong> {cliente.CLI_ESTADO}</p>
      {/if}
    </div>
  </div>

  <div class="card mb-4">
    <div class="card-header bg-secondary text-white">Usuario Asociado</div>
    <div class="card-body">
      {#if errores.usuario}
        <div class="text-danger">{errores.usuario}</div>
      {:else if !usuario}
        <div>Cargando...</div>
      {:else}
        <p><strong>Usuario:</strong> {usuario.US_USUARIO}</p>
        <p><strong>Rol:</strong> {usuario.US_ROL}</p>
        <p><strong>Estado:</strong> {usuario.US_ESTADO}</p>
      {/if}
    </div>
  </div>

  <div class="card">
    <div class="card-header bg-dark text-white">Facturas</div>
    <div class="card-body">
      {#if errores.facturas}
        <div class="text-danger">{errores.facturas}</div>
      {:else if !facturas || facturas.length === 0}
        <div>No hay facturas para este cliente.</div>
      {:else}
        <div class="accordion" id="accordionFacturas">
          {#each facturas as factura, i}
            <div class="accordion-item">
              <h2 class="accordion-header">
                <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target={`#collapse${factura.FAC_COD}`} on:click={() => cargarDetallesFactura(factura)}>
                  Factura #{factura.FAC_COD} - {new Date(factura.FAC_FECHA).toLocaleDateString('es-EC')}
                </button>
              </h2>
              <div id={`collapse${factura.FAC_COD}`} class="accordion-collapse collapse">
                <div class="accordion-body">
                  <p><strong>Total:</strong> ${factura.FAC_TOTAL.toFixed(2)}</p>

                  {#if factura.detalles && factura.detalles.length > 0}
                    <table class="table table-sm table-bordered">
                      <thead>
                        <tr>
                          <th>Producto</th>
                          <th>Cantidad</th>
                          <th>Precio</th>
                          <th>Estado</th>
                        </tr>
                      </thead>
                      <tbody>
                        {#each factura.detalles as d}
                          <tr>
                            <td>{d.PRD_NOMBRE}</td>
                            <td>{d.DTF_CANTIDAD}</td>
                            <td>${d.DTF_PRECIO.toFixed(2)}</td>
                            <td>{d.DTF_ESTADO}</td>
                          </tr>
                        {/each}
                      </tbody>
                    </table>
                  {:else}
                    <div>No hay productos en esta factura.</div>
                  {/if}
                </div>
              </div>
            </div>
          {/each}
        </div>
      {/if}
    </div>
  </div>
</div>

<footer class="bg-dark text-white text-center py-3 mt-5">
  <p class="mb-0">&copy; 2025 AdminDB. Todos los derechos reservados.</p>
</footer>
