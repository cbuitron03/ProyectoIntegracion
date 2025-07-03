<script>
  import { onMount } from 'svelte';
  import { page } from '$app/stores';
  import { goto } from '$app/navigation';
  import { get } from 'svelte/store';

  let cedula = '';
  let cliente = {
    CLI_CEDULA: '',
    US_COD: '',
    CLI_NOMBRE: '',
    CLI_TELEFONO: '',
    CLI_CORREO: '',
    CLI_DIRECCION: '',
    CLI_ESTADO: ''
  };
  let cargando = false;
  let error = '';

  onMount(async () => {
    cedula = get(page).url.searchParams.get('cedula') || '';
    if (!cedula) return;

    try {
      const res = await fetch(`https://backendternurainfinita.runasp.net/api/Clientes?cedula=${encodeURIComponent(cedula)}`);
      const data = await res.json();
      cliente = data;
    } catch (err) {
      error = 'Error al cargar el cliente';
    }
  });

  async function guardar() {
    error = '';

    if (!/^\d{10}$/.test(cliente.CLI_CEDULA)) {
      error = 'Cédula inválida';
      return;
    }

    if (!cliente.CLI_NOMBRE || !cliente.US_COD || !cliente.CLI_ESTADO) {
      error = 'Complete todos los campos obligatorios';
      return;
    }

    cargando = true;
    try {
      const res = await fetch('https://backendternurainfinita.runasp.net/api/Clientes', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ ...cliente, FACTURA: [], USUARIO: null })
      });
      if (res.ok) {
        alert('Cliente actualizado');
        goto('/clientes');
      } else {
        const msg = await res.text();
        error = `Error: ${msg}`;
      }
    } catch (err) {
      error = 'Error de red';
    }
    cargando = false;
  }
</script>

<svelte:head>
  <title>Editar Cliente</title>
</svelte:head>

<div class="container max-w-md mx-auto mt-4">
  <h2 class="text-center text-xl font-bold mb-4">Editar Cliente</h2>

  {#if error}
    <div class="alert alert-danger">{error}</div>
  {/if}

  <form on:submit|preventDefault={guardar} class="space-y-3">
    <input bind:value={cliente.CLI_CEDULA} class="form-control" placeholder="Cédula" maxlength="10" required />
    <input bind:value={cliente.US_COD} readonly class="form-control" placeholder="Código Usuario" />
    <input bind:value={cliente.CLI_NOMBRE} class="form-control" placeholder="Nombre" required />
    <input bind:value={cliente.CLI_TELEFONO} class="form-control" placeholder="Teléfono" />
    <input type="email" bind:value={cliente.CLI_CORREO} class="form-control" placeholder="Correo" />
    <input bind:value={cliente.CLI_DIRECCION} class="form-control" placeholder="Dirección" />

    <select bind:value={cliente.CLI_ESTADO} class="form-select" required>
      <option value="">-- Seleccione estado --</option>
      <option value="Activo">Activo</option>
      <option value="Inactivo">Inactivo</option>
    </select>

    <div class="flex justify-between mt-4">
      <button type="submit" class="btn btn-success btn-sm" disabled={cargando}>Guardar</button>
      <a href="/gestion-clientes" class="btn btn-secondary btn-sm">Cancelar</a>
    </div>
  </form>
</div>
