var Fonoart = Fonoart || {};

$(function () {
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
});

Fonoart.Atendimendo = {

};