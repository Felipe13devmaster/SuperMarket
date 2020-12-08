//Declaração de variaveis ===========================================================================
var enderecoProduto = "https://localhost:5001/Produtos/GetProduto/";
var produto;
var listaDeCompra = [];
var _totalVenda_ = 0.00;
//===================================================================================================

//Inicio===========================================================================================
atualizarTotal();



//Funções===========================================================================================

function preencherFormulario(produto) {
    $("#campoNome").val(produto.nome);
    $("#campoCategoria").val(produto.categoria.nome);
    $("#campoFornecedor").val(produto.fornecedor.nome);
    $("#campoPrecoDeVenda").val(produto.precoDeVenda);
}

function limparFormulario() {
    $("#campoNome").val(" ");
    $("#campoCategoria").val(" ");
    $("#campoFornecedor").val(" ");
    $("#campoPrecoDeVenda").val(" ");
    $("#campoQuantidade").val(" ");
}

function atualizarTotal() {
    $("#totalVenda").html(_totalVenda_);
}

function adicionarNaTabela(produto, quantidade) {
    var produtoTemporario = {};// {} define que e um tipo objeto no js

    Object.assign(produtoTemporario, produto);// clona o objeto ... Isto esta sendo feito aqui para preservar o estado do objeto que sera passado para a lista.

    var venda = {produto: produtoTemporario, quantidade: quantidade, subtotal: produtoTemporario.precoDeVenda * quantidade};

    _totalVenda_ += venda.subtotal;

    atualizarTotal();

    listaDeCompra.push(venda);//adiciona elementos no array js
   
    $("#tabelaCompra").append(
    `<tr>
        <td>${produto.id}</td>
        <td>${produto.nome}</td>
        <td>${quantidade}</td>
        <td>R$ ${produto.precoDeVenda}</td>
        <td>${produto.unidadeDeMedida}</td>
        <td>R$ ${produto.precoDeVenda * quantidade}</td>
        <td><button class='btn btn-danger'>Remover</button></td>
    </tr>`); 
}
//Detecta o evento de envio de formulario
$("#formularioDeProduto").on("submit", function(event) {
    event.preventDefault();//Tira a autonomia da pagina, desse modo ela nao recarrega quando submeter o formulario.
    var produtoTabela = produto;
    var qtd = $("#campoQuantidade").val();
    adicionarNaTabela(produtoTabela, qtd);
    produto = undefined;//limpar a variavel (objeto)
    limparFormulario();
});

//=================================================================================================

//AJAX =============================================================================================
$("#pesquisar").click(function() {
    var codigoProduto = $("#codProduto").val();//val retorna o valor digitado no campo de id informado.
    var enderecoRequisicao = enderecoProduto + codigoProduto;
    $.post(enderecoRequisicao, function (dados, status) {
        // alert(`Dados: ${dados}, Status: ${status}`);
        produto = dados;
        var undMedida = " ";

        switch (produto.unidadeDeMedida) {
            case 1:
                undMedida = "Litro";
                break;
            case 2:
                undMedida = "Unidade";
                break;
            case 3:
                undMedida = "Kilo";
                break;
            default:
                undMedida = "Ops ocorreu um erro...";
                break;
        }

        produto.unidadeDeMedida = undMedida;

        preencherFormulario(produto);
    }).fail(function(){
        alert("Codigo inválido.");
    });
});
//==========================================================================================================

//Finalizar venda =============================================================================================
$("#btnFinalizarVenda").click(function () {
    if (_totalVenda_ <= 0) {
        alert("Compra inválida, adicione um produto antes.")
        return;
    }

    var valorPago = $("#valorPago").val();

    if (typeof valorPago == Number || valorPago >= _totalVenda_) {
        
    }else{
        alert("Valor pago inválido.")
        return;
    }
});
    
