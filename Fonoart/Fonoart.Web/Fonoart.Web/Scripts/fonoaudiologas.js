var Fonoart = Fonoart || { Fonoaudiologas: {} };

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
            Fonoart.Principal.exibirModalDeConfirmacao("Salvar Evento", "Deseja salvar alterações da fonoaudióloga?", false, Fonoart.Fonoaudiologas.salvarFono());
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
        var fono = {
            Cpf: $('#cpfFono').val(),
            Crfa: $('#crfaFono').val(),
            Nome: $('#nomeFono').val(),
            DataNascimento: $('#dataNascFono').val(),
            Endereco: $('#enderecoFono').val(),
            Telefone: $('#telefoneFono').val(),
            NovaFonoaudiologa: true
        };
        var action = $('#salvarFonoaudiologa').data('url-salvar');
        Fonoart.Principal.chamadaAjax(action, JSON.stringify({fono}), function (dados) {
            alert('Sucesso');
        });
    }
};
