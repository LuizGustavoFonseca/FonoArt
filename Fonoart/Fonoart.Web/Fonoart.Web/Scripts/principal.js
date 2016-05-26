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
                if (!naoExibirCarregando) {
                    if (NPC.Principal.contadorLoading == 0) {
                        NPC.Principal.exibirLoading();
                    }
                    NPC.Principal.contadorLoading++;
                }
            },
            complete: function () {
                if (!naoExibirCarregando) {
                    NPC.Principal.contadorLoading--;
                    if (NPC.Principal.contadorLoading == 0) {
                        NPC.Principal.esconderLoading();
                    }
                }
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
    }
};