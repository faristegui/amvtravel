var mainUrl = "https://localhost:7041/api/";

function login() {
    var usuario = document.getElementById('usuario').value;
    var password = document.getElementById('password').value;
    var hashedPassword = CryptoJS.MD5(password).toString();
    
    var datos = {
        usuario: usuario,
        password: hashedPassword
    };
    
    var xhr = new XMLHttpRequest();
    
    xhr.onreadystatechange = function () {
        if (xhr.readyState === XMLHttpRequest.DONE) {
            if (xhr.status === 200) {
                window.location.href = "dashboard.html";
            } else {
                alert('Login incorrecto.');
            }
        }
    };

    xhr.open('POST', mainUrl + "login/session");
    xhr.setRequestHeader('Content-Type', 'application/json');
    
    var jsonDatos = JSON.stringify(datos);
    
    xhr.send(jsonDatos);
}

function MostrarTours() {
    $('#listadoTours').html('');
    $.ajax({
        url: mainUrl + "gestor/mostrartours",
        method: 'GET',
        dataType: 'json',
        success: function (tours) {
            $.each(tours, function (index, viaje) {
                var fila = `
                    <tr>
                        <td>${viaje.id}</td>
                        <td>${viaje.nombre}</td>
                        <td>${viaje.destino}</td>
                        <td>${viaje.fechaInicio}</td>
                        <td>${viaje.fechaFin}</td>
                        <td>$ ${viaje.precio}</td>
                    </tr>
                `;
                $('#listadoTours').append(fila);
            });
        },
        error: function () {
            alert('No se pudo obtener la lista de tours.');
        }
    });
}

function MostrarReservas() {
    $('#listadoReservas').html('');
    $.ajax({
        url: mainUrl + "gestor/mostrarreservas",
        method: 'GET',
        dataType: 'json',
        success: function (tours) {
            $.each(tours, function (index, viaje) {
                var fila = `
                    <tr>
                        <td>${viaje.id}</td>
                        <td>${viaje.cliente}</td>
                        <td>${viaje.fechaReserva}</td>
                        <td>${viaje.tourId}</td>
                    </tr>
                `;
                $('#listadoReservas').append(fila);
            });
        },
        error: function () {
            alert('No se pudo obtener la lista de tours.');
        }
    });
}

function eliminarReserva() {
    var idReserva = $('#idReserva').val();
    
    $.ajax({
        url: mainUrl + "gestor/eliminarreserva/" + idReserva,
        method: 'DELETE',
        success: function (response) {
            $('#idReserva').val('');
            MostrarReservas();
        },
        error: function (xhr, status, error) {
            alert('Error al eliminar la reserva:', error);
        }
    });

    
}