definaNamespace("app.views.movimentacao.index", {});


app.views.movimentacao.index = function ($el, modelParaOClientSide, options) {
    "use strict"

    if (!$el) {
        throw "Elemento não definido.";
    }

    this.$el = $el;
    this.$el.data("app.views.movimentacao.index", this)
    this.modelParaOClientSide = modelParaOClientSide;

    this.options = options ? jQuery.extend({}, this.options, options) : this.options;

    this.inicialize();
}

app.views.movimentacao.index.prototype = {

    inicialize: function () {
        this.$elDataDaOcorrencia = this.$el.find("[name='DataDaOcorrencia']");
        this.$elFuncionario = this.$el.find("input[name='Funcionario']");
        this.$elDepartamentoAtual = this.$el.find("input[name='DepartamentoAtual']");

        this.prepareComponente();
        this.ligaEventos();
    },

    prepareComponente: function () {
        this.prepareDataDaOcorrencia();
    },

    ligaEventos: function () {
        var _this = this;

        this.$elFuncionario.on("itemSelecionado", function (e, retorno) {
            _this.defineDepartamentoAtual(retorno);
        });
    },

    prepareDataDaOcorrencia: function () {
        this.$elDataDaOcorrencia.datepicker();
    },

    defineDepartamentoAtual: function (retorno) {
        var _this = this;
        var url = location.origin + "/Funcionario/Consulte/" + retorno.codigo;

        $.ajax({
            type: 'GET',
            url: url,
            data: {},
            dataType: 'json',
            success: function (resultado) {
                _this.preencheDepartamentoDestino(resultado.departamento);
            }
        });
    },

    preencheDepartamentoDestino: function (departamento) {
        var api = this.$elDepartamentoAtual.closest('.app-combogrid').data("app.combogrid");

        api.defineItemSelecionado(departamento);
    }
}
