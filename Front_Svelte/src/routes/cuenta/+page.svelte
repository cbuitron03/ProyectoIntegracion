<script>
  import { goto } from '$app/navigation';

  let cedula = '';
  let nombre = '';
  let telefono = '';
  let correo = '';
  let direccion = '';
  let clave = '';
  let confirmarClave = '';

  async function registrar(e) {
    e.preventDefault();

    if (clave !== confirmarClave) {
      alert('Las contraseñas no coinciden.');
      return;
    }

    const cliente = {
      CLI_CEDULA: cedula,
      CLI_NOMBRE: nombre,
      CLI_TELEFONO: telefono,
      CLI_CORREO: correo,
      CLI_DIRECCION: direccion,
      CLI_CLAVE: clave
    };

    try {
      const res = await fetch('https://backendternurainfinita.runasp.net/api/Clientes', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(cliente)
      });

      if (res.ok) {
        alert('Registro exitoso 🎉');
        goto('/Login/InicioSesion');
      } else {
        alert('Error al registrar usuario.');
      }
    } catch (err) {
      alert('Error de red. Intenta de nuevo.');
      console.error(err);
    }
  }
</script>

<div class="login-container">
  <div class="text-center">
    <img src="https://res.cloudinary.com/dvmxzzsj2/image/upload/v1746092699/Imagen_de_WhatsApp_2025-05-01_a_las_04.43.53_d579ddc9_qlpice.jpg" alt="Ternura Infinita" class="logo" />
    <h2 class="bienvenido">Crea tu Cuenta</h2>
    <p class="sub">Completa el formulario para registrarte</p>
  </div>

  <div class="card-login">
    <form on:submit={registrar}>
      <div class="form-group">
        <label for="cedula">Cédula</label>
        <input type="text" id="cedula" bind:value={cedula} required />
      </div>

      <div class="form-group">
        <label for="nombre">Nombre completo</label>
        <input type="text" id="nombre" bind:value={nombre} required />
      </div>

      <div class="form-group">
        <label for="telefono">Teléfono</label>
        <input type="tel" id="telefono" bind:value={telefono} required />
      </div>

      <div class="form-group">
        <label for="correo">Correo electrónico</label>
        <input type="email" id="correo" bind:value={correo} required />
      </div>

      <div class="form-group">
        <label for="direccion">Dirección</label>
        <textarea id="direccion" bind:value={direccion} rows="2" required></textarea>
      </div>

      <div class="form-group">
        <label for="clave">Contraseña</label>
        <input type="password" id="clave" bind:value={clave} required />
      </div>

      <div class="form-group">
        <label for="confirmarClave">Confirmar contraseña</label>
        <input type="password" id="confirmarClave" bind:value={confirmarClave} required />
      </div>

      <button type="submit" class="btn-primary">Registrarse</button>
    </form>

    <hr />
    <p class="text-muted">¿Ya tienes una cuenta?</p>
    <a href="/Login/InicioSesion" class="btn-secondary">Iniciar Sesión</a>
  </div>
</div>
