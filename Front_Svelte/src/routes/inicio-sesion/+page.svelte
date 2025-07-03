<script>
  import { onMount } from 'svelte';
  import { goto } from '$app/navigation';

  let usuario = '';
  let clave = '';

  const login = async (e) => {
    e.preventDefault();

    if (!usuario.trim() || !clave.trim()) {
      alert('Por favor, complete todos los campos.');
      return;
    }

    if (usuario === 'Admin' && clave === '12345') {
      alert('Bienvenido, Administrador 👑');
      window.location.href = 'https://ternurainfinita.runasp.net/Gestion/Index';
      return;
    }

    try {
      const url = `https://backendternurainfinita.runasp.net/api/autenticarUsuario?US_USUARIO=${encodeURIComponent(usuario)}&US_PASS=${encodeURIComponent(clave)}`;
      const res = await fetch(url);
      const texto = (await res.text()).trim().toLowerCase();

      if (texto === 'true') {
        alert('Inicio de sesión exitoso 🎉');

        const userRes = await fetch(`https://backendternurainfinita.runasp.net/api/Usuarios?usuario=${encodeURIComponent(usuario)}`);
        const usuarioData = await userRes.json();

        if (usuarioData && usuarioData.US_USUARIO) {
          sessionStorage.setItem('usuarioActual', JSON.stringify(usuarioData));

          const params = new URLSearchParams(window.location.search);
          if (params.get("requiereCompra") === "true") {
            goto('/carrito');
          } else {
            goto('/home');
          }
        } else {
          alert('No se pudo recuperar los datos del usuario.');
        }
      } else {
        alert('Credenciales incorrectas. Intenta de nuevo.');
      }
    } catch (error) {
      console.error('Error al iniciar sesión:', error);
      alert('Error al intentar iniciar sesión. Por favor, intenta más tarde.');
    }
  };
</script>

<div class="login-container">
  <div class="text-center">
    <img src="https://res.cloudinary.com/dvmxzzsj2/image/upload/v1746092699/Imagen_de_WhatsApp_2025-05-01_a_las_04.43.53_d579ddc9_qlpice.jpg" alt="Ternura Infinita" class="logo" />
    <h2 class="bienvenido">Bienvenido a Ternura Infinita</h2>
    <p class="sub">Ingresa tus datos para continuar</p>
  </div>

  <div class="card-login">
    <h4 class="titulo">Iniciar Sesión</h4>

    <form on:submit={login}>
      <div class="form-group">
        <label for="usuario">Usuario</label>
        <input type="text" id="usuario" bind:value={usuario} placeholder="Ingrese su usuario" required />
      </div>

      <div class="form-group">
        <label for="clave">Contraseña</label>
        <input type="password" id="clave" bind:value={clave} placeholder="Ingrese su contraseña" required />
      </div>

      <button type="submit" class="btn-primary">Iniciar Sesión</button>
    </form>

    <hr />
    <p class="text-muted">¿No tienes cuenta?</p>
    <a href="/cuenta" class="btn-secondary">Registrarse</a>
  </div>
</div>
