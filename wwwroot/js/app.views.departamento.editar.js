definaNamespace("app.views.departamento.editar", {})

app.views.departamento.editar = function ($el, modelParaOClientSide, options) {
    "use strict"

    if (!$el) {
        throw "Elemento não definido.";
    }

    this.$el = $el;
    this.$el.data("app.views.departamento.editar", this)
    this.modelParaOClientSide = modelParaOClientSide;

    this.options = options ? jQuery.extend({}, this.options, options) : this.options;

    this.inicialize();
}

app.views.departamento.editar.prototype = {
    inicialize: function () {

        this.prepareComponente();

        this.ligaEventos();
    },

    prepareComponente: function () {

    },

    ligaEventos: function () {
    }
}