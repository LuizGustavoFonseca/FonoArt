angular.module("atendimento").controller("atendimentoCtrl", function ($scope, produtosAPI, $uibModal, $log) {
    $scope.app = "Cadastro Produtos";

    var carregarProdutos = function () {
        produtosAPI.getProdutos().success(function (data) {
            $scope.produtos = data.produtos;
        }).error(function (data, status) {
            $scope.error = "Não foi possível carregar os dados!";
        });
    };

    $scope.animationsEnabled = true;
    $scope.abrirModalProduto = function (produto, novoProduto) {
        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: 'myModalContent.html',
            controller: 'modalCtrl',
            resolve: {
                produto: function () { return angular.copy(produto); },
                produtos: function () { return $scope.produtos; },
                novoProduto: function () { return novoProduto; }
            }
        });

        modalInstance.result.then(function (obj) {
            console.log(obj.novoProduto);
            if (obj.novoProduto) {
                $scope.produtos.push(obj.produto);
            }
            else {
                var indice = $scope.produtos.findIndex(function (obj) { return obj.Codigo == obj.produto.Codigo });
                $scope.produtos[indice] = obj.produto;
            }
        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });
    };

    $scope.toggleAnimation = function () {
        $scope.animationsEnabled = !$scope.animationsEnabled;
    };

    $scope.operadoras = [
        { nome: "Oi", codigo: 14, categoria: "Celular", preco: 2 },
        { nome: "Vivo", codigo: 15, categoria: "Celular", preco: 1 },
        { nome: "Tim", codigo: 41, categoria: "Celular", preco: 3 },
        { nome: "GVT", codigo: 25, categoria: "Fixo", preco: 1 },
        { nome: "Embratel", codigo: 21, categoria: "Fixo", preco: 1.5 }
    ];
    $scope.adicionarContato = function (contato) {
        $scope.contatos.push(angular.copy(contato));
        delete $scope.contato;
        $scope.contatoForm.$setPristine();
    }
    $scope.apagarProduto = function (produtoExcluido) {
        $scope.produtos = $scope.produtos.filter(function (produto) {
            if (produto != produtoExcluido) return produto;
        });
    }

    //$scope.isContatoSelecionado = function (contatos) {
    //    var contatosEstaSelecionados = contatos.some(function (contato) {
    //        return contato.selecionado;
    //    });
    //    return contatosEstaSelecionados;
    //}

    $scope.ordenarPor = function (campo) {
        $scope.criterioDeOrcednacao = campo;
        $scope.direcaoDaOrdenacao = !$scope.direcaoDaOrdenacao;
    }

    carregarProdutos();
});