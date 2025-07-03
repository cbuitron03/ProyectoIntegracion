<script>
  import { onMount } from 'svelte';
  import { goto } from '$app/navigation';

  let US_USUARIO = '';
  let US_PASS = '';
  let US_ROL = '';
  let loading = false;

  const validarFormulario = () => {
    if (!/^\d{10,11}$/.test(US_USUARIO)) return 'Cédula inválida';
    if (US_PASS.length < 4) return 'Contraseña muy corta';
    if (!US_ROL) return 'Rol no seleccionado';
    return null;
  };

  const crearUsuario = async (e) => {
    e.preventDefault();
    const error = validarFormulario();
    if (error) return alert(error);

    loading = true;

    const params = new URLSearchParams({
      CLI_CEDULA: '',
      US_COD: 0,
      CLI_NOMBRE: '',
      CLI_TELEFONO: '',
      CLI_CORREO: '',
      CLI_DIRECCION: '',
      CLI_ESTADO: '',
      US_USUARIO,
      US_PASS,
      US_ROL
    });

    try {
      const res = await fetch(`https://backendternurainfinita.runasp.net/api/Usuarios?${params}`, {
        method: 'POST'
      });
      const data = await res.json();
      if (data === true || data === 'true') {
        alert('Usuario creado correctamente.');
        goto('/GesUsuarios');
      } else {
        alert('No se pudo crear el usuario.');
      }
    } catch (err) {
      alert('Error al crear usuario: ' + err);
    } finally {
      loading = false;
    }
  };
</script>

<svelte:head>
  <title>Crear Usuario</title>
</svelte:head>

<div class="container mt-4 d-flex justify-content-center">
  <form on:submit={crearUsuario} style="max-width: 420px; width: 100%;">
    <h2 class="text-center mb-4">Crear Usuario</h2>

    <div class="mb-3">
      <label for="US_USUARIO" class="form-label">Cédula (Usuario)</label>
      <input id="US_USUARIO" bind:value={US_USUARIO} class="form-control form-control-sm" required pattern="^\d{10,11}$" placeholder="Ingrese cédula" />
    </div>

    <div class="mb-3">
      <label for="US_PASS" class="form-label">Contraseña</label>
      <input type="password" id="US_PASS" bind:value={US_PASS} class="form-control form-control-sm" required minlength="4" placeholder="Mínimo 4 caracteres" />
    </div>

    <div class="mb-4">
      <label for="US_ROL" class="form-label">Rol</label>
      <select id="US_ROL" bind:value={US_ROL} class="form-select form-select-sm" required>
        <option value="" disabled selected>-- Seleccione un rol --</option>
        <option value="cliente">Cliente</option>
        <option value="administrador">Administrador</option>
      </select>
    </div>

    <div class="d-flex justify-content-between">
      <button type="submit" class="btn btn-primary btn-sm" disabled={loading}>
        {#if loading}
          <span class="spinner-border spinner-border-sm me-2" role="status" aria-hidden="true"></span>
        {/if}
        Crear
      </button>
      <a class="btn btn-secondary btn-sm" href="/gestion-usuarios">Volver</a>
    </div>
  </form>
</div>

<footer class="bg-dark text-white text-center py-3 mt-5">
  <p class="mb-0">&copy; {new Date().getFullYear()} AdminDB. Todos los derechos reservados.</p>
</footer>

<style>
  .container {
    font-family: 'Segoe UI', sans-serif;
  }
</style>
