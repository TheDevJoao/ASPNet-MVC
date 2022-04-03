definaNamespace("app.tabela", {})

app.tabela = function ($el, modelParaOClientSide, options) {
    "use strict"

    if (!$el) {
        throw "Elemento não definido.";
    }

    this.$el = $el;
    this.$el.data("app.tabela", this)
    this.modelParaOClientSide = modelParaOClientSide;

    this.options = options ? jQuery.extend({}, this.options, options) : this.options;

    this.inicialize();
}

app.tabela.prototype = {
    inicialize: function () {

        if (this.modelParaOClientSide.habiliteFiltro) {
            this.$elFiltro = this.$el.find("[name='filtro']");
        }

        this.$elTabelaItens = this.$el.find('[name="' + this.modelParaOClientSide.tabela + '"] tbody');

        if (this.modelParaOClientSide.habilitePaginacao) {
            var elPaginacao = this.$el.find(".app-paginacao");
            this.apiPaginacao = new app.paginacao(elPaginacao, this);
            this.$elTabelaTotal = this.$el.find('[name="' + this.modelParaOClientSide.tabela + '"] tfoot span');
        } else {
            this.$elTabelaTotal = this.$el.find("#total span");
        }
       
        this.prepareComponente();

        this.ligaEventos();
    },

    prepareComponente: function () {
        this.pesquisar();
    },

    ligaEventos: function () {
        var _this = this;

        if (this.modelParaOClientSide.habiliteFiltro) {
            this.$elFiltro.on("keyup", function () {
                if (_this.modelParaOClientSide.habilitePaginacao) {
                    _this.pesquisar(function (retorno) {
                        _this.apiPaginacao.atualizePagina(1);
                        _this.apiPaginacao.totalDeItens = retorno.totalDeItens;
                    });
                } else {
                    _this.pesquisar();
                }
            });
        }

        this.$elTabelaItens.on("click", ".item", function () {
            var codigo = $(this).find("[data-identificador]").text();
            _this.editar(codigo);
        });
    },
        
    pesquisar: function (callbackSucesso, callbackErro) {
        var _this = this;
        var url = location.origin + "/" + this.modelParaOClientSide.controller + "/" + this.modelParaOClientSide.action;

        var filtro = this.modelParaOClientSide.habiliteFiltro ? this.$elFiltro.val() : "";
        var pagina = this.modelParaOClientSide.pagina;
        var quantidade = this.modelParaOClientSide.quantidade;

        if (this.modelParaOClientSide.habilitePaginacao) {
            pagina = this.apiPaginacao.pagina;
            quantidade = this.apiPaginacao.quantidade;
        }

        var data = {
            filtro: filtro,
            pagina: pagina,
            quantidade: quantidade
        };

        $.ajax({
            type: "GET",
            url: url,
            data: data,
            dataType: "json",
            success: function (retorno) {
                _this.preencheTabela(retorno);

                if (callbackSucesso) {
                    callbackSucesso(retorno);
                }

                _this.$el.trigger("tabelaCarregada", retorno);
            },
            error: callbackErro
        });
    },

    preencheTabela: function (dados) {
        var _this = this;

        var tbody = dados.lista.reduce(function (linhas, entidade) {

            var identificador = entidade[_this.modelParaOClientSide.campoChave];

            linhas += "<tr class='item'>";

            for (var i = 0; i < _this.modelParaOClientSide.campos.length; i++) {

                if (_this.modelParaOClientSide.campos[i] == _this.modelParaOClientSide.campoChave) {
                    linhas += "<td data-identificador='" + identificador + "' >" + identificador + "</td>"
                } else {
                    linhas += "<td>" + entidade[_this.modelParaOClientSide.campos[i]] + "</td>";
                }
            }

            linhas += "</tr>";

            return linhas;
        }, "");

        var ultimaLinha = "<tr>" + this.modelParaOClientSide.campos.reduce((acc, colunas) => {
            return acc = acc + "<td></td>"
        }, "") + "</tr>";

        this.$elTabelaItens.html(tbody.concat(ultimaLinha));
        this.$elTabelaTotal.text(dados.totalDeItens);
    },

    editar: function (codigo) {
        window.location.href = location.origin + "/" + this.modelParaOClientSide.controller + "/Editar/" + codigo
    }
}