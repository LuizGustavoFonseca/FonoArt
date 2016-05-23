angular.module("atendimento").factory("produtosAPI", function ($http) {
    var _getProdutos = function () {
        return $http.get("http://localhost:59148/CadastroProduto/ObterProdutos");
    };

    var _saveProdutos = function (produto) {
        return $http.post("http://localhost:59148/CadastroProduto/ObterProdutos", contato);
    };

    return {
        getProdutos: _getProdutos,
        saveProdutos: _saveProdutos
    };
});