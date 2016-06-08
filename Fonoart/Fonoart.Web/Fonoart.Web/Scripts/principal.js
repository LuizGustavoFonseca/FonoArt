var Fonoart = Fonoart || {};


$(function () {
    $('.icheck').iCheck({
        checkboxClass: 'icheckbox_flat-aero',
        radioClass: 'iradio_flat-aero'
    });
});

Fonoart.Principal = {
    chamadaAjax: function (url, parametros, callbackSucesso, callbackErro, naoExibirCarregando) {
        $.ajax({
            type: "POST",
            url: url,
            data: parametros,
            dataType: "json",
            traditional: true,
            beforeSend: function () {
                //if (!naoExibirCarregando) {
                //    if (Fonoart.Principal.contadorLoading == 0) {
                //        Fonoart.Principal.exibirLoading();
                //    }
                //    Fonoart.Principal.contadorLoading++;
                //}
            },
            complete: function () {
                //if (!naoExibirCarregando) {
                //    Fonoart.Principal.contadorLoading--;
                //    if (Fonoart.Principal.contadorLoading == 0) {
                //        Fonoart.Principal.esconderLoading();
                //    }
                //}
            },
            success: function (args) {
                if (args.expirou) {
                    location = args.urlSessaoExpirada;
                }
                else {
                    callbackSucesso(args);
                }
            },
            error: function (reqObj, tipoErro, mensagemErro) {
                var jsonValue = { Mensagem: mensagemErro };
                try {
                    jsonValue = jQuery.parseJSON(reqObj.responseText);
                }
                catch (excecao) {
                }
                alertaErro(jsonValue.Mensagem);
                if (reqObj.state() != 'rejected') {
                    if (callbackErro) {
                        callbackErro(tipoErro, mensagemErro);
                    }
                }
            }
        });
    },
    exibirModalDeConfirmacao: function (titulo, texto, corpoHtml, callbackConfirma, callbackCancela) {
        $('#modalConfirmacao').modal('toggle');
        $('#tituloModalConfirmacao').text(titulo);
        if (corpoHtml) {
            $(texto).appendTo($('#corpoModal'));
        }
        else {
            $('#corpoModal').text(texto);
        }
        $('#confirmarModal').prop('onclick', null).off('click');
        $('#confirmarModal').on('click', function () {
            if (callbackConfirma)
                callbackConfirma();
            $('#modalConfirmacao').modal('toggle');
        });
        $('#cancelaModal').prop('onclick', null).off('click');
        $('#cancelaModal').on('click', function () {
            if (callbackCancela)
                callbackCancela();
            $('#modalConfirmacao').modal('toggle');
        });
    },
    locale: function (filtro) {
        return {
            "format": "DD/MM/YYYY",
            "applyLabel": "Aplicar",
            "cancelLabel": filtro ? "Limpar" : "Cancelar",
            "fromLabel": "Início",
            "toLabel": "Fim",
            "customRangeLabel": "Customizado",
            "daysOfWeek": [
                "D",
                "S",
                "T",
                "Q",
                "Q",
                "S",
                "S"
            ],
            "monthNames": [
                "Janeiro",
                "Fevereiro",
                "Março",
                "Abril",
                "Maio",
                "Junho",
                "Julho",
                "Agosto",
                "Setembro",
                "Outubro",
                "Novembro",
                "Dezembro"
            ],
            "firstDay": 0
        }
    },
    dataTableLanguage: {
        "sEmptyTable": "Nenhum registro encontrado",
        "sInfo": "Mostrando de _START_ até _END_ de _TOTAL_ registros",
        "sInfoEmpty": "Mostrando 0 até 0 de 0 registros",
        "sInfoFiltered": "(Filtrados de _MAX_ registros)",
        "sInfoPostFix": "",
        "sInfoThousands": ".",
        "sLengthMenu": "_MENU_ resultados por página",
        "sLoadingRecords": "Carregando...",
        "sProcessing": "Processando...",
        "sZeroRecords": "Nenhum registro encontrado",
        "sSearch": "Pesquisar",
        "oPaginate": {
            "sNext": "Próximo",
            "sPrevious": "Anterior",
            "sFirst": "Primeiro",
            "sLast": "Último"
        },
        "oAria": {
            "sSortAscending": ": Ordenar colunas de forma ascendente",
            "sSortDescending": ": Ordenar colunas de forma descendente"
        }
    },
    adicionarMascaraDeTelefone: function (inputTelefone) {
        inputTelefone.mask("(99) 9999-9999?9")
        .focusout(function (event) {
            var target, phone, element;
            target = (event.currentTarget) ? event.currentTarget : event.srcElement;
            phone = target.value.replace(/\D/g, '');
            element = $(target);
            element.unmask();
            if (phone.length > 10) {
                element.mask("(99) 99999-999?9");
            }
            else {
                element.mask("(99) 9999-9999?9");
            }
        });
    }
};