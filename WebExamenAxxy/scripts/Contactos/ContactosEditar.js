$(document).ready(function () {

    var idcontacto = 0;
    obtenerDepartamento();
    obtenerContactoEditar();


    $('#btnAgregarDireccion').click(function () {
        var id = $('#tabla_direccioness tbody tr').length + 1;
        $('#tabla_direccioness tbody').append('<tr class="eliminar_'+id+'"> ' +
                    '<td><input class="form-control" style="min-width: 100% !important;" type="text" /></td>' +
                     '<td>'+
                     '<button type="button" class="btn btn-danger eliminardireccion" data-id=' + id + ' >Eliminar</button>' +
                    '</td>' + 
                    '</tr>');
    });

    $('#tabla_direccioness tbody').on('click', 'button.eliminardireccion', function () {
        var respuesta = confirm('Seguro desea eliminar la direccion');
        if (respuesta) {
            $('#tabla_direccioness tbody').find('tr.eliminar_' + $(this).data('id') + '').remove()
        }
    });


    $('#btnRegresar').click(function () {
      
        $('#panelCrudContactoIndex').show();
        $('#panelCrudContactohtml').html('');
        $('#panelCrudContactohtml').hide(); 
    });

    $('#btnGuardar').click(function () {

        if ($('#nombreContacto').val() === '') {
            alert('Ingrese el nombre contacto, es requerido');
        } else if ($('#departamentoContacto').val() === '') {
            alert('Seleccione el departamento , es requerido');       

        } else if ($('#tabla_direccioness tbody tr').length ===  0) {
            alert('Debe ingresar al menos una direccion, es requerido');

        } else {
            var _Direcciones = [];
            $.each($('#tabla_direccioness tbody tr'), function (i, fila) {

                _Direcciones.push({ IdDireccion: $(fila).find('input.form-control').data('iddireccion') ,Direccion: $(fila).find('input.form-control').val()} );

            });

            var Contacto = {
                IdContacto : idcontacto,
                IdDepartamento: parseInt($('#departamentoContacto').val()),
                NombreContacto: $('#nombreContacto').val(),
                Direcciones: _Direcciones

            };
            console.log(Contacto);
            $.post('ActualizarContacto', { Contacto: Contacto }, function (data) {
                if (data.estado === true) {
                    alert('Se guardo correctamente');
                    obtenerListaContacto();
                    $('#btnRegresar').trigger('click');
                } else {
                    alert(data.mensajeerror);
                }
            });
        }
    });

    
    function obtenerDepartamento() {
        $.post('ObtenerDepartamento', function (data) { 
            if (data.estado === true) {
                $.each(data.data, function (i, fila) {                   
                    $('#departamentoContacto').append('<option value=' + fila.IdDepartamento + '>' + fila.NombreDepartamento + '</option>');
                });                
            } else {
                alert(data.mensajeerror);
            }
        });
    }

    function obtenerContactoEditar() {
        $.post('ObtenerContactoPorID', function (data) {
            if (data.estado === true) {
                console.log(data);
                idcontacto = data.data.IdContacto;
                $('#nombreContacto').val(data.data.NombreContacto);
                $('#departamentoContacto').val(data.data.IdDepartamento);
                $.each(data.data.Direcciones, function (i, fila) {
                    var id = $('#tabla_direccioness tbody tr').length + 1;
                    $('#tabla_direccioness tbody').append('<tr class="eliminar_' + id + '"> ' +
                                '<td><input class="form-control" style="min-width: 100% !important;" type="text"  data-iddireccion='+fila.IdDireccion+' value="'+fila.Direccion+'" /></td>' +
                                 '<td>' +
                                 '<button type="button" class="btn btn-danger eliminardireccion" data-id=' + id + ' >Eliminar</button>' +
                                '</td>' +
                                '</tr>');
                });                

            } else {
                alert(data.mensajeerror);
            }
        });
    }
});
