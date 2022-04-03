definaNamespace("app.combogrid", {});

app.combogrid = function ($el, modelParaOClientSide, options) {
    'use strict';

    if (!$el) {
        throw "Elemento não definido";
    }

    this.$el = $el;
    this.$el.data("app.combogrid", this);
    this.modelParaOClientSide = modelParaOClientSide;
    this.options = options ? jQuery.extend({}, this.options, options) : this.options;

    this.abrirPesquisaStatus = false;

    this.inicialize();
}

app.combogrid.prototype = {
    inicialize: function () {
        // inicializar propriedades                        
        this.$elPesquisar = this.$el.find("[data-pesquisar]");
        this.$elPesquisarIcon = this.$el.find(".dropdown-icon");

        this.$elDropdown = this.$el.find(".dropdown");

        this.$elTabela = this.$el.find("[name='grid']");
        this.$elThead = this.$elTabela.find('thead');
        this.$elTbody = this.$elTabela.find("tbody");

        this.$elPropriedadeSelecionada = this.$el.find("[name='" + this.modelParaOClientSide.propriedadeSelecionada + "']");

        // prepare componentes
        this.prepareComponente();

        // eventos
        this.ligaEventos();
    },

    prepareComponente: function () {
        this.defineColunasDaTabela();
        this.defineItemSelecionado(this.modelParaOClientSide.itemSelecionado);        
    },

    ligaEventos: function () {
        var _this = this;

        this.$elPesquisar.on("click", function () {
            if (_this.abrirPesquisaStatus) {
                _this.pesquisar();
            }

            _this.atualizeStatusPesquisa(true);
        });

        this.$elPesquisarIcon.on("click", function () {
            var abrirPesquisa = !_this.abrirPesquisaStatus;

            if (abrirPesquisa) {
                _this.pesquisar();
            }

            _this.atualizeStatusPesquisa(abrirPesquisa);
            _this.$elPesquisar.focus();

        })

        this.$elPesquisar.on("keyup", function () {
            var filtro = _this.$elPesquisar.val();
            _this.pesquisar(filtro);            
        });

        this.$elPesquisar.on("focusin", function () {
            if (_this.abrirPesquisaStatus) {
                _this.pesquisar();
            }

            _this.atualizeStatusPesquisa(true);
        });

        this.$elPesquisar.on("focusout", function (e) {            
            setTimeout(function () {
                _this.atualizeStatusPesquisa(false)
            }, 300);
        });

        this.$elPesquisar.on("keyup", function (e) {
            if (e.key == "Escape" || e.key == "Esc" || e.keyCode == 27) {
                _this.atualizeStatusPesquisa(false);
            }
        });

        this.$elTbody.on("click", ".item", function () {
            var el = $(this);
            _this.selecionar(el);
            _this.atualizeStatusPesquisa(false);
        });
    },

    pesquisar: function (filtro) {
        var _this = this;
        var url = location.origin + "/" + this.modelParaOClientSide.controller + "/" + this.modelParaOClientSide.action;

        var data = {
            filtro,
            pagina: this.modelParaOClientSide.pagina,
            quantidade: this.modelParaOClientSide.quantidade
        };

        $.ajax({
            type: 'GET',
            url: url,
            data: data,
            dataType: 'json',
            success: function (resultado) {
                _this.preencheTabela(resultado);
            }
        });
    },

    defineColunasDaTabela: function () {
        var ths = JSON.parse(this.modelParaOClientSide.colunas).reduce(function (colunas, coluna) {
            var col = "<th data-name='" + coluna.name + "'>" + coluna.label + "</th>";

            colunas = colunas.concat(col);
            return colunas;
        }, "");

        var thead = "<tr scope='col'>" + ths + "</tr>";
        this.$elThead.html(thead);
    },

    preencheTabela: function (dados) {
        if (!(dados && dados.lista)) {
            return;
        }

        var _this = this;

        var tbody = dados.lista.reduce(function (linhas, item) {
            var valorChave = null;

            var cols = JSON.parse(_this.modelParaOClientSide.colunas).reduce(function (colunas, coluna) {
                var valor = item[coluna.name];

                if (_this.modelParaOClientSide.campoChave == coluna.name) {
                    valorChave = valor;
                }

                var col = "<td data-name='" + coluna.name + "'>" + valor + "</td>";

                return colunas.concat(col);
            }, "");

            var linha = "<tr class='item' data-item='" + valorChave + "'>".concat(cols).concat("</tr>");

            return linhas.concat(linha);
        }, "");

        var ultimaLinha = JSON.parse(this.modelParaOClientSide.colunas).reduce(function (acc, c) {
            acc += "<td></td>";
            return acc;
        }, "");

        this.$elTbody.html(tbody.concat("<tr>" + ultimaLinha + "</tr>"));
    },

    selecionar: function (el) {
        var _this = this;
        _this.modelParaOClientSide.itemSelecionado = {};

        var itemSelecionado = this.modelParaOClientSide.camposTemplate.reduce(function (t, tCampo) {
            var elDataName = el.find('[data-name="' + tCampo + '"]');

            if (elDataName && elDataName.length == 1) {
                var conteudo = elDataName.text();
                t[tCampo] = conteudo;
            }

            return t;
        }, {});

        this.defineItemSelecionado(itemSelecionado);
        this.$elPesquisar.trigger("itemSelecionado", _this.modelParaOClientSide.itemSelecionado);
    },

    defineItemSelecionado: function (itemSelecionado) {
        if (!itemSelecionado) {
            return;
        }

        var _this = this;
        _this.modelParaOClientSide.itemSelecionado = {};

        var templateConteudo = this.modelParaOClientSide.camposTemplate.reduce(function (t, tCampo) {
            var conteudo = itemSelecionado[tCampo];

            if (t) {
                t = t + " - " + conteudo;
            }
            else {
                t = conteudo;
            }

            _this.modelParaOClientSide.itemSelecionado[tCampo] = conteudo;


            return t;
        }, null);

        var valorChave = _this.modelParaOClientSide.itemSelecionado[this.modelParaOClientSide.campoChave];

        this.$elPesquisar.val(templateConteudo);
        this.$elPropriedadeSelecionada.val(valorChave);
    },

    obtenhaItemSelecionado: function () {
        return this.modelParaOClientSide.itemSelecionado;
    },

    abrirPesquisa: function () {
        this.$elPesquisar.attr('aria-expanded', true);        
        this.$elDropdown.addClass('show');        
    },

    fecharPesquisa: function () {
        this.$elPesquisar.attr('aria-expanded', false);
        this.$elDropdown.removeClass('show');
        this.preencheTabela([]);
    },

    atualizeStatusPesquisa: function (aberto) {
        if (aberto) {
            this.abrirPesquisa();
        } else {
            this.fecharPesquisa();            
        }
        
        this.abrirPesquisaStatus = aberto;
    }
}