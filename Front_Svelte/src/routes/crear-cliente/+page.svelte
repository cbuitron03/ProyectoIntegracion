<script>
  import { goto } from '$app/navigation';
  import { onMount } from 'svelte';
  import 'bootstrap-icons/font/bootstrap-icons.css';

  let cliente = {
    CLI_CEDULA: '',
    CLI_NOMBRE: '',
    CLI_TELEFONO: '',
    CLI_CORREO: '',
    CLI_DIRECCION: '',
    CLI_ESTADO: ''
  };

  let usuario = {
    US_USUARIO: '',
    US_PASS: '',
    US_ROL: ''
  };

  let loading = false;

  function sincronizarCedula() {
    usuario.US_USUARIO = cliente.CLI_CEDULA.trim();
  }

  function esValido() {
    return (
      /^\d{10,11}$/.test(cliente.CLI_CEDULA) &&
      cliente.CLI_NOMBRE &&
      /^\d{7,10}$/.test(cliente.CLI_TELEFONO) &&
      cliente.CLI_CORREO &&
      cliente.CLI_DIRECCION &&
      cliente.CLI_ESTADO &&
      usuario.US_PASS.length >= 4 &&
      usuario.US_ROL
    );
  }

  async function crearClienteUsuario() {
    if (!esValido()) {
      alert('Por favor complete todos los campos correctamente.');
      return;
    }

    loading = true;

    const params = new URLSearchParams({
      CLI_CEDULA: cliente.CLI_CEDULA,
      US_COD: 0,
      CLI_NOMBRE: cliente.CLI_NOMBRE,
      CLI_TELEFONO: cliente.CLI_TELEFONO,
      CLI_CORREO: cliente.CLI_CORREO,
      CLI_DIRECCION: cliente.CLI_DIRECCION,
      CLI_ESTADO: cliente.CLI_ESTADO,
      US_USUARIO: usuario.US_USUARIO,
      US_PASS: usuario.US_PASS,
      US_ROL: usuario.US_ROL
    });

    const url = `https://backendternurainfinita.runasp.net/api/Usuarios?${params.toString()}`;

    try {
      const res = await fetch(url, { method: 'POST' });
      const data = await res.json();

      if (data === true || data === 'true') {
        alert('Cliente y usuario creados correctamente.');
        goto('/gestion-clientes');
      } else {
        alert('No se pudo crear. Verifique los datos.');
      }
    } catch (err) {
      alert('Error al crear el cliente y usuario.');
    } finally {
      loading = false;
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
  <h2 class="mb-4 text-center">Crear Cliente y Usuario</h2>

  <form on:submit|preventDefault={crearClienteUsuario}>
    <div class="row">
      <!-- Cliente -->
      <div class="col-md-6">
        <h5>Datos del Cliente</h5>

        <div class="mb-2">
          <label class="form-label">Cédula</label>
          <input class="form-control form-control-sm" bind:value={cliente.CLI_CEDULA} on:input={sincronizarCedula} required />
        </div>

        <div class="mb-2">
          <label class="form-label">Nombre</label>
          <input class="form-control form-control-sm" bind:value={cliente.CLI_NOMBRE} required />
        </div>

        <div class="mb-2">
          <label class="form-label">Teléfono</label>
          <input class="form-control form-control-sm" bind:value={cliente.CLI_TELEFONO} required />
        </div>

        <div class="mb-2">
          <label class="form-label">Correo</label>
          <input type="email" class="form-control form-control-sm" bind:value={cliente.CLI_CORREO} required />
        </div>

        <div class="mb-2">
          <label class="form-label">Dirección</label>
          <input class="form-control form-control-sm" bind:value={cliente.CLI_DIRECCION} required />
        </div>

        <div class="mb-2">
          <label class="form-label">Estado</label>
          <select class="form-select form-select-sm" bind:value={cliente.CLI_ESTADO} required>
            <option value="" disabled selected>-- Seleccione estado --</option>
            <option value="Activo">Activo</option>
            <option value="Inactivo">Inactivo</option>
          </select>
        </div>
      </div>

      <!-- Usuario -->
      <div class="col-md-6">
        <h5>Datos del Usuario</h5>

        <div class="mb-2">
          <label class="form-label">Usuario (Cédula)</label>
          <input class="form-control form-control-sm" bind:value={usuario.US_USUARIO} readonly />
        </div>

        <div class="mb-2">
          <label class="form-label">Contraseña</label>
          <input type="password" class="form-control form-control-sm" bind:value={usuario.US_PASS} minlength="4" required />
        </div>

        <div class="mb-2">
          <label class="form-label">Rol</label>
          <select class="form-select form-select-sm" bind:value={usuario.US_ROL} required>
            <option value="" disabled selected>-- Seleccione un rol --</option>
            <option value="cliente">Cliente</option>
            <option value="administrador">Administrador</option>
          </select>
        </div>
      </div>
    </div>

    <div class="d-flex justify-content-between mt-4">
      <button type="submit" class="btn btn-success btn-sm" disabled={loading}>
        {#if loading}
          <span class="spinner-border spinner-border-sm me-2" role="status" aria-hidden="true"></span>
        {/if}
        Crear
      </button>
      <a href="/gestion-clientes" class="btn btn-secondary btn-sm">Volver</a>
    </div>
  </form>
</div>

<footer class="bg-dark text-white text-center py-3 mt-5">
  <p class="mb-0">&copy; 2025 AdminDB. Todos los derechos reservados.</p>
</footer>
