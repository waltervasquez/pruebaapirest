$(document).ready(function () {

     
    obtenerListaDepartamento();

    $('#btnNuevoDepartamento').click(function () {
        $.post('Crear', function (data) {
            $('#panelCrudDepartamentoIndex').hide();
            $('#panelCrudDepartamentohtml').html(data);
            $('#panelCrudDepartamentohtml').show();
        });
    });


    $('#tabla_departamento tbody').on('click', 'button.eliminar', function () {
        var respuesta = confirm('Seguro desea eliminar el contacto');
        if (respuesta) {
            $.post('EliminarContacto', { IdContacto: $(this).data('id') }, function (data) {
                if (data.estado === true) {
                    alert('Se elimino correctamente');
                    obtenerListaDepartamento();
                } else {
                    alert(data.mensajeerror);
                }
            });
        }
    });


    $('#tabla_departamento tbody').on('click', 'button.actualizar', function () {

       
    });


});