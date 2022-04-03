definaNamespace("app.barradebotoes", {})

app.barradebotoes = function ($el, $elFormulario) {
    "use strict"

    if (!$el) {
        throw "Elemento não definido.";
    }

    this.$el = $el;
    this.$el.data("app.barradebotoes", this);

    this.$elFormulario = $elFormulario;

    this.inicialize();
}

app.barradebotoes.prototype = {
    inicialize: function () {
        this.$elSalvar = this.$el.find("[name='salvar']");
        this.ligaEventos();
    },

    ligaEventos: function () {
        var _this = this;

        this.$elSalvar.on("click", function () {
            _this.salvar();
        })

        this.$elFormulario.on("submit", function (e) {
            _this.valideFormulario(e);
        })
    },

    salvar: function () {
        this.$elFormulario.submit();
    },

    valideFormulario: function (e) {
        if (!this.$elFormulario[0].checkValidity()) {
            e.preventDefault();
            e.stopPropagation();

            this.$elFormulario.addClass("valideInconsistencia");
        }
    }
}