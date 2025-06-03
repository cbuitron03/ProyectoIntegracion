$(document).ready(function () {
    const regexEmail = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

    function validarEmail(email) {
        return regexEmail.test(email);
    }

    $("#registroForm").submit(function (e) {
        e.preventDefault();

        const cedula = $("input[name='CLI_CEDULA']").val().trim();
        const nombre = $("input[name='CLI_NOMBRE']").val().trim();
        const telefono = $("input[name='CLI_TELEFONO']").val().trim();
        const correo = $("input[name='CLI_CORREO']").val().trim();
        const direccion = $("textarea[name='CLI_DIRECCION']").val().trim();
        const clave = $("input[name='CLI_CLAVE']").val().trim();
        const confirmarClave = $("input[name='ConfirmarClave']").val().trim();

        if (!cedula || !nombre || !telefono || !correo || !direccion || !clave || !confirmarClave) {
            alert("Todos los campos son obligatorios.");
            return;
        }

        if (cedula.length !== 10 || isNaN(cedula)) {
            alert("La cédula debe tener 10 dígitos numéricos.");
            return;
        }

        if (telefono.length !== 10 || isNaN(telefono)) {
            alert("El teléfono debe tener 10 dígitos numéricos.");
            return;
        }

        if (!validarEmail(correo)) {
            alert("Correo electrónico inválido.");
            return;
        }

        if (clave !== confirmarClave) {
            alert("Las contraseñas no coinciden.");
            return;
        }

        // Verificar si ya existe el usuario
        $.ajax({
            url: 'https://backendternurainfinita.runasp.net/api/Usuarios?usuario=' + encodeURIComponent(cedula),
            method: 'GET',
            success: function (response) {
                if (response && response.US_COD > 0) {
                    alert("Ya existe una cuenta registrada con esta cédula.");
                } else {
                    // Crear usuario
                    const url = `https://backendternurainfinita.runasp.net/api/Usuarios?` +
                        `CLI_CEDULA=${encodeURIComponent(cedula)}&` +
                        `US_COD=0&` +
                        `CLI_NOMBRE=${encodeURIComponent(nombre)}&` +
                        `CLI_TELEFONO=${encodeURIComponent(telefono)}&` +
                        `CLI_CORREO=${encodeURIComponent(correo)}&` +
                        `CLI_DIRECCION=${encodeURIComponent(direccion)}&` +
                        `CLI_ESTADO=Activo&` +
                        `US_USUARIO=${encodeURIComponent(cedula)}&` +
                        `US_PASS=${encodeURIComponent(clave)}&` +
                        `US_ROL=cliente`;

                    $.ajax({
                        url: url,
                        method: "POST",
                        success: function () {
                            // ✅ Esperar a que se cree, luego consultar el usuario completo
                            $.ajax({
                                url: `https://backendternurainfinita.runasp.net/api/Usuarios?usuario=${encodeURIComponent(cedula)}`,
                                method: "GET",
                                success: function (usuarioData) {
                                    if (usuarioData && usuarioData.US_USUARIO) {
                                        // ✅ Guardar correctamente en sessionStorage
                                        sessionStorage.setItem("usuarioActual", JSON.stringify(usuarioData));
                                        // 🔁 Redirigir
                                        window.location.href = "/Home/Index";
                                    } else {
                                        alert("Usuario creado, pero no se pudo recuperar su información.");
                                    }
                                },
                                error: function () {
                                    alert("Usuario creado, pero ocurrió un error al recuperar sus datos.");
                                }
                            });
                        },
                        error: function (xhr, status, error) {
                            console.error("Error en la creación del usuario:", xhr.responseText);
                            alert("Error al registrar. Intenta de nuevo más tarde.");
                        }
                    });
                }
            },
            error: function (xhr, status, error) {
                console.error("Error al verificar usuario:", xhr.responseText);
                alert("Error al verificar usuario existente.");
            }
        });
    });
});
