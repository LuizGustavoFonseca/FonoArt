﻿var Fonoart = Fonoart || { Fonoaudiologas: {} };

$(function () {

    if ($('.listagem') && $('.listagem').length > 0) {
        $('#tabelaFonos').DataTable({
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
    }
    else {
        $("#cpfFono").mask("999.999.999-99");
        Fonoart.Principal.adicionarMascaraDeTelefone($('#telefoneFono'));

        $('#dataNascFono').daterangepicker({            
            singleDatePicker: true,
            showDropdowns: true,
            opens: 'left',
            locale: Fonoart.Principal.locale(true)
        });
        $('#salvarFonoaudiologa').on('click', function () {
            Fonoart.Principal.exibirModalDeConfirmacao("Salvar Evento", "Deseja salvar alterações da fonoaudióloga?", false, function () { Fonoart.Fonoaudiologas.salvarFono() });
        });
    }
});

Fonoart.Fonoaudiologas = {
    preencherGrid: function () {
        var action = $('#listagem').data('url-listar');
        Fonoart.Principal.chamadaAjax(action, null, function (dados) {
            
        });
    },
    salvarFono: function () {
        var dataArray = $('#dataNascFono').val().split('/');
        var dataNascimento = new Date(parseInt(dataArray[2]), parseInt(dataArray[1] - 1), parseInt(dataArray[0]));

        var fonoaudiologa = {
            Cpf: $('#cpfFono').val(),
            Crfa: $('#crfaFono').val(),
            Nome: $('#nomeFono').val(),
            DataNascimento: '\/Date(' + (dataNascimento.getTime() - dataNascimento.getTimezoneOffset() * 60 * 1000) + ')\/',
            Endereco: $('#enderecoFono').val(),
            Telefone: $('#telefoneFono').val(),
            NovaFonoaudiologa: true
        };
        var action = $('#salvarFonoaudiologa').data('url-salvar');
        Fonoart.Principal.chamadaAjax(action, JSON.stringify(fonoaudiologa), function (dados) {
            alert('Sucesso');
        });
    }
};
