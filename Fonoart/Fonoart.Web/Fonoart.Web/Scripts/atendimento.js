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
        $('#dataInternacao').daterangepicker({
            singleDatePicker: true,
            showDropdowns: true,
            opens: 'left',
            locale: Fonoart.Principal.locale(true)
        });

        $('#dataSolicitacaoInt').daterangepicker({
            singleDatePicker: true,
            showDropdowns: true,
            opens: 'left',
            locale: Fonoart.Principal.locale(true)
        });

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

        $('#salvarAtendimento').on('click', function () {
            if ($('#formCadastroAtendimento').validationEngine('validate')) {
                Fonoart.Principal.exibirModalDeConfirmacao("Salvar Atendimento", "Deseja salvar alterações da atendimento?", false, function () { Fonoart.Atendimento.salvarAtendimento() });
            }
        });

        $('#cancelarAlteracoes').on('click', function () {
            Fonoart.Principal.exibirModalDeConfirmacao("Cancelar Alterações", "Ao cancelar todas as alterações serão perdidas. Confirma?", false, function () { Fonoart.Atendimento.cancelarAlteracoes() });
        });

        $('#codigoPaciente').on('change', function () {
            Fonoart.Atendimento.obterPaciente($(this).val());
        });
    }
});

Fonoart.Atendimento = {
    novoPaciente: true,
    salvarAtendimento: function () {
        var action;
        if ($('#checkInternacao').is(':checked')) {
            action = $('#salvarAtendimento').data('url-salvar-internacao');

            var dataInternacaoArray = $('#dataInternacao').val().split('/');
            var dataInternacao = new Date(parseInt(dataInternacaoArray[2]), parseInt(dataInternacaoArray[1] - 1), parseInt(dataInternacaoArray[0]));

            var dataSolicitacaoArray = $('#dataSolicitacaoInt').val().split('/');
            var dataSolicitacao = new Date(parseInt(dataSolicitacaoArray[2]), parseInt(dataSolicitacaoArray[1] - 1), parseInt(dataSolicitacaoArray[0]));

            var atendimento = {
                Quarto: $('#quarto').val(),
                DataInternacao: '\/Date(' + (dataInternacao.getTime() - dataInternacao.getTimezoneOffset() * 60 * 1000) + ')\/',
                CodigoAtendimento: $('#codigoAtendimentoInt').val(),
                DataSolicitacao: '\/Date(' + (dataSolicitacao.getTime() - dataSolicitacao.getTimezoneOffset() * 60 * 1000) + ')\/',
                CodigoPaciente: $('#codigoPaciente').val(),
                CpfFonoaudiologa: $('#fonoInt').val(),
                IdSituacao: $('#situacaoInt').val(),
                TipoAtendimento: $('#checkInternacao').data('valor'),
                Paciente: {
                    NovoPaciente: Fonoart.Atendimento.novoPaciente,
                    CodigoPaciente: $('#codigoPaciente').val(),
                    NomePaciente: $('#nomePaciente').val(),
                    TelefonePaciente: $('#telefone').val(),
                    CodigoConvenio: $('#convenios').val(),
                    NumeroCarteirinha: $('#numeroCarteirinha').val()
                }
            };
            Fonoart.Principal.chamadaAjax(action, JSON.stringify(atendimento), function (dados) {

            });
        }
        else {
            action = $('#salvarAtendimento').data('url-salvar-audiencia');
        }
    },
    obterPaciente: function (codigoPaciente) {
        var action = $('#codigoPaciente').data('url-obter-cliente');
        Fonoart.Principal.chamadaAjax(action, { codigoPaciente: codigoPaciente }, function (dados) {
            if (dados.Paciente) {
                $('#codigoPaciente').val(dados.Paciente.CodigoPaciente);
                $('#nomePaciente').val(dados.Paciente.NomePaciente);
                $('#telefone').val(dados.Paciente.TelefonePaciente);
                $('#convenios').val(dados.Paciente.CodigoConvenio);
                $('#numeroCarteirinha').val(dados.Paciente.NumeroCarteirinha);

                $('#nomePaciente').attr('disabled', 'disabled');
                $('#telefone').attr('disabled', 'disabled');
                $('#convenios').attr('disabled', 'disabled');
                $('#numeroCarteirinha').attr('disabled', 'disabled');

                Fonoart.Atendimento.novoPaciente = false;
            }
            else {
                $('#nomePaciente').val('');
                $('#telefone').val('');
                $('#convenios').val('');
                $('#numeroCarteirinha').val('');

                $('#nomePaciente').removeAttr('disabled');
                $('#telefone').removeAttr('disabled');
                $('#convenios').removeAttr('disabled');
                $('#numeroCarteirinha').removeAttr('disabled');

                Fonoart.Atendimento.novoPaciente = true;
                $('#nomePaciente').focus();
            }
        });

    }
};