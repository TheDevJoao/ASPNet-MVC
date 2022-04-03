definaNamespace("app.paginacao", {});

app.paginacao = function ($el, api) {
    'use strict';

    if (!$el) {
        throw "Elemento não definido";
    }

    this.$el = $el;
    this.$el.data("app.paginacao", this);
    
    this.api = api;
    this.pagina = api.modelParaOClientSide.pagina;
    this.quantidade = api.modelParaOClientSide.quantidade;
    this.paginaAnterior = this.api.modelParaOClientSide.pagina;
    this.paginaAtual = this.api.modelParaOClientSide.pagina;
    this.totalDeItens = 0;

    this.inicialize();
}

app.paginacao.prototype = {
    inicialize: function () {
        // inicializar propriedades                        
        this.$elPaginacao = this.$el.find(".paginacao");
        this.$elAtualizar = this.$el.find(".atualizar");
                
        // prepare componentes
        this.prepareComponente();

        // eventos
        this.ligaEventos();
    },

    prepareComponente: function () {
    },

    ligaEventos: function () {
        var _this = this;

        this.api.$el.on("tabelaCarregada", function (e, totalDeItens) {
            _this.preenchePaginacao(totalDeItens);
        });

        this.$elPaginacao.on("click", "[name='anterior']", function () {
            _this.verifiqueAnterior();
        });

        this.$elPaginacao.on("click", "[name='proximo']", function () {
            _this.verifiqueProximo();
        });

        this.$elPaginacao.on("click", "[name='paginaNumerada']", function () {
            var pagina = $(this).find('a').text();
            _this.verifiquePagina(Number(pagina));
        });

        this.$elAtualizar.on("click", function () {
            _this.atualizePagina(1);
            _this.api.pesquisar();
        });
    },

    verifiqueAnterior: function () {
        var novaPagina = this.pagina - 1;

        if (novaPagina > 0) {
            this.atualizePagina(novaPagina);
            this.pesquisar();
        }
    },

    verifiqueProximo: function () {
        var novaPagina = this.pagina + 1;

        if (novaPagina <= this.obtenhaQuantidadeDePaginacao(this.totalDeItens)) {
            this.atualizePagina(novaPagina);
            this.pesquisar();
        }
    },

    verifiquePagina: function (pagina) {
        if (this.pagina != pagina) {
            this.atualizePagina(pagina);
            this.pesquisar();
        }
    },

    atualizePagina: function (novaPagina) {
        this.paginaAnterior = this.paginaAtual;
        this.paginaAtual = novaPagina;
        this.pagina = novaPagina;
    },

    pesquisar: function (filtro) {
        var _this = this;

        this.api.pesquisar(() => { }, function () {
            // se error
            _this.atualizePagina(_this.paginaAnterior);
        });
    },

    preenchePaginacao: function (dados) {
        var _this = this;
        this.totalDeItens = dados.totalDeItens;

        var quantidadePaginas = this.obtenhaQuantidadeDePaginacao(dados.totalDeItens);

        var elPaginas = new Array(quantidadePaginas).fill("").reduce(function (paginas, item, i) {
            var index = i + 1;
            var ativo = _this.pagina == index;
            var pagina = _this.obtenhaElPagina(ativo, index);
            paginas = paginas + pagina;

            return paginas;
        }, "");

        var elAnterior = this.obtenhaElAnterior(this.pagina > 1);
        var elProximo = this.obtenhaElProximo(this.pagina < quantidadePaginas);

        this.$elPaginacao.html(elAnterior.concat(elPaginas).concat(elProximo));
    },

    obtenhaQuantidadeDePaginacao: function (totalDeItens) {
        var calculo = totalDeItens / this.quantidade;
        var parteInteira = Math.trunc(calculo);
        var parteDecimal = (calculo + "").split(".").length > 1 ? 1 : 0;
        var quantidadePaginas = parteInteira + parteDecimal;

        return quantidadePaginas;
    },

    obtenhaElAnterior: function (habilitado) {
        var atributoDesabilitado = !habilitado ? "disabled" : "";

        var elAnterior =
            '<li class="page-item ' + atributoDesabilitado + '" name="anterior">' +
            '  <a class="page-link" href="#" aria-label="Anterior">' +
            '     <span aria-hidden="true">&laquo;</span>' +
            '     <span class="sr-only">Anterior</span>' +
            '  </a>' +
            '</li >';

        return elAnterior;
    },

    obtenhaElProximo: function (habilitado) {
        var atributoDesabilitado = !habilitado ? "disabled" : "";

        var elProximo =
            '<li class="page-item ' + atributoDesabilitado + '" name="proximo">' +
            '  <a class="page-link" href="#" aria-label="Proximo">' +
            '     <span class="sr-only">Proximo</span>' +
            '     <span aria-hidden="true">&raquo;</span>' +
            '  </a>' +
            '</li >';

        return elProximo;
    },

    obtenhaElPagina: function (ativo, pagina) {
        var atributoAtivo = ativo ? "active" : "";
        var elPagina = '<li class="page-item ' + atributoAtivo + '" name="paginaNumerada"><a class="page-link" href="#">' + pagina + '</a></li>';
        return elPagina;
    }
}