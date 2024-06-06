class FiltrosEstudianteVM{
    constructor(data){
        data = data || {};
        var self = this;

        self.Carnet = ko.observable(data.Carnet || "");
        self.Nombre = ko.observable(data.Nombre || "");
        self.Apellido = ko.observable(data.Apellido || "");
        self.Carrera = ko.observable(data.Carrera || "");
    }
}