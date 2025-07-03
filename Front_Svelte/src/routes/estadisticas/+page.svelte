<script>
  import { onMount } from 'svelte';
  import Chart from 'chart.js/auto';

  let productoNombre = 'Cargando...';
  let productoCantidad = 'Cargando...';
  let productoTotal = 'Cargando...';

  onMount(() => {
    fetch('https://backendternurainfinita.runasp.net/api/DetalleFactura')
      .then(res => res.json())
      .then(data => {
        let productos = {};
        data.forEach(item => {
          if (item.DTF_ESTADO !== 'Anulado') {
            let codigo = item.PRD_COD;
            if (!productos[codigo]) {
              productos[codigo] = { cantidad: 0, total: 0 };
            }
            productos[codigo].cantidad += item.DTF_CANTIDAD;
            productos[codigo].total += item.DTF_CANTIDAD * item.DTF_PRECIO;
          }
        });

        let productoMasComprado = Object.keys(productos).reduce((a, b) =>
          productos[a].cantidad > productos[b].cantidad ? a : b
        );

        fetch(`https://backendternurainfinita.runasp.net/api/Productos/${productoMasComprado}`)
          .then(res => res.json())
          .then(producto => {
            productoNombre = producto.PRD_NOMBRE;
          });

        productoCantidad = productos[productoMasComprado].cantidad;
        productoTotal = `$${productos[productoMasComprado].total.toFixed(2)}`;
      });

    fetch('https://backendternurainfinita.runasp.net/api/Facturas')
      .then(res => res.json())
      .then(data => {
        let clientes = {};
        data.forEach(factura => {
          if (factura.FAC_ESTADO !== 'Anulado') {
            let cliente = factura.CLI_CEDULA;
            if (!clientes[cliente]) clientes[cliente] = 0;
            clientes[cliente] += factura.FAC_TOTAL;
          }
        });
        let topClientes = Object.entries(clientes).sort((a, b) => b[1] - a[1]).slice(0, 5);

        new Chart(document.getElementById('clientesChart'), {
          type: 'bar',
          data: {
            labels: topClientes.map(c => c[0]),
            datasets: [{
              label: 'Total Comprado ($)',
              data: topClientes.map(c => c[1]),
              backgroundColor: 'rgba(75, 192, 192, 0.6)',
              borderColor: 'rgba(75, 192, 192, 1)',
              borderWidth: 1
            }]
          },
          options: { responsive: true, scales: { y: { beginAtZero: true } } }
        });
      });

    fetch('https://backendternurainfinita.runasp.net/api/DetalleFactura')
      .then(res => res.json())
      .then(data => {
        let productos = {};
        data.forEach(item => {
          if (item.DTF_ESTADO !== 'Anulado') {
            let codigo = item.PRD_COD;
            if (!productos[codigo]) productos[codigo] = 0;
            productos[codigo] += item.DTF_CANTIDAD;
          }
        });

        let labels = [], cantidades = [], colores = [], promises = [];

        for (let codigo of Object.keys(productos)) {
          promises.push(
            fetch(`https://backendternurainfinita.runasp.net/api/Productos/${codigo}`)
              .then(res => res.json())
              .then(producto => {
                labels.push(producto.PRD_NOMBRE);
                cantidades.push(productos[codigo]);
                colores.push(`hsl(${Math.random() * 360}, 70%, 60%)`);
              })
          );
        }

        Promise.all(promises).then(() => {
          new Chart(document.getElementById('productosChart'), {
            type: 'pie',
            data: {
              labels: labels,
              datasets: [{
                label: 'Cantidad Vendida',
                data: cantidades,
                backgroundColor: colores,
                borderWidth: 1
              }]
            },
            options: {
              responsive: true,
              plugins: {
                legend: { position: 'top' },
                title: { display: true, text: 'Distribución de Productos Vendidos' }
              }
            }
          });
        });
      });
  });
</script>

<div class="card">
  <h2>📦 Producto Más Comprado y Productos Más Vendidos</h2>
  <div class="flex-container">
    <div class="producto-info">
      <p><strong>Producto:</strong> {productoNombre}</p>
      <p><strong>Cantidad Vendida:</strong> {productoCantidad}</p>
      <p><strong>Total Vendido:</strong> {productoTotal}</p>
    </div>
    <div class="producto-grafico">
      <canvas id="productosChart"></canvas>
    </div>
  </div>
</div>

<div class="card">
  <h2>👤 Clientes con Más Compras</h2>
  <canvas id="clientesChart"></canvas>
</div>

<footer class="bg-dark text-white text-center py-3 mt-5">
  <p class="mb-0">&copy; 2025 AdminDB. Todos los derechos reservados.</p>
</footer>

<style>
  h2 {
    color: #333;
  }
  .card {
    background-color: white;
    padding: 20px;
    margin-bottom: 30px;
    border-radius: 8px;
    box-shadow: 0 2px 6px rgba(0, 0, 0, 0.1);
  }
  #clientesChart, #productosChart {
    max-width: 400px;
  }
  .flex-container {
    display: flex;
    flex-wrap: wrap;
    gap: 20px;
    align-items: flex-start;
  }
  .producto-info {
    flex: 1;
    min-width: 250px;
  }
  .producto-grafico {
    max-width: 400px;
  }
</style>
