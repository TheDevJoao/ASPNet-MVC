definaNamespace("app.textbox", {})

app.textbox = function ($el, modelParaOClientSide, options) {
    "use strict"

    if (!$el) {
        throw "Elemento não definido.";
    }

    this.$el = $el;
    this.$el.data("app.textbox", this)
    this.modelParaOClientSide = modelParaOClientSide;

    this.options = options ? jQuery.extend({}, this.options, options) : this.options;

    this.inicialize();
}

app.textbox.prototype = {
    inicialize: function () {
       
        this.prepareComponente();

        this.ligaEventos();
    },

    prepareComponente: function () {

    },

    ligaEventos: function () {
       
    },

    habilite: function () {
        this.$el.removeAttr("disabled");
    },

    desabilite: function () {
        this.$el.attr("disabled", "disabled");
    }
}