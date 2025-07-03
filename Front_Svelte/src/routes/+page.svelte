<script>
  import { goto } from '$app/navigation';
  import { onMount } from 'svelte';

  onMount(() => {
    goto('/home');
  });
</script>

<p>Redirigiendo a Home...</p>
