class EstudianteVM{
    constructor(data){
        data = data || {};
        var self = this;

        self.Id = ko.observable(data.Id || "");
        self.Carnet = ko.observable(data.Carnet || "");
        self.Nombre = ko.observable(data.Nombre || "");
        self.Apellido = ko.observable(data.Apellido || "");
        self.Edad = ko.observable(data.Eda || "");
        self.CarreraId = ko.observable(data.CarreraId || "");

        //Propiedades Extras
        self.DescripcionCarrera = ko.observable(data.DescripcionCarrera || "");
        self.DetalleEstudianteTelefonos = ko.observableArray(data.DetalleEstudianteTelefonos ? data.DetalleEstudianteTelefonos.map(x=> new DetalleEstudianteTelefono(x)) : []);
    }
} 