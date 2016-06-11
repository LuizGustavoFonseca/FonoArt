var Fonoart = Fonoart || { Fonoaudiologas: {} };

$(function () {
    $('.navegacao').find('li').removeClass('active');
    $('.navBarFono').addClass('active');

    if ($('.listagem') && $('.listagem').length > 0) {
        $('#tabelaFonos').DataTable({
            "columns": [
                { "sWidth": "12%" },
                { "sWidth": "12%", },
                { "sWidth": "36%", },
                { "sWidth": "17%", },                
                { "sWidth": "17%", },
                { "sWidth": "6%", "bSortable": false }
            ],
            "filter": false,
            "lengthChange": false
        });

        Fonoart.Fonoaudiologas.preencherGrid();
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

        $('#cancelarAlteracoes').on('click', function () {
            Fonoart.Principal.exibirModalDeConfirmacao("Cancelar Alterações", "Ao cancelar todas as alterações serão perdidas. Confirma?", false, function () { Fonoart.Fonoaudiologas.cancelarFono() });
        });

        if ($('.cadastro').data('cpf-fono')) {
            Fonoart.Fonoaudiologas.preencherCamposEdicao();
        }
    }
});

Fonoart.Fonoaudiologas = {
    novaFono: true,
    preencherGrid: function () {
        var action = $('.listagem').data('url-listar');
        Fonoart.Principal.chamadaAjax(action, null, function (dados) {
            $('#tabelaFonos').DataTable().clear().draw();
            $.each(dados.Fonoaudiologas, function (indice, fono) {
                $('#tabelaFonos').DataTable().row.add([
                    fono.Cpf,
                    fono.Crfa,
                    fono.Nome,
                    fono.DataNascimentoFormatada,                    
                    fono.Telefone,
                    '<a class="btn btn-info" href="' + $('.listagem').data('url-cadastro') + '?cpf=' + fono.Cpf + '"><i class="fa fa-edit"></i></button>'
                ]).draw();
            });
        });
    },
    preencherCamposEdicao: function () {
        var action = $('.cadastro').data('url-obter-fonoaudiologa');
        Fonoart.Principal.chamadaAjax(action, { cpf: $('.cadastro').data('cpf-fono') }, function (dados) {
            $('.titulo').text($('.titulo').text() + dados.Fonoaudiologa.Nome);
            $('#cpfFono').attr('disabled', 'disabled');
            $('#cpfFono').val(dados.Fonoaudiologa.Cpf);
            $('#crfaFono').val(dados.Fonoaudiologa.Crfa);
            $('#nomeFono').val(dados.Fonoaudiologa.Nome);
            $('#dataNascFono').data('daterangepicker').setStartDate(dados.Fonoaudiologa.DataNascimento);
            $('#enderecoFono').val(dados.Fonoaudiologa.Endereco);
            $('#telefoneFono').val(dados.Fonoaudiologa.Telefone);
            Fonoart.Fonoaudiologas.novaFono = false;
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
            NovaFonoaudiologa: Fonoart.Fonoaudiologas.novaFono
        };
        var action = $('#salvarFonoaudiologa').data('url-salvar');
        Fonoart.Principal.chamadaAjax(action, JSON.stringify(fonoaudiologa), function (dados) {
            noty({ text: 'noty - a jquery notification library!', layout: "topCenter" });
            //window.location.href = $('.cadastro').data('url-listar');
        });
    },
    cancelarFono: function () {
        window.location.href = $('.cadastro').data('url-listar');
    }

};
