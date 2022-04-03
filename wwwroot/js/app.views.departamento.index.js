definaNamespace("app.views.departamento.index", {});


app.views.departamento.index = function ($el, modelParaOClientSide, options) {
    "use strict"

    if (!$el) {
        throw "Elemento não definido.";
    }

    this.$el = $el;
    this.$el.data("app.views.departamento.index", this)
    this.modelParaOClientSide = modelParaOClientSide;

    this.options = options ? jQuery.extend({}, this.options, options) : this.options;

    this.inicialize();
}

app.views.departamento.index.prototype = {

    inicialize: function () {
        // inicilizar propriedades
                
        this.prepareComponente();

        this.ligaEventos();
    },

    prepareComponente: function () {        
    },

    ligaEventos: function () {
        
    }
}
