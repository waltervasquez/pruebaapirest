$(document).ready(function () {

    obtenerListaContacto();


    $('#btnNuevoContacto').click(function () {
        $.post('Crear', function (data) {
            $('#panelCrudContactoIndex').hide();
            $('#panelCrudContactohtml').html(data);
            $('#panelCrudContactohtml').show();
        });
    });
     

    $('#tabla_contactos tbody').on('click', 'button.eliminar', function () {
        var respuesta = confirm('Seguro desea eliminar el contacto');
        if (respuesta) {
            $.post('EliminarContacto', { IdContacto: $(this).data('id') }, function (data) {
                if (data.estado === true) {                        
                    alert('Se elimino correctamente');
                    obtenerListaContacto();
                } else {
                    alert(data.mensajeerror);
                }
            });
        }
    });


    $('#tabla_contactos tbody').on('click', 'button.actualizar', function () {
        
        $.post('Editar', { IdContacto: $(this).data('id') }, function (data) {
            $('#panelCrudContactoIndex').hide();
            $('#panelCrudContactohtml').html(data);
            $('#panelCrudContactohtml').show();
        }); 
    });


});