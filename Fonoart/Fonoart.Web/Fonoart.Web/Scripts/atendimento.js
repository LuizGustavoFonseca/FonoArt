var Fonoart = Fonoart || {};

$(function () {
    $('.navegacao').find('li').removeClass('active');
    $('.navBarAtendimento').addClass('active');

    if ($('.listagem') && $('.listagem').length > 0) {
        $('#tabelaAtendimento').DataTable({
            "columns": [
                { "sWidth": "26%" },
                { "sWidth": "14%", },
                { "sWidth": "14%", },
                { "sWidth": "10%", },
                { "sWidth": "12%", },
                { "sWidth": "18%", },
                { "sWidth": "6%", "bSortable": false }
            ],
            "filter": false,
            "lengthChange": false
        });

        $('#dataSolicitacao').daterangepicker();
        $('#altaAdministrativa').daterangepicker();
    }
    else {
        $('[name=tipoAtendimento]').on('ifChanged', function () {
            if ($('#checkInternacao').is(':checked')) {
                $('.partialInternacao').show();
                $('.partialAmbulatorial').hide();
            }
            else {
                $('.partialInternacao').hide();
                $('.partialAmbulatorial').show();
            }
        });
    }
});

Fonoart.Atendimendo.Listagem = {

};

Fonoart.Atendimento.Cadastro = {

};