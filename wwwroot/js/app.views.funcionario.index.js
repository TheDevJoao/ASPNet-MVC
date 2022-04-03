definaNamespace("app.views.funcionario.index", {});


app.views.funcionario.index = function ($el, modelParaOClientSide, options) {
    "use strict"

    if (!$el) {
        throw "Elemento não definido.";
    }

    this.$el = $el;
    this.$el.data("app.views.funcionario.index", this)
    this.modelParaOClientSide = modelParaOClientSide;

    this.options = options ? jQuery.extend({}, this.options, options) : this.options;

    this.inicialize();
}

app.views.funcionario.index.prototype = {

    inicialize: function () {        
        this.prepareComponente();
        this.ligaEventos();
    },

    prepareComponente: function () {        
    },

    ligaEventos: function () {
    }
}
