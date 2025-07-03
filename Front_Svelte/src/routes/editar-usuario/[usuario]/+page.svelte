<script>
	import { onMount } from 'svelte';
	import { page } from '$app/stores';
	import { goto } from '$app/navigation';

	let usuario = {
		US_COD: '',
		US_USUARIO: '',
		US_PASS: '',
		US_ROL: '',
		US_ESTADO: ''
	};

	let cargando = false;
	let cedula = '';
	$page.subscribe(p => cedula = p.url.searchParams.get('usuario'));

	onMount(async () => {
		if (!cedula) return;
		const res = await fetch(`https://backendternurainfinita.runasp.net/api/Usuarios?usuario=${cedula}`);
		usuario = await res.json();
	});

	async function guardar(e) {
		e.preventDefault();
		cargando = true;
		const res = await fetch('https://backendternurainfinita.runasp.net/api/Usuarios', {
			method: 'PUT',
			headers: { 'Content-Type': 'application/json' },
			body: JSON.stringify({ ...usuario, CLIENTE: [] })
		});
		if ((await res.text()) === 'true') goto('/GesUsuarios');
		else alert('Error al guardar');
		cargando = false;
	}
</script>

<form on:submit={guardar} class="container mt-4" style="max-width: 450px">
	<h3 class="mb-4 text-center">Editar Usuario</h3>

	<div class="mb-3">
		<label>Código</label>
		<input class="form-control" type="number" bind:value={usuario.US_COD} readonly />
	</div>

	<div class="mb-3">
		<label>Cédula (Usuario)</label>
		<input class="form-control" type="text" bind:value={usuario.US_USUARIO} readonly />
	</div>

	<div class="mb-3">
		<label>Contraseña</label>
		<input class="form-control" type="text" bind:value={usuario.US_PASS} minlength="4" required />
	</div>

	<div class="mb-3">
		<label>Rol</label>
		<select class="form-select" bind:value={usuario.US_ROL} required>
			<option value="">-- Seleccione --</option>
			<option value="cliente">Cliente</option>
			<option value="administrador">Administrador</option>
		</select>
	</div>

	<div class="d-flex justify-content-between">
		<button class="btn btn-success" type="submit" disabled={cargando}>
			{cargando ? 'Guardando...' : 'Guardar'}
		</button>
		<a class="btn btn-secondary" href="/GesUsuarios">Cancelar</a>
	</div>
</form>

<style>
	form {
		font-size: 0.9rem;
	}
</style>
